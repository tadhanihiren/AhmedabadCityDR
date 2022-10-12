function editData(id) {
    $("#submitbtn").html('Save Missing Age Wise'); //Change button value to Save
    //console.log("Edit popup show.");
    $.ajax({
        url: "/api/ApiMissingagewiseMaster/GetById",
        type: "Get",
        dataType: "json",
        data: { "id": id },
        headers: {
            "Accept": "application/json",
            "Content-Type": "application/json",
        },
        success: function (response) {
            //console.log(response.content);
            $('#form_MissingAgeWise').trigger("reset");
            $('#basicModal').modal('show');
            Populate('#form_MissingAgeWise', response.content);
        },
    });
}


$(document).ready(function () {

    PopulateSearchPoliceStationDRD();

    $("#addData").click(() => {
        $('#form_MissingAgeWise').trigger('reset');
        $("#submitbtn").html('+ ADD Missing Age Wise '); //Change button value to add
    });

    $.validator.addMethod(
        "regex",
        function (value, element, regexp) {
            return this.optional(element) || regexp.test(value);
        },
        "Please check your input."
    );

    $('#data_HistoryAgewise_Missing').DataTable({
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
            url: "/api/ApiMissingAgeWiseMaster/Get",
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
            { title: 'ID', data: 'historyMissingAgeWiseId', "width": "100px" },
            { title: 'પો.સ્ટે', data: 'policeStationName', "width": "150px" },
            { title: 'ખોવાયેલ છોકરા', data: 'missingboy', "width": "100px" },
            { title: 'ખોવાયેલ છોકરી', data: 'missinggirl', "width": "100px" },
            { title: 'કુલ', data: 'missingChildDetails', "width": "100px" },
            { title: 'મળી આવેલ છોકરા', data: 'returnboy', "width": "100px" },
            { title: 'મળી આવેલ  છોકરી', data: 'returngirl', "width": "100px" },
            { title: 'કુલ', data: 'returnChildDetails', "width": "100px" },
            { title: '૧ થી ૫ ખોવાયેલ  છોકરા', data: 'missing1to5boy', "width": "100px" },
            { title: '૧ થી ૫ ખોવાયેલ  છોકરી', data: 'missing1to5Girl', "width": "100px" },
            { title: '૬ થી ૧૨ ખોવાયેલ  છોકરા', data: 'missing6to12boy', "width": "100px" },
            { title: '૬ થી ૧૨ ખોવાયેલ છોકરી', data: 'missing6to12Girl', "width": "100px" },
            { title: '૧૩ થી ૧૮ ખોવાયેલ છોકરા ', data: 'missing13to18boy', "width": "100px" },
            { title: '૧૩ થી ૧૮ ખોવાયેલ છોકરી ', data: 'missing13to18Girl', "width": "100px" },
            { title: '૧ થી ૫ મળી આવેલ  છોકરા', data: 'return1to5boy', "width": "100px" },
            { title: '૧ થી ૫ મળી આવેલ  છોકરી', data: 'return1to5Girl', "width": "100px" },
            { title: '૬ થી ૧૨ મળી આવેલ  છોકરા', data: 'return6to12boy', "width": "100px" },
            { title: '૬ થી ૧૨ મળી આવેલ  છોકરી', data: 'return6to12Girl', "width": "100px" },
            { title: '૧૩ થી ૧૮ મળી આવેલ છોકરા ', data: 'return13to18boy', "width": "100px" },
            { title: '૧૩ થી ૧૮ મળી આવેલ છોકરી', data: 'return13to18Girl', "width": "100px" },
            { title: 'કુલ મળી આવેલ', data: 'totalmissing', "width": "100px" },
            { title: 'મળવાના બાકી', data: 'totalreturn', "width": "100px" },
            { title: 'ટકાવારી', data: 'per', "width": "100px" },
            {
                mRender: function (data, type, row) {
                    var bEdit = '<button type="button" class="btn btn-success" onclick="editData(' + row.historyMissingAgeWiseId + ')">Edit</button> ';
                    return bEdit;
                },
                "width": "100px",
            },

        ],
    });


    $("#form_MissingAgeWise").validate({
        rules: {
            policeStationId: "required",
            missingboy: {
                required: true,
                regex: /^[0-9]*$/,
            },
            missinggirl: {
                required: true,
                regex: /^[0-9]*$/,
            },
            returnboy: {
                required: true,
                regex: /^[0-9]*$/,
            },
            returngirl: {
                required: true,
                regex: /^[0-9]*$/,
            },
            missing1to5Girl: {
                required: true,
                regex: /^[0-9]*$/,
            },
            missing1to5boy: {
                required: true,
                regex: /^[0-9]*$/,
            },
            missing6to12Girl: {
                required: true,
                regex: /^[0-9]*$/,
            },
            missing6to12boy: {
                required: true,
                regex: /^[0-9]*$/,
            },
            missing13to18Girl: {
                required: true,
                regex: /^[0-9]*$/,
            },
            missing13to18boy: {
                required: true,
                regex: /^[0-9]*$/,
            },
            return1to5Girl: {
                required: true,
                regex: /^[0-9]*$/,
            },
            return1to5boy: {
                required: true,
                regex: /^[0-9]*$/,
            },
            return6to12Girl: {
                required: true,
                regex: /^[0-9]*$/,
            },
            return6to12boy: {
                required: true,
                regex: /^[0-9]*$/,
            },
            return13to18Girl: {
                required: true,
                regex: /^[0-9]*$/,
            },
            return13to18boy: {
                required: true,
                regex: /^[0-9]*$/,
            },
            totalmissing: {
                required: true,
                regex: /^[0-9]*$/,
            },
            totalreturn: {
                required: true,
                regex: /^[0-9]*$/,
            },
            per: {
                required: true,
                regex: /^[0-9]*$/,
            },
            createdDate: "required",

        },
        messages: {
            policeStationId: "required",
            missingboy: {
                required: "required",
                regex: "Numbers only.",
            },
            missinggirl: {
                required: "required",
                regex: "Numbers only.",
            },
            returnboy: {
                required: "required",
                regex: "Numbers only.",
            },
            returngirl: {
                required: "required",
                regex: "Numbers only.",
            },
            missing1to5Girl: {
                required: "required",
                regex: "Numbers only.",
            },
            missing1to5boy: {
                required: "required",
                regex: "Numbers only.",
            },
            missing6to12Girl: {
                required: "required",
                regex: "Numbers only.",
            },
            missing6to12boy: {
                required: "required",
                regex: "Numbers only.",
            },
            missing13to18Girl: {
                required: "required",
                regex: "Numbers only.",
            },
            missing13to18boy: {
                required: "required",
                regex: "Numbers only.",
            },
            return1to5Girl: {
                required: "required",
                regex: "Numbers only.",
            },
            return1to5boy: {
                required: "required",
                regex: "Numbers only.",
            },
            return6to12Girl: {
                required: "required",
                regex: "Numbers only.",
            },
            return6to12boy: {
                required: "required",
                regex: "Numbers only.",
            },
            return13to18Girl: {
                required: "required",
                regex: "Numbers only.",
            },
            return13to18boy: {
                required: "required",
                regex: "Numbers only.",
            },
            totalmissing: {
                required: "required",
                regex: "Numbers only.",
            },
            totalreturn: {
                required: "required",
                regex: "Numbers only.",
            },
            per: {
                required: "required",
                regex: " Numbers only..",
            },
            createdDate: "required",
        },

        submitHandler: () => {
            var formData = new FormData(document.getElementById("form_MissingAgeWise"));
            var payload = JSON.stringify(Object.fromEntries(formData));
            console.log(payload);
            debugger
            $.ajax({
                url: '/api/ApiMissingAgeWiseMaster/Save',
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
                    $('#form_MissingAgeWise').trigger("reset");
                    $('#data_HistoryAgewise_Missing').DataTable().ajax.reload();
                    $('#basicModal').modal('hide');
                    swal("Successfully!", "Form has been submitted.", "success");
                },
            });
        },
    });
});