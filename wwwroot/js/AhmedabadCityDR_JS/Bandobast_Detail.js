$(document).ready(function () {

    PopulateSearchPoliceStationDRD();

    $('#data_Bandobast_Detail').DataTable({
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
            url: "/api/ApiBandobastDetailMaster/Get",
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
            { title: 'પોલીસ સ્ટેશન', data: 'policeStationName', "width": "100px" },
            { title: 'તારીખ', data: 'createdDate', "width": "100px" },
            { title: 'ઝોન', data: 'zoneName', "width": "100px" },
            { title: 'ડી.વી.જ.ન', data: 'divisionName', "width": "100px" },
            { title: 'બંદોબસ્તનું સ્થળ તથા રાખેલ પોઈન્ટની સંખ્યા', data: 'bandoBastPlace', "width": "200px" },
            { title: 'બંદોબસ્તનો પ્રકાર', data: 'bandobastTypeId', "width": "150px" },
            { title: 'આપેલ બંદોબસ્તની વિગત /ફોર્સની સંખ્યા', data: 'bandobastDetailForceNumber', "width": "150px" },
            { title: 'ટૂંક વિગત', data: 'shortDetail', "width": "100px" },
           {
                mRender: function (data, type, row) {
                    var bEdit = '<button type="button" class="btn btn-success" onclick="editData(' + row.nightRoundId + ')">Edit</button> ';
                    var bDelete = '<button type="button" class="btn btn-danger" onclick="deleteData(' + row.nightRoundId + ')">Delete</button>';
                    return bEdit + bDelete;
                },
                "width": "120px",
            },
        ],
    });


});

$("#zoneId").change(function (e) {
    $("#divisionId").empty(),
        $.get("/api/ApiCommon/GetDivision", { zoneId: $("#zoneId").val() },
            function (data) {
                $("#divisionId").append("<option selected disabled>--Select Division:--</option>")
                console.log(data);
                $.each(data, function (index, row) {
                    $("#divisionId").append("<option value='" + row.value + "'>" + row.text + "</option>")
                });
            });
});

$("#divisionId").change(function (e) {
    $("#policestationId").empty(),
        $.get("/api/ApiCommon/GetPoliceStation_For_BandobastDetails", { divisionId: $("#divisionId").val() },
            function (data) {
                $("#policestationId").append("<option selected disabled>--Select Policestation:--</option>")
                console.log(data);
                $.each(data, function (index, row) {
                    $("#policestationId").append("<option value='" + row.value + "'>" + row.text + "</option>")
                });
            });
});