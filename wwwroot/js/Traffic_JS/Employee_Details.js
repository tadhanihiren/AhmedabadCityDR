$(document).ready(function () {

    PopulateSearchTrafficPoliceStationDRD();

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
            url: "/api/ApiTrafficEmployeeMaster/Get",
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
            { title: 'પો.સ્ટે', data: 'policeStationName', "width": "75px" },
            { title: 'હોદ્દો', data: 'designationName', "width": "40px" },
            { title: 'બકલ નં.', data: 'buckleNo', "width": "50px" },
            { title: 'અધિકારીનું નામ', data: 'employeName', "width": "100px" },
            { title: 'સંપર્ક નંબર', data: 'contactNumber', "width": "60px" },
            { title: 'પ્રતિનિયુક્ત નામ', data: 'prtiniyukatName', "width": "100px" },
            { title: 'fromdate', data: 'fromdate', "width": "70px" },
            { title: 'todate', data: 'todate', "width": "70px" },
            { title: 'પ્રતિનિયુક્ત જગ્યા', data: 'prtiniyukatPlace', "width": "100px" },
            { title: 'તારીખ', data: 'createdDate', "width": "70px" },

            {
                mRender: function (data, type, row) {
                    var bEdit = '<button type="button" class="btn btn-success" onclick="editData(' + row.accusedInformationId + ')">Edit</button> ';
                    var bDelete = '<button type="button" class="btn btn-danger" onclick="deleteData(' + row.accusedInformationId + ')">Delete</button>';
                    return bEdit + bDelete;
                },
                "width": "120px",
            },

        ],
    });

});