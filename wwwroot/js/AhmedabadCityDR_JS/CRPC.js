function EditData(id) {
    $("#submitbtn").html('Save CRPC ૪૧(૧) ની વિગત'); //Change button value to Save
    $.ajax({
        url: "/api/ApiCRPC41Master/GetById",
        type: "Get",
        dataType: "json",
        data: { "id": id },
        headers: {
            "Accept": "application/json",
            "Content-Type": "application/json",
        },
        success: function (response) {
            /*console.log(response.content);*/
            $('#form_CRPC').trigger("reset");
            $('#basicModal').modal('show');
            Populate('#form_CRPC', response.content);
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
                url: "/api/ApiCRPC41Master/Delete",
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

                    $('#data_CRPC').DataTable().ajax.reload();
                    swal("Successfully!", "Record has been deleted.", "success");
                },
            });

        }
    })
}

$(document).ready(() => {

    PopulateSearchPoliceStationDRD();

    $("#addData").click(() => {
        $('#form_CRPC').trigger('reset');
        $("#submitbtn").html('+ ADD CRPC ૪૧(૧) ની વિગત'); //Change button value to add
    });

    $("#searchButton").click(function () {
        $('#data_CRPC').DataTable().ajax.reload();
    });

    $('#data_CRPC').DataTable({
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
            url: "/api/ApiCRPC41Master/Get",
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
            { title: 'તારીખ', data: 'createdDate', "width": "100px" },
            { title: 'સ્ટે. ડા. એ.નં.', data: 'crpcNumber', "width": "100px" },
            { title: 'ફરીયાદી', data: 'crime', "width": "200px" },
            { title: 'પકડાયેલ આરોપી', data: 'accusedName', "width": "600px" },
            { title: 'મળી આવેલ વાહન/ મુદ્દામાલની વિગત', data: 'vehicalDetails', "width": "300px" },
            { title: 'પકડાયેલ આરોપીથી શોધાયેલ ગુન્હાની વિગત', data: 'accusedDetails', "width": "300px" },
            { title: 'આરોપીનો પૂર્વ ઇતિહાસ', data: 'shortDetails', "width": "100px" },
            {
                mRender: function (data, type, row) {
                    var bEdit = '<button type="button" class="btn btn-success" onclick="EditData(' + row.crpcId + ')">Edit</button> ';
                    var bDelete = ' <button type="button" class="btn btn-danger" onclick="DeleteData(' + row.crpcId + ')">Delete</button>';
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

    $("#form_CRPC").validate({
        rules: {
            policeStationId: "required",
            createdDate: "required",
            crpcNumber: "required",
            crime: "required",
            accusedName: "required",
            vehicalDetails: "required",
            accusedDetails: "required",
            shortDetails: "required",
        },
        messages: {
            policeStationId: "Required!",
            createdDate: "Required!",
            crpcNumber: "Required!",
            crime: "Required!",
            accusedName: "Required!",
            vehicalDetails: "Required!",
            accusedDetails: "Required!",
            shortDetails: "Required!",
        },
        submitHandler: () => {
            var formData = new FormData(document.getElementById("form_CRPC"));
            var payload = JSON.stringify(Object.fromEntries(formData));
            //console.log(payload);
            $.ajax({
                url: "/api/ApiCRPC41Master/Save",
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

                    $('#data_CRPC').DataTable().ajax.reload();
                    $('#form_CRPC').trigger("reset");
                    $('#basicModal').modal('hide');
                    swal("Successfully!", "Form has been submitted.", "success");
                },
            });
        },
    });
});