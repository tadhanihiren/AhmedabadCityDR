function editData(id) {
    $("#submitbtn").html('Save અકસ્માત મોત (AD) અને કલમ '); //Change button value to add
    $.ajax({
        url: "/api/ApiAksmat_death/GetById",
        type: "Get",
        dataType: "json",
        data: { "id": id },
        headers: {
            "Accept": "application/json",
            "Content-Type": "application/json",
        },
        success: function (response) {
            console.log(response.content);
            $('#form_Aksmat_death').trigger("reset");
            $('#basicModal').modal('show');
            Populate('#form_Aksmat_death', response.content);
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
                url: "/api/ApiAksmat_death/Delete",
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

                    $('#data_Aksmat_death').DataTable().ajax.reload();
                    swal("Successfully!", "Record has been deleted.", "success");
                },
            });

        }
    })
}

$(document).ready(function () {

    PopulateSearchPoliceStationDRD();

    $("#addData").click(() => {
        $('#form_Aksmat_death').trigger('reset');
        $("#submitbtn").html('+ Add અકસ્માત મોત (AD) અને કલમ '); //Change button value to add
    });

    $("#searchButton").click(function () {
        $('#data_Aksmat_death').DataTable().ajax.reload();
    });

    $('#data_Aksmat_death').DataTable({
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
            url: "/api/ApiAksmat_death/Get",
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
            }
        },
        "columns": [
            { title: 'પો.સ્ટે ગુ.ર.નં', data: 'policeStationNumber', "width": "100px" },
            { title: 'પો.સ્ટે', data: 'policeStationName', "width": "100px" },
            { title: 'તારીખ', data: 'createdDate', "width": "100px" },
            { title: 'ખબર આપનાર', data: 'complainer', "width": "100px" },
            { title: 'મરણ જનાર નુ નામ સરનામું', data: 'accused', "width": "100px" },
            { title: 'બનાવ બ.તા.ટા.', data: 'gubatata', "width": "100px" },
            { title: 'બનાવ જા.તા.ટા', data: 'gujatata', "width": "100px" },
            { title: 'બનાવ દા.તા.ટા', data: 'gudatata', "width": "100px" },
            { title: 'મરણ ની જગ્યા', data: 'crimePlace', "width": "900px" },
            { title: 'ગુન્હો દાખલ કરનારનુ નામ હોદ્દો', data: 'personNameWhoFiledCrime', "width": "100px" },
            { title: 'તપાસ કરનારનુ નામ હોદ્દો', data: 'investigationOfficer', "width": "100px" },
            { title: 'ગુનાની ટુંક વિગત', data: 'shortDetail', "width": "150px" },
            { title: 'Hdiits અંતર્ગત એન્ટ્રી કરેલ છે.કે કેમ?', data: 'hdiitsEntry', "width": "100px" },
            { title: 'કલમ', data: 'ipcact', "width": "100px" },
            {
                mRender: function (data, type, row) {
                    var bEdit = '<button type="button" class="btn btn-success" onclick="editData(' + row.crimesId + ')">Edit</button> ';
                    var bDelete = '<button type="button" class="btn btn-danger" onclick="deleteData(' + row.crimesId + ')">Delete</button>';
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

    $("#form_Aksmat_death").validate({
        rules: {
            policeStationId: "required",
            policeStationNumber: {
                required: true,
                minlength: 14,
                maxlength: 14,
            },
            complainer: "required",
            accused: "required",
            gubatata: "required",
            gujatata: "required",
            gudatata: "required",
            crimePlace: "required",
            personNameWhoFiledCrime: "required",
            investigationOfficer: "required",
            shortDetail: "required",
            hdiitsEntry: "required",
            createdDate: "required",
            ipcact: "required",


        },
        messages: {
            policeStationId: "required",
            policeStationNumber: {
                required: "Required!",
                minlength: "Required minimum 14 numbers",
                maxlength: "Required maxlength 14 numbers",
            },
            complainer: "required",
            accused: "required",
            gubatata: "required",
            gujatata: "required",
            gudatata: "required",
            crimePlace: "required",
            personNameWhoFiledCrime: "required",
            investigationOfficer: "required",
            shortDetail: "required",
            hdiitsEntry: "required",
            createdDate: "required",
            ipcact: "required",
        },

        submitHandler: () => {
            var formData = new FormData(document.getElementById("form_Aksmat_death"));
            var payload = JSON.stringify(Object.fromEntries(formData));
            console.log(payload);
            $.ajax({
                url: '/api/ApiAksmat_death/Save',
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
                    $('#data_Aksmat_death').DataTable().ajax.reload();
                    $('#form_Aksmat_death').trigger("reset");
                    $('#basicModal').modal('hide');
                    swal("Successfully!", "Form has been submitted.", "success");
                },
            });
        },
    });
});