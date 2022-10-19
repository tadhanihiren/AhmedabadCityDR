function EditData(id) {
    $("#submitbtn").html('Save ઈગુજકોપ'); //Change button value to Save
    $.ajax({
        url: "/api/ApiEGujkopDetails/GetById",
        type: "Get",
        dataType: "json",
        data: { "id": id },
        headers: {
            "Accept": "application/json",
            "Content-Type": "application/json",
        },
        success: function (response) {
            //console.log(JSON.stringify(response.content));
            $('#form_E_Gujkop_Details').trigger("reset");
            $('#basicModal').modal('show');
            Populate('#form_E_Gujkop_Details', response.content);
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
                url: "/api/ApiEGujkopDetails/Delete",
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

                    $('#data_E_Gujkop_Details').DataTable().ajax.reload();
                    swal("Successfully!", "Record has been deleted.", "success");
                },
            });

        }
    })
}

$(document).ready(() => {

    PopulateSearchPoliceStationDRD();

    $("#addData").click(() => {
        $('#form_E_Gujkop_Details').trigger('reset');
        $("#submitbtn").html('+ ADD ઈગુજકોપ'); //Change button value to add
    });

    $("#searchButton").click(function () {
        $('#data_E_Gujkop_Details').DataTable().ajax.reload();
    });

    $('#data_E_Gujkop_Details').DataTable({
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
            url: "/api/ApiEGujkopDetails/Get",
            type: "get",
            dataSrc: "content",
            dataType: "json",
            data: function (d) {
                d.fromDate = $('#searchFromDate').val();
                d.toDate = $('#searchToDate').val();
                //console.log(d);
            },
            headers: {
                "Accept": "application/json",
                "Content-Type": "application/json",
            }
        },
        "columns": [
            { title: 'પોલીસ સ્ટેશન', data: 'policeStationName', "width": "100px" },
            { title: 'પો.સ્ટે. ખાતે આજ રોજ નોધાયેલ એફ.આઈ.આર. (IIF-1)', data: 'policeStationKhate_Nondhayel_FIR', "width": "200px" },
            { title: 'આજ રોજ નોધાયેલ  એફ.આઈ.આર. પૈકી ઈગુજકોપમાં એફ.આઈ.આર. ની કરેલ એન્ટ્રી ', data: 'e_Gujkop_FIR_Entry', "width": "250px" },
            { title: 'આજ રોજ પો.સ્ટે. ખાતે નોધાયેલ ગુના સબંધે કરવામાં આવેલ પંચનામું (IIF-2)', data: 'policeStationKhate_Nondhayel_Panchnamu', "width": "250px" },
            { title: 'આજ રોજ કરવામાં આવેલ પંચનામા પૈકી ઈગુજકોપમાં કરેલ એન્ટ્રી ', data: 'panchnama_EGujop_Entry', "width": "200px" },
            { title: 'આજ રોજ અટક કરેલ ઈસમ (IIF-3)', data: 'atakKarel_Isam', "width": "200px" },
            { title: 'આજ રોજ અટક કરેલ ઈસમોની ઈગુજકોપમાં કરેલ એન્ટ્રી', data: 'atakKarel_Isam_EGujkop_Entry', "width": "200px" },
            { title: 'આજ રોજ અટક કરેલ ઈસમ પૈકી કેટલાના ફોટા ઈગુજકોપ પર અપલોડ કરેલ', data: 'atakKarel_Isam_Egujkop_PhotoUpload', "width": "250px" },
            { title: 'પો.સ્ટે. ખાતે નોધાયેલ ગુના સબંધે આજ રોજ કેટલી મુદ્દામાલ પાવતી ફાડી (IIF-4)', data: 'post_Khate_Mudamal_Pavti_Fadi', "width": "250px" },
            { title: 'આજ રોજ ફાડવામાં આવેલ મુદ્દામાલ પાવતી પૈકી કેટલાની ઈગુજકોપ પર એન્ટ્રી કરી', data: 'mudamal_Pavti_EGujkop_Entry', "width": "250px" },
            { title: 'આજ રોજ કેટલી ચાર્જશીટ  મંજુર કરેલ (IIF-5)', data: 'chargesheet_ManjurKarel', "width": "200px" },
            { title: 'આજ રોજ મંજુર કરવામાં આવેલ ચાર્જશીટ  પૈકી કેટલાની ઈગુજકોપમાં એન્ટ્રી કરી', data: 'chargsheet_EGujkop_Entry', "width": "250px" },
            { title: 'મળેલ સર્વિસ શીટ પૈકી આજ રોજ કેટલી સર્વિસ શીટની ઈગુજકોપમાં  એન્ટ્રી કરી', data: 'serviceSheet_EGujkop_Entry', "width": "250px" },
            { title: 'પો.સ્ટે. ખાતે હાજર કુલ અધિકારી/કર્મચારીની સંખ્યા', data: 'postKhate_Hajar_EmployeeName', "width": "250px" },
            { title: 'આજ રોજ કેટલા અધિકારી/કર્મચારીના હેલ્થ કાર્ડની ડેટા એન્ટ્રી કરી', data: 'employee_healthcard_Entry', "width": "250px" },
            { title: 'આજ રોજ કેટલા મીસીંગની જાણવાજોગ નોધાઈ.', data: 'missing_Janvajog', "width": "200px" },
            { title: 'આજ રોજ મીસીંગની નોધાયેલ જાણવાજોગ પૈકી કેટલી જાણવાજોગની ઈગુજકોપમાં એન્ટ્રી કરી', data: 'missing_Janvajog_EGujkop_Entry', "width": "260px" },
            { title: 'આજ રોજ મીસીંગની નોધાયેલ જાણવાજોગ સબંધે કરેલ ફોટા અપલોડની સંખ્યા', data: 'missing_Janvajog_PhotoUpload', "width": "250px" },
            { title: 'આજ રોજ ખોવાયેલ બાળકો સબંધે નોધાયેલ એફ.આઈ.આર.ની સંખ્યા', data: 'missingChild_FIRNumber', "width": "200px" },
            { title: 'આજ રોજ ખોવાયેલ બાળક સબંધે કરેલ ફોટા અપલોડની સંખ્યા', data: 'missingChild_PhotoUpload', "width": "200px" },
            { title: 'પો.સ્ટે. ખાતે ફાળવેલ પોકેટ કોપ મોબાઈલ  ડિવાઈસની સંખ્યા', data: 'pocketCop_MobileDevice_Number', "width": "200px" },
            { title: 'આ પૈકીના કેટલા પોકેટ કોપ ડિવાઈસમાં આજ રોજ લોગીન કરી વાહન સર્ચ/વ્યક્તિ સર્ચ/લેટ-લોંગ/પાસપોર્ટ માટે ઉપયોગ કર્યો.', data: 'numberOf_PocketCop_Device_login', "width": "400px" },
            { title: 'તારીખ', data: 'createdDate', "width": "100px" },
            {
                mRender: function (data, type, row) {
                    var bEdit = '<button type="button" class="btn btn-success" onclick="EditData(' + row.e_GujkopDetailsId + ')">Edit</button> ';
                    var bDelete = ' <button type="button" class="btn btn-danger" onclick="DeleteData(' + row.e_GujkopDetailsId + ')">Delete</button>';
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

    $("#form_E_Gujkop_Details").validate({
        rules: {
            createdDate: "required",
            policeStationKhateNondhayelFir: { required: true, regex: /^[0-9]*$/, },
            eGujkopFirEntry: { required: true, regex: /^[0-9]*$/, },
            policeStationKhateNondhayelPanchnamu: { required: true, regex: /^[0-9]*$/, },
            panchnamaEgujopEntry: { required: true, regex: /^[0-9]*$/, },
            atakKarelIsam: { required: true, regex: /^[0-9]*$/, },
            atakKarelIsamEgujkopEntry: { required: true, regex: /^[0-9]*$/, },
            atakKarelIsamEgujkopPhotoUpload: { required: true, regex: /^[0-9]*$/, },
            postKhateMudamalPavtiFadi: { required: true, regex: /^[0-9]*$/, },
            mudamalPavtiEgujkopEntry: { required: true, regex: /^[0-9]*$/, },
            chargesheetManjurKarel: { required: true, regex: /^[0-9]*$/, },
            chargsheetEgujkopEntry: { required: true, regex: /^[0-9]*$/, },
            serviceSheetEgujkopEntry: { required: true, regex: /^[0-9]*$/, },
            serviceSheetBuckleNoName: "required",
            postKhateHajarEmployeeName: { required: true, regex: /^[0-9]*$/, },
            healthcardBuckleNoName: "required",
            employeeHealthcardEntry: { required: true, regex: /^[0-9]*$/, },
            missingJanvajog: { required: true, regex: /^[0-9]*$/, },
            missingJanvajogEgujkopEntry: { required: true, regex: /^[0-9]*$/, },
            missingJanvajogPhotoUpload: { required: true, regex: /^[0-9]*$/, },
            missingChildFirnumber: { required: true, regex: /^[0-9]*$/, },
            missingChildPhotoUpload: { required: true, regex: /^[0-9]*$/, },
            pocketCopMobileDeviceNumber: { required: true, regex: /^[0-9]*$/, },
            numberOfPocketCopDeviceLogin: { required: true, regex: /^[0-9]*$/, },
            dataEntry: { required: true, regex: /^[0-9]*$/, },
        },
        messages: {
            createdDate: "Required!",
            policeStationKhateNondhayelFir: { required: "Required!", regex: "Numbers only.", },
            eGujkopFirEntry: { required: "Required!", regex: "Numbers only.", },
            policeStationKhateNondhayelPanchnamu: { required: "required", regex: "Numbers only.", },
            panchnamaEgujopEntry: { required: "Required!", regex: "Numbers only.", },
            atakKarelIsam: { required: "Required!", regex: "Numbers only.", },
            atakKarelIsamEgujkopEntry: { required: "Required!", regex: "Numbers only.", },
            atakKarelIsamEgujkopPhotoUpload: { required: "Required!", regex: "Numbers only.", },
            postKhateMudamalPavtiFadi: { required: "Required!", regex: "Numbers only.", },
            mudamalPavtiEgujkopEntry: { required: "Required!", regex: "Numbers only.", },
            chargesheetManjurKarel: { required: "Required!", regex: "Numbers only.", },
            chargsheetEgujkopEntry: { required: "Required!", regex: "Numbers only.", },
            serviceSheetEgujkopEntry: { required: "Required!", regex: "Numbers only.", },
            serviceSheetBuckleNoName: "Required!",
            postKhateHajarEmployeeName: { required: "Required!", regex: "Numbers only.", },
            healthcardBuckleNoName: "Required!",
            employeeHealthcardEntry: { required: "Required!", regex: "Numbers only.", },
            missingJanvajog: { required: "Required!", regex: "Numbers only.", },
            missingJanvajogEgujkopEntry: { required: "Required!", regex: "Numbers only.", },
            missingJanvajogPhotoUpload: { required: "Required!", regex: "Numbers only.", },
            missingChildFirnumber: { required: "Required!", regex: "Numbers only.", },
            missingChildPhotoUpload: { required: "Required!", regex: "Numbers only.", },
            pocketCopMobileDeviceNumber: { required: "Required!", regex: "Numbers only.", },
            numberOfPocketCopDeviceLogin: { required: "Required!", regex: "Numbers only.", },
            dataEntry: { required: "Required!", regex: "Numbers only.", },
        },
        submitHandler: () => {
            var formData = new FormData(document.getElementById("form_E_Gujkop_Details"));
            var payload = JSON.stringify(Object.fromEntries(formData));
            //console.log(payload);
            $.ajax({
                url: "/api/ApiEGujkopDetails/Save",
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

                    $('#data_E_Gujkop_Details').DataTable().ajax.reload();
                    $('#form_E_Gujkop_Details').trigger("reset");
                    $('#basicModal').modal('hide');
                    swal("Successfully!", "Form has been submitted.", "success");
                },
            });
        },
    });
});