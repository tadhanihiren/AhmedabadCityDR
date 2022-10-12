function editData(id) {
    $("#submitbtn").html('Save પોલીસ સ્ટેશન બાકી અરજી'); //Change button value to add
    console.log(id);
    $.ajax({
        url: "/api/ApiPoliceStationWisePendingApplication/GetById",
        type: "Get",
        dataType: "json",
        data: { "id": id },
        headers: {
            "Accept": "application/json",
            "Content-Type": "application/json",
        },
        success: function (response) {
            console.log(response.content);
            $('#form_PoliceStationWisePendingApplication').trigger("reset");
            $('#basicModal').modal('show');
            Populate('#form_PoliceStationWisePendingApplication', response.content);
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
                url: "/api/ApiPoliceStationWisePendingApplication/Delete",
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

                    $('#data_PoliceStationWisePendingApplication').DataTable().ajax.reload();
                    swal("Successfully!", "Record has been deleted.", "success");
                },
            });

        }
    })
}
$(document).ready(function () {

    PopulateSearchPoliceStationDRD();

    $("#addData").click(() => {
        $('#form_PoliceStationWisePendingApplication').trigger('reset');
        $("#submitbtn").html('+ Add પોલીસ સ્ટેશન બાકી અરજી '); //Change button value to add
    });

    $("#searchButton").click(function () {
        $('#data_PoliceStationWisePendingApplication').DataTable().ajax.reload();
    });

    $.validator.addMethod(
        "regex",
        function (value, element, regexp) {
            return this.optional(element) || regexp.test(value);
        },
        "Please check your input."
    );

    $('#data_PoliceStationWisePendingApplication').DataTable({
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
            url: "/api/ApiPoliceStationWisePendingApplication/Get",
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
            { title: 'કચેરી', data: 'kacheriName', "width": "100px" },
            { title: 'પો.સ્ટે', data: 'policeStationName', "width": "100px" },
            { title: 'તારીખ', data: 'createdDate', "width": "100px" },
            { title: '૧૦ દિવસ અંદરની', data: 'tenDaysBelow', "width": "150px" },
            { title: '૧૦ દિવસ ઉપરની', data: 'tenDaysAbove', "width": "150px" },
            { title: 'એક માસ ઉપરની', data: 'oneMonthAbove', "width": "150px" },
            { title: 'બે માસ ઉપરની', data: 'twoMonthAbove', "width": "150px" },
            { title: 'ત્રણ માસ ઉપરની', data: 'threeMonthAbove', "width": "150px" },
            { title: 'છ માસ ઉપરની', data: 'sixMonthAbove', "width": "150px" },
            { title: '૧ વર્ષ તથા તેનાથી ઉપરની તમામ', data: 'oneYearAndAbove', "width": "150px" },

            {
                mRender: function (data, type, row) {
                    var bEdit = '<button type="button" class="btn btn-success" onclick="editData(' + row.policeStationWisePendingApplicationId + ')">Edit</button> ';
                    var bDelete = '<button type="button" class="btn btn-danger" onclick="deleteData(' + row.policeStationWisePendingApplicationId + ')">Delete</button>';
                    return bEdit + bDelete;
                },
                "width": "120px",
            },

        ],
    });
    $("#form_PoliceStationWisePendingApplication").validate({

        rules: {
            policeStationId: "required",
            createdDate: "required",
            kacheriId: "required",
            tenDaysBelow: {
                required: true,
                regex: /^[0-9]*$/,
            },
            tenDaysAbove: {
                required: true,
                regex: /^[0-9]*$/,
            },
            oneMonthAbove: {
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
            policeStationId: "required",
            createdDate: "required",
            kacheriId: "required",
            tenDaysBelow: {
                required: "required",
                regex: "Numbers only.",
            },
            tenDaysAbove: {
                required: "required",
                regex: "Numbers only.",
            },
            oneMonthAbove: {
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
            var formData = new FormData(document.getElementById("form_PoliceStationWisePendingApplication"));
            var payload = JSON.stringify(Object.fromEntries(formData));
            console.log(payload);
            $.ajax({
                url: '/api/ApiPoliceStationWisePendingApplication/Save',
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
                    $('#form_PoliceStationWisePendingApplication').trigger("reset");
                    $('#data_PoliceStationWisePendingApplication').DataTable().ajax.reload();
                    $('#basicModal').modal('hide');
                    swal("Successfully!", "Form has been submitted.", "success");
                },
            });
        },
    });
});