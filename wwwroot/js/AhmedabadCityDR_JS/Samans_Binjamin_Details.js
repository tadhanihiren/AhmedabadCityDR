function editData(id) {
    $("#submitbtn").html('Save બિન જામીન લાયક વોરન્ટ'); //Change button value to add
    $.ajax({
        url: "/api/ApiSamans_jamin_details/GetBinJaminById",
        type: "Get",
        dataType: "json",
        data: { "id": id },
        headers: {
            "Accept": "application/json",
            "Content-Type": "application/json",
        },
        success: function (response) {
            console.log(response);
            $('#form_BinJamin_Details').trigger("reset");
            $('#basicModal').modal('show');
            Populate('#form_BinJamin_Details', response.content);
        },
    });
}

$(document).ready(function () {

    PopulateSearchPoliceStationDRD();

    $("#addData").click(() => {
        $('#form_BinJamin_Details').trigger('reset');
        $("#submitbtn").html('+ Add બિન જામીન લાયક વોરન્ટ'); //Change button value to add
    });

    $("#searchButton").click(function () {
        $('#data_BinJamin_Details').DataTable().ajax.reload();
    });

    $('#data_BinJamin_Details').DataTable({
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
            url: "/api/ApiSamans_jamin_details/GetBinJamin",
            type: "Get",
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
            { title: 'પો.સ્‍ટે.નું નામ', data: 'policeStationName', "width": "150px" },
            { title: 'આજની તારીખે જુના પેન્‍ડીંગ', data: 'today_old_pending', "width": "160px" },
            { title: 'આજની તારીખે નવા આવેલ', data: 'today_new', "width": "160px" },
            { title: 'આજની તારીખે કુલ', data: 'today_total', "width": "150px" },
            { title: 'આજની તારીખે બજેલ', data: 'today_complete', "width": "150px" },
            { title: 'આજની તારીખે વગર બજવેલ', data: 'today_non_complete', "width": "170px" },
            { title: 'આજની તારીખે ટ્રાન્‍સફર', data: 'today_transfer', "width": "160px" },
            { title: 'આજની તારીખે પેન્‍ડીંગ', data: 'today_pending', "width": "150px" },
            {
                mRender: function (data, type, row) {
                    return '<button type="button" class="btn btn-success" onclick="editData(' + row.samans_id + ')">Edit</button> ';
                },
                "width": "20px",
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

    $("#form_BinJamin_Details").validate({

        rules: {
            policeStationId: {
                required: true,
            },
            createdDate: {
                required: true,
            },
            todayOldPending: {
                required: true,
                regex: /^[0-9]*$/,
            },
            todayNew: {
                required: true,
                regex: /^[0-9]*$/,
            },
            todayComplete: {
                required: true,
                regex: /^[0-9]*$/,
            },
            todayNonComplete: {
                required: true,
                regex: /^[0-9]*$/,
            },
            todayTransfer: {
                required: true,
                regex: /^[0-9]*$/,
            },
        },
        messages: {
            policeStationId: {
                required: "required",
            },
            createdDate: {
                required: "required",
            },
            todayOldPending: {
                required: "required",
                regex: "Numbers only.",
            },
            todayNew: {
                required: "required",
                regex: "Numbers only.",
            },
            todayComplete: {
                required: "required",
                regex: "Numbers only.",
            },
            todayNonComplete: {
                required: "required",
                regex: "Numbers only.",
            },
            todayTransfer: {
                required: "required",
                regex: "Numbers only.",
            },
        },

        submitHandler: () => {
            var formData = new FormData(document.getElementById("form_BinJamin_Details"));
            var payload = JSON.stringify(Object.fromEntries(formData));
            console.log(payload);
            $.ajax({
                url: '/api/ApiSamans_jamin_details/SaveBinJamin',
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
                    $('#data_BinJamin_Details').DataTable().ajax.reload();
                    $('#form_BinJamin_Details').trigger("reset");
                    $('#basicModal').modal('hide');
                    swal("Successfully!", "Form has been submitted.", "success");
                },
            });
        },
    });
});