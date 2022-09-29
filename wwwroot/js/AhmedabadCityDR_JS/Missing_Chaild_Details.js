function EditData(id) {
    $("#submitbtn").html('Save ગુમ થયેલ બાળકો'); //Change button value to Save
    $.ajax({
        url: "/api/ApiMissingChildDetails/GetById",
        type: "Get",
        dataType: "json",
        data: { "id": id },
        headers: {
            "Accept": "application/json",
            "Content-Type": "application/json",
        },
        success: function (response) {
            console.log(response.content);
            $('#form_MissingChild').trigger("reset");
            $('#basicModal').modal('show');
            Populate('#form_MissingChild', response.content);
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
                url: "/api/ApiMissingChildDetails/Delete",
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

                    $('#data_MissingChild').DataTable().ajax.reload();
                    swal("Successfully!", "Record has been deleted.", "success");
                },
            });

        }
    })
}

$(document).ready(() => {

    PopulateSearchPoliceStationDRD();

    $("#addData").click(() => {
        $('#form_MissingChild').trigger('reset');
        $("#submitbtn").html('+ ADD ગુમ થયેલ બાળકો'); //Change button value to add
    });

    $("#searchButton").click(function () {
        $('#data_MissingChild').DataTable().ajax.reload();
    });

    $('#data_MissingChild').DataTable({
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
            url: "/api/ApiMissingChildDetails/Get",
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
            { title: 'ગુમ થનારનું નામ સરનામું', data: 'missingPersonName', "width": "300px" },
            { title: 'ગુમ થવાનું કારણ', data: 'missingReson', "width": "300px" },
            { title: 'જાતિ', data: 'gender', "width": "50px" },
            { title: 'ઉંમર', data: 'age', "width": "50px" },
            { title: 'ગુમ થયાની તારીખ', data: 'missingDate', "width": "80px" },
            { title: 'પરત મળ્યાની તારીખ', data: 'returnDate', "width": "80px" },
            { title: 'પો.સ્ટે. ગુમ અરજી નં.તા. તથા સ્ટે.ડા. તારીખ', data: 'missingApplicationNo_Date', "width": "200px" },
            { title: 'જાહેર કરનારનું  સરનામું', data: 'publisherName_Address', "width": "300px" },
            { title: 'સંપર્ક મો.નં./ટે.નં.', data: 'mobileNo', "width": "80px" },
            {
                mRender: function (data, type, row) {
                    var bEdit = '<button type="button" class="btn btn-success" onclick="EditData(' + row.missingChildId + ')">Edit</button> ';
                    var bDelete = ' <button type="button" class="btn btn-danger" onclick="DeleteData(' + row.missingChildId + ')">Delete</button>';
                    return bEdit + bDelete;
                },
                "width": "100px",
            },
        ],
    });

    $("#form_MissingChild").validate({
        rules: {
            policeStationId: "required",
            missingChildId: "required",
            createdDate: "required",
            missingPersonName: "required",
            missingReson: "required",
            genderId: "required",
            age: {
                required: true,
                regex: /^[0-9]*$/,
            },
            missingDate: "required",
            missingApplicationNo_Date: "required",
            publisherName_Address: "required",
            mobileNo: {
                required: true,
                regex: /^(?:(?:\+|0{0,2})91(\s*[\-]\s*)?|[0]?)?[6789]\d{9}$/,
            },
        },
        messages: {
            policeStationId: "Required!",
            missingChildId: "Required!",
            createdDate: "Required!",
            missingPersonName: "Required!",
            missingReson: "Required!",
            genderId: "Required!",
            age: {
                required: "Required!",
                regex: "Provide valid age!",
            },
            missingDate: "Required!",
            missingApplicationNo_Date: "Required!",
            publisherName_Address: "Required!",
            mobileNo: {
                required: "Required!",
                regex: "Provide Valid contactNo"
            },
        },
        submitHandler: () => {
            var formData = new FormData(document.getElementById("form_MissingChild"));
            var payload = JSON.stringify(Object.fromEntries(formData));
            //console.log(payload);
            $.ajax({
                url: "/api/ApiMissingChildDetails/Save",
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

                    $('#data_MissingChild').DataTable().ajax.reload();
                    $('#form_MissingChild').trigger("reset");
                    $('#basicModal').modal('hide');
                    swal("Successfully!", "Form has been submitted.", "success");
                },
            });
        },
    });

    $.get("/api/ApiCommon/GetGender",
        function (data) {
            //console.log(data);
            $.each(data,
                function (index, row) {
                    //console.log(row);
                    $("#genderId").append("<option value='" + row.value + "'>" + row.text + "</option>");
                }
            );
        },
    );
});