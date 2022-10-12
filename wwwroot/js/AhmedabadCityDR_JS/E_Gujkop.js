function EditData(id) {
    $("#submitbtn").html('Save ઈ-ગુજકોપ હેઠળ થયેલ છેલ્લી એન્ટ્રી'); //Change button value to Save
    $.ajax({
        url: "/api/ApiEGujakopMaster/GetById",
        type: "Get",
        dataType: "json",
        data: { "id": id },
        headers: {
            "Accept": "application/json",
            "Content-Type": "application/json",
        },
        success: function (response) {
            /*console.log(response.content);*/
            $('#form_E_Gujkop').trigger("reset");
            $('#basicModal').modal('show');
            Populate('#form_E_Gujkop', response.content);
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
                url: "/api/ApiEGujakopMaster/Delete",
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

                    $('#data_E_Gujkop').DataTable().ajax.reload();
                    swal("Successfully!", "Record has been deleted.", "success");
                },
            });

        }
    })
}

$(document).ready(() => {

    PopulateSearchPoliceStationDRD();

    $("#addData").click(() => {
        $('#form_E_Gujkop').trigger('reset');
        $("#submitbtn").html('+ ADD ઈ-ગુજકોપ હેઠળ થયેલ છેલ્લી એન્ટ્રી'); //Change button value to add
    });

    $("#searchButton").click(function () {
        $('#data_E_Gujkop').DataTable().ajax.reload();
    });

    $('#data_E_Gujkop').DataTable({
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
            url: "/api/ApiEGujakopMaster/Get",
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
            { title: 'ભાગ ૧ થી ૫ છેલ્લો ગુ.ર.નં.', data: 'part1to5number', "width": "200px" },
            { title: 'ભાગ ૧ થી ૫ ઈગુજકોપ હેઠળ એન્ટ્રી કરેલ છેલ્લો ગુ.ર.નં.', data: 'part1to5E_Gujakop', "width": "200px" },
            { title: 'ભાગ ૬ છેલ્લો ગુ.ર.નં.', data: 'part6number', "width": "200px" },
            { title: 'ભાગ ૬ ઈગુજકોપ હેઠળ એન્ટ્રી કરેલ છેલ્લો ગુ.ર.નં.', data: 'part6E_Gujakop', "width": "200px" },
            { title: 'પ્રોહી છેલ્લો ગુ.ર.નં.', data: 'prohiNumber', "width": "200px" },
            { title: 'પ્રોહી ઈ ગુજકોપ હેઠળ એન્ટ્રી કરેલ છેલ્લો ગુ.ર.નં.', data: 'prohiE_Gujakop', "width": "200px" },
            { title: 'એમ.કેસ છેલ્લો ગુ.ર.નં.', data: 'a_amNumber', "width": "200px" },
            { title: 'એમ.કેસ ઈગુજકોપ હેઠળ એન્ટ્રી કરેલ છેલ્લો ગુ.ર.નં.', data: 'a_amE_Gujakop', "width": "200px" },
            { title: 'અકસ્માત મોત છેલ્લો અ.મોત .નં.', data: 'acciendentNumber', "width": "200px" },
            { title: 'અકસ્માત મોત ઈ ગુજકોપ હેઠળ એન્ટ્રી કરેલ છેલ્લો અ.મોત નં.', data: 'acciendentE_Gujakop', "width": "200px" },
            { title: 'જાણવા જોગ છેલ્લો જા.જોગ એ.નં.', data: 'janvajogNumber', "width": "200px" },
            { title: 'જાણવા જોગ ઈ ગુજકોપ હેઠળ એન્ટ્રી કરેલ છેલ્લી  જા.જોગ એ..નં.', data: 'janvajogE_Gujakop', "width": "200px" },
            {
                mRender: function (data, type, row) {
                    var bEdit = '<button type="button" class="btn btn-success" onclick="EditData(' + row.e_GujakopId + ')">Edit</button> ';
                    var bDelete = ' <button type="button" class="btn btn-danger" onclick="DeleteData(' + row.e_GujakopId + ')">Delete</button>';
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

    $("#form_E_Gujkop").validate({
        rules: {
            policeStationId: "required",
            createdDate: "required",
            part1to5number: {
                required: true,
                regex: /^[0-9]*$/,
            },
            part1to5EGujakop: {
                required: true,
                regex: /^[0-9]*$/,
            },
            part6number: {
                required: true,
                regex: /^[0-9]*$/,
            },
            part6EGujakop: {
                required: true,
                regex: /^[0-9]*$/,
            },
            prohiNumber: {
                required: true,
                regex: /^[0-9]*$/,
            },
            prohiEGujakop: {
                required: true,
                regex: /^[0-9]*$/,
            },
            aAmNumber: {
                required: true,
                regex: /^[0-9]*$/,
            },
            aAmEGujakop: {
                required: true,
                regex: /^[0-9]*$/,
            },
            acciendentNumber: {
                required: true,
                regex: /^[0-9]*$/,
            },
            acciendentEGujakop: {
                required: true,
                regex: /^[0-9]*$/,
            },
            janvajogNumber: {
                required: true,
                regex: /^[0-9]*$/,
            },
            janvajogEGujakop: {
                required: true,
                regex: /^[0-9]*$/,
            },
        },
        messages: {
            policeStationId: "Required!",
            createdDate: "Required!",
            part1to5number: {
                required: "required!",
                regex: "Numbers only.",
            },
            part1to5EGujakop: {
                required: "required!",
                regex: "Numbers only.",
            },
            part6number: {
                required: "required!",
                regex: "Numbers only.",
            },
            part6EGujakop: {
                required: "required!",
                regex: "Numbers only.",
            },
            prohiNumber: {
                required: "required!",
                regex: "Numbers only.",
            },
            prohiEGujakop: {
                required: "required!",
                regex: "Numbers only.",
            },
            aAmNumber: {
                required: "required!",
                regex: "Numbers only.",
            },
            aAmEGujakop: {
                required: "required!",
                regex: "Numbers only.",
            },
            acciendentNumber: {
                required: "required!",
                regex: "Numbers only.",
            },
            acciendentEGujakop: {
                required: "required!",
                regex: "Numbers only.",
            },
            janvajogNumber: {
                required: "required!",
                regex: "Numbers only.",
            },
            janvajogEGujakop: {
                required: "required!",
                regex: "Numbers only.",
            },
        },
        submitHandler: () => {
            var formData = new FormData(document.getElementById("form_E_Gujkop"));
            var payload = JSON.stringify(Object.fromEntries(formData));
            //console.log(payload);
            $.ajax({
                url: "/api/ApiEGujakopMaster/Save",
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

                    $('#data_E_Gujkop').DataTable().ajax.reload();
                    $('#form_E_Gujkop').trigger("reset");
                    $('#basicModal').modal('hide');
                    swal("Successfully!", "Form has been submitted.", "success");
                },
            });
        },
    });
});