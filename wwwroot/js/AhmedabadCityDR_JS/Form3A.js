function editData(id) {
    $("#submitbtn").html('+Save Form3A'); //Change button value to Save
    $.ajax({
        url: "/api/ApiForm3A/GetById",
        type: "Get",
        dataType: "json",
        data: { "id": id },
        headers: {
            "Accept": "application/json",
            "Content-Type": "application/json",
        },
        success: function (response) {
            console.log(response.content);
            console.log(id);
            $('#form_Form3A').trigger("reset");
            $('#basicModal').modal('show');
            Populate('#form_Form3A', response.content);
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
                url: "/api/ApiForm3A/Delete",
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

                    $('#data_Form3A').DataTable().ajax.reload();
                    swal("Successfully!", "Record has been deleted.", "success");
                },
            });

        }
    })
}

$(document).ready(function () {

    PopulateSearchPoliceStationDRD();

    $("#AddForm3A").click(() => {
        $('#form_Form3A').trigger('reset');
    });

    $("#searchButton").click(function () {
        $('#data_Form3A').DataTable().ajax.reload();
    });
    $.validator.addMethod(
        "regex",
        function (value, element, regexp) {
            return this.optional(element) || regexp.test(value);
        },
        "Please check your input."
    );

    $('#data_Form3A').DataTable({
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
            url: "/api/ApiForm3A/Get",
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
            { title: 'akasmatId', data: 'akasmatId', "width": "100px" },
            { title: 'પો.સ્ટેશન', data: 'policeStationName', "width": "100px" },
            { title: 'તારીખ', data: 'createdDate', "width": "100px" },
            { title: 'ફરીયાદી કે આરોપી ', data: 'complainant_accused', "width": "200px" },
            { title: 'ફરીયાદી/આરોપી આરોપીનું નામ ', data: 'complainant_accusedName', "width": "300px" },
            { title: 'પૂર્વ ઈતિહાસની વિગત ', data: 'historyofPast', "width": "100px" },

            {
                mRender: function (data, type, row) {
                    var bEdit = '<button type="button" class="btn btn-primary" onclick="editData(' + row.akasmatId + ')">Edit</button> ';
                    var bDelete = ' <button type="button" class="btn btn-danger" onclick="DeleteData(' + row.akasmatId + ')">Delete</button>';
                    return bEdit + bDelete;
                },
                "width": "120px",
            },
        ],
        bAutoWidth: false,
    });


    $("#form_Form3A").validate({
        rules: {
            policeStationId: "required",
            complainantAccused: "required",
            complainantAccusedName: "required",
            historyofPast: "required",
            createdDate: "required",
        },
        messages: {
            policeStationId: "required",
            complainantAccused: "required",
            complainantAccusedName: "required",
            historyofPast: "required",
            createdDate: "required",
        },

        submitHandler: () => {
            var formData = new FormData(document.getElementById("form_Form3A"));
            var payload = JSON.stringify(Object.fromEntries(formData));
            console.log(payload);
            debugger
            $.ajax({
                url: '/api/ApiForm3A/Save',
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
                    $('#form_Form3A').trigger("reset");
                    $('#data_Form3A').DataTable().ajax.reload();
                    $('#basicModal').modal('hide');
                    swal("Successfully!", "Form has been submitted.", "success");
                },
            });
        },
    });
});