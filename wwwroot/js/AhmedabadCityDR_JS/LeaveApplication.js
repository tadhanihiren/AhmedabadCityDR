$(document).ready(function () {

    $("#searchButton").click(function () {
        $('#data_LeaveApplication').DataTable().ajax.reload();
    });

    $('#data_LeaveApplication').DataTable({
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
            url: "/api/ApiLeaveApplicationMaster/GetLeaveApplication",
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
            { title: 'Designation', data: 'designationName', "width": "100px" },
            { title: 'Employee Name', data: 'employeName', "width": "200px" },
            { title: 'Incharge PoliceStation', data: 'inchrgePoliceStationName', "width": "200px" },
            { title: 'Incharge Designtion', data: 'inchargeDesignationName', "width": "200px" },
            { title: 'Incharge EmployeeName', data: 'inchargeEmployeName', "width": "200px" },
            { title: 'Leave Type', data: 'leaveTypeName', "width": "100px" },
            { title: 'Total Days', data: 'totalDays', "width": "300px" },
            { title: 'Remarks', data: 'remarks', "width": "300px" },
        ],
    });

    $.validator.addMethod(
        "regex",
        function (value, element, regexp) {
            return this.optional(element) || regexp.test(value);
        },
        "Please check your input."
    );

    $("#form_LeaveApplication").validate({
        rules: {
            designationId: "required",
            tempSZDPId: "required",
            employeeId: "required",
            inchargeDesignationId: "required",
            tempInchargeSectorId: "required",
            inchargeEmployeeId: "required",
            leaveTypeId: "required",
            fromDate: "required",
            toDate: "required",
            totalDays: "required",
            remarks: "required",
        },
        messages: {
            designationId: "required",
            tempSZDPId: "required",
            employeeId: "required",
            inchargeDesignationId: "required",
            tempInchargeSectorId: "required",
            inchargeEmployeeId: "required",
            leaveTypeId: "required",
            fromDate: "required",
            toDate: "required",
            totalDays: "required",
            remarks: "required",
        },

        submitHandler: () => {
            var formData = new FormData(document.getElementById("form_LeaveApplication"));
            var payload = JSON.stringify(Object.fromEntries(formData));
            console.log(payload);
            $.ajax({
                url: '/api/ApiLeaveApplicationMaster/Save',
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
                    $('#data_LeaveApplication').DataTable().ajax.reload();
                    $('#form_LeaveApplication').trigger("reset");
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
            $("#tempSZDPId").empty();
            $.get("/api/ApiCommon/GetSector",
                { designationId: $("#designationId").val() },
                function (data) {

                    $("#tempSZDPId").append("<option selected disabled>--Select Sector/Zone/Division/PoliceStation:--</option>")

                    $.each(data, function (index, row) {
                        //console.log(row);
                        $("#tempSZDPId").append("<option value='" + row.value + "'>" + row.text + "</option>")
                    });
                },
            );
        }
    );

    $("#tempSZDPId").change(
        function (e) {
            $("#employeeId").empty();
            $.get("/api/ApiCommon/GetEmployee",
                { policeStationId: $("#tempSZDPId").val(), designationId: $("#designationId").val() },
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
            $("#tempInchargeSectorId").empty();
            $.get("/api/ApiCommon/GetInchargeSector",
                { inchargeDesignationId: $("#inchargeDesignationId").val() },
                function (data) {

                    $("#tempInchargeSectorId").append("<option selected disabled>--Select Sector/Zone/Division/PoliceStation:--</option>")

                    $.each(data, function (index, row) {
                        //console.log(row);
                        $("#tempInchargeSectorId").append("<option value='" + row.value + "'>" + row.text + "</option>")
                    });
                },
            );
        }
    );

    $("#tempInchargeSectorId").change(
        function (e) {
            $("#inchargeEmployeeId").empty();
            $.get("/api/ApiCommon/GetInchargeEmployee",
                { inchargePoliceStationId: $("#tempInchargeSectorId").val(), inchargeDesignationId: $("#inchargeDesignationId").val() },
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