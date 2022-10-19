function editData(id) {
    $("#submitbtn").html('Save CCTV '); //Change button value to add
    $.ajax({
        url: "/api/ApiCCTV/GetById",
        type: "Get",
        dataType: "json",
        data: { "id": id },
        headers: {
            "Accept": "application/json",
            "Content-Type": "application/json",
        },
        success: function (response) {
            console.log(response.content);
            $('#form_CCTV').trigger("reset");
            $('#basicModal').modal('show');
            Populate('#form_CCTV', response.content);
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
                url: "/api/ApiCCTV/Delete",
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

                    $('#data_CCTV').DataTable().ajax.reload();
                    swal("Successfully!", "Record has been deleted.", "success");
                },
            });

        }
    })
}

$(document).ready(function () {

    PopulateSearchPoliceStationDRD();

    $("#addData").click(() => {
        $('#form_CCTV').trigger('reset');
        $("#submitbtn").html('+ Add CCTV'); //Change button value to add
    });

    $("#searchButton").click(function () {
        $('#data_CCTV').DataTable().ajax.reload();
    });

    $.validator.addMethod(
        "regex",
        function (value, element, regexp) {
            return this.optional(element) || regexp.test(value);
        },
        "Please check your input."
    );

    $('#data_CCTV').DataTable({
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
            url: "/api/ApiCCTV/Get",
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
            { title: 'પો.સ્ટે', data: 'policeStationName', "width": "150px" },
            { title: 'તારીખ', data: 'createdDate', "width": "100px" },
            { title: 'Range', data: 'range', "width": "100px" },
            { title: 'City Distict', data: 'city_Distict', "width": "100px" },
            { title: 'Cluster', data: 'cluster', "width": "100px" },
            { title: 'Vender Name', data: 'venderName', "width": "100px" },
            { title: 'PTZ installed', data: 'ptZ_installed', "width": "100px" },
            { title: 'BLT installed', data: 'blT_installed', "width": "100px" },
            { title: 'DM installed', data: 'dM_installed', "width": "100px" },
            { title: 'Total installed', data: 'total_installed', "width": "100px" },
            { title: 'PTZ funcational', data: 'ptZ_funcational', "width": "100px" },
            { title: 'BLT funcational', data: 'blT_funcational', "width": "100px" },
            { title: 'DM funcational', data: 'dM_funcational', "width": "100px" },
            { title: 'Total funcation', data: 'total_funcation', "width": "100px" },
            { title: 'PTZ not funcational', data: 'ptZ_not_funcational', "width": "100px" },
            { title: 'BLT not funcational', data: 'blT_not_funcational', "width": "100px" },
            { title: 'DM not funcational', data: 'dM_not_funcational', "width": "100px" },
            { title: 'Total not funcation', data: 'total_not_funcation', "width": "100px" },
            { title: 'Complaint1', data: 'complaint1', "width": "100px" },
            { title: 'ComplaintDate1', data: 'complaintDate1', "width": "100px" },
            { title: 'Complaint2', data: 'complaint2', "width": "100px" },
            { title: 'ComplaintDate2', data: 'complaintDate2', "width": "100px" },
            { title: 'Complaint3', data: 'complaint3', "width": "100px" },
            { title: 'ComplaintDate3', data: 'complaintDate3', "width": "100px" },
            { title: 'Equipmenttype', data: 'type', "width": "100px" },
            { title: 'NatureofComplant', data: 'natureofComplant', "width": "100px" },
            { title: 'Visited_Remark', data: 'visited_Remark', "width": "100px" },
            { title: 'StatusType', data: 'statusType', "width": "100px" },
            { title: 'ResolveDate', data: 'resolveDate', "width": "100px" },
            { title: 'Remark', data: 'remark', "width": "100px" },

            {
                mRender: function (data, type, row) {
                    var bEdit = '<button type="button" class="btn btn-success" onclick="editData(' + row.cctvId + ')">Edit</button> ';
                    var bDelete = '<button type="button" class="btn btn-danger" onclick="deleteData(' + row.cctvId + ')">Delete</button>';
                    return bEdit + bDelete;
                },
                "width": "120px",
            },

        ],
    });

    $("#form_CCTV").validate({

        rules: {
            policeStationId: "required",
            createdDate: "required",
            equipmentsId: "required",
            statusId: "required",
            range: "required",
            cityDistict: "required",
            cluster: "required",
            venderName: "required",
            ptzInstalled: {
                required: true,
                regex: /^[0-9]*$/,
            },
            bltInstalled: {
                required: true,
                regex: /^[0-9]*$/,
            },
            dmInstalled: {
                required: true,
                regex: /^[0-9]*$/,
            },
            ptzFuncational: {
                required: true,
                regex: /^[0-9]*$/,
            },
            bltFuncational: {
                required: true,
                regex: /^[0-9]*$/,
            },
            dmFuncational: {
                required: true,
                regex: /^[0-9]*$/,
            },
            ptzNotFuncational: {
                required: true,
                regex: /^[0-9]*$/,
            },
            bltNotFuncational: {
                required: true,
                regex: /^[0-9]*$/,
            },
            dmNotFuncational: {
                required: true,
                regex: /^[0-9]*$/,
            },
        },
        messages: {
            policeStationId: "required",
            createdDate: "required",
            equipmentsId: "required",
            statusId: "required",
            range: "required",
            cityDistict: "required",
            cluster: "required",
            venderName: "required",
            ptzInstalled: {
                required: "required",
                regex: "Numbers only.",
            },
            bltInstalled: {
                required: "required",
                regex: "Numbers only.",
            },
            dmInstalled: {
                required: "required",
                regex: "Numbers only.",
            },
            ptzFuncational: {
                required: "required",
                regex: "Numbers only.",
            },
            bltFuncational: {
                required: "required",
                regex: "Numbers only.",
            },
            dmFuncational: {
                required: "required",
                regex: "Numbers only.",
            },
            ptzNotFuncational: {
                required: "required",
                regex: "Numbers only.",
            },
            bltNotFuncational: {
                required: "required",
                regex: "Numbers only.",
            },
            dmNotFuncational: {
                required: "required",
                regex: "Numbers only.",
            },
        },
        submitHandler: () => {
            var formData = new FormData(document.getElementById("form_CCTV"));
            var payload = JSON.stringify(Object.fromEntries(formData));
            console.log(payload);
            $.ajax({
                url: '/api/ApiCCTV/Save',
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
                    $('#form_CCTV').trigger("reset");
                    $('#data_CCTV').DataTable().ajax.reload();
                    $('#basicModal').modal('hide');
                    swal("Successfully!", "Form has been submitted.", "success");
                },
            });
        },
    });

    $("#policeStationId").change(function (e) {
        $.get("/api/ApiCCTV/GetCCTV_Details", { policeStationId: $("#policeStationId").val() },
            function (response) {
                console.log(JSON.stringify(response));
                if (response.data==null)
                {
                    $('#range').val('');
                    $('#cityDistict').val('');
                    $('#ptzInstalled').val('');
                    $('#bltInstalled').val('');
                    $('#dmInstalled').val('');
                }
                $('#range').val(response.data.co);
                $('#cityDistict').val(response.data.city);
                $('#ptzInstalled').val(response.data.ptzInstalled);
                $('#bltInstalled').val(response.data.bltInstalled);
                $('#dmInstalled').val(response.data.dmInstalled);
            });
    });
});
