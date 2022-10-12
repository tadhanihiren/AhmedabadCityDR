function EditData(id) {
    $("#submitbtn").html('Save અરજી'); //Change button value to Save
    $.ajax({
        url: "/api/ApiPendingArjiDetails/GetById",
        type: "Get",
        dataType: "json",
        data: { "id": id },
        headers: {
            "Accept": "application/json",
            "Content-Type": "application/json",
        },
        success: function (response) {
            /*console.log(response.content);*/
            $('#form_PendingArjiDetail').trigger("reset");
            $('#basicModal').modal('show');
            Populate('#form_PendingArjiDetail', response.content);
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
                url: "/api/ApiPendingArjiDetails/Delete",
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

                    $('#data_PendingArjiDetail').DataTable().ajax.reload();
                    swal("Successfully!", "Record has been deleted.", "success");
                },
            });

        }
    })
}

$(document).ready(() => {

    PopulateSearchPoliceStationDRD();

    $("#addData").click(() => {
        $('#form_PendingArjiDetail').trigger('reset');
        $("#submitbtn").html('+ ADD અરજી'); //Change button value to add
    });

    $("#searchButton").click(function () {
        $('#data_PendingArjiDetail').DataTable().ajax.reload();
    });

    $('#data_PendingArjiDetail').DataTable({
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
            url: "/api/ApiPendingArjiDetails/Get",
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
            { title: 'અરજી રેફરન્સ', data: 'categoryName', "width": "100px" },
            { title: '10 દિવસ અંદર', data: 'under_10Days', "width": "100px" },
            { title: '10 દિવસ ઉપર', data: 'above_10Days', "width": "100px" },
            { title: '1 મહિના ઉપર', data: 'above_OneMonth', "width": "100px" },
            { title: '2 મહિના ઉપર', data: 'above_TwoMonth', "width": "100px" },
            { title: '3 મહિના ઉપર', data: 'above_ThreeMonth', "width": "100px" },
            { title: '6 મહિના ઉપર', data: 'above_SixMonth', "width": "100px" },
            { title: '1 વર્ષ  ઉપર', data: 'above_OneYear', "width": "100px" },
            { title: 'તારીખ', data: 'createdDate', "width": "100px" },
            {
                mRender: function (data, type, row) {
                    var bEdit = '<button type="button" class="btn btn-success" onclick="EditData(' + row.pendingArjiDetailId + ')">Edit</button> ';
                    var bDelete = ' <button type="button" class="btn btn-danger" onclick="DeleteData(' + row.pendingArjiDetailId + ')">Delete</button>';
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

    $("#form_PendingArjiDetail").validate({
        rules: {
            policeStationId: "required",
            pendingArjiCategoryId: "required",
            under10days: {
                required: true,
                regex: /^[0-9]*$/,
            },
            above10days: {
                required: true,
                regex: /^[0-9]*$/,
            },
            aboveOneMonth: {
                required: true,
                regex: /^[0-9]*$/,
            },
            aboveTwoMonth: {
                required: true,
                regex: /^[0-9]*$/,
            },
            aboveThreeMonth: {
                required: true,
                regex: /^[0-9]*$/,
            },
            aboveSixMonth: {
                required: true,
                regex: /^[0-9]*$/,
            },
            createdDate: "required",
        },
        messages: {
            policeStationId: "Required!",
            pendingArjiCategoryId: "Required!",
            under10days: {
                required: "required!",
                regex: "Numbers only.",
            },
            above10days: {
                required: "required!",
                regex: "Numbers only.",
            },
            aboveOneMonth: {
                required: "required!",
                regex: "Numbers only.",
            },
            aboveTwoMonth: {
                required: "required!",
                regex: "Numbers only.",
            },
            aboveThreeMonth: {
                required: "required!",
                regex: "Numbers only.",
            },
            aboveSixMonth: {
                required: "required!",
                regex: "Numbers only.",
            },
            createdDate: "Required!",
        },
        submitHandler: () => {
            var formData = new FormData(document.getElementById("form_PendingArjiDetail"));
            var payload = JSON.stringify(Object.fromEntries(formData));
            //console.log(payload);
            $.ajax({
                url: "/api/ApiPendingArjiDetails/Save",
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

                    $('#data_PendingArjiDetail').DataTable().ajax.reload();
                    $('#form_PendingArjiDetail').trigger("reset");
                    $('#basicModal').modal('hide');
                    swal("Successfully!", "Form has been submitted.", "success");
                },
            });
        },
    });
});