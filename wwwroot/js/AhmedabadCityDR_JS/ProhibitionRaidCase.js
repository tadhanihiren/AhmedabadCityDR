function EditData(id) {
    $("#submitbtn").html('Save પ્રોહીબીશનના કેસોમા રેઇડ'); //Change button value to Save
    //console.log("Edit popup show.");
    $.ajax({
        url: "/api/ApiProhibitionRaidCase/GetById",
        type: "Get",
        dataType: "json",
        data: { "id": id },
        headers: {
            "Accept": "application/json",
            "Content-Type": "application/json",
        },
        success: function (response) {
            //console.log(response.content);
            $('#form_ProhibitionRaidCase').trigger("reset");
            $('#basicModal').modal('show');
            Populate('#form_ProhibitionRaidCase', response.content);
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
                url: "/api/ApiProhibitionRaidCase/Delete",
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

                    $('#data_ProhibitionRaidCase').DataTable().ajax.reload();
                    swal("Successfully!", "Record has been deleted.", "success");
                },
            });

        }
    })
}

$(document).ready(() => {

    PopulateSearchPoliceStationDRD();

    $("#addData").click(() => {
        $('#form_ProhibitionRaidCase').trigger('reset');
        $("#submitbtn").html('+ ADD પ્રોહીબીશનના કેસોમા રેઇડ'); //Change button value to add
    });

    $("#searchButton").click(function () {
        //console.log("Click....")
        $('#data_ProhibitionRaidCase').DataTable().ajax.reload();
    });

    $('#data_ProhibitionRaidCase').DataTable({
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
            url: "/api/ApiProhibitionRaidCase/Get",
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
            { title: 'પો.સ્ટે ગુ.ર.નં', data: 'policeStationNumber', "width": "100px" },
            { title: 'પો.સ્ટે', data: 'policeStationName', "width": "100px" },
            { title: 'કલમ', data: 'ipact', "width": "300px" },
            { title: 'તારીખ', data: 'createdDate', "width": "100px" },
            { title: 'ગુ.બ.તા.ટા./ગુ.જા.તા.ટા.', data: 'gubatata', "width": "200px" },
            { title: 'ગુનાની જગ્યા', data: 'crimePlace', "width": "200px" },
            { title: 'રેઈડ દરમ્યાન સ્થળ ઉપરથી ભાગી જનાર આરોપીના નામ', data: 'raidTimeCriminalName', "width": "200px" },
            { title: 'રેઈડીંગ પાર્ટીના અધીકારી/ કર્મચારીઓના નામ', data: 'raidingPartyEmployeeName', "width": "200px" },
            { title: 'તપાસ કરનારનુ નામ હોદ્દો', data: 'investigationOfficerName', "width": "200px" },
            {
                mRender: function (data, type, row) {
                    var bEdit = '<button type="button" class="btn btn-success" onclick="EditData(' + row.prohibitionRaidCaseId + ')">Edit</button> ';
                    var bDelete = ' <button type="button" class="btn btn-danger" onclick="DeleteData(' + row.prohibitionRaidCaseId + ')">Delete</button>';
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

    $("#form_ProhibitionRaidCase").validate({
        rules: {
            policeStationId: "required",
            policeStationNumber: {
                required: true,
                minlength: 14,
                maxlength: 14,
            },
            ipcact: "required",
            gubatata: "required",
            raidTimeCriminalName: "required",
            raidingPartyEmployeeName: "required",
            investigationOfficerName: "required",
            createdDate: "required",
        },
        messages: {
            policeStationId: "Required!",
            policeStationNumber: {
                required: "Required!",
                minlength: "Required minimum 14 numbers",
                maxlength: "Required maxlength 14 numbers",
            },
            ipcact: "Required!",
            gubatata: "Required!",
            raidTimeCriminalName: "Required!",
            raidingPartyEmployeeName: "Required!",
            investigationOfficerName: "Required!",
            createdDate: "Required!",
        },
        submitHandler: () => {
            var formData = new FormData(document.getElementById("form_ProhibitionRaidCase"));
            var payload = JSON.stringify(Object.fromEntries(formData));
            //console.log(payload);
            $.ajax({
                url: "/api/ApiProhibitionRaidCase/Save",
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

                    $('#data_ProhibitionRaidCase').DataTable().ajax.reload();
                    $('#form_ProhibitionRaidCase').trigger("reset");
                    $('#basicModal').modal('hide');
                    swal("Successfully!", "Form has been submitted.", "success");
                },
            });
        },
    });
});