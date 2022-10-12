
function editData(id) {
    $("#submitbtn").html('Save નાસતા-ફરતા આરોપીઓની માહીતી '); //Change button value to add
    $.ajax({
        url: "/api/ApiAccusedInformationMaster/GetById",
        type: "Get",
        dataType: "json",
        data: { "id": id },
        headers: {
            "Accept": "application/json",
            "Content-Type": "application/json",
        },
        success: function (response) {
            console.log(response.content);
            $('#form_Accused_Information').trigger("reset");
            $('#basicModal').modal('show');
            Populate('#form_Accused_Information', response.content);
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
                url: "/api/ApiAccusedInformationMaster/Delete",
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

                    $('#data_AccusedInformation').DataTable().ajax.reload();
                    swal("Successfully!", "Record has been deleted.", "success");
                },
            });

        }
    })
}


$(document).ready(function () {

    PopulateSearchPoliceStationDRD();


    $("#addData").click(() => {
        $('#form_Accused_Information').trigger('reset');
        $("#submitbtn").html('+ Add નાસતા-ફરતા આરોપીઓની માહીતી'); //Change button value to add
    });

    $("#searchButton").click(function () {
        $('#data_AccusedInformation').DataTable().ajax.reload();
    });

    $.validator.addMethod(
        "regex",
        function (value, element, regexp) {
            return this.optional(element) || regexp.test(value);
        },
        "Please check your input."
    );

    $('#data_AccusedInformation').DataTable({
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
            url: "/api/ApiAccusedInformationMaster/Get",
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
            { title: 'પો.સ્ટે', data: 'policeStationName', "width": "150px" },
            { title: 'તારીખ', data: 'createdDate', "width": "100px" },
            { title: 'ના.ફ.આરોપીઓ હોય તેવા કુલ કેશોની સંખ્યા', data: 'totalCaches', "width": "200px" },
            { title: 'આવા કેટલા કેશોની કે.ડા. અને કાગળો ઉપલબ્ધ છે ?', data: 'availableCaches', "width": "200px" },
            { title: 'કે.ડા./કેસો ઉપલબ્ધ ન હોય તો તેના કારણો', data: 'notAvailableCachesReasonRemarks', "width": "200px" },
            { title: 'કુલ ના.ફ. આરોપીઓની સંખ્યા', data: 'totalAccused', "width": "200px" },
            { title: 'આજરોજ ના.ફ.પકડાયેલ આરોપીઓની સંખ્યા', data: 'arrestedAccused', "width": "200px" },
            { title: 'પકડવાના બાકી રહેલ ના.ફ. આરોપીઓની સંખ્યા', data: 'remainingArrestedAccused', "width": "200px" },
            { title: 'સી. આર. પી. સી. કલમ ૨૯૯ હેઠળ કરેલ કાર્યવાહી', data: 'crpcSection_299_UnderProcedure', "width": "200px" },
            { title: 'સી. આર. પી. સી. કલમ ૭0 હેઠળ કરેલ કાર્યવાહી', data: 'crpcSection_7_UnderProcedure', "width": "200px" },
            { title: 'સી. આર. પી. સી. કલમ ૮૨ હેઠળ કરેલ કાર્યવાહી', data: 'crpcSection_8_UnderProcedure', "width": "200px" },
            { title: 'સી. આર. પી. સી. કલમ ૮3 હેઠળ કરેલ કાર્યવાહી', data: 'crpcSection_83_UnderProcedure', "width": "200px" },
            { title: 'ipC_174_UnderProcedure', data: 'ipC_174_UnderProcedure', "width": "200px" },

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


    $("#form_Accused_Information").validate({

        rules: {
            policeStationId: "required",
            createdDate: "required",
            totalCaches: {
                required: true,
                regex: /^[0-9]*$/,
            },
            availableCaches: {
                required: true,
                regex: /^[0-9]*$/,
            },
            notAvailableCachesReasonRemarks: "required",
            totalAccused: {
                required: true,
                regex: /^[0-9]*$/,
            },
            arrestedAccused: {
                required: true,
                regex: /^[0-9]*$/,
            },
            remainingArrestedAccused: {
                required: true,
                regex: /^[0-9]*$/,
            },
            crpcsection299UnderProcedure: {
                required: true,
                regex: /^[0-9]*$/,
            },
            crpcsection7UnderProcedure: {
                required: true,
                regex: /^[0-9]*$/,
            },
            crpcsection8UnderProcedure: {
                required: true,
                regex: /^[0-9]*$/,
            },
            crpcsection83UnderProcedure: {
                required: true,
                regex: /^[0-9]*$/,
            },
            ipc174UnderProcedure: {
                required: true,
                regex: /^[0-9]*$/,
            },
        },

        messages: {
            policeStationId: "required",
            createdDate: "required",
            totalCaches: {
                required: "required",
                regex: "Numbers only.",
            },
            availableCaches: {
                required: "required",
                regex: "Numbers only.",
            },
            notAvailableCachesReasonRemarks: "required",
            totalAccused: {
                required: "required",
                regex: "Numbers only.",
            },
            arrestedAccused: {
                required: "required",
                regex: "Numbers only.",
            },
            remainingArrestedAccused: {
                required: "required",
                regex: "Numbers only.",
            },
            crpcsection299UnderProcedure: {
                required: "required",
                regex: "Numbers only.",
            },
            crpcsection7UnderProcedure: {
                required: "required",
                regex: "Numbers only.",
            },
            crpcsection8UnderProcedure: {
                required: "required",
                regex: "Numbers only.",
            },
            crpcsection83UnderProcedure: {
                required: "required",
                regex: "Numbers only.",
            },
            ipc174UnderProcedure: {
                required: "required",
                regex: "Numbers only.",
            },
        },

        submitHandler: () => {
            var formData = new FormData(document.getElementById("form_Accused_Information"));
            var payload = JSON.stringify(Object.fromEntries(formData));
            console.log(payload);
            $.ajax({
                url: '/api/ApiAccusedInformationMaster/Save',
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
                    $('#form_Accused_Information').trigger("reset");
                    $('#data_AccusedInformation').DataTable().ajax.reload();
                    $('#basicModal').modal('hide');
                    swal("Successfully!", "Form has been submitted.", "success");
                },
            });
        },
    });
});