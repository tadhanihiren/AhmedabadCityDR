
$(document).ready(function () {

    PopulateSearchPoliceStationDRD();

    $.validator.addMethod(
        "regex",
        function (value, element, regexp) {
            return this.optional(element) || regexp.test(value);
        },
        "Please check your input."
    );

    $("#form_NightRound").validate({
        rules: {
            designationId: "required",
            tempId: "required",
            nightRoundOfficerName: "required",
            goingTime: "required",
            returnTime: "required",
            nightRoundPlace: "required",
            remarks: "required",
            createdDate: "required",
           
        },
        messages: {
            designationId: "required",
            tempId: "required",
            nightRoundOfficerName: "required",
            goingTime: "required",
            returnTime: "required",
            nightRoundPlace: "required",
            remarks: "required",
            createdDate: "required",
           
        },

        submitHandler: () => {
            var formData = new FormData(document.getElementById("form_NightRound"));
            var payload = JSON.stringify(Object.fromEntries(formData));
            debugger
            console.log(payload);
            $.ajax({
                url: '/api/ApiNightRound/Save',
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
                    $('#form_NightRound').trigger("reset");
                    $('#basicModal').modal('hide');
                    swal("Successfully!", "Form has been submitted.", "success");
                },
            });
        },
    });
});


$("#designationId").change(function (e) {
    $("#tempId").empty(),
        $.get("/api/ApiCommon/Get_PolicestationId_For_NightRound", { designationId: $("#designationId").val() },
            function (data) {
                $("#tempId").append("<option selected disabled>--Select Sector/Zone/Division/PoliceStation:--</option>")
                console.log(data);
                $.each(data, function (index, row) {
                    $("#tempId").append("<option value='" + row.value + "'>" + row.text + "</option>")
                });
            });
});