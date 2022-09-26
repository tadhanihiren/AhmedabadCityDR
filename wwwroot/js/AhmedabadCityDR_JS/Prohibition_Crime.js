function EditData(id) {
    //$("#submitbtn").html('Save પાર્ટ-સી ના ગુનાઓ'); //Change button value to Save
    //console.log("Edit popup show.");
    $.ajax({
        url: "/api/ApiProhibitionCrimeMaster/GetById",
        type: "Get",
        dataType: "json",
        data: { "id": id },
        headers: {
            "Accept": "application/json",
            "Content-Type": "application/json",
        },
        success: function (response) {
            //console.log(response.content);
            $('#form_ProhibitionCrime').trigger("reset");
            $('#basicModal').modal('show');
            Populate('#form_ProhibitionCrime', response.content);
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
                url: "/api/ApiProhibitionCrimeMaster/Delete",
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

                    $('#data_ProhibitionCrime').DataTable().ajax.reload();
                    swal("Successfully!", "Record has been deleted.", "success");
                },
            });

        }
    })
}

$(document).ready(function () {

    PopulateSearchPoliceStationDRD();


    $("#addData").click(() => {
        $('#form_ProhibitionCrime').trigger('reset');
    });
    $("#searchButton").click(function () {
        console.log("Click....")
        $('#data_ProhibitionCrime').DataTable().ajax.reload();
    });

    $('#data_ProhibitionCrime').DataTable({
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
            url: "/api/ApiProhibitionCrimeMaster/Get",
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
            { title: 'ProhibitioncrimeId', data: 'prohibitioncrimeId', "width": "100px" },
            { title: 'પોલીસ સ્ટેશન', data: 'policeStationName', "width": "100px" },
            { title: 'તારીખ', data: 'createdDate', "width": "100px" },
            { title: 'પીધેલા', data: 'pidhela', "width": "100px" },
            { title: 'કબજાના', data: 'kabjama', "width": "100px" },
            { title: 'આરોપી અટક ની સંખ્‍યા', data: 'crimeNumber', "width": "200px" },
            { title: 'પકડવાના બાકી સંખ્યા', data: 'arrestsNumber', "width": "200px" },
            { title: 'મુદ્દામાલની વિગત', data: 'mudamal_value', "width": "300px" },
            { title: 'મુદ્દામાલની કીંમત', data: 'issue', "width": "100px" },
            { title: 'કુલ કેસોની સંખ્યા', data: 'totalNumberCase', "width": "100px" },
            {
                mRender: function (data, type, row) {
                    var bEdit = '<button type="button" class="btn btn-success" onclick="EditData(' + row.prohibitioncrimeId + ')">Edit</button> ';
                    var bDelete = ' <button type="button" class="btn btn-danger" onclick="DeleteData(' + row.prohibitioncrimeId + ')">Delete</button>';
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
    $("#form_ProhibitionCrime").validate({
        rules: {
            policeStationId: "required",
            createdDate: "required",
            pidhela: {
                required: true,
                regex: /^[0-9]*$/,
            },
            kabjama: {
                required: true,
                regex: /^[0-9]*$/,
            },
            crimeNumber: {
                required: true,
                regex: /^[0-9]*$/,
            },
            arrestsNumber: {
                required: true,
                regex: /^[0-9]*$/,
            },
            mudamalValue: "required",
            issue: {
                required: true,
                regex: /^[0-9]*$/,
            },
            totalNumberCase: {
                required: true,
                regex: /^[0-9]*$/,
            },

        },
        messages: {
            policeStationId: "required",
            createdDate: "required",
            pidhela: {
                required: "required!",
                regex: "Numbers only.",
            },
            kabjama: {
                required: "required!",
                regex: "Numbers only.",
            },
            crimeNumber: {
                required: "required",
                regex: "Numbers only.",
            },
            arrestsNumber: {
                required: "required",
                regex: "Numbers only.",
            },
            mudamalValue: "required",
            issue: {
                required: "required",
                regex: "Numbers only.",
            },
            totalNumberCase: {
                required: "required",
                regex: "Numbers only.",
            },

        },
        submitHandler: () => {
            var formData = new FormData(document.getElementById("form_ProhibitionCrime"));
            var payload = JSON.stringify(Object.fromEntries(formData));
            //console.log(payload);
            $.ajax({
                url: "/api/ApiProhibitionCrimeMaster/Save",
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
                    $('#data_ProhibitionCrime').DataTable().ajax.reload();
                    $('#form_ProhibitionCrime').trigger("reset");
                    $('#basicModal').modal('hide');
                    swal("Successfully!", "Form has been submitted.", "success");
                },
            });
        },
    });
});