
function editData(id) {
    $("#submitbtn").html('Save CCTV Installed'); //Change button value to add
    console.log(id);
    $.ajax({
        url: "/api/ApiCCTVInstalled/GetById",
        type: "Get",
        dataType: "json",
        data: { "id": id },
        headers: {
            "Accept": "application/json",
            "Content-Type": "application/json",
        },
        success: function (response) {
            console.log(response.content);
            $('#form_CCTV_Installed').trigger("reset");
            $('#basicModal').modal('show');
            Populate('#form_CCTV_Installed', response.content);
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
                url: "/api/ApiCCTVInstalled/Delete",
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

                    $('#data_CCTV_Installed').DataTable().ajax.reload();
                    swal("Successfully!", "Record has been deleted.", "success");
                },
            });

        }
    })
}



$(document).ready(function () {

    PopulateSearchPoliceStationDRD();

    $("#addData").click(() => {
        $('#form_CCTV_Installed').trigger('reset');
        $("#submitbtn").html('+ Add CCTV Installed'); //Change button value to add
    });

    $("#searchButton").click(function () {
        $('#data_CCTV_Installed').DataTable().ajax.reload();
    });


    $.validator.addMethod(
        "regex",
        function (value, element, regexp) {
            return this.optional(element) || regexp.test(value);
        },
        "Please check your input."
    );

    $('#data_CCTV_Installed').DataTable({
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
            url: "/api/ApiCCTVInstalled/Get",
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
            { title: 'પો.સ્ટે', data: 'policeStationName', "width": "100px" },
            { title: 'તારીખ', data: 'createdDate', "width": "100px" },
            { title: 'PtzInstalled', data: 'ptZ_installed', "width": "100px" },
            { title: 'BltInstalled', data: 'blT_installed', "width": "100px" },
            { title: 'DmInstalled', data: 'dM_installed', "width": "100px" },
            { title: 'TotalInstalled', data: 'total_installed', "width": "100px" },
            {
                mRender: function (data, type, row) {
                    var bEdit = '<button type="button" class="btn btn-success" onclick="editData(' + row.installId + ')">Edit</button> ';
                    var bDelete = '<button type="button" class="btn btn-danger" onclick="deleteData(' + row.installId + ')">Delete</button>';
                    return bEdit + bDelete;
                },
                "width": "120px",
            },

        ],
    });

    $("#form_CCTV_Installed").validate({

        rules: {
            policeStationId: "required",
            ptZ_installed: "required",
            blT_installed: "required",
            dM_installed: "required",
        },

        messages: {
            policeStationId: "required",
            ptZ_installed: "required",
            blT_installed: "required",
            dM_installed: "required",
        },

        submitHandler: () => {
            var formData = new FormData(document.getElementById("form_CCTV_Installed"));
            var payload = JSON.stringify(Object.fromEntries(formData));
            console.log(payload);
            $.ajax({
                url: '/api/ApiCCTVInstalled/Save',
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
                    $('#form_CCTV_Installed').trigger("reset");
                    $('#data_CCTV_Installed').DataTable().ajax.reload();
                    $('#basicModal').modal('hide');
                    swal("Successfully!", "Form has been submitted.", "success");
                },
            });
        },
    });

});