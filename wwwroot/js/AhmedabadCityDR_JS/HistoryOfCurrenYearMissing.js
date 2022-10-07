function editData(id) {
    $("#submitbtn").html('+Save CurrentYear_Missing_Details'); //Change button value to Save
    $.ajax({
        url: "/api/ApiHistroryOfCurrentMissing/GetById",
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
            $('#data_HistoryOfCurrentMissing').DataTable().ajax.reload();
            $('#basicModal').modal('show');
            Populate('#form_CurrentYear_Missing_Details', response.content);
        },
    });
}

$(document).ready(function () {

    PopulateSearchPoliceStationDRD();

    $("#searchButton").click(function () {
        $('#data_HistoryOfCurrentMissing').DataTable().ajax.reload();
    });

    $("#addData").click(() => {
        $('#form_CurrentYear_Missing_Details').trigger('reset');
        $("#submitbtn").html('+ ADD CurrentYear_Missing_Details'); //Change button value to add
    });

    $.validator.addMethod(
        "regex",
        function (value, element, regexp) {
            return this.optional(element) || regexp.test(value);
        },
        "Please check your input."
    );

    $('#data_HistoryOfCurrentMissing').DataTable({
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
            url: "/api/ApiHistroryOfCurrentMissing/Get",
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
            { title: 'ID', data: 'histroryOfCurrentMissingId', "width": "100px" },
            { title: 'પો.સ્ટે', data: 'policeStationName', "width": "150px" },
            { title: 'તારીખ', data: 'createdDate', "width": "100px" },
            { title: 'ગુમ થયેલ છોકરા', data: 'missingboy', "width": "100px" },
            { title: 'ગુમ થયેલ છોકરી', data: 'missinggirl', "width": "100px" },
            { title: 'પરત મળ્યા છોકરા', data: 'returnboy', "width": "100px" },
            { title: 'પરત મળ્યા છોકરી', data: 'returngirl', "width": "100px" },
            { title: 'ગુમ થયેલ સ્ત્રી', data: 'missingwoman', "width": "100px" },
            { title: 'ગુમ થયેલ પુરૂષ', data: 'missingman', "width": "100px" },
            { title: 'પરત મળ્યા સ્ત્રી', data: 'returnWoman', "width": "100px" },
            { title: 'પરત મળ્યા પુરૂષ', data: 'returnman', "width": "100px" },
            { title: 'કૂલ ગુમ બાળકો', data: 'totalmissingChild', "width": "100px" },
            { title: 'કૂલ પરત બાળકો', data: 'totalRetrunChild', "width": "100px" },
            { title: 'કૂલ ગુમ વ્યક્તિઓ', data: 'totalMissingPerson', "width": "100px" },
            { title: 'કૂલ પરત વ્યક્તિઓ', data: 'totalReturnPerson', "width": "100px" },
            {
                mRender: function (data, type, row) {
                    var bEdit = '<button type="button" class="btn btn-success" onclick="editData(' + row.histroryOfCurrentMissingId + ')">Edit</button> ';
                    return bEdit;
                },
                "width": "120px",
            },

        ],
    });


    $("#form_CurrentYear_Missing_Details").validate({
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
            missingwoman: {
                required: true,
                regex: /^[0-9]*$/,
            },
            missingman: {
                required: true,
                regex: /^[0-9]*$/,
            },
            returnWoman: {
                required: true,
                regex: /^[0-9]*$/,
            },
            returnman: {
                required: true,
                regex: /^[0-9]*$/,
            },
            totalmissingChild: {
                required: true,
                regex: /^[0-9]*$/,
            },
            totalRetrunChild: {
                required: true,
                regex: /^[0-9]*$/,
            },
            totalMissingPerson: {
                required: true,
                regex: /^[0-9]*$/,
            },
            totalReturnPerson: {
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
            missingwoman: {
                required: "required",
                regex: "Numbers only.",
            },
            missingman: {
                required: "required",
                regex: "Numbers only.",
            },
            returnWoman: {
                required: "required",
                regex: "Numbers only.",
            },
            returnman: {
                required: "required",
                regex: "Numbers only.",
            },
            totalmissingChild: {
                required: "required",
                regex: "Numbers only.",
            },
            totalRetrunChild: {
                required: "required",
                regex: "Numbers only.",
            },
            totalMissingPerson: {
                required: "required",
                regex: "Numbers only.",
            },
            totalReturnPerson: {
                required: "required",
                regex: "Numbers only.",
            },
            createdDate: "required",
        },

        submitHandler: () => {
            var formData = new FormData(document.getElementById("form_CurrentYear_Missing_Details"));
            var payload = JSON.stringify(Object.fromEntries(formData));
            console.log(payload);
            debugger
            $.ajax({
                url: '/api/ApiHistroryOfCurrentMissing/Save',
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
                    $('#data_HistoryOfCurrentMissing').DataTable().ajax.reload();
                    $('#form_CurrentYear_Missing_Details').trigger("reset");
                    $('#basicModal').modal('hide');
                    swal("Successfully!", "Form has been submitted.", "success");
                },
            });
        },
    });
});