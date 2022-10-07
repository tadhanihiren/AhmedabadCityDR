function EditData(id) {
    $("#submitbtn").html('Save વાહનોની હકિકત દર્શાવતુ પત્રક'); //Change button value to Save
    $.ajax({
        url: "/api/APIPoliceStationWiseVehicalMastre/GetById",
        type: "Get",
        dataType: "json",
        data: { "id": id },
        headers: {
            "Accept": "application/json",
            "Content-Type": "application/json",
        },
        success: function (response) {
            /*console.log(response.content);*/
            $('#form_PoliceStationWiseVehical').trigger("reset");
            $('#basicModal').modal('show');
            Populate('#form_PoliceStationWiseVehical', response.content);
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
                url: "/api/APIPoliceStationWiseVehicalMastre/Delete",
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

                    $('#data_PoliceStationWiseVehical').DataTable().ajax.reload();
                    swal("Successfully!", "Record has been deleted.", "success");
                },
            });

        }
    })
}

$(document).ready(() => {

    PopulateSearchPoliceStationDRD();

    $("#addData").click(() => {
        $('#form_PoliceStationWiseVehical').trigger('reset');
        $("#submitbtn").html('+ ADD વાહનોની હકિકત દર્શાવતુ પત્રક'); //Change button value to add
    });

    $("#searchButton").click(function () {
        $('#data_PoliceStationWiseVehical').DataTable().ajax.reload();
    });

    $('#data_PoliceStationWiseVehical').DataTable({
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
            url: "/api/APIPoliceStationWiseVehicalMastre/Get",
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
            { title: 'કુલ જીપો', data: 'jeeps_Total', "width": "100px" },
            { title: 'કેટલી ઓફરોડ જીપો', data: 'jeeps_OFFroad', "width": "100px" },
            { title: 'કઇ તારીખથી', data: 'jeeps_date', "width": "100px" },
            { title: 'કુલ મોબાઇલ', data: 'mobile_total', "width": "100px" },
            { title: 'કેટલી ઓફરોડ મોબાઇલ', data: 'mobile_offroad', "width": "100px" },
            { title: 'કઇ તારીખથી', data: 'mobile_date', "width": "100px" },
            { title: 'કુલ સાયકલો', data: 'cycling_total', "width": "100px" },
            { title: 'કેટલી ઓફરોડ સાયકલો', data: 'cycling_offroad', "width": "100px" },
            { title: 'કઇ તારીખથી', data: 'cycling_date', "width": "100px" },
            {
                mRender: function (data, type, row) {
                    var bEdit = '<button type="button" class="btn btn-success" onclick="EditData(' + row.policeStationwiseVehicalId + ')">Edit</button> ';
                    var bDelete = ' <button type="button" class="btn btn-danger" onclick="DeleteData(' + row.policeStationwiseVehicalId + ')">Delete</button>';
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

    $("#form_PoliceStationWiseVehical").validate({
        rules: {
            policeStationId: "required",
            createdDate: "required",
            jeepsTotal: {
                required: true,
                regex: /^[0-9]*$/,
            },
            jeepsOffroad: {
                required: true,
                regex: /^[0-9]*$/,
            },
            jeepsDate: "required",
            mobileTotal: {
                required: true,
                regex: /^[0-9]*$/,
            },
            mobileOffroad: {
                required: true,
                regex: /^[0-9]*$/,
            },
            mobileDate: "required",
            cyclingTotal: {
                required: true,
                regex: /^[0-9]*$/,
            },
            cyclingOffroad: {
                required: true,
                regex: /^[0-9]*$/,
            },
            cyclingDate: "required",
        },
        messages: {
            policeStationId: "Required!",
            createdDate: "Required!",
            jeepsTotal: {
                required: "required!",
                regex: "Numbers only.",
            },
            jeepsOffroad: {
                required: "required!",
                regex: "Numbers only.",
            },
            jeepsDate: "Required!",
            mobileTotal: {
                required: "required!",
                regex: "Numbers only.",
            },
            mobileOffroad: {
                required: "required!",
                regex: "Numbers only.",
            },
            mobileDate: "Required!",
            cyclingTotal: {
                required: "required!",
                regex: "Numbers only.",
            },
            cyclingOffroad: {
                required: "required!",
                regex: "Numbers only.",
            },
            cyclingDate: "Required!",
        },
        submitHandler: () => {
            var formData = new FormData(document.getElementById("form_PoliceStationWiseVehical"));
            var payload = JSON.stringify(Object.fromEntries(formData));
            //console.log(payload);
            $.ajax({
                url: "/api/APIPoliceStationWiseVehicalMastre/Save",
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

                    $('#data_PoliceStationWiseVehical').DataTable().ajax.reload();
                    $('#form_PoliceStationWiseVehical').trigger("reset");
                    $('#basicModal').modal('hide');
                    swal("Successfully!", "Form has been submitted.", "success");
                },
            });
        },
    });
});