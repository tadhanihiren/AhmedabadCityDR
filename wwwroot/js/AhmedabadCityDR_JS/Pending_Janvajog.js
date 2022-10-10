function EditData(id) {
    $("#submitbtn").html('Save પો.સ્ટે વાઈઝ પેન્ડીંગ'); //Change button value to Save
    $.ajax({
        url: "/api/ApiPendingJanvaJog/GetById",
        type: "Get",
        dataType: "json",
        data: { "id": id },
        headers: {
            "Accept": "application/json",
            "Content-Type": "application/json",
        },
        success: function (response) {
            /*console.log(response.content);*/
            $('#form_PendingJanvaJog').trigger("reset");
            $('#basicModal').modal('show');
            Populate('#form_PendingJanvaJog', response.content);
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
                url: "/api/ApiPendingJanvaJog/Delete",
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

                    $('#data_PendingJanvaJog').DataTable().ajax.reload();
                    swal("Successfully!", "Record has been deleted.", "success");
                },
            });

        }
    })
}

$(document).ready(() => {

    PopulateSearchPoliceStationDRD();

    $("#addData").click(() => {
        $('#form_PendingJanvaJog').trigger('reset');
        $("#submitbtn").html('+ ADD પો.સ્ટે વાઈઝ પેન્ડીંગ'); //Change button value to add
    });

    $("#searchButton").click(function () {
        $('#data_PendingJanvaJog').DataTable().ajax.reload();
    });

    $('#data_PendingJanvaJog').DataTable({
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
            url: "/api/ApiPendingJanvaJog/Get",
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
            { title: 'તારીખ', data: 'createdDate', "width": "100px" },
            { title: 'એક માસ અંદરની', data: 'oneMonthUnder', "width": "100px" },
            { title: 'એક માસ ઉપરની', data: 'oneMonthAbove', "width": "100px" },
            { title: 'બે માસ ઉપરની', data: 'twoMonthAbove', "width": "100px" },
            { title: 'ત્રણ માસ ઉપરની', data: 'threeMonthAbove', "width": "100px" },
            { title: 'છ માસ ઉપરની', data: 'sixMonthAbove', "width": "100px" },
            { title: '૧ વર્ષ તથા તેનાથી ઉપરની તમામ', data: 'oneYearAndAbove', "width": "100px" },
            {
                mRender: function (data, type, row) {
                    var bEdit = '<button type="button" class="btn btn-success" onclick="EditData(' + row.pendingJanvaJog + ')">Edit</button> ';
                    var bDelete = ' <button type="button" class="btn btn-danger" onclick="DeleteData(' + row.pendingJanvaJog + ')">Delete</button>';
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

    $("#form_PendingJanvaJog").validate({
        rules: {
            policeStationId: "required",
            createdDate: "required",
            oneMonthAbove: {
                required: true,
                regex: /^[0-9]*$/,
            },
            oneMonthUnder: {
                required: true,
                regex: /^[0-9]*$/,
            },
            twoMonthAbove: {
                required: true,
                regex: /^[0-9]*$/,
            },
            threeMonthAbove: {
                required: true,
                regex: /^[0-9]*$/,
            },
            sixMonthAbove: {
                required: true,
                regex: /^[0-9]*$/,
            },
            oneYearAndAbove: {
                required: true,
                regex: /^[0-9]*$/,
            },
        },
        messages: {
            policeStationId: "Required!",
            createdDate: "Required!",
            oneMonthAbove: {
                required: "required",
                regex: "Numbers only.",
            },
            oneMonthUnder: {
                required: "required",
                regex: "Numbers only.",
            },
            twoMonthAbove: {
                required: "required",
                regex: "Numbers only.",
            },
            threeMonthAbove: {
                required: "required",
                regex: "Numbers only.",
            },
            sixMonthAbove: {
                required: "required",
                regex: "Numbers only.",
            },
            oneYearAndAbove: {
                required: "required",
                regex: "Numbers only.",
            },
        },
        submitHandler: () => {
            var formData = new FormData(document.getElementById("form_PendingJanvaJog"));
            var payload = JSON.stringify(Object.fromEntries(formData));
            //console.log(payload);
            $.ajax({
                url: "/api/ApiPendingJanvaJog/Save",
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

                    $('#data_PendingJanvaJog').DataTable().ajax.reload();
                    $('#form_PendingJanvaJog').trigger("reset");
                    $('#basicModal').modal('hide');
                    swal("Successfully!", "Form has been submitted.", "success");
                },
            });
        },
    });
});