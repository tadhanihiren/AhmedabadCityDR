function EditData(id) {
    $("#submitbtn").html('Save ગુન્હાની આંકડાકીય માહીતી'); //Change button value to add
    $.ajax({
        url: "/api/ApiAtakayatiPaglaSummary/GetById",
        type: "Get",
        dataType: "json",
        data: { "id": id },
        headers: {
            "Accept": "application/json",
            "Content-Type": "application/json",
        },
        success: function (response) {
            //console.log(response.content);
            $('#form_AtakayatiPagalaSummary').trigger("reset");
            $('#basicModal').modal('show');
            Populate('#form_AtakayatiPagalaSummary', response.content);
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
                url: "/api/ApiAtakayatiPaglaSummary/Delete",
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

                    $('#form_AtakayatiPagalaSummary').DataTable().ajax.reload();
                    swal("Successfully!", "Record has been deleted.", "success");
                },
            });

        }
    })
}

$().ready(() => {

    PopulateSearchPoliceStationDRD();

    $("#addData").click(() => {
        $('#form_AtakayatiPagalaSummary').trigger('reset');
        $("#submitbtn").html('+ ADD ગુન્હાની આંકડાકીય માહીતી'); //Change button value to add
    });

    $("#searchButton").click(function () {
        $('#data_AtakayatiPagalaSummary').DataTable().ajax.reload();
    });

    $('#data_AtakayatiPagalaSummary').DataTable({
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
            url: "/api/ApiAtakayatiPaglaSummary/Get",
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
            { title: 'હેડ', data: 'subCategoryName', "width": "100px" },
            { title: 'ચાલુ સાલના આજદીન સુધીના', data: 'currentYear', "width": "200px" },
            { title: 'ગઇ સાલના આજદીન સુધીના', data: 'lastYear', "width": "200px" },
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

    $("#form_AtakayatiPagalaSummary").validate({
        rules: {
            policeStationId: "required",
            subCategoryId: "required",
            sreatedDate: "required",
            todays: "required",
            last: "required",
            currentMonth: "required",
            lastMonth: "required",
            currentYear: "required",
            lastYear: {
                required: true,
                regex: /^[0-9]*$/,
            },
           
        },
        messages: {
            policeStationId: "required",
            subCategoryId: "required",
            createdDate: "required",
            todays: "required",
            last: "required",
            currentMonth: "required",
            lastMonth: "required",
            currentYear: "required",
            lastYear: {
                required: "required",
                regex: "Numbers only.",
            },
        },

        submitHandler: () => {
            var formData = new FormData(document.getElementById("form_AtakayatiPagalaSummary"));
            var payload = JSON.stringify(Object.fromEntries(formData));
            /*console.log(payload);*/
            $.ajax({
                url: '/api/ApiAtakayatiPaglaSummary/Save',
                type: 'post',
                dataType: 'json',
                headers: {
                    'Accept': 'application/json',
                    'Content-Type': 'application/json'
                },
                data: payload,
                success: function (response) {
                
                    if (!response.isValid) {
                        swal("Contact Your Administrator!", "", "error");
                        return;
                    }

                    $('#form_AtakayatiPagalaSummary').trigger("reset");
                    $('#data_AtakayatiPagalaSummary').DataTable().ajax.reload();
                    $('#basicModal').modal('hide');
                    swal("Successfully!", "Form has been submitted.", "success");
                }, 
            });
        },
    });
});
