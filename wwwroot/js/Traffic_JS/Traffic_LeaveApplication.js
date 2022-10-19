$(document).ready(function () {


    $('#data_Traffic_LeaveApplication').DataTable({
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
            url: "/api/ApiTrafficLeaveApplicationMasters/GetTrafficLeaveApplication",
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

});