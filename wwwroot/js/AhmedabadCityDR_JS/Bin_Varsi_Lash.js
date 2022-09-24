function EditData(id) {
    $("#prohibitionCat").show();
    $("#submitbtn").html('Save બીનવારસી લાશની વિગત'); //Change button value to Save
    //console.log("Edit popup show.");
    $.ajax({
        url: "/api/ApiBin_varsi_lash/GetById",
        type: "Get",
        dataType: "json",
        data: { "id": id },
        headers: {
            "Accept": "application/json",
            "Content-Type": "application/json",
        },
        success: function (response) {
            //console.log(response.content);
            $('#form_Bin_Varsi_Lash').trigger("reset");
            $('#basicModal').modal('show');
            Populate('#form_Bin_Varsi_Lash', response.content);
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
                url: "/api/ApiBin_varsi_lash/Delete",
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

                    $('#data_Bin_Varsi_Lash').DataTable().ajax.reload();
                    swal("Successfully!", "Record has been deleted.", "success");
                },
            });

        }
    })
}

$(document).ready(() => {

    PopulateSearchPoliceStationDRD();

    $("#addData").click(() => {
        $("#prohibitionCat").hide();
        $('#form_Bin_Varsi_Lash').trigger('reset');
        $("#submitbtn").html('+ Add બીનવારસી લાશની વિગત'); //Change button value to add
    });

    $("#searchButton").click(function () {
        $('#data_Bin_Varsi_Lash').DataTable().ajax.reload();
    });

    $('#data_Bin_Varsi_Lash').DataTable({
        "processing": true,
        "language": {
            processing: '<div class="spinner-grow text-primary" role="status"></div>'
        },
        lengthMenu: [[10, 20, 50, 100, 500, 1000, 1500, 2000], [10, 20, 50, 100, 500, 1000, 1500, 2000]],
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
            url: "/api/ApiBin_varsi_lash/Get",
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
            { title: 'પો.સ્ટે ગુ.ર.નં', data: 'policeStationNumber', "width": "100px" },
            { title: 'પો.સ્ટે', data: 'policeStationName', "width": "100px" },
            { title: 'તારીખ', data: 'createdDate', "width": "100px" },
            { title: 'ખબર આપનાર', data: 'complainer', "width": "600px" },
            { title: 'ગુ.બ.તા.ટા.', data: 'gubatata', "width": "200px" },
            { title: 'ગુ.જા.તા.ટા.', data: 'gujatata', "width": "200px" },
            { title: 'ગુ.દા.તા.ટા.', data: 'gudatata', "width": "200px" },
            { title: 'મરણ ની જગ્યા', data: 'crimePlace', "width": "200px" },
            { title: 'ગુન્હો દાખલ કરનારનુ નામ હોદ્દો', data: 'personNameWhoFiledCrime', "width": "200px" },
            { title: 'તપાસ કરનારનુ નામ હોદ્દો', data: 'investigationOfficer', "width": "200px" },
            { title: 'ગુનાની ટુંક વિગત', data: 'shortDetail', "width": "1000px" },
            { title: 'Hdiits અંતર્ગત એન્ટ્રી કરેલ છે.કે કેમ?', data: 'hdiitsEntry', "width": "120px" },
            { title: 'કલમ', data: 'ipcact', "width": "300px" },
            {
                mRender: function (data, type, row) {
                    var bEdit = '<button type="button" class="btn btn-success" onclick="EditData(' + row.crimesId + ')">Edit</button> ';
                    var bDelete = ' <button type="button" class="btn btn-danger" onclick="DeleteData(' + row.crimesId + ')">Delete</button>';
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

    $("#form_Bin_Varsi_Lash").validate({
        rules: {
            policeStationId: "required",
            subCategoryId: "required",
            policeStationNumber: {
                required: true,
                minlength: 14,
                maxlength: 14,
            },
            pidhelaKabjanaType: "required",
            ipcact: "required",
            complainer: "required",
            accused: "required",
            gubatata: "required",
            gujatata: "required",
            gudatata: "required",
            crimePlace: "required",
            crimePurpose: "required",
            personNameWhoFiledCrime: "required",
            investigationOfficer: "required",
            shortDetail: "required",
            latitude: {
                regex: /^[0-9]{1,2}(?:\.[0-9]{1,8})?$/,
                maxlength: 10
            },
            longitude: {
                regex: /^[0-9]{1,2}(?:\.[0-9]{1,8})?$/,
                maxlength: 10
            },
            lateComplaintReason: "required",
            hdiitsEntry: "required",
            complainerAccusedCriminalHistory: "required",
            createdDate: "required",
        },
        messages: {
            policeStationId: "Required!",
            subCategoryId: "Required!",
            policeStationNumber: {
                required: "Required!",
                minlength: "Required minimum 14 numbers",
                maxlength: "Required maxlength 14 numbers",
            },
            pidhelaKabjanaType: "Required!",
            ipcact: "Required!",
            complainer: "Required!",
            accused: "Required!",
            gubatata: "Required!",
            gujatata: "Required!",
            gudatata: "Required!",
            crimePlace: "Required!",
            crimePurpose: "Required!",
            personNameWhoFiledCrime: "Required!",
            investigationOfficer: "Required!",
            shortDetail: "Required!",
            latitude: {
                regex: "Provide valid input. Like '12.12345678'",
                maxlength: "Maximum 10 numbers allowed."
            },
            longitude: {
                regex: "Provide valid input. Like '12.12345678'",
                maxlength: "Maximum 10 numbers allowed."
            },
            lateComplaintReason: "Required!",
            hdiitsEntry: "Required!",
            complainerAccusedCriminalHistory: "Required!",
            createdDate: "Required!",
        },
        submitHandler: () => {
            var formData = new FormData(document.getElementById("form_Bin_Varsi_Lash"));
            var payload = JSON.stringify(Object.fromEntries(formData));
            //console.log(payload);
            $.ajax({
                url: "/api/ApiBin_varsi_lash/Save",
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

                    $('#data_Bin_Varsi_Lash').DataTable().ajax.reload();
                    $('#form_Bin_Varsi_Lash').trigger("reset");
                    $('#basicModal').modal('hide');
                    swal("Successfully!", "Form has been submitted.", "success");
                },
            });
        },
    });
});