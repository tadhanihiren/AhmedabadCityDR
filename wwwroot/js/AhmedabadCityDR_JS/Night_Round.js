function editData(id) {
    $("#submitbtn").html('+Save નાઇટ રાઉન્‍ડ '); //Change button value to Save
    $.ajax({
        url: "/api/ApiNightRound/GetById",
        type: "Get",
        dataType: "json",
        data: { "id": id },
        headers: {
            "Accept": "application/json",
            "Content-Type": "application/json",
        },
        success: function (response) {
            console.log(response.content);
            console.log(id);
            $('#form_NightRound').trigger("reset");
            $('#basicModal').modal('show');
            Populate('#form_NightRound', response.content);
        },
    });
}


function deleteData(id) {
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
                url: "/api/ApiNightRound/Delete",
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

                    $('#data_Night_Round').DataTable().ajax.reload();
                    swal("Successfully!", "Record has been deleted.", "success");
                },
            });

        }
    })
}

$(document).ready(function () {

    PopulateSearchPoliceStationDRD();

    $("#addData").click(() => {
        $('#form_NightRound').trigger('reset');
        $("#submitbtn").html('+ ADD નાઇટ રાઉન્‍ડ'); //Change button value to add
    });

    $("#searchButton").click(function () {
        $('#data_Night_Round').DataTable().ajax.reload();
    });

    $.validator.addMethod(
        "regex",
        function (value, element, regexp) {
            return this.optional(element) || regexp.test(value);
        },
        "Please check your input."
    );

    $('#data_Night_Round').DataTable({
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
            url: "/api/ApiNightRound/Get",
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
            { title: 'NightRoundId', data: 'nightRoundId', "width": "100px" },
            { title: 'ના.રા.માં નિકળનાર અધિકારીશ્રીઓના નામ', data: 'nightRoundOfficerName', "width": "150px" },
            { title: 'પો.સ્ટે', data: 'policeStationName', "width": "150px" },
            { title: 'તારીખ', data: 'createdDate', "width": "100px" },
            { title: 'રવાના સમય', data: 'goingTime', "width": "100px" },
            { title: 'પરત સમય', data: 'returnTime', "width": "100px" },
            { title: 'ના.રા.વિસ્તાર', data: 'nightRoundPlace', "width": "100px" },
            { title: 'નોંધ', data: 'remarks', "width": "100px" },
            {
                mRender: function (data, type, row) {
                    var bEdit = '<button type="button" class="btn btn-success" onclick="editData(' + row.nightRoundId + ')">Edit</button> ';
                    var bDelete = '<button type="button" class="btn btn-danger" onclick="deleteData(' + row.nightRoundId + ')">Delete</button>';
                    return bEdit + bDelete;
                },
                "width": "120px",
            },
        ],
    });


    $("#form_NightRound").validate({
        rules: {
            designationId: "required",
            tempId: "required",
            nightRoundOfficerName: "required",
            goingTime: "required",
            returnTime: "required",
            nightRoundPlace: "required",
            remarks: "required",
            createdDate: "required",

        },
        messages: {
            designationId: "required",
            tempId: "required",
            nightRoundOfficerName: "required",
            goingTime: "required",
            returnTime: "required",
            nightRoundPlace: "required",
            remarks: "required",
            createdDate: "required",

        },

        submitHandler: () => {
            var formData = new FormData(document.getElementById("form_NightRound"));
            var payload = JSON.stringify(Object.fromEntries(formData));
            debugger
            console.log(payload);
            $.ajax({
                url: '/api/ApiNightRound/Save',
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
                    $('#form_NightRound').trigger("reset");
                    $('#data_Night_Round').DataTable().ajax.reload();
                    $('#basicModal').modal('hide');
                    swal("Successfully!", "Form has been submitted.", "success");
                },
            });
        },
    });
});


$("#designationId").change(function (e) {
    $("#tempId").empty(),
        $.get("/api/ApiCommon/Get_PolicestationId_For_NightRound", { designationId: $("#designationId").val() },
            function (data) {
                $("#tempId").append("<option selected disabled>--Select Sector/Zone/Division/PoliceStation:--</option>")
                console.log(data);
                $.each(data, function (index, row) {
                    $("#tempId").append("<option value='" + row.value + "'>" + row.text + "</option>")
                });
            });
});