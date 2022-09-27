function EditData(id) {
    $("#submitbtn").html('Save નાઇટરાઉન્ડ પર્સન કાઉન્ટ'); //Change button value to Save
    $.ajax({
        url: "/api/ApiNightRountPersonCountMaster/GetById",
        type: "Get",
        dataType: "json",
        data: { "id": id },
        headers: {
            "Accept": "application/json",
            "Content-Type": "application/json",
        },
        success: function (response) {
            //console.log(response.content);
            $('#form_NightRountPersonCount').trigger("reset");
            $('#basicModal').modal('show');
            Populate('#form_NightRountPersonCount', response.content);
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
                url: "/api/ApiNightRountPersonCountMaster/Delete",
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

                    $('#data_NightRountPersonCount').DataTable().ajax.reload();
                    swal("Successfully!", "Record has been deleted.", "success");
                },
            });

        }
    })
}

$(document).ready(() => {

    PopulateSearchPoliceStationDRD();

    $("#addData").click(() => {
        $('#form_NightRountPersonCount').trigger('reset');
        $("#submitbtn").html('+ ADD નાઇટરાઉન્ડ પર્સન કાઉન્ટ'); //Change button value to add
    });

    $("#searchButton").click(function () {
        $('#data_NightRountPersonCount').DataTable().ajax.reload();
    });

    $('#data_NightRountPersonCount').DataTable({
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
            url: "/api/ApiNightRountPersonCountMaster/Get",
            type: "get",
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
            {
                title: 'તારીખ',
                data: 'createdDate',
                width: "100px"
            },
            {
                title: 'પોલીસ સ્ટેશન',
                data: 'policeStationName',
                width: "100px"
            },
            {
                title: 'હાજર મહેકમ',
                data: 'presentMahekam',
                width: "100px"
            },
            {
                title: 'ના.રા.માં ફાળવેલ માણસોની સંખ્યા',
                data: 'nightRountPersonCount',
                width: "200px"
            },
            {
                title: 'હાજર મહેકમ પૈકી ના.રા.માં ફાળવેલ માણસોની ટકાવારી',
                data: 'percentage',
                width: "300px"
            },
            {
                title: 'નોંધ',
                data: 'remarks',
                width: "100px"
            },
            {
                mRender: function (data, type, row) {
                    var bEdit = '<button type="button" class="btn btn-success" onclick="EditData(' + row.nightRoundPersonCountId + ')">Edit</button> ';
                    var bDelete = ' <button type="button" class="btn btn-danger" onclick="DeleteData(' + row.nightRoundPersonCountId + ')">Delete</button>';
                    return bEdit + bDelete;
                },
                "width": "100px",
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

    $("#form_NightRountPersonCount").validate({
        rules: {
            policeStationId: {
                required: true,
            },
            designationId: {
                required: true,
                regex: /^[0-9]*$/,
            },
            presentMahekam: {
                required: true,
                regex: /^[0-9]*$/,
            },
            nightRountPersonCount: {
                required: true,
                regex: /^[0-9]*$/,
            },
            percentage: {
                required: true,
                regex: /^\d+\.?\d*$/,
            },
            remarks: {
                required: true,
            },
            createdDate: {
                required: true,
            },
        },
        messages: {
            policeStationId: {
                required: "required",
            },
            designationId: {
                required: "required",
                regex: "Numbers only.",
            },
            presentMahekam: {
                required: "required",
                regex: "Numbers only.",
            },
            nightRountPersonCount: {
                required: "required",
                regex: "Numbers only.",
            },
            percentage: {
                required: "required",
                regex: "Numbers only.",
            },
            remarks: "required",
            createdDate: "required",
        },
        submitHandler: () => {
            var formData = new FormData(document.getElementById("form_NightRountPersonCount"));
            var payload = JSON.stringify(Object.fromEntries(formData));
            console.log(payload);
            $.ajax({
                url: "/api/ApiNightRountPersonCountMaster/Save",
                type: "post",
                dataType: "json",
                headers: {
                    Accept: "application/json",
                    "Content-Type": "application/json",
                },
                data: payload,
                success: function (response) {
                    if (!response.isValid) {
                        swal(response.error, "", "error");
                        return;
                    }

                    $('#data_NightRountPersonCount').DataTable().ajax.reload();
                    $('#form_NightRountPersonCount').trigger("reset");
                    $('#basicModal').modal('hide');
                    swal("Successfully!", "Form has been submitted.", "success");
                },
            });
        },
    });
});