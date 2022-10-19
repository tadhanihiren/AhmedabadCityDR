function editData(id) {
    $("#submitbtn").html('Save UserName & Password '); //Change button value to add
    console.log(id);
    $.ajax({
        url: "/api/ApiUserNamePassword/GetById",
        type: "Get",
        dataType: "json",
        data: { "id": id },
        headers: {
            "Accept": "application/json",
            "Content-Type": "application/json",
        },
        success: function (response) {
            console.log(response.content);
            $('#Form_LoginMaster').trigger("reset");
            $('#basicModal').modal('show');
            Populate('#Form_LoginMaster', response.content);
            $("#designationId").val("");
        },
    });
}

$(document).ready(function () {

    $("#loginbtn").click(() => {
        $('#Form_LoginMaster').trigger('reset');
    });

    $.validator.addMethod(
        "regex",
        function (value, element, regexp) {
            return this.optional(element) || regexp.test(value);
        },
        "Please check your input."
    );

    $('#data_Login_User').DataTable({
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
            url: "/api/ApiUserNamePassword/Get",
            type: "get",
            dataSrc: "content",
            dataType: "json",

            headers: {
                "Accept": "application/json",
                "Content-Type": "application/json",
            }
        },
        "columns": [
            { title: 'LoginId', data: 'loginId', "width": "100px" },
            { title: 'Policestation Name', data: 'policeStationName', "width": "100px" },
            { title: 'Sector Name', data: 'sectorName', "width": "100px" },
            { title: 'Zone Name', data: 'zoneName', "width": "100px" },
            { title: 'Division Name', data: 'divisionName', "width": "100px" },
            { title: 'UserName', data: 'userName', "width": "100px" },
            { title: 'ContactNo', data: 'contactNo', "width": "100px" },
            { title: 'Designation Name', data:'designationName',"width": "150px" },

            {
                mRender: function (data, type, row) {
                    return '<button type="button" class="btn btn-success" onclick="editData(' + row.loginId + ')">Edit</button> ';
                },
                "width": "40px",
            },
        ],
    });

    $("#Form_LoginMaster").validate({
        rules: {
            designationId: "required",
            tempId: "required",
            userName: "required",
            password: "required",
            contactNo: {
                required: true,
                regex: /^(?:(?:\+|0{0,2})91(\s*[\-]\s*)?|[0]?)?[6789]\d{9}$/,
            }
        },
        messages: {
            designationId: "required",
            tempId: "required",
            userName: "required",
            password: "required",
            contactNo: {
                required: "Required!",
                regex: "Provide Valid contactNo"
            }
        }
        ,
        submitHandler: () => {
            var formData = new FormData(document.getElementById("Form_LoginMaster"));
            var payload = JSON.stringify(Object.fromEntries(formData));

            $.ajax({
                url: '/api/ApiUserNamePassword/Save',
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
                    $('#data_Login_User').DataTable().ajax.reload();
                    $('#Form_LoginMaster').trigger("reset");
                    $('#basicModal').modal('hide');
                    swal("Successfully!", "Form has been submitted.", "success");
                },
            });
        },
    });
});

$("#designationId").change(function (e) {
    $("#tempId").empty(),
        $.get("/UserNamePassword/GetSector_Zone_Division_PoliceStationId", { designationId: $("#designationId").val() },
            function (data) {
                $("#tempId").append("<option selected disabled>--Select Sector/Zone/Division/PoliceStation:--</option>")

                $.each(data, function (index, row) {
                    $("#tempId").append("<option value='" + row.value + "'>" + row.text + "</option>")
                });
            });
});