function EditData(id) {
    $("#prohibitionCat").show();
    $("#submitbtn").html('Save પાર્ટ-બી'); //Change button value to Save
    $.ajax({
        url: "/api/ApiPart6Crimes/GetById",
        type: "Get",
        dataType: "json",
        data: { "id": id },
        headers: {
            "Accept": "application/json",
            "Content-Type": "application/json",
        },
        success: function (response) {
            console.log("Edit get data Complete.");
            //console.log(response.content);
            $('#form_part6Crimes').trigger("reset");
            $('#basicModal').modal('show');
            Populate('#form_part6Crimes', response.content);
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
                url: "/api/ApiPart6Crimes/Delete",
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

                    $('#data_Part6Crimes').DataTable().ajax.reload();
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
        $('#form_part6Crimes').trigger('reset');
        $("#submitbtn").html('+ ADD પાર્ટ-બી'); //Change button value to add
    });

    $("#subCategoryId").change(function () {
        var selectedValue = $('option:selected', this).val();
        if (selectedValue == 124 || selectedValue == 127 || selectedValue == 128) {
            $("#prohibitionCat").show();
        }
        else {
            $("#prohibitionCat").hide();
        }
    });

    $("#searchButton").click(function () {
        $('#data_Part6Crimes').DataTable().ajax.reload();
    });

    $('#data_Part6Crimes').DataTable({
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
            url: "/api/ApiPart6Crimes/Get",
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
            { title: 'ભાગ ૧ થી ૫ પ્રકાર', data: 'subCategoryName', "width": "200px" },
            { title: 'ફરીયાદીનુ નામ મોબાઇલ નંબર અને સરનામુ', data: 'complainer', "width": "600px" },
            { title: 'આરોપીનુ નામ અને સરનામુ', data: 'accused', "width": "900px" },
            { title: 'ગુ.બ.તા.ટા.', data: 'gubatata', "width": "200px" },
            { title: 'ગુ.જા.તા.ટા.', data: 'gujatata', "width": "200px" },
            { title: 'ગુ.દા.તા.ટા.', data: 'gudatata', "width": "200px" },
            { title: 'ગુનાની જગ્યા', data: 'crimePlace', "width": "200px" },
            { title: 'ગુનાનો હેતુ', data: 'crimePurpose', "width": "200px" },
            { title: 'ગુન્હો દાખલ કરનારનુ નામ હોદ્દો', data: 'personNameWhoFiledCrime', "width": "200px" },
            { title: 'તપાસ કરનારનુ નામ હોદ્દો', data: 'investigationOfficer', "width": "200px" },
            { title: 'ટુંક વિગત', data: 'shortDetail', "width": "1000px" },
            { title: 'લેટ ફરીયાદનુ કારણ', data: 'lateComplaintReason', "width": "500px" },
            { title: 'Hdiits અંતર્ગત એન્ટ્રી કરેલ છે.કે કેમ?', data: 'hdiitsEntry', "width": "120px" },
            { title: 'સંવેદનશીલ', data: 'savendansilText', "width": "100px" },
            { title: 'બીન સંવેદનશીલ', data: 'binSavendansilText', "width": "100px" },
            { title: 'અક્ષાંશ', data: 'latitude', "width": "100px" },
            { title: 'રેખાંશ', data: 'longitude', "width": "100px" },
            { title: 'ફરીયાદી/આરોપી પક્ષ ગુનાહીત ઇતિહાસ ધરાવે છે કે કેમ?', data: 'complainer_AccusedCriminalHistory', "width": "200px" },
            { title: 'એપેડેમિક ડીસીઝ એકટ / ડિઝાસ્ટર મેનેજમેન્ટ એકટ માં કોને પકડેલ ની વિગત', data: 'pidhela_Kabjana_Type', "width": "220px" },
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

    $("#form_part6Crimes").validate({
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
            var formData = new FormData(document.getElementById("form_part6Crimes"));
            var payload = JSON.stringify(Object.fromEntries(formData));
            console.log(payload);
            $.ajax({
                url: "/api/ApiPart6Crimes/Save",
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

                    $('#data_Part6Crimes').DataTable().ajax.reload();
                    $('#form_part6Crimes').trigger("reset");
                    $('#basicModal').modal('hide');
                    swal("Successfully!", "Form has been submitted.", "success");
                },
            });
        },
    });
});