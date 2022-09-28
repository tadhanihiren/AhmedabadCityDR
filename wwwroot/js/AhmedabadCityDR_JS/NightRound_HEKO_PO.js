
function editData(id) {
    $("#submitbtn").html('+Save હે.કો./પો.કો.'); //Change button value to Save
    $.ajax({
        url: "/api/ApiNightRound_HEKO_POMaster/GetById",
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
            $('#form_NightRound_HEKOPO').trigger("reset");
            $('#data_Night_Round_HEKO_PO').DataTable().ajax.reload();
            $('#basicModal').modal('show');
            Populate('#form_NightRound_HEKOPO', response.content);
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
                url: "/api/ApiNightRound_HEKO_POMaster/Delete",
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

                    $('#data_Night_Round_HEKO_PO').DataTable().ajax.reload();
                    swal("Successfully!", "Record has been deleted.", "success");
                },
            });

        }
    })
}


$(document).ready(function () {

    PopulateSearchPoliceStationDRD();

    $("#addData").click(() => {
        $('#form_NightRound_HEKOPO').trigger('reset');
        $("#submitbtn").html('+ ADD હે.કો./પો.કો.'); //Change button value to add
    });

    $("#searchButton").click(function () {
        $('#data_Night_Round_HEKO_PO').DataTable().ajax.reload();
    });


    $.validator.addMethod(
        "regex",
        function (value, element, regexp) {
            return this.optional(element) || regexp.test(value);
        },
        "Please check your input."
    );

    $('#data_Night_Round_HEKO_PO').DataTable({
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
            url: "/api/ApiNightRound_HEKO_POMaster/Get",
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
            { title: 'NightRoundHEKOPOId', data: 'nightRound_HEKO_POID', "width": "100px" },
            { title: 'પો.સ્ટે', data: 'policeStationName', "width": "150px" },
            { title: 'તારીખ', data: 'createdDate', "width": "150px" },
            { title: 'પો.સ્‍ટે.માં ફાળવેલ કુલ મોટર સાયકલની સંખ્‍યા', data: 'totalOfMotarcycle', "width": "150px" },
            { title: 'ના.રા.માં નીકળેલ મો.સા. ની સંખ્‍યા', data: 'maofNumber', "width": "150px" },
            { title: 'મો.સા.સાથે ના.રા.માં નીકળેલ હે.કો./પો.કો. ની સંખ્‍યા', data: 'nightRound_Heko_PONumber', "width": "150px" },
            { title: 'એમ.ટી.માં જમા મો.સા. (ડીફેકટ) ની સંખ્યા', data: 'defectNumber', "width": "150px" },
            { title: 'એમ.ટી.માં જમા સિ’વાય મો.સા.નહી નીકળેલા સંખ્યા', data: 'notavailabelNumber', "width": "150px" },
            { title: 'રિમાર્કસ', data: 'remark', "width": "100px" },
            {
                mRender: function (data, type, row) {
                    var bEdit = '<button type="button" class="btn btn-success" onclick="editData(' + row.nightRound_HEKO_POID + ')">Edit</button> ';
                    var bDelete = '<button type="button" class="btn btn-danger" onclick="deleteData(' + row.nightRound_HEKO_POID + ')">Delete</button>';
                    return bEdit + bDelete;
                },
                "width": "120px",
            },
        ],
    });

    $("#form_NightRound_HEKOPO").validate({
        rules: {
            policeStationId: "required",
            createdDate: "required",
            totalOfMotarcycle: {
                required: true,
                regex: /^[0-9]*$/,
            },
            maofNumber: {
                required: true,
                regex: /^[0-9]*$/,
            },
            nightRoundHekoPonumber: {
                required: true,
                regex: /^[0-9]*$/,
            },
            defectNumber: {
                required: true,
                regex: /^[0-9]*$/,
            },
            notavailabelNumber: {
                required: true,
                regex: /^[0-9]*$/,
            },

        },
        messages: {
            policeStationId: "required",
            createdDate: "required",
            totalOfMotarcycle: {
                required: "required",
                regex: "Numbers only.",
            },
            maofNumber: {
                required: "required",
                regex: "Numbers only.",
            },
            nightRoundHekoPonumber: {
                required: "required",
                regex: "Numbers only.",
            },
            defectNumber: {
                required: "required",
                regex: "Numbers only.",
            },
            notavailabelNumber: {
                required: "required",
                regex: "Numbers only.",
            },
        },

        submitHandler: () => {
            var formData = new FormData(document.getElementById("form_NightRound_HEKOPO"));
            var payload = JSON.stringify(Object.fromEntries(formData));
            console.log(payload);
            debugger
            $.ajax({
                url: '/api/ApiNightRound_HEKO_POMaster/Save',
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
                    $('#form_NightRound_HEKOPO').trigger("reset");
                    $('#data_Night_Round_HEKO_PO').DataTable().ajax.reload();
                    $('#basicModal').modal('hide');
                    swal("Successfully!", "Form has been submitted.", "success");
                },
            });
        },
    });
});