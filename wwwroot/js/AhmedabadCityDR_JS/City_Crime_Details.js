$(document).ready(() => {
    $("#searchButton").click(function () {
        $('#data_City_Crime_Details').DataTable().ajax.reload();
    });

    $('#data_City_Crime_Details').DataTable({
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
            url: "/api/ApiCityCrimeDetails/GetDetailsOfCrimes",
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
            { title: 'ગુનાની વિગત', data: 'subCategoryName', "width": "100px" },
            { title: 'કુલ બનાવ', data: 'total', "width": "80px" },
            { title: 'પોલીસ સ્‍ટેશન', data: 'policeStationName', "width": "600px" },
        ],
    });
});