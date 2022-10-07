
function editData(id) {
    $("#submitbtn").html('+Save ક્રાઇમ બ્રાન્ચ ની વીઝીટ'); //Change button value to Save
    $.ajax({
        url: "/api/ApiVisitation_CrimeBranch/GetById",
        type: "Get",
        dataType: "json",
        data: { "id": id },
        headers: {
            "Accept": "application/json",
            "Content-Type": "application/json",
        },
        success: function (response) {
            console.log(response.content);
            console.log(id);
            $('#form_CrimeBranch_Visit').trigger("reset");
            $('#data_CrimeBranch_Visit').DataTable().ajax.reload();
            $('#basicModal').modal('show');
            Populate('#form_CrimeBranch_Visit', response.content);
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
                url: "/api/ApiVisitation_CrimeBranch/Delete",
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

                    $('#data_CrimeBranch_Visit').DataTable().ajax.reload();
                    swal("Successfully!", "Record has been deleted.", "success");
                },
            });

        }
    })
}

$(document).ready(function () {

    PopulateSearchPoliceStationDRD();

    $("#addData").click(() => {
        $('#form_CrimeBranch_Visit').trigger('reset');
        $("#submitbtn").html('+ ADD ક્રાઇમ બ્રાન્ચ ની વીઝીટ '); //Change button value to add
    });

    $("#searchButton").click(function () {
        $('#data_CrimeBranch_Visit').DataTable().ajax.reload();
    });


    $.validator.addMethod(
        "regex",
        function (value, element, regexp) {
            return this.optional(element) || regexp.test(value);
        },
        "Please check your input."
    );

    $('#data_CrimeBranch_Visit').DataTable({
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
            url: "/api/ApiVisitation_CrimeBranch/Get",
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
            { title: 'VisitationId', data: 'visitationId', "width": "100px" },
            { title: 'પો.સ્ટે', data: 'policeStationName', "width": "150px" },
            { title: 'તારીખ', data: 'createdDate', "width": "100px" },
            { title: 'ગુ.બ.તા.ટા તથા ગુનાની જગ્‍યા', data: 'gubatatA_CrimePlace', "width": "100px" },
            { title: 'ગુનાનુ વીઝીટનુ સ્‍થળ', data: 'crimeVisitPlace', "width": "100px" },
            { title: 'વીઝીટ કર્યાની તા.ટા', data: 'visitDate', "width": "100px" },
            { title: 'વીઝીટ કરનાર અઘિકારી', data: 'visiter_OfficerName', "width": "100px" },
            {
                mRender: function (data, type, row) {
                    var bEdit = '<button type="button" class="btn btn-success" onclick="editData(' + row.visitationId + ')">Edit</button> ';
                    var bDelete = '<button type="button" class="btn btn-danger" onclick="deleteData(' + row.visitationId + ')">Delete</button>';
                    return bEdit + bDelete;
                },
                "width": "120px",
            },

        ],
    });


    $("#form_CrimeBranch_Visit").validate({
        rules: {
            policeStationId: "required",
            createdDate: "required",
            gubatataCrimePlace: "required",
            crimeVisitPlace: "required",
            visitDate: "required",
            visiterOfficerName: "required",

        },
        messages: {
            policeStationId: "required",
            createdDate: "required",
            gubatataCrimePlace: "required",
            crimeVisitPlace: "required",
            visitDate: "required",
            visiterOfficerName: "required",
        },

        submitHandler: () => {
            var formData = new FormData(document.getElementById("form_CrimeBranch_Visit"));
            var payload = JSON.stringify(Object.fromEntries(formData));
            console.log(payload);
            debugger
            $.ajax({
                url: '/api/ApiVisitation_CrimeBranch/Save',
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
                    $('#form_CrimeBranch_Visit').trigger("reset");
                    $('#data_CrimeBranch_Visit').DataTable().ajax.reload();
                    $('#basicModal').modal('hide');
                    swal("Successfully!", "Form has been submitted.", "success");
                },
            });
        },
    });
});