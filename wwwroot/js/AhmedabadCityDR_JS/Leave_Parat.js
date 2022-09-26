function EditData(id) {
    $.ajax({
        url: "/api/ApiLeaveParat/GetById",
        type: "Get",
        dataType: "json",
        data: { "id": id },
        headers: {
            "Accept": "application/json",
            "Content-Type": "application/json",
        },
        success: function (response) {
            console.log(response.content);
            $('#form_LeaveParat').trigger("reset");
            $('#basicModal').modal('show');
            Populate('#form_LeaveParat', response.content);
        },
    });
}

$(document).ready(function () {

    $("#searchButton").click(function () {
        $('#data_LeaveParat').DataTable().ajax.reload();
    });

    $('#data_LeaveParat').DataTable({
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
            url: "/api/ApiLeaveParat/GetLeaveApplication",
            type: "Get",
            dataSrc: "content",
            dataType: "json",
            data: function (d) {
                d.fromDate = $('#searchFromDate').val();
                d.toDate = $('#searchToDate').val();
            },
            headers: {
                "Accept": "application/json",
                "Content-Type": "application/json",
            }
        },
        "columns": [
            { title: 'Police Station', data: 'policeStationName', "width": "100px" },
            { title: 'From Date', data: 'fromDate', "width": "100px" },
            { title: 'To Date', data: 'toDate', "width": "100px" },
            { title: 'Name', data: 'employeName', "width": "200px" },
            { title: 'Designation', data: 'designationName', "width": "100px" },
            { title: 'Leave Type', data: 'leaveTypeName', "width": "100px" },
            { title: 'Total Days', data: 'totalDays', "width": "300px" },
            { title: 'Remarks', data: 'remarks', "width": "300px" },
            {
                mRender: function (data, type, row) {
                    return '<button type="button" class="btn btn-success" onclick="EditData(' + row.leaveApplicationID + ')">Edit</button> ';
                },
                "width": "120px",
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

    $("#form_LeaveParat").validate({
        rules: {
            designationId: "required",
            tempPoliceStationId: "required",
            employeeId: "required",
            inchargeDesignationId: "required",
            tempInchargePoliceStationId: "required",
            inchargeEmployeeId: "required",
            leaveTypeId: "required",
            fromDate: "required",
            toDate: "required",
            totalDays: "required",
            remarks: "required",
        },
        messages: {
            designationId: "required",
            tempPoliceStationId: "required",
            employeeId: "required",
            inchargeDesignationId: "required",
            tempInchargePoliceStationId: "required",
            inchargeEmployeeId: "required",
            leaveTypeId: "required",
            fromDate: "required",
            toDate: "required",
            totalDays: "required",
            remarks: "required",
        },

        submitHandler: () => {
            var formData = new FormData(document.getElementById("form_LeaveParat"));
            var payload = JSON.stringify(Object.fromEntries(formData));
            console.log(payload);
            $.ajax({
                url: '/api/ApiLeaveParat/Save',
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
                    $('#data_LeaveParat').DataTable().ajax.reload();
                    $('#form_LeaveParat').trigger("reset");
                    $('#basicModal').modal('hide');
                    swal("Successfully!", "Form has been submitted.", "success");
                },
            });
        },
    });

    /* Get leave taking employye details */
    $.get("/api/ApiCommon/GetDesignation",
        function (data) {
            //console.log(data);
            $.each(data,
                function (index, row) {
                    //console.log(row);
                    $("#designationId").append("<option value='" + row.designationId + "'>" + row.designationName + "</option>");
                }
            );
        },
    );

    $("#designationId").change(
        function (e) {
            $("#tempPoliceStationId").empty();
            $.get("/api/ApiCommon/GetSector",
                { designationId: $("#designationId").val() },
                function (data) {

                    $("#tempPoliceStationId").append("<option selected disabled>--Select Sector/Zone/Division/PoliceStation:--</option>")

                    $.each(data, function (index, row) {
                        //console.log(row);
                        $("#tempPoliceStationId").append("<option value='" + row.value + "'>" + row.text + "</option>")
                    });
                },
            );
        }
    );

    $("#tempPoliceStationId").change(
        function (e) {
            $("#employeeId").empty();
            $.get("/api/ApiCommon/GetEmployee",
                { policeStationId: $("#tempPoliceStationId").val(), designationId: $("#designationId").val() },
                function (data) {

                    $("#employeeId").append("<option selected disabled>--Select Employee Name--</option>")
                    $.each(data, function (index, row) {
                        //console.log(row);
                        $("#employeeId").append("<option value='" + row.value + "'>" + row.text + "</option>")
                    });
                },
            );
        }
    );
    /* End get leave taking employye details */

    /* Sub employee details */
    $.get("/api/ApiCommon/GetInchargeDesignation",
        function (data) {
            $.each(data,
                function (index, row) {
                    //console.log(row);
                    $("#inchargeDesignationId").append("<option value='" + row.value + "'>" + row.text + "</option>");
                }
            );
        },
    );

    $("#inchargeDesignationId").change(
        function (e) {
            $("#tempInchargePoliceStationId").empty();
            $.get("/api/ApiCommon/GetInchargeSector",
                { inchargeDesignationId: $("#inchargeDesignationId").val() },
                function (data) {

                    $("#tempInchargePoliceStationId").append("<option selected disabled>--Select Sector/Zone/Division/PoliceStation:--</option>")

                    $.each(data, function (index, row) {
                        //console.log(row);
                        $("#tempInchargePoliceStationId").append("<option value='" + row.value + "'>" + row.text + "</option>")
                    });
                },
            );
        }
    );

    $("#tempInchargePoliceStationId").change(
        function (e) {
            $("#inchargeEmployeeId").empty();
            $.get("/api/ApiCommon/GetInchargeEmployee",
                { inchargePoliceStationId: $("#tempInchargePoliceStationId").val(), inchargeDesignationId: $("#inchargeDesignationId").val() },
                function (data) {
                    $("#inchargeEmployeeId").append("<option selected disabled>--Select Employee Name--</option>")
                    $.each(data, function (index, row) {
                        //console.log(row);
                        $("#inchargeEmployeeId").append("<option value='" + row.value + "'>" + row.text + "</option>")
                    });
                },
            );
        }
    );
    /* End Sub employee details */

    /* Populate drop down Leave type */
    $.get("/api/ApiCommon/GetLeaveType",
        function (data) {
            $.each(data,
                function (index, row) {
                    //console.log(row);
                    $("#leaveTypeId").append("<option value='" + row.value + "'>" + row.text + "</option>");
                }
            );
        },
    );
    /* End Populate drop down Leave type */
});