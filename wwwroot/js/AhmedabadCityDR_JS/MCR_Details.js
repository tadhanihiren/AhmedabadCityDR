function EditData(id) {
    $("#submitbtn").html('Save MCR-Details'); //Change button value to Save
    $.ajax({
        url: "/api/ApiMCRDetails/GetById",
        type: "Get",
        dataType: "json",
        data: { "id": id },
        headers: {
            "Accept": "application/json",
            "Content-Type": "application/json",
        },
        success: function (response) {
            console.log(response.content);
            $('#form_MCRDetails').trigger("reset");
            $('#basicModal').modal('show');
            Populate('#form_MCRDetails', response.content);
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
                url: "/api/ApiMCRDetails/Delete",
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

                    $('#data_MCRDetails').DataTable().ajax.reload();
                    swal("Successfully!", "Record has been deleted.", "success");
                },
            });

        }
    })
}

$(document).ready(() => {

    PopulateSearchPoliceStationDRD();

    $("#addData").click(() => {
        $('#form_MCRDetails').trigger('reset');
        $("#submitbtn").html('+ ADD MCR-Details'); //Change button value to add
    });

    $("#searchButton").click(function () {
        $('#data_MCRDetails').DataTable().ajax.reload();
    });

    $('#data_MCRDetails').DataTable({
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
            url: "/api/ApiMCRDetails/Get",
            type: "get",
            dataSrc: "content",
            dataType: "json",
            data: function (d) {
                d.fromDate = $('#searchFromDate').val();
                d.toDate = $('#searchToDate').val();
                d.searchPoliceStationId = $('#searchPoliceStationId').val();
                //console.log(d);
            },
            headers: {
                "Accept": "application/json",
                "Content-Type": "application/json",
            }
        },
        "columns": [
            { title: 'પોલીસ સ્ટેશન', data: 'policeStationName', "width": "100px" },
            { title: 'તારીખ', data: 'createdDate', "width": "80px" },
            { title: 'ચેક કરેલ MCR કાર્ડ નંબર', data: 'mcrCardNo', "width": "90px" },
            { title: 'ચેક કરેલ MCR કાર્ડવાળા ઇસમનું નામ', data: 'nameOfISM', "width": "200px" },
            { title: 'ચેક કરેલ MCR કાર્ડવાળા ઇસમનો લેટેસ્ટ મોબાઇલ નંબર', data: 'latestMobileNo', "width": "300px" },
            { title: 'ચેક કરેલ MCR કાર્ડવાળા ઇસમનું લેટેસ્ટ સરનામું', data: 'latestAddressOfISM', "width": "300px" },
            { title: 'રિમાર્કસ', data: 'remarks', "width": "150px" },
            {
                mRender: function (data, type, row) {
                    var bEdit = '<button type="button" class="btn btn-success" onclick="EditData(' + row.mcrId + ')">Edit</button> ';
                    var bDelete = ' <button type="button" class="btn btn-danger" onclick="DeleteData(' + row.mcrId + ')">Delete</button>';
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

    $("#form_MCRDetails").validate({
        rules: {
            policeStationId: "required",
            createdDate: "required",
            latestAddressOfIsm: "required",
            nameOfIsm: "required",
            latestMobileNo: {
                regex: /^(?:(?:\+|0{0,2})91(\s*[\-]\s*)?|[0]?)?[6789]\d{9}$/,
            },
        },
        messages: {
            policeStationId: "Required!",
            createdDate: "Required!",
            latestAddressOfIsm: "Required!",
            nameOfIsm: "Required!", latestMobileNo: {
                regex: "Provide Valid contactNo"
            },
        },
        submitHandler: () => {
            var formData = new FormData(document.getElementById("form_MCRDetails"));
            var payload = JSON.stringify(Object.fromEntries(formData));
            //console.log(payload);
            $.ajax({
                url: "/api/ApiMCRDetails/Save",
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

                    $('#data_MCRDetails').DataTable().ajax.reload();
                    $('#form_MCRDetails').trigger("reset");
                    $('#basicModal').modal('hide');
                    swal("Successfully!", "Form has been submitted.", "success");
                },
            });
        },
    });
});