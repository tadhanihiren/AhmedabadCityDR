function EditData(id) {
    $("#submitbtn").html('Save ઑટોરિક્ષાની માહિતી'); //Change button value to Save
    $.ajax({
        url: "/api/ApiAutoRickshawDetailsMaster/GetById",
        type: "Get",
        dataType: "json",
        data: { "id": id },
        headers: {
            "Accept": "application/json",
            "Content-Type": "application/json",
        },
        success: function (response) {
            /*console.log(response.content);*/
            $('#form_AutoRickshawDetail').trigger("reset");
            $('#basicModal').modal('show');
            Populate('#form_AutoRickshawDetail', response.content);
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
                url: "/api/ApiAutoRickshawDetailsMaster/Delete",
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

                    $('#data_AutoRickshawDetail').DataTable().ajax.reload();
                    swal("Successfully!", "Record has been deleted.", "success");
                },
            });

        }
    })
}

$(document).ready(() => {

    PopulateSearchPoliceStationDRD();

    $("#addData").click(() => {
        $('#form_AutoRickshawDetail').trigger('reset');
        $("#submitbtn").html('+ ADD ઑટોરિક્ષાની માહિતી'); //Change button value to add
    });

    $("#searchButton").click(function () {
        $('#data_AutoRickshawDetail').DataTable().ajax.reload();
    });

    $('#data_AutoRickshawDetail').DataTable({
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
            url: "/api/ApiAutoRickshawDetailsMaster/Get",
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
            { title: 'ઓટો રિક્ષા નંબર', data: 'autoRickshawNo', "width": "100px" },
            { title: 'ડ્રાયવરનુ નામ સરનામુ', data: 'driverName', "width": "200px" },
            { title: 'માલિક્નુ નામ સરનામુ', data: 'ownerName', "width": "200px" },
            { title: 'લાયસન્સ નંબર', data: 'licenseNumber', "width": "100px" },
            { title: 'પરમીટ નંબર', data: 'permitNumber', "width": "100px" },
            { title: 'ચાલકનો બેઝ નંબર', data: 'driversBaseNo', "width": "100px" },
            { title: 'આર સી બુક છે કે કેમ', data: 'rcBook', "width": "100px" },
            { title: 'આર સી બુક મુજ્બ એ.નં ચે નં છે કે કેમ', data: 'rcBook_Detail', "width": "100px" },
            { title: 'વીમા પોલીસી છે કે કેમ', data: 'insurancePolicy', "width": "100px" },
            { title: 'ચેકીઁગ દરમ્યાન કામગીરી', data: 'checkingOperation', "width": "100px" },
            {
                mRender: function (data, type, row) {
                    var bEdit = '<button type="button" class="btn btn-success" onclick="EditData(' + row.autoRickshawId + ')">Edit</button> ';
                    var bDelete = ' <button type="button" class="btn btn-danger" onclick="DeleteData(' + row.autoRickshawId + ')">Delete</button>';
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

    $("#form_AutoRickshawDetail").validate({
        rules: {
            policeStationId: "required",
            createdDate: "required",
            autoRickshawNo: "required",
            driverName: "required",
            ownerName: "required",
            licenseNumber: {
                required: true,
                regex: /^[0-9]*$/,
            },
            permitNumber: {
                required: true,
                regex: /^[0-9]*$/,
            },
            driversBaseNo: {
                required: true,
                regex: /^[0-9]*$/,
            },
            rcBook: {
                required: true,
                regex: /^[0-9]*$/,
            },
            rcBook_Detail: {
                required: true,
                regex: /^[0-9]*$/,
            },
            insurancePolicy: {
                required: true,
                regex: /^[0-9]*$/,
            },
            checkingOperation: {
                required: true,
                regex: /^[0-9]*$/,
            },
        },
        messages: {
            policeStationId: "Required!",
            createdDate: "Required!",
            autoRickshawNo: "Required!",
            driverName: "Required!",
            ownerName: "Required!",
            licenseNumber: {
                required: "required",
                regex: "Numbers only.",
            },
            permitNumber: {
                required: "required",
                regex: "Numbers only.",
            },
            driversBaseNo: {
                required: "required",
                regex: "Numbers only.",
            },
            rcBook: {
                required: "required",
                regex: "Numbers only.",
            },
            rcBook_Detail: {
                required: "required",
                regex: "Numbers only.",
            },
            insurancePolicy: {
                required: "required",
                regex: "Numbers only.",
            },
            checkingOperation: {
                required: "required",
                regex: "Numbers only.",
            },
        },
        submitHandler: () => {
            var formData = new FormData(document.getElementById("form_AutoRickshawDetail"));
            var payload = JSON.stringify(Object.fromEntries(formData));
            console.log(payload);
            $.ajax({
                url: "/api/ApiAutoRickshawDetailsMaster/Save",
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

                    $('#data_AutoRickshawDetail').DataTable().ajax.reload();
                    $('#form_AutoRickshawDetail').trigger("reset");
                    $('#basicModal').modal('hide');
                    swal("Successfully!", "Form has been submitted.", "success");
                },
            });
        },
    });
});