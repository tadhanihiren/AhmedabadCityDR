function EditData(id) {
    $("#submitbtn").html('Save વાહન તપાસની માહિતી'); //Change button value to Save
    $.ajax({
        url: "/api/ApiVehicleCheckingMaster/GetById",
        type: "Get",
        dataType: "json",
        data: { "id": id },
        headers: {
            "Accept": "application/json",
            "Content-Type": "application/json",
        },
        success: function (response) {
            /*console.log(response.content);*/
            $('#form_VehicleChecking').trigger("reset");
            $('#basicModal').modal('show');
            Populate('#form_VehicleChecking', response.content);
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
                url: "/api/ApiVehicleCheckingMaster/Delete",
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

                    $('#data_VehicleChecking').DataTable().ajax.reload();
                    swal("Successfully!", "Record has been deleted.", "success");
                },
            });

        }
    })
}

$(document).ready(() => {

    PopulateSearchPoliceStationDRD();

    $("#addData").click(() => {
        $('#form_VehicleChecking').trigger('reset');
        $("#submitbtn").html('+ ADD વાહન તપાસની માહિતી'); //Change button value to add
    });

    $("#searchButton").click(function () {
        $('#data_VehicleChecking').DataTable().ajax.reload();
    });

    $('#data_VehicleChecking').DataTable({
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
            url: "/api/ApiVehicleCheckingMaster/Get",
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
            { title: 'તારીખ', data: 'createdDate', "width": "70px" },
            { title: 'વિભાગ', data: 'subCategoryName', "width": "100px" },
            { title: 'કુલ ચેક કરેલ વાહનો ની સંખ્યા', data: 'checktwowheeler', "width": "100px" },
            { title: 'કુલ ચેક કરેલ મેમો ની સંખ્યા', data: 'checkthreewheeler', "width": "100px" },
            { title: 'કુલ દંડ વસુલાત', data: 'dandtwowheeler', "width": "100px" },
            { title: 'ડિટેઈન કરવામા આવેલ વાહનોની સંખ્યા', data: 'detain', "width": "100px" },
            { title: 'રિમાર્કસ', data: 'remarks', "width": "100px" },
            {
                mRender: function (data, type, row) {
                    var bEdit = '<button type="button" class="btn btn-success" onclick="EditData(' + row.vehicleCheckingId + ')">Edit</button> ';
                    var bDelete = ' <button type="button" class="btn btn-danger" onclick="DeleteData(' + row.vehicleCheckingId + ')">Delete</button>';
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

    $("#form_VehicleChecking").validate({
        rules: {
            policeStationId: "required",
            createdDate: "required",
            subCategoryId: "required",
            checktwowheeler: {
                required: true,
                regex: /^[0-9]*$/,
            },
            checkthreewheeler: {
                required: true,
                regex: /^[0-9]*$/,
            },
            dandtwowheeler: {
                required: true,
                regex: /^[0-9]*$/,
            },
            detain: {
                required: true,
                regex: /^[0-9]*$/,
            },
        },
        messages: {
            policeStationId: "Required!",
            createdDate: "Required!",
            subCategoryId: "Required!",
            checktwowheeler: {
                required: "Required!",
                regex: "Numbers only.",
            },
            checkthreewheeler: {
                required: "Required!",
                regex: "Numbers only.",
            },
            dandtwowheeler: {
                required: "Required!",
                regex: "Numbers only.",
            },
            detain: {
                required: "Required!",
                regex: "Numbers only.",
            },
        },
        submitHandler: () => {
            var formData = new FormData(document.getElementById("form_VehicleChecking"));
            var payload = JSON.stringify(Object.fromEntries(formData));
            console.log(payload);
            $.ajax({
                url: "/api/ApiVehicleCheckingMaster/Save",
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

                    $('#data_VehicleChecking').DataTable().ajax.reload();
                    $('#form_VehicleChecking').trigger("reset");
                    $('#basicModal').modal('hide');
                    swal("Successfully!", "Form has been submitted.", "success");
                },
            });
        },
    });
});