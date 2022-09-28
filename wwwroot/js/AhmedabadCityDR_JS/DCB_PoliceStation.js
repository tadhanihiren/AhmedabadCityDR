function EditData(id) {
    $("#submitbtn").html('Save ડીસીબી પોલીસ-સ્ટેશન'); //Change button value to Save
    $.ajax({
        url: "/api/ApiDcbPolicestationMaster/GetById",
        type: "Get",
        dataType: "json",
        data: { "id": id },
        headers: {
            "Accept": "application/json",
            "Content-Type": "application/json",
        },
        success: function (response) {
            /*console.log(response.content);*/
            $('#form_DcbPolicestationMaster').trigger("reset");
            $('#basicModal').modal('show');
            Populate('#form_DcbPolicestationMaster', response.content);
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
                url: "/api/ApiDcbPolicestationMaster/Delete",
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

                    $('#data_DcbPolicestationMaster').DataTable().ajax.reload();
                    swal("Successfully!", "Record has been deleted.", "success");
                },
            });

        }
    })
}

$(document).ready(() => {

    PopulateSearchPoliceStationDRD();

    $("#addData").click(() => {
        $('#form_DcbPolicestationMaster').trigger('reset');
        $("#submitbtn").html('+ ADD ડીસીબી પોલીસ-સ્ટેશન'); //Change button value to add
    });

    $("#searchButton").click(function () {
        $('#data_DcbPolicestationMaster').DataTable().ajax.reload();
    });

    $('#data_DcbPolicestationMaster').DataTable({
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
            url: "/api/ApiDcbPolicestationMaster/Get",
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
        order: [[0, 'asc']],
        columnDefs: [
            {
                target: 0,
                visible: false,
                searchable: false,
            },
        ],
        "columns": [
            { title: 'Id', data: 'dcbid'},
            { title: 'કામગીરી', data: 'operation', "width": "70px" },
            { title: 'વિગત', data: 'shortDetails', "width": "500px" },
            { title: 'તારીખ', data: 'createdDate', "width": "70px" },
            {
                mRender: function (data, type, row) {
                    var bEdit = '<button type="button" class="btn btn-success" onclick="EditData(' + row.dcbid + ')">Edit</button> ';
                    var bDelete = ' <button type="button" class="btn btn-danger" onclick="DeleteData(' + row.dcbid + ')">Delete</button>';
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

    $("#form_DcbPolicestationMaster").validate({
        rules: {
            operation: "required",
            shortDetails: "required",
            createdDate: "required",
        },
        messages: {
            operation: "Required!",
            shortDetails: "Required!",
            createdDate: "Required!",
        },
        submitHandler: () => {
            var formData = new FormData(document.getElementById("form_DcbPolicestationMaster"));
            var payload = JSON.stringify(Object.fromEntries(formData));
            console.log(payload);
            $.ajax({
                url: "/api/ApiDcbPolicestationMaster/Save",
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

                    $('#data_DcbPolicestationMaster').DataTable().ajax.reload();
                    $('#form_DcbPolicestationMaster').trigger("reset");
                    $('#basicModal').modal('hide');
                    swal("Successfully!", "Form has been submitted.", "success");
                },
            });
        },
    });
});