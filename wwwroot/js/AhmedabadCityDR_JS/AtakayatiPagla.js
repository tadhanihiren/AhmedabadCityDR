function EditData(id) {
    $("#submitbtn").html('Save અટકાયતી પગલાની વિગત'); //Change button value to add
    $.ajax({
        url: "/api/ApiAtakayatiPagla/GetById",
        type: "Get",
        dataType: "json",
        data: { "id": id },
        headers: {
            "Accept": "application/json",
            "Content-Type": "application/json",
        },
        success: function (response) {
            console.log(response.content);
            $('#form_AtakayatiPagala').trigger("reset");
            $('#basicModal').modal('show');
            Populate('#form_AtakayatiPagala', response.content);
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
                url: "/api/ApiAtakayatiPagla/Delete",
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

                    $('#data_AtakayatiPagla').DataTable().ajax.reload();
                    swal("Successfully!", "Record has been deleted.", "success");
                },
            });

        }
    })
}

$().ready(() => {

    PopulateSearchPoliceStationDRD();

    $("#addData").click(() => {
        $('#form_AtakayatiPagala').trigger('reset');
        $("#submitbtn").html('+ ADD અટકાયતી પગલાની વિગત'); //Change button value to add
    });

    $("#searchButton").click(function () {
        $('#data_AtakayatiPagla').DataTable().ajax.reload();
    });

    $('#data_AtakayatiPagla').DataTable({
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
            url: "/api/ApiAtakayatiPagla/Get",
            type: "Get",
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
            },
        },
        "columns": [
            { title: 'પોલીસ સ્ટેશન', data: 'policeStationName', "width": "100px" },
            { title: 'તારીખ', data: 'createdDate', "width": "100px" },
            { title: 'સી.આર.પી.સી.–૧૦૭', data: 'crpC107', "width": "100px" },
            { title: 'પ્રોહી – ૯૩', data: 'prohi93', "width": "100px" },
            { title: 'સી.આર.પી.સી.–૧૦૯', data: 'crpC109', "width": "100px" },
            { title: 'સી.આર.પી.સી. – ૧૧૦', data: 'crpC110', "width": "100px" },
            { title: 'બી.પી.એકટ – ૧૨૨ સી', data: 'bpacT122C', "width": "100px" },
            { title: 'બી.પી.એકટ – ૧૨૪', data: 'bpacT124', "width": "100px" },
            { title: 'બી.પી.એકટ – ૫૬', data: 'bpacT56', "width": "100px" },
            { title: 'બી.પી.એકટ – ૫૭', data: 'bpacT57', "width": "100px" },
            { title: 'બી.પી.એકટ – ૧૩૫(૧)', data: 'bpacT135_1', "width": "100px" },
            { title: 'બી.પી.એકટ – ૧૪૨', data: 'bpacT142', "width": "100px" },
            { title: 'પાસા', data: 'pasa', "width": "100px" },
            { title: 'Total', data: 'total', "width": "100px" },
            {
                mRender: function (data, type, row) {
                    var bEdit = '<button type="button" class="btn btn-success" onclick="EditData(' + row.atakayatiPagalaBackupId + ')">Edit</button> ';
                    var bDelete = '<button type="button" class="btn btn-danger" onclick="DeleteData(' + row.atakayatiPagalaBackupId + ')">Delete</button>';
                    return bEdit + bDelete;
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

    $("#form_AtakayatiPagala").validate({
        rules: {
            policeStationId: "required",
            createdDate: "required",
            crpc107: {
                required: true,
                regex: /^[0-9]*$/,
            },
            prohi93: {
                required: true,
                regex: /^[0-9]*$/,
            },  
            crpc109: {
                required: true,
                regex: /^[0-9]*$/,
            },  
            crpc110: {
                required: true,
                regex: /^[0-9]*$/,
            },  
            bpact122c: {
                required: true,
                regex: /^[0-9]*$/,
            },  
            bpact124: {
                required: true,
                regex: /^[0-9]*$/,
            },  
            bpact56: {
                required: true,
                regex: /^[0-9]*$/,
            },  
            bpact57: {
                required: true,
                regex: /^[0-9]*$/,
            },  
            bpact1351: {
                required: true,
                regex: /^[0-9]*$/,
            },  
            bpact142: {
                required: true,
                regex: /^[0-9]*$/,
            },  
            pasa: {
                required: true,
                regex: /^[0-9]*$/,
            },           
        },
        messages: {
            policeStationId: "required",
            createdDate: "required",
            crpc107: {
                required: "required",
                regex: "Numbers only.",
            },
            prohi93: {
                required: "required",
                regex: "Numbers only.",
            },
            crpc109: {
                required: "required",
                regex: "Numbers only.",
            },
            crpc110: {
                required: "required",
                regex: "Numbers only.",
            },
            bpact122c: {
                required: "required",
                regex: "Numbers only.",
            },
            bpact124: {
                required: "required",
                regex: "Numbers only.",
            },
            bpact56: {
                required: "required",
                regex: "Numbers only.",
            },
            bpact57: {
                required: "required",
                regex: "Numbers only.",
            },
            bpact1351: {
                required: "required",
                regex: "Numbers only.",
            },
            bpact142: {
                required: "required",
                regex: "Numbers only.",
            },
            pasa: {
                required: "required",
                regex: "Numbers only.",
            },
        },

        submitHandler: () => {
            var formData = new FormData(document.getElementById("form_AtakayatiPagala"));
            var payload = JSON.stringify(Object.fromEntries(formData));
            /*console.log(payload);*/
            $.ajax({
                url: '/api/ApiAtakayatiPagla/Save',
                type: 'post',
                dataType: 'json',
                headers: {
                    'Accept': 'application/json',
                    'Content-Type': 'application/json'
                },
                data: payload,
                success: function (response) {
                
                    if (!response.isValid) {
                        swal("Contact Your Administrator!", "", "error");
                        return;
                    }

                    $('#form_AtakayatiPagala').trigger("reset");
                    $('#data_AtakayatiPagla').DataTable().ajax.reload();
                    $('#basicModal').modal('hide');
                    swal("Successfully!", "Form has been submitted.", "success");
                }, 
            });
        },
    });
});
