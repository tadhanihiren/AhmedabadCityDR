function editData(id) {
    $.ajax({
        url: "/api/ApiInternalTransffer/GetById",
        type: "Get",
        dataType: "json",
        data: { "id": id },
        headers: {
            "Accept": "application/json",
            "Content-Type": "application/json",
        },
        success: function (response) {

            var responseData = response.content

            console.log(responseData);
            $('#form_InternalTransffer').trigger("reset");
            $('#basicModal').modal('show');

            $.get("/api/ApiCommon/GetAllDesignation",
                function (data) {
                    //console.log(data);
                    $.each(data,
                        function (index, row) {
                            //console.log(row);
                            $("#designationId").append("<option value='" + row.value + "'>" + row.text + "</option>");
                        }
                    );
                },
            );
            $("#designationId").val(responseData.designationId);

            //console.log(responseData.designationId);
            if (responseData.designationId != null && responseData.designationId != "1") {

                $.get("/api/ApiCommon/GetInternalTransfferPoliceStation",
                    { designationId: responseData.designationId },
                    function (data) {
                        //console.log(data);
                        $.each(data,
                            function (index, row) {
                                //console.log(row);
                                $("#tempId").append("<option value='" + row.value + "'>" + row.text + "</option>");
                                $("#transfferTempId").append("<option value='" + row.value + "'>" + row.text + "</option>");
                            }
                        );
                    },
                );

                var roleId = parseInt(responseData.designationId);

                if (roleId == 2 || roleId == 15) {
                    $("#tempId").val(responseData.sectorId);
                }

                if (roleId == 3) {
                    $("#tempId").val(responseData.zoneId);
                }

                if (roleId == 4) {
                    $("#tempId").val(responseData.divisionId);
                }

                if (roleId >= 5 || roleId != 15) {
                    $("#tempId").val(responseData.policeStationId);
                }
            }

            Populate('#form_InternalTransffer', responseData);
        },
    });
}
$(document).ready(function () {

    PopulateSearchPoliceStationDRD();

    $("#searchButton").click(function () {
        $('#data_InternalTransffer').DataTable().ajax.reload();
    });

    $.validator.addMethod(
        "regex",
        function (value, element, regexp) {
            return this.optional(element) || regexp.test(value);
        },
        "Please check your input."
    );

    $('#data_InternalTransffer').DataTable({
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
            url: "/api/ApiInternalTransffer/Get",
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
            { title: 'પો.સ્ટે', data: 'policeStationName', "width": "75px" },
            { title: 'હોદ્દો', data: 'designationName', "width": "40px" },
            { title: 'બકલ નં.', data: 'buckleNo', "width": "50px" },
            { title: 'અધિકારીનું નામ', data: 'employeName', "width": "100px" },
            { title: 'સંપર્ક નંબર', data: 'contactNumber', "width": "60px" },
            { title: 'પ્રતિનિયુક્ત નામ', data: 'prtiniyukatName', "width": "100px" },
            { title: 'fromdate', data: 'fromdate', "width": "70px" },
            { title: 'todate', data: 'todate', "width": "70px" },
            { title: 'પ્રતિનિયુક્ત જગ્યા', data: 'prtiniyukatPlace', "width": "100px" },
            { title: 'તારીખ', data: 'createdDate', "width": "70px" },
            {
                mRender: function (data, type, row) {
                    return '<button type="button" class="btn btn-success" onclick="editData(' + row.employeeId + ')">Edit</button> ';
                },
                "width": "50px",
            },

        ],
    });

    $("#form_InternalTransffer").validate({

        rules: {
            designationId: "required",
            tempId: "required",
            buckleNo: "required",
            employeName: "required",
            createdDate: "required",
            transfferTempId: "required",
            contactNumber: {
                required: true,
                regex: /^(?:(?:\+|0{0,2})91(\s*[\-]\s*)?|[0]?)?[6789]\d{9}$/,
            },
        },
        messages: {
            designationId: "required",
            tempId: "required",
            buckleNo: "required",
            employeName: "required",
            createdDate: "required",
            transfferTempId: "required",
            ptzInstalled: {
                required: "required",
                regex: "Provide Valid contactNo.",
            },
        },
        submitHandler: () => {
            var formData = new FormData(document.getElementById("form_InternalTransffer"));
            var payload = JSON.stringify(Object.fromEntries(formData));
            console.log(payload);
            $.ajax({
                url: '/api/ApiInternalTransffer/Save',
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
                    $('#form_InternalTransffer').trigger("reset");
                    $('#data_InternalTransffer').DataTable().ajax.reload();
                    $('#basicModal').modal('hide');
                    swal("Successfully!", "Form has been submitted.", "success");
                },
            });
        },
    });

    $("#designationId").change(
        function (e) {
            $("#tempId").empty();
            $("#transfferTempId").empty();
            $.get("/api/ApiCommon/GetInternalTransfferPoliceStation",
                { designationId: $("#designationId").val() },
                function (data) {
                    //console.log(data);
                    $("#tempId").append("<option selected disabled>--Select Sector/Zone/Division/PoliceStation:--</option>")
                    $("#transfferTempId").append("<option selected disabled>--Select Sector/Zone/Division/PoliceStation:--</option>")

                    $.each(data, function (index, row) {
                        //console.log(row);
                        $("#tempId").append("<option value='" + row.value + "'>" + row.text + "</option>")
                        $("#transfferTempId").append("<option value='" + row.value + "'>" + row.text + "</option>")
                    });
                },
            );
        }
    );
});
