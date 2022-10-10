function EditData(id) {
    $("#submitbtn").html('Save CRPC ૪૧(૧) ની વિગત'); //Change button value to Save
    $.ajax({
        url: "/api/ApiCRPC41CAmendmentMater/GetById",
        type: "Get",
        dataType: "json",
        data: { "id": id },
        headers: {
            "Accept": "application/json",
            "Content-Type": "application/json",
        },
        success: function (response) {
            console.log(response.content);
            $('#form_CRPC41C_Amendment').trigger("reset");
            $('#basicModal').modal('show');
            Populate('#form_CRPC41C_Amendment', response.content);
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
                url: "/api/ApiCRPC41CAmendmentMater/Delete",
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

                    $('#data_CRPC41C_Amendment').DataTable().ajax.reload();
                    swal("Successfully!", "Record has been deleted.", "success");
                },
            });

        }
    })
}

$(document).ready(() => {

    PopulateSearchPoliceStationDRD();

    $("#addData").click(() => {
        $('#form_CRPC41C_Amendment').trigger('reset');
        $("#submitbtn").html('+ ADD CRPC ૪૧(૧) ની વિગત'); //Change button value to add
    });

    $("#searchButton").click(function () {
        $('#data_CRPC41C_Amendment').DataTable().ajax.reload();
    });

    $('#data_CRPC41C_Amendment').DataTable({
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
            url: "/api/ApiCRPC41CAmendmentMater/Get",
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
            { title: 'ગુ.ર.નં કલમ', data: 'crimes_date', "width": "200px" },
            { title: 'ગુન્‍હો જાહેર તારીખ', data: 'jaherTarikh', "width": "100px" },
            { title: 'અટક કર્યા તા.ટા.', data: 'dated', "width": "100px" },
            { title: 'આરોપી નુ નામ', data: 'accused_name_address', "width": "250px" },
            { title: 'સરનામુ', data: 'address', "width": "250px" },
            { title: 'કોગ્નીઝેબલ ગુનો કરતી જ વખતે અટક કરેલ છે કે કેમ ?', data: 'cognizable_offens', "width": "200px" },
            { title: 'આરોપીના ફીંગરપ્રિન્ટ સર્ચ સ્લીપ લીધેલ છે કે કેમ.? હા/ના', data: 'victims_fingerprint', "width": "200px" },
            { title: 'કોલમ .7 માં જો ના તો કયા કારણસર લીધેલ નથી.?', data: 'victims_fingerprint_Remark', "width": "200px" },
            { title: 'ગુનામાં પાછળથી અટક કરેલ હોય તો તે અંગેના CRPC -41 C', data: 'crpC_41C', "width": "200px" },
            { title: 'અટક કરનાર અધિ.નુ નામ હોદ્દો', data: 'designation_Name', "width": "200px" },
            { title: 'જામીન મુકત કર્યા', data: 'release_the_bail', "width": "100px" },
            { title: 'કોર્ટ માં રવાના', data: 'depart_in_court', "width": "100px" },
            { title: 'આરોપી ની સંખ્‍યા', data: 'number_of_accused', "width": "100px" },
            {
                mRender: function (data, type, row) {
                    var bEdit = '<button type="button" class="btn btn-success" onclick="EditData(' + row.crpC41CId + ')">Edit</button> ';
                    var bDelete = ' <button type="button" class="btn btn-danger" onclick="DeleteData(' + row.crpC41CId + ')">Delete</button>';
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

    $("#form_CRPC41C_Amendment").validate({
        rules: {
            policeStation: "required",
            createdDate: "required",
            crimesDate: "required",
            jaherTarikh: "required",
            dated: "required",
            accusedNameAddress: "required",
            address: "required",
            victimsFingerprintRemark: "required",
            crpc41c: "required",
            designationName: "required",
            releaseTheBail: "required",
            departInCourt: "required",
            numberOfAccused: {
                required: true,
                regex: /^[0-9]*$/,
            },
        },
        messages: {
            policeStation: "Required!",
            createdDate: "Required!",
            crimesDate: "Required!",
            jaherTarikh: "Required!",
            dated: "Required!",
            accusedNameAddress: "Required!",
            address: "Required!",
            victimsFingerprintRemark: "Required!",
            crpc41c: "Required!",
            designationName: "Required!",
            releaseTheBail: "Required!",
            departInCourt: "Required!",
            numberOfAccused: {
                required: "Required!",
                regex: "Numbers only.",
            },
        },
        submitHandler: () => {
            var formData = new FormData(document.getElementById("form_CRPC41C_Amendment"));
            var payload = JSON.stringify(Object.fromEntries(formData));
            //console.log(payload);
            $.ajax({
                url: "/api/ApiCRPC41CAmendmentMater/Save",
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

                    $('#data_CRPC41C_Amendment').DataTable().ajax.reload();
                    $('#form_CRPC41C_Amendment').trigger("reset");
                    $('#basicModal').modal('hide');
                    swal("Successfully!", "Form has been submitted.", "success");
                },
            });
        },
    });
});