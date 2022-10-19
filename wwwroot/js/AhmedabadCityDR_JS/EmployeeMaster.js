function EditData(id) {
    $("#submitbtn").html('Save અધિકારી/કર્મચારી'); //Change button value to Save
    $.ajax({
        url: "/api/ApiEmployeeMaster/GetById",
        type: "Get",
        dataType: "json",
        data: { "id": id },
        headers: {
            "Accept": "application/json",
            "Content-Type": "application/json",
        },
        success: function (response) {
            var data = response.content;
            //console.log(data);
            $('#form_Employee_Details').trigger("reset");
            $('#basicModal').modal('show');

            var designationId = parseInt(data.designationId);

            $('#designationId').val(designationId);

            if (designationId > 1) {
                //console.log(designationId);
                $.get("/api/ApiCommon/GetCitySector",
                    { designationId: designationId },
                    function (data) {
                        $("#policeStationId").empty();
                        $("#policeStationId").append("<option selected disabled>--Select PoliceStation:--</option>");
                        //console.log(data);
                        $.each(data, function (index, row) {
                            $("#policeStationId").append("<option value='" + row.value + "'>" + row.text + "</option>")
                        });
                    });

                if (designationId == 2 || designationId == 15) {
                    $("#policeStationId").val(data.sectorId);
                }

                if (designationId == 3) {
                    $("#policeStationId").val(data.zoneId);
                }

                if (designationId == 4) {
                    $("#policeStationId").val(data.divisionId);
                }

                if (designationId >= 5 || designationId != 15) {
                    $("#policeStationId").val(data.policeStationId);
                }
            }

            Populate('#form_Employee_Details', data);
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
                url: "/api/ApiEmployeeMaster/Delete",
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

                    $('#data_Employee_Details').DataTable().ajax.reload();
                    swal("Successfully!", "Record has been deleted.", "success");
                },
            });

        }
    })
}

$(document).ready(() => {

    $("#addData").click(() => {
        $('#form_Employee_Details').trigger('reset');
        $("#submitbtn").html('+ ADD અધિકારી/કર્મચારી'); //Change button value to add
    });

    $("#searchButton").click(function () {
        $('#data_Employee_Details').DataTable().ajax.reload();
    });

    $('#data_Employee_Details').DataTable({
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
            url: "/api/ApiEmployeeMaster/Get",
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
            { title: 'પોલીસ સ્ટેશન', data: 'policeStationName', "width": "80px" },
            { title: 'હોદ્દો', data: 'designationName', "width": "40px" },
            { title: 'બકલ નં.', data: 'buckleNo', "width": "50px" },
            { title: 'અધિકારીનું નામ', data: 'employeName', "width": "100px" },
            { title: 'સંપર્ક નંબર', data: 'contactNumber', "width": "70px" },
            { title: 'પ્રતિનિયુક્ત નામ', data: 'prtiniyukatName', "width": "100px" },
            { title: 'From date', data: 'fromdate', "width": "70px" },
            { title: 'To date', data: 'todate', "width": "60px" },
            { title: 'પ્રતિનિયુક્ત જગ્યા', data: 'prtiniyukatPlace', "width": "100px" },
            { title: 'તારીખ', data: 'createdDate', "width": "70px" },
            {
                mRender: function (data, type, row) {
                    var bEdit = '<button type="button" class="btn btn-success" onclick="EditData(' + row.employeeId + ')">Edit</button> ';
                    var bDelete = ' <button type="button" class="btn btn-danger" onclick="DeleteData(' + row.employeeId + ')">Delete</button>';
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

    $("#form_Employee_Details").validate({
        rules: {
            designationId: "required",
            policeStationId: "required",
            buckleNo: "required",
            employeName: "required",
            contactNumber: {
                required: true,
                regex: /^(?:(?:\+|0{0,2})91(\s*[\-]\s*)?|[0]?)?[6789]\d{9}$/,
            },
            createdDate: "required",
        },
        messages: {
            designationId: "Required!",
            policeStationId: "Required!",
            buckleNo: "Required!",
            employeName: "Required!",
            contactNumber: {
                required: "Required!",
                regex: "Provide Valid contactNo"
            },
            createdDate: "Required!",
        },
        submitHandler: () => {
            var formData = new FormData(document.getElementById("form_Employee_Details"));
            var payload = JSON.stringify(Object.fromEntries(formData));
            console.log(payload);
            $.ajax({
                url: "/api/ApiEmployeeMaster/Save",
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

                    $('#data_Employee_Details').DataTable().ajax.reload();
                    $('#form_Employee_Details').trigger("reset");
                    $('#basicModal').modal('hide');
                    swal("Successfully!", "Form has been submitted.", "success");
                },
            });
        },
    });

    $.get("/api/ApiCommon/GetDesignation",
        function (data) {
            //console.log(data);
            $("#designationId").empty();
            $("#designationId").append("<option selected disabled>--Select DesignationName--</option>");
            $.each(data, function (index, row) {
                $("#designationId").append("<option value='" + row.designationId + "'>" + row.designationName + "</option>")
            });
        });

    $("#designationId").change(function (e) {
        $("#policeStationId").empty(),
            $.get("/api/ApiCommon/GetCitySector",
                { designationId: $("#designationId").val() },
                function (data) {
                    $("#policeStationId").append("<option selected disabled>--Select PoliceStation:--</option>")
                    //console.log(data);
                    $.each(data, function (index, row) {
                        $("#policeStationId").append("<option value='" + row.value + "'>" + row.text + "</option>")
                    });
                });
    });
});