function EditData(id) {
    $("#submitbtn").html('Save બી- રોલ ભરેલાની વિગત દર્શાવતું પત્રક'); //Change button value to Save
    $.ajax({
        url: "/api/ApiLaborInformationMaster/GetById",
        type: "Get",
        dataType: "json",
        data: { "id": id },
        headers: {
            "Accept": "application/json",
            "Content-Type": "application/json",
        },
        success: function (response) {
            /*console.log(response.content);*/
            $('#form_Labor_Information').trigger("reset");
            $('#basicModal').modal('show');
            Populate('#form_Labor_Information', response.content);
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
                url: "/api/ApiLaborInformationMaster/Delete",
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

                    $('#data_Labor_Information').DataTable().ajax.reload();
                    swal("Successfully!", "Record has been deleted.", "success");
                },
            });

        }
    })
}

$(document).ready(() => {

    PopulateSearchPoliceStationDRD();

    $("#addData").click(() => {
        $('#form_Labor_Information').trigger('reset');
        $("#submitbtn").html('+ ADD બી- રોલ ભરેલાની વિગત દર્શાવતું પત્રક'); //Change button value to add
    });

    $("#searchButton").click(function () {
        $('#data_Labor_Information').DataTable().ajax.reload();
    });

    $('#data_Labor_Information').DataTable({
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
            url: "/api/ApiLaborInformationMaster/Get",
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
            { title: 'બી-રોલ પ્રકાર', data: 'subCategoryName', "width": "100px" },
            { title: 'કેટલા મજુરો ચેક કર્યા', data: 'checkedLabor', "width": "100px" },
            { title: 'ચેક કરેલ જગ્‍યાની સંખ્‍યા', data: 'checkedPlace', "width": "100px" },
            { title: 'કેટલા મજુરોની  વી.ગ્રાફી, ફો.ગ્રાફી કરી', data: 'totalLaborersVideography', "width": "100px" },
            { title: 'મજુરોના એ-રોલ બી-રોલ ભર્યાની સંખ્‍યા', data: 'workers_ARoll_BRollNumber', "width": "100px" },
            {
                mRender: function (data, type, row) {
                    var bEdit = '<button type="button" class="btn btn-success" onclick="EditData(' + row.laborInformationId + ')">Edit</button> ';
                    var bDelete = ' <button type="button" class="btn btn-danger" onclick="DeleteData(' + row.laborInformationId + ')">Delete</button>';
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

    $("#form_Labor_Information").validate({
        rules: {
            policeStationId: "required",
            createdDate: "required",
            checkedLabor: {
                required: true,
                regex: /^[0-9]*$/,
            },
            checkedPlace: {
                required: true,
                regex: /^[0-9]*$/,
            },
            totalLaborersVideography: {
                required: true,
                regex: /^[0-9]*$/,
            },
            workers_ARoll_BRollNumber: {
                required: true,
                regex: /^[0-9]*$/,
            },
        },
        messages: {
            policeStationId: "Required!",
            createdDate: "Required!",
            checkedLabor: {
                required: "Required!",
                regex: "Numbers only.",
            },
            checkedPlace: {
                required: "Required!",
                regex: "Numbers only.",
            },
            totalLaborersVideography: {
                required: "Required!",
                regex: "Numbers only.",
            },
            workers_ARoll_BRollNumber: {
                required: "Required!",
                regex: "Numbers only.",
            },
        },
        submitHandler: () => {
            var formData = new FormData(document.getElementById("form_Labor_Information"));
            var payload = JSON.stringify(Object.fromEntries(formData));
            //console.log(payload);
            $.ajax({
                url: "/api/ApiLaborInformationMaster/Save",
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

                    $('#data_Labor_Information').DataTable().ajax.reload();
                    $('#form_Labor_Information').trigger("reset");
                    $('#basicModal').modal('hide');
                    swal("Successfully!", "Form has been submitted.", "success");
                },
            });
        },
    });
});