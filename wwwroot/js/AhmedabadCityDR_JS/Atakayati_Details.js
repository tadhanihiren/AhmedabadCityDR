function EditData(id) {
    $("#submitbtn").html('Save અટકાયતી પગલાની વિગત-પત્રક નંબર–૫'); //Change button value to add
    $.ajax({
        url: "/api/ApiAtakayatidetails/GetById",
        type: "Get",
        dataType: "json",
        data: { "id": id },
        headers: {
            "Accept": "application/json",
            "Content-Type": "application/json",
        },
        success: function (response) {
            console.log(id);
            $('#form_AtakayatiDetails').trigger("reset");
            $('#basicModal').modal('show');
            Populate('#form_AtakayatiDetails', response.content);
        },
    });
}

function DeleteData(id) {
    swal({
        title: "Are you sure?",
        icon: "warning",
        buttons: [
            'No, cancel it!',
            'Yes, I am sure!'
        ],
        dangerMode: true,
    }).then((isConfirm) => {
        if (isConfirm) {
            $.ajax({
                url: "/api/ApiAtakayatidetails/Delete",
                type: "get",
                dataType: "json",
                data: { "id": id },
                headers: {
                    Accept: "application/json",
                    "Content-Type": "application/json",
                },
                success: function (response) {
                    if (!response.isValid) {
                        swal(response.error, "", "error");
                        return;
                    }

                    $('#data_AtakayatiDetails').DataTable().ajax.reload();
                    swal("Successfully!", "Record has been deleted.", "success");
                },
            });

        }
    })
}



$(document).ready(function () {

    PopulateSearchPoliceStationDRD();

    $("#addData").click(() => {
        $('#form_AtakayatiDetails').trigger('reset');
        $("#submitbtn").html('+ ADD અટકાયતી પગલાની વિગત-પત્રક નંબર–૫'); //Change button value to add
    });


    $("#searchButton").click(function () {
        $('#data_AtakayatiDetails').DataTable().ajax.reload();
    });

    $('#data_AtakayatiDetails').DataTable({
        "processing": true,
        "language": {
            processing: '<div class="spinner-grow text-primary" role="status"></div>'
        },
        lengthMenu: [[10, 50, 100, 500, 1000, 1500, 2000], [10, 50, 100, 500, 1000, 1500, 2000]],
        "columnStyle": true,
        "scrollX": true,
        "sScrollXInner": "100%",
        "destroy": true,
        "info": true,
        "bLengthChange": true,
        "bFilter": true,
        "autoWidth": false,
        bAutoWidth: false,
        "ajax": {
            url: "/api/ApiAtakayatidetails/Get",
            type: "Get",
            dataSrc: "content",
            dataType: "json",
            data: function (d) {
                d.fromDate = $('#searchFromDate').val();
                d.toDate = $('#searchToDate').val();
                d.searchPoliceStationId = $('#searchPoliceStationId').val();
            },
            headers: {
                "Accept": "application/json",
                "Content-Type": "application/json",
            }
        },
        "columns": [
            { title: 'પોલીસ સ્ટેશન', data: 'policeStationName', "width": "100px" },
            { title: 'તારીખ', data: 'createdDate', "width": "100px" },
            { title: 'અટકાયતી પગલાના પ્રકાર', data: 'subCategoryName', "width": "100px" },
            { title: 'ચાલુ સાલના આજદીન સુધીના', data: 'currentYear', "width": "200px" },
            { title: 'ગઇ સાલના આજદીન સુધીના', data: 'lastYear', "width": "200px" },
            { title: 'વધ ઘટ', data: 'cY_LY', "width": "200px" },

            {
                mRender: function (data, type, row) {
                    var bEdit = '<button type="button" class="btn btn-success" onclick="EditData(' + row.atakayatiPagalaSummaryId + ')">Edit</button> ';
                    var bDelete = '<button type="button" class="btn btn-danger" onclick="DeleteData(' + row.atakayatiPagalaSummaryId + ')">Delete</button>';
                    return bEdit + bDelete;
                },
                "width": "120px",
            },
        ],
    });

    $.validator.addMethod(
        "regex",
        function (value, element, regexp) {
            return this.optional(element) || regexp.test(value);
        },
        "Please check your input."
    );

    $("#form_AtakayatiDetails").validate({
        rules: {
            policeStationId: "required",
            subCategoryId: "required",
            createdDate: "required",
            currentYear: {
                required: true,
                regex: /^[0-9]*$/,
            },
            lastYear: {
                required: true,
                regex: /^[0-9]*$/,
            },
        },
        messages: {
            policeStationId: "required",
            subCategoryId: "required",
            createdDate: "required",
            currentYear: {
                required: "required",
                regex: "Numbers only.",
            },
            lastYear: {
                required: "required",
                regex: "Numbers only.",
            },
        },

        submitHandler: () => {
            var formData = new FormData(document.getElementById("form_AtakayatiDetails"));
            var payload = JSON.stringify(Object.fromEntries(formData));
            debugger
            console.log(payload);
            $.ajax({
                url: '/api/ApiAtakayatidetails/Save',
                type: 'post',
                dataType: 'json',
                headers: {
                    'Accept': 'application/json',
                    'Content-Type': 'application/json'
                },
                data: payload,
                success: function (response) {

                    if (!response.isValid) {
                        swal(response.error, "", "error");
                        return;
                    }
                    $('#form_AtakayatiDetails').trigger("reset");
                    $('#data_AtakayatiDetails').DataTable().ajax.reload();
                    $('#basicModal').modal('hide');
                    swal("Successfully!", "Form has been submitted.", "success");
                },
            });
        },
    });
});