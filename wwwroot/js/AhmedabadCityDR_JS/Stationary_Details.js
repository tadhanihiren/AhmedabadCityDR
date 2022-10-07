function EditData(id) {
    $("#submitbtn").html('Save સ્ટેશનરી અંગેની હકીક્ત દર્શાવતુ પત્રક'); //Change button value to Save
    $.ajax({
        url: "/api/ApiStationaryMaster/GetById",
        type: "Get",
        dataType: "json",
        data: { "id": id },
        headers: {
            "Accept": "application/json",
            "Content-Type": "application/json",
        },
        success: function (response) {
            //console.log(response.content);
            $('#form_Stationary_Details').trigger("reset");
            $('#basicModal').modal('show');
            Populate('#form_Stationary_Details', response.content);
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
                url: "/api/ApiStationaryMaster/Delete",
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

                    $('#data_Stationary_Details').DataTable().ajax.reload();
                    swal("Successfully!", "Record has been deleted.", "success");
                },
            });

        }
    })
}

$(document).ready(function () {

    PopulateSearchPoliceStationDRD();

    $("#addData").click(() => {
        $('#form_Stationary_Details').trigger('reset');
        $("#submitbtn").html('+ ADD સ્ટેશનરી અંગેની હકીક્ત દર્શાવતુ પત્રક'); //Change button value to add
    });

    $("#searchButton").click(function () {
        $('#data_Stationary_Details').DataTable().ajax.reload();
    });

    $('#data_Stationary_Details').DataTable({
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
            url: "/api/ApiStationaryMaster/Get",
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
            { title: 'પોલીસ સ્ટેશન', data: 'policeStationName', "width": "100px" },
            { title: 'તારીખ', data: 'createdDate', "width": "100px" },
            { title: 'લેન્ડ લાઇન ટેલીફોન ચાલુ છે કે કેમ?ટેલીફોન નંબર સાથે', data: 'telephone', "width": "200px" },
            { title: 'કોમ્પ્યુટર તથા જી-સ્વાન કનેક્ટીવીટી ચાલુ છે કે કેમ? તેની વિગત', data: 'computer', "width": "200px" },
            { title: 'જીસ્વાન કનેકટીવીટી બંદ હોય તો કમ્પલેન નંબર', data: 'giswan_Connectivity', "width": "200px" },
            { title: 'ફેક્સ મશીન ચાલુ છે કે કેમ? તેની વિગત ફેક્સ નંબર સાથે', data: 'fax_machine', "width": "200px" },
            { title: 'ઝેરોક્ષ મશીનચાલુ છે કે કેમ? તેની વિગત ફેક્સ નંબર સાથે', data: 'xerox_machine', "width": "200px" },
            { title: 'અન્ય સ્ટેશનરી વિગેરે સ્ટોક', data: 'other_Stationary_Stocks', "width": "200px" },
            {
                mRender: function (data, type, row) {
                    var bEdit = '<button type="button" class="btn btn-success" onclick="EditData(' + row.stationaryId + ')">Edit</button> ';
                    var bDelete = ' <button type="button" class="btn btn-danger" onclick="DeleteData(' + row.stationaryId + ')">Delete</button>';
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

    $("#form_Stationary_Details").validate({
        rules: {
            policeStationId: "required",
            createdDate: "required",
            telephone: "required",
            computer: "required",
            giswanConnectivity: "required",
            faxMachine: "required",
            xeroxMachine: "required",
            otherStationaryStocks: "required",

        },
        messages: {
            policeStationId: "required",
            createdDate: "required",
            telephone: "required",
            computer: "required",
            giswanConnectivity: "required",
            faxMachine: "required",
            xeroxMachine: "required",
            otherStationaryStocks: "required",

        },

        submitHandler: () => {
            var formData = new FormData(document.getElementById("form_Stationary_Details"));
            var payload = JSON.stringify(Object.fromEntries(formData));
            //console.log(payload);
            $.ajax({
                url: '/api/ApiStationaryMaster/Save',
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
                    $('#form_Stationary_Details').trigger("reset");
                    $('#basicModal').modal('hide');
                    $('#data_Stationary_Details').DataTable().ajax.reload();
                    swal("Successfully!", "Form has been submitted.", "success");
                },
            });
        },
    });
});