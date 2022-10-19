using AhmedabadCityDR.Interfaces;
using AhmedabadCityDR.Models.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AhmedabadCityDR.APIs
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiTrafficLeaveApplicationMastersController : ControllerBase
    {
        #region Private Members

        /// <summary>
        /// Unit of work.
        /// </summary>
        private readonly IUnitOfWork _unitOfWork;

        #endregion

        #region Constructors

        /// <summary>
        /// Constructors
        /// </summary>
        public ApiTrafficLeaveApplicationMastersController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        #endregion

        #region Get Methods

        [HttpGet("GetTrafficLeaveApplication")]
        public JsonResult GetTrafficLeaveApplication(DateTime? fromDate, DateTime? toDate)
        {
            if (!fromDate.HasValue)
            {
                fromDate = DateTime.Now.Date;
            }

            if (!toDate.HasValue)
            {
                toDate = DateTime.Now.Date;
            }

            var user = HttpContext.GetClaimsPrincipal();

            int roleId = Convert.ToInt32(user.RoleId);
            int zoneId = Convert.ToInt32(user.ZoneId);
            int divisionId = Convert.ToInt32(user.DivisionId);
            int policeStationId = Convert.ToInt32(user.PoliceStationId);

            var lstLeaveTypeMaster = new List<Traffic_LeaveApplicationViewModel>();

            var data = _unitOfWork.TrafficLeaveApplication.GetTrafficLeaveApplication(fromDate.Value, toDate.Value, false);

            if (policeStationId == 0 && (roleId == 2 || roleId == 1 || roleId == 3) && zoneId == 0 && divisionId == 0)
            {
                foreach (var item in data)
                {
                    var lc = new Traffic_LeaveApplicationViewModel();
                    lc.CreatedDate = item.CreatedDate;
                    lc.CreatedUserId = item.CreatedUserId;
                    lc.DesignationId = item.DesignationId;
                    lc.DesignationName = item.DesignationName;
                    lc.EmployeeId = item.EmployeeId;
                    lc.EmployeName = item.EmployeName;
                    lc.FromDate = item.FromDate;
                    lc.InchargeDesignationId = item.InchargeDesignationId;
                    lc.InchargeDesignationName = item.InchargeDesignationName;
                    lc.InchargeEmployeeId = item.InchargeEmployeeId;
                    lc.InchargeEmployeName = item.InchargeEmployeName;
                    lc.IsActive = item.IsActive;
                    lc.IsDelete = item.IsActive;
                    lc.IsTraffic = item.IsTraffic;
                    lc.LeaveApplicationID = item.LeaveApplicationID;
                    lc.LeaveTypeId = item.LeaveTypeId;
                    lc.LeaveTypeName = item.LeaveTypeName;
                    lc.ModifiedDate = item.ModifiedDate;
                    lc.ModifiedUserId = item.ModifiedUserId;
                    lc.Remarks = item.Remarks;
                    lc.ToDate = item.ToDate;
                    lc.TotalDays = item.TotalDays;
                    lc.ZoneId = item.ZoneId;
                    lc.ZoneName = item.ZoneName;
                    if (item.DesignationId == 2 || item.DesignationId == 15)
                    {
                        lc.PoliceStationId = item.SectorId;
                        lc.PoliceStationName = item.SectorName;
                    }
                    else if (item.DesignationId == 3)
                    {
                        lc.PoliceStationId = item.ZoneId;
                        lc.PoliceStationName = item.ZoneName;
                    }
                    else if (item.DesignationId == 4)
                    {
                        lc.PoliceStationId = item.DivisionId;
                        lc.PoliceStationName = item.DivisionName;
                    }
                    else if (item.DesignationId == 5 || item.DesignationId == 6)
                    {
                        lc.PoliceStationId = item.PoliceStationId;
                        lc.PoliceStationName = item.PoliceStationName;
                    }

                    if (item.InchargeDesignationId == 2 || item.InchargeDesignationId == 15)
                    {
                        lc.InchargePoliceStationId = item.InchargeSectorId;
                        lc.InchrgePoliceStationName = item.InchargeSectorName;
                    }
                    else if (item.InchargeDesignationId == 3)
                    {
                        lc.InchargePoliceStationId = item.InchargeZoneId;
                        lc.InchrgePoliceStationName = item.InchargeZoneName;
                    }
                    else if (item.InchargeDesignationId == 4)
                    {
                        lc.InchargePoliceStationId = item.InchargeDivisionId;
                        lc.InchrgePoliceStationName = item.InchargeDivisionName;
                    }
                    else if (item.InchargeDesignationId == 5 || item.InchargeDesignationId == 6)
                    {
                        lc.InchargePoliceStationId = item.InchargePoliceStationId;
                        lc.InchrgePoliceStationName = item.InchrgePoliceStationName;
                    }

                    lstLeaveTypeMaster.Add(lc);
                }
            }
            else if (zoneId != 0 && divisionId == 0 && policeStationId == 0 && roleId == 4)
            {
                foreach (var item in data)
                {
                    var LC = new Traffic_LeaveApplicationViewModel();
                    LC.CreatedDate = item.CreatedDate;
                    LC.CreatedUserId = item.CreatedUserId;
                    LC.DesignationId = item.DesignationId;
                    LC.DesignationName = item.DesignationName;
                    LC.EmployeeId = item.EmployeeId;
                    LC.EmployeName = item.EmployeName;
                    LC.FromDate = item.FromDate;
                    LC.InchargeDesignationId = item.InchargeDesignationId;
                    LC.InchargeDesignationName = item.InchargeDesignationName;
                    LC.InchargeEmployeeId = item.InchargeEmployeeId;
                    LC.InchargeEmployeName = item.InchargeEmployeName;
                    LC.IsActive = item.IsActive;
                    LC.IsDelete = item.IsActive;
                    LC.IsTraffic = item.IsTraffic;
                    LC.LeaveApplicationID = item.LeaveApplicationID;
                    LC.LeaveTypeId = item.LeaveTypeId;
                    LC.LeaveTypeName = item.LeaveTypeName;
                    LC.ModifiedDate = item.ModifiedDate;
                    LC.ModifiedUserId = item.ModifiedUserId;
                    LC.Remarks = item.Remarks;
                    LC.ToDate = item.ToDate;
                    LC.TotalDays = item.TotalDays;
                    LC.ZoneId = item.ZoneId;
                    LC.ZoneName = item.ZoneName;
                    if (item.DesignationId == 2 || item.DesignationId == 15)
                    {
                        LC.PoliceStationId = item.SectorId;
                        LC.PoliceStationName = item.SectorName;
                    }
                    else if (item.DesignationId == 3)
                    {
                        LC.PoliceStationId = item.ZoneId;
                        LC.PoliceStationName = item.ZoneName;
                    }
                    else if (item.DesignationId == 4)
                    {
                        LC.PoliceStationId = item.DivisionId;
                        LC.PoliceStationName = item.DivisionName;
                    }
                    else if (item.DesignationId == 5 || item.DesignationId == 6)
                    {
                        LC.PoliceStationId = item.PoliceStationId;
                        LC.PoliceStationName = item.PoliceStationName;
                    }

                    if (item.InchargeDesignationId == 2 || item.InchargeDesignationId == 15)
                    {
                        LC.InchargePoliceStationId = item.InchargeSectorId;
                        LC.InchrgePoliceStationName = item.InchargeSectorName;
                    }
                    else if (item.InchargeDesignationId == 3)
                    {
                        LC.InchargePoliceStationId = item.InchargeZoneId;
                        LC.InchrgePoliceStationName = item.InchargeZoneName;
                    }
                    else if (item.InchargeDesignationId == 4)
                    {
                        LC.InchargePoliceStationId = item.InchargeDivisionId;
                        LC.InchrgePoliceStationName = item.InchargeDivisionName;
                    }
                    else if (item.InchargeDesignationId == 5 || item.InchargeDesignationId == 6)
                    {
                        LC.InchargePoliceStationId = item.InchargePoliceStationId;
                        LC.InchrgePoliceStationName = item.InchrgePoliceStationName;
                    }
                    lstLeaveTypeMaster.Add(LC);
                }
            }
            else if (zoneId == 0 && divisionId != 0 && policeStationId == 0 && roleId == 5)
            {
                foreach (var item in data)
                {
                    var LC = new Traffic_LeaveApplicationViewModel();
                    LC.CreatedDate = item.CreatedDate;
                    LC.CreatedUserId = item.CreatedUserId;
                    LC.DesignationId = item.DesignationId;
                    LC.DesignationName = item.DesignationName;
                    LC.EmployeeId = item.EmployeeId;
                    LC.EmployeName = item.EmployeName;
                    LC.FromDate = item.FromDate;
                    LC.InchargeDesignationId = item.InchargeDesignationId;
                    LC.InchargeDesignationName = item.InchargeDesignationName;
                    LC.InchargeEmployeeId = item.InchargeEmployeeId;
                    LC.InchargeEmployeName = item.InchargeEmployeName;
                    LC.IsActive = item.IsActive;
                    LC.IsDelete = item.IsActive;
                    LC.IsTraffic = item.IsTraffic;
                    LC.LeaveApplicationID = item.LeaveApplicationID;
                    LC.LeaveTypeId = item.LeaveTypeId;
                    LC.LeaveTypeName = item.LeaveTypeName;
                    LC.ModifiedDate = item.ModifiedDate;
                    LC.ModifiedUserId = item.ModifiedUserId;
                    LC.Remarks = item.Remarks;
                    LC.ToDate = item.ToDate;
                    LC.TotalDays = item.TotalDays;
                    LC.ZoneId = item.ZoneId;
                    LC.ZoneName = item.ZoneName;
                    if (item.DesignationId == 2 || item.DesignationId == 15)
                    {
                        LC.PoliceStationId = item.SectorId;
                        LC.PoliceStationName = item.SectorName;
                    }
                    else if (item.DesignationId == 3)
                    {
                        LC.PoliceStationId = item.ZoneId;
                        LC.PoliceStationName = item.ZoneName;
                    }
                    else if (item.DesignationId == 4)
                    {
                        LC.PoliceStationId = item.DivisionId;
                        LC.PoliceStationName = item.DivisionName;
                    }
                    else if (item.DesignationId == 5 || item.DesignationId == 6)
                    {
                        LC.PoliceStationId = item.PoliceStationId;
                        LC.PoliceStationName = item.PoliceStationName;
                    }

                    if (item.InchargeDesignationId == 2 || item.InchargeDesignationId == 15)
                    {
                        LC.InchargePoliceStationId = item.InchargeSectorId;
                        LC.InchrgePoliceStationName = item.InchargeSectorName;
                    }
                    else if (item.InchargeDesignationId == 3)
                    {
                        LC.InchargePoliceStationId = item.InchargeZoneId;
                        LC.InchrgePoliceStationName = item.InchargeZoneName;
                    }
                    else if (item.InchargeDesignationId == 4)
                    {
                        LC.InchargePoliceStationId = item.InchargeDivisionId;
                        LC.InchrgePoliceStationName = item.InchargeDivisionName;
                    }
                    else if (item.InchargeDesignationId == 5 || item.InchargeDesignationId == 6)
                    {
                        LC.InchargePoliceStationId = item.InchargePoliceStationId;
                        LC.InchrgePoliceStationName = item.InchrgePoliceStationName;
                    }
                    lstLeaveTypeMaster.Add(LC);
                }
            }
            else if (policeStationId != 0)
            {
                foreach (var item in data)
                {
                    var LC = new Traffic_LeaveApplicationViewModel();
                    LC.CreatedDate = item.CreatedDate;
                    LC.CreatedUserId = item.CreatedUserId;
                    LC.DesignationId = item.DesignationId;
                    LC.DesignationName = item.DesignationName;
                    LC.EmployeeId = item.EmployeeId;
                    LC.EmployeName = item.EmployeName;
                    LC.FromDate = item.FromDate;
                    LC.InchargeDesignationId = item.InchargeDesignationId;
                    LC.InchargeDesignationName = item.InchargeDesignationName;
                    LC.InchargeEmployeeId = item.InchargeEmployeeId;
                    LC.InchargeEmployeName = item.InchargeEmployeName;
                    LC.IsActive = item.IsActive;
                    LC.IsDelete = item.IsActive;
                    LC.IsTraffic = item.IsTraffic;
                    LC.LeaveApplicationID = item.LeaveApplicationID;
                    LC.LeaveTypeId = item.LeaveTypeId;
                    LC.LeaveTypeName = item.LeaveTypeName;
                    LC.ModifiedDate = item.ModifiedDate;
                    LC.ModifiedUserId = item.ModifiedUserId;
                    LC.Remarks = item.Remarks;
                    LC.ToDate = item.ToDate;
                    LC.TotalDays = item.TotalDays;
                    LC.ZoneId = item.ZoneId;
                    LC.ZoneName = item.ZoneName;
                    if (item.DesignationId == 2 || item.DesignationId == 15)
                    {
                        LC.PoliceStationId = item.SectorId;
                        LC.PoliceStationName = item.SectorName;
                    }
                    else if (item.DesignationId == 3)
                    {
                        LC.PoliceStationId = item.ZoneId;
                        LC.PoliceStationName = item.ZoneName;
                    }
                    else if (item.DesignationId == 4)
                    {
                        LC.PoliceStationId = item.DivisionId;
                        LC.PoliceStationName = item.DivisionName;
                    }
                    else if (item.DesignationId == 5 || item.DesignationId == 6)
                    {
                        LC.PoliceStationId = item.PoliceStationId;
                        LC.PoliceStationName = item.PoliceStationName;
                    }

                    if (item.InchargeDesignationId == 2 || item.InchargeDesignationId == 15)
                    {
                        LC.InchargePoliceStationId = item.InchargeSectorId;
                        LC.InchrgePoliceStationName = item.InchargeSectorName;
                    }
                    else if (item.InchargeDesignationId == 3)
                    {
                        LC.InchargePoliceStationId = item.InchargeZoneId;
                        LC.InchrgePoliceStationName = item.InchargeZoneName;
                    }
                    else if (item.InchargeDesignationId == 4)
                    {
                        LC.InchargePoliceStationId = item.InchargeDivisionId;
                        LC.InchrgePoliceStationName = item.InchargeDivisionName;
                    }
                    else if (item.InchargeDesignationId == 5 || item.InchargeDesignationId == 6)
                    {
                        LC.InchargePoliceStationId = item.InchargePoliceStationId;
                        LC.InchrgePoliceStationName = item.InchrgePoliceStationName;
                    }
                    lstLeaveTypeMaster.Add(LC);
                }
            }

            var responseData = lstLeaveTypeMaster.Select(x => new
            {
                x.LeaveApplicationID,
                x.PoliceStationName,
                FromDate = x.FromDate.Value.ToString("dd/MM/yyyy"),
                ToDate = x.ToDate.Value.ToString("dd/MM/yyyy"),
                x.DesignationName,
                x.EmployeName,
                x.InchrgePoliceStationName,
                x.InchargeDesignationName,
                x.InchargeEmployeName,
                x.LeaveTypeName,
                x.TotalDays,
                x.Remarks
            });

            return new JsonResult(new
            {
                Success = true,
                Headers = "LeaveApplication",
                Header_Title = "LeaveApplication",
                Header_Desc = $"તારીખ : {fromDate.Value.Date} થી : {toDate.Value.Date}",
                Content = responseData
            });
        }

        #endregion
    }
}
