function EditData(id) {
  $("#submitbtn").html("Save નાઇટ અઘિકારી"); //Change button value to Save
  $.ajax({
    url: "/api/ApiNightEmployeeMaster/GetById",
    type: "Get",
    dataType: "json",
    data: { id: id },
    headers: {
      Accept: "application/json",
      "Content-Type": "application/json",
    },
    success: function (response) {
      //console.log(response.content);
      $("#form_Night_Employee_Round").trigger("reset");
      $("#basicModal").modal("show");
      Populate("#form_Night_Employee_Round", response.content);
    },
  });
}

function DeleteData(id) {
  swal({
    title: "Are you sure?",
    icon: "warning",
    buttons: ["No, cancel it!", "Yes, I am sure!"],
    dangerMode: true,
  }).then((isConfirm) => {
    if (isConfirm) {
      $.ajax({
        url: "/api/ApiNightEmployeeMaster/Delete",
        type: "get",
        dataType: "json",
        data: { id: id },
        headers: {
          Accept: "application/json",
          "Content-Type": "application/json",
        },
        success: function (response) {
          if (!response.isValid) {
            swal(response.error, "", "error");
            return;
          }

          $("#data_Night_Employee_Round").DataTable().ajax.reload();
          swal("Successfully!", "Record has been deleted.", "success");
        },
      });
    }
  });
}

$(document).ready(() => {
  PopulateSearchPoliceStationDRD();

  $("#addData").click(() => {
    $("#prohibitionCat").hide();
    $("#form_Night_Employee_Round").trigger("reset");
    $("#submitbtn").html("+ ADD નાઇટ અઘિકારી"); //Change button value to add
  });

  $("#searchButton").click(function () {
    $("#data_Night_Employee_Round").DataTable().ajax.reload();
  });

  $("#data_Night_Employee_Round").DataTable({
    processing: true,
    language: {
      processing: '<div class="spinner-grow text-primary" role="status"></div>',
    },
    lengthMenu: [
      [10, 50, 100, 500, 1000, 1500, 2000],
      [10, 50, 100, 500, 1000, 1500, 2000],
    ],
    columnStyle: true,
    scrollX: true,
    sScrollXInner: "100%",
    destroy: true,
    info: true,
    bLengthChange: true,
    bFilter: true,
    autoWidth: false,
    bAutoWidth: false,
    ajax: {
      url: "/api/ApiNightEmployeeMaster/Get",
      type: "get",
      dataSrc: "content",
      dataType: "json",
      data: function (d) {
        d.fromDate = $("#searchFromDate").val();
        d.toDate = $("#searchToDate").val();
        d.searchPoliceStationId = $("#searchPoliceStationId").val();
      },
      headers: {
        Accept: "application/json",
        "Content-Type": "application/json",
      },
    },
    columns: [
      {
        title: "પોલીસ સ્ટેશન",
        data: "policeStationName",
        width: "100px",
      },
      {
        title: "અધિકારીનુ નામ",
        data: "employeName",
        width: "200px",
      },
      {
        title: "તારીખ",
        data: "createdDate",
        width: "100px",
      },
      {
        title: "હોદ્દો",
        data: "designationName",
        width: "100px",
      },
      {
        title: "જવાનો સમય",
        data: "goingTime",
        width: "100px",
      },
      {
        title: "પરત સમય",
        data: "returnTime",
        width: "100px",
      },
      {
        title: "રિમાર્કસ",
        data: "remarks",
        width: "100px",
      },
      {
        mRender: function (data, type, row) {
          var bEdit =
            '<button type="button" class="btn btn-success" onclick="EditData(' +
            row.nightEmployeeId +
            ')">Edit</button> ';
          var bDelete =
            ' <button type="button" class="btn btn-danger" onclick="DeleteData(' +
            row.nightEmployeeId +
            ')">Delete</button>';
          return bEdit + bDelete;
        },
        width: "120px",
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

  $("#form_Night_Employee_Round").validate({
    rules: {
      policeStationId: "required",
      designationId: "required",
      employeeId: "required",
      goingTime: "required",
      returnTime: "required",
      remarks: "required",
      createdDate: "required",
    },
    submitHandler: () => {
      var formData = new FormData(
        document.getElementById("form_Night_Employee_Round")
      );
      var payload = JSON.stringify(Object.fromEntries(formData));
      //console.log(payload);
      $.ajax({
        url: "/api/ApiNightEmployeeMaster/Save",
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

          $("#data_Night_Employee_Round").DataTable().ajax.reload();
          $("#form_Night_Employee_Round").trigger("reset");
          $("#basicModal").modal("hide");
          swal("Successfully!", "Form has been submitted.", "success");
        },
      });
    },
  });

  /* Get leave taking employye details */
  $.get(
    "/api/ApiCommon/Get_DesignationId_For_NightEmployeeRound",
    function (data) {
      //console.log(data);
      $.each(data, function (index, row) {
        //console.log(row);
        $("#designationId").append(
          "<option value='" + row.value + "'>" + row.text + "</option>"
        );
      });
    }
  );

  $("#designationId").change(function (e) {
    $("#employeeId").empty();
    $.get(
      "/api/ApiCommon/GetEmployee",
      {
        designationId: $("#designationId").val(),
        policeStationId: $("#policeStationId").val(),
      },
      function (data) {
        $("#employeeId").append(
          "<option selected disabled>--Select Employee Name--</option>"
        );

        $.each(data, function (index, row) {
          //console.log(row);
          $("#employeeId").append(
            "<option value='" + row.value + "'>" + row.text + "</option>"
          );
        });
      }
    );
  });
});
