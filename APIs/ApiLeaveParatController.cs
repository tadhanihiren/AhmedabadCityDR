using AhmedabadCityDR.Interfaces;
using AhmedabadCityDR.Models.APIModels;
using AhmedabadCityDR.Models.TableModels;
using AhmedabadCityDR.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace AhmedabadCityDR.APIs
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiLeaveParatController : ControllerBase
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
        public ApiLeaveParatController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        #endregion

        #region Get Methods

        [HttpGet("GetById")]
        public JsonResult GetById(int? id)
        {
            return new JsonResult(new
            {
                Content = _unitOfWork.LeaveApplication.Find(x => x.LeaveApplicationId == id),
            });
        }

        [HttpGet("GetLeaveApplication")]
        public JsonResult GetLeaveApplication(DateTime? fromDate, DateTime? toDate)
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

            var lstLeaveTypeMaster = new List<LeaveApplicationMasterViewModel>();

            var data = _unitOfWork.LeaveApplication.GetLeaveApplication(fromDate.Value, toDate.Value, false);

            if (policeStationId == 0 && (roleId == 2 || roleId == 1 || roleId == 3) && zoneId == 0 && divisionId == 0)
            {
                foreach (var item in data)
                {
                    var lc = new LeaveApplicationMasterViewModel();
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
                    var LC = new LeaveApplicationMasterViewModel();
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
                    var LC = new LeaveApplicationMasterViewModel();
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
                    var LC = new LeaveApplicationMasterViewModel();
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
                Headers = "LeaveParat",
                Header_Title = "LeaveParat",
                Header_Desc = $"તારીખ : {fromDate.Value.Date} થી : {toDate.Value.Date}",
                Content = responseData
            });
        }

        #endregion

        #region Post Methods

        [HttpPost("Save")]
        public JsonResult Save(Post_LeaveApplicationMaster model)
        {
            try
            {
                var user = HttpContext.GetClaimsPrincipal();

                if (model.DesignationId == 2)
                {
                    model.SectorId = model.TempPoliceStationId.Value;
                    model.ZoneId = 0;
                    model.DivisionId = 0;
                    model.PoliceStationId = 0;
                }
                else if (model.DesignationId == 3)
                {
                    model.ZoneId = model.TempPoliceStationId.Value;
                    model.SectorId = 0;
                    model.DivisionId = 0;
                    model.PoliceStationId = 0;
                }
                else if (model.DesignationId == 4)
                {
                    model.DivisionId = model.TempPoliceStationId.Value;
                    model.SectorId = 0;
                    model.ZoneId = 0;
                    model.PoliceStationId = 0;
                }
                else
                {
                    model.DivisionId = 0;
                    model.SectorId = 0;
                    model.ZoneId = 0;
                    model.PoliceStationId = model.TempPoliceStationId.Value;
                }

                if (model.InchargeDesignationId == 2)
                {
                    model.InchargeSectorId = model.TempInchargePoliceStationId;
                    model.InchargeZoneId = 0;
                    model.InchargeDivisionId = 0;
                    model.InchargePoliceStationId = 0;
                }
                else if (model.InchargeDesignationId == 3)
                {
                    model.InchargeZoneId = model.TempInchargePoliceStationId;
                    model.InchargeSectorId = 0;
                    model.InchargeDivisionId = 0;
                    model.InchargePoliceStationId = 0;
                }
                else if (model.InchargeDesignationId == 4)
                {
                    model.InchargeDivisionId = model.TempInchargePoliceStationId;
                    model.InchargeSectorId = 0;
                    model.InchargeZoneId = 0;
                    model.InchargePoliceStationId = 0;
                }
                else
                {
                    model.InchargeDivisionId = 0;
                    model.InchargeSectorId = 0;
                    model.InchargeZoneId = 0;
                    model.InchargePoliceStationId = model.TempInchargePoliceStationId;
                }

                if (model.LeaveApplicationID != 0)
                {
                    if (model.LeaveTypeId == 36)
                    {
                        var data = new TblLeaveApplicationMaster();

                        data.LeaveApplicationId = model.LeaveApplicationID;
                        data.PoliceStationId = model.PoliceStationId;
                        data.DesignationId = model.DesignationId;
                        data.InchargeDesignationId = model.InchargeDesignationId;
                        data.InchargePoliceStationId = model.InchargePoliceStationId;
                        data.InchargeEmployeeId = model.InchargeEmployeeId;
                        data.LeaveTypeId = model.LeaveTypeId;
                        data.EmployeeId = model.EmployeeId;
                        data.Name = string.Empty;
                        data.FromDate = model.FromDate;
                        data.ToDate = model.ToDate;
                        data.TotalDays = model.TotalDays;
                        data.Remarks = model.Remarks;
                        data.CreatedUserId = Convert.ToInt32(user.UserId);
                        data.IsActive = true;
                        data.IsDelete = false;
                        data.SectorId = model.SectorId;
                        data.ZoneId = model.ZoneId;
                        data.DivisionId = model.DivisionId;
                        data.InchargeSectorId = model.InchargeSectorId;
                        data.InchargeZoneId = model.InchargeZoneId;
                        data.InchargeDivisionId = model.InchargeDivisionId;

                        _unitOfWork.LeaveApplication.Update(data, model.LeaveApplicationID);
                        _unitOfWork.Save();

                        var updateData = _unitOfWork.EmployeeMaster.Find(x => x.EmployeeId == model.EmployeeId);

                        updateData.IsActive = true;
                        updateData.IsDeleted = false;
                        updateData.ModifiedUserId = Convert.ToInt32(user.UserId);

                        _unitOfWork.EmployeeMaster.Update(updateData, updateData.EmployeeId);
                        _unitOfWork.Save();
                    }
                    else
                    {
                        var data = new TblLeaveApplicationMaster();

                        data.LeaveApplicationId = model.LeaveApplicationID;
                        data.PoliceStationId = 0;
                        data.DesignationId = model.DesignationId;
                        data.InchargeDesignationId = model.InchargeDesignationId;
                        data.InchargePoliceStationId = model.InchargePoliceStationId;
                        data.InchargeEmployeeId = model.InchargeEmployeeId;
                        data.LeaveTypeId = model.LeaveTypeId;
                        data.EmployeeId = model.EmployeeId;
                        data.Name = string.Empty;
                        data.FromDate = model.FromDate;
                        data.ToDate = model.ToDate;
                        data.TotalDays = model.TotalDays;
                        data.Remarks = model.Remarks;
                        data.CreatedUserId = Convert.ToInt32(user.UserId);
                        data.IsActive = true;
                        data.IsDelete = false;
                        data.SectorId = model.TempPoliceStationId;
                        data.ZoneId = 0;
                        data.DivisionId = 0;
                        data.InchargeSectorId = model.InchargeSectorId;
                        data.InchargeZoneId = model.InchargeZoneId;
                        data.InchargeDivisionId = model.InchargeDivisionId;

                        _unitOfWork.LeaveApplication.Update(data, model.LeaveApplicationID);
                        _unitOfWork.Save();

                        var updateData = _unitOfWork.EmployeeMaster.Find(x => x.EmployeeId == model.EmployeeId);

                        updateData.IsActive = false;
                        updateData.IsDeleted = true;
                        updateData.ModifiedUserId = Convert.ToInt32(user.UserId);

                        _unitOfWork.EmployeeMaster.Update(updateData, updateData.EmployeeId);
                        _unitOfWork.Save();
                    }

                    return new JsonResult(new
                    {
                        IsValid = true,
                    });
                }

                return new JsonResult(new
                {
                    IsValid = false,
                    Error = ConstantsData.ErrContactYourAdministrator,
                });
            }
            catch (Exception)
            {
                return new JsonResult(new
                {
                    IsValid = false,
                    Error = ConstantsData.ErrContactYourAdministrator,
                });
            }
        }

        #endregion
    }
}
