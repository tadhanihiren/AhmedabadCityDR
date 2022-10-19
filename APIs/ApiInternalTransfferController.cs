using AhmedabadCityDR.Interfaces;
using AhmedabadCityDR.Models.APIModels;
using AhmedabadCityDR.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace AhmedabadCityDR.APIs
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiInternalTransfferController : ControllerBase
    {
        #region Private Members

        /// <summary>
        /// UnitOfWork.
        /// </summary>
        private readonly IUnitOfWork _unitOfWork;

        #endregion

        #region Constructors

        /// <summary>
        /// Constructors
        /// </summary>
        /// <param name="unitOfWork"></param>
        public ApiInternalTransfferController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        #endregion

        #region Get Methodes

        [HttpGet("GetById")]
        public JsonResult GetById(int? id)
        {

            var user = HttpContext.GetClaimsPrincipal();
            var roleId = Convert.ToInt32(user.RoleId);
            var sectorId = Convert.ToInt32(user.SectorId);
            var zoneId = Convert.ToInt32(user.ZoneId);
            var divisionId = Convert.ToInt32(user.DivisionId);
            var policeStationId = Convert.ToInt32(user.PoliceStationId);
            var forTrafficCity = Convert.ToInt32(user.ForTraffic_City);

            var lstEmployeeMaster = new List<EmployeeMasterViewModel>();

            if (forTrafficCity == 0)
            {
                var model = _unitOfWork.EmployeeMaster.GetAll().Where(x => x.EmployeeId == id);
                foreach (var item in model)
                {
                    var emp = new EmployeeMasterViewModel();

                    emp.BuckleNo = item.BuckleNo;
                    emp.ContactNumber = item.ContactNumber;
                    emp.CreatedDate = item.CreatedDate;
                    emp.DesignationId = item.DesignationId;
                    emp.EmployeeId = item.EmployeeId;
                    emp.EmployeName = item.EmployeName;
                    emp.IsActive = item.IsActive;
                    emp.IsDeleted = item.IsDeleted;
                    emp.IsTraffic = item.IsTraffic;
                    emp.Name = item.Name;
                    emp.RoleId = item.RoleId;
                    emp.Todate = item.Todate;

                    if (item.DesignationId == 2 || item.DesignationId == 15)
                    {
                        emp.PoliceStationId = item.SectorId;
                    }
                    else if (item.DesignationId == 3)
                    {
                        emp.PoliceStationId = item.ZoneId;
                    }
                    else if (item.DesignationId == 4)
                    {
                        emp.PoliceStationId = item.DivisionId;
                    }
                    else if (item.DesignationId >= 5 && item.DesignationId != 15)
                    {
                        emp.PoliceStationId = item.PoliceStationId;
                    }

                    lstEmployeeMaster.Add(emp);
                }
            }
            else if (forTrafficCity == 1)
            {
                var model = _unitOfWork.EmployeeMaster.GetAll().Where(x => x.EmployeeId == id);
                foreach (var item in model)
                {
                    var emp = new EmployeeMasterViewModel();

                    emp.BuckleNo = item.BuckleNo;
                    emp.ContactNumber = item.ContactNumber;
                    emp.CreatedDate = item.CreatedDate;
                    emp.DesignationId = item.DesignationId;
                    emp.EmployeeId = item.EmployeeId;
                    emp.EmployeName = item.EmployeName;
                    emp.IsActive = item.IsActive;
                    emp.IsDeleted = item.IsDeleted;
                    emp.IsTraffic = item.IsTraffic;
                    emp.Name = item.Name;
                    emp.RoleId = item.RoleId;
                    emp.Todate = item.Todate;

                    if (item.DesignationId == 2 || item.DesignationId == 15)
                    {
                        emp.PoliceStationId = item.SectorId;
                    }
                    else if (item.DesignationId == 3)
                    {
                        emp.PoliceStationId = item.ZoneId;
                    }
                    else if (item.DesignationId == 4)
                    {
                        emp.PoliceStationId = item.DivisionId;
                    }
                    else if (item.DesignationId >= 5 && item.DesignationId != 15)
                    {
                        emp.PoliceStationId = item.PoliceStationId;
                    }
                    lstEmployeeMaster.Add(emp);
                }
            }
            else if (forTrafficCity == 2)
            {
                var model = _unitOfWork.EmployeeMaster.GetAll().Where(x => x.EmployeeId == id);
                foreach (var item in model)
                {
                    var emp = new EmployeeMasterViewModel();

                    emp.BuckleNo = item.BuckleNo;
                    emp.ContactNumber = item.ContactNumber;
                    emp.CreatedDate = item.CreatedDate;
                    emp.DesignationId = item.DesignationId;
                    emp.EmployeeId = item.EmployeeId;
                    emp.EmployeName = item.EmployeName;
                    emp.IsActive = item.IsActive;
                    emp.IsDeleted = item.IsDeleted;
                    emp.IsTraffic = item.IsTraffic;
                    emp.Name = item.Name;
                    emp.RoleId = item.RoleId;
                    emp.Todate = item.Todate;

                    if (item.DesignationId == 2 || item.DesignationId == 15)
                    {
                        emp.PoliceStationId = item.SectorId;
                    }
                    else if (item.DesignationId == 3)
                    {
                        emp.PoliceStationId = item.ZoneId;
                    }
                    else if (item.DesignationId == 4)
                    {
                        emp.PoliceStationId = item.DivisionId;
                    }
                    else if (item.DesignationId >= 5 && item.DesignationId != 15)
                    {
                        emp.PoliceStationId = item.PoliceStationId;
                    }
                    lstEmployeeMaster.Add(emp);
                }
            }

            var responseData = lstEmployeeMaster.Where(x => x.IsActive == true && x.IsDeleted == false)
                                                .OrderByDescending(x => x.CreatedDate)
                                                .ThenBy(x => x.PoliceStationId)
                                                .Select(x => new
                                                {
                                                    x.EmployeeId,
                                                    x.PoliceStationId,
                                                    x.DesignationId,
                                                    x.BuckleNo,
                                                    x.EmployeName,
                                                    x.ContactNumber,
                                                    x.PrtiniyukatName,
                                                    Fromdate = Helper.ConvertDate(x.Fromdate.ToString()),
                                                    Todate = Helper.ConvertDate(x.Todate.ToString()),
                                                    x.PrtiniyukatPlace,
                                                    CreatedDate = x.CreatedDate.Value.ToString("dd/MM/yyyy"),

                                                });

            return new JsonResult(new
            {
                Content = _unitOfWork.EmployeeMaster.Find(x => x.EmployeeId == id),
            });
        }

        [HttpGet("Get")]
        public JsonResult Get(DateTime? fromDate, DateTime? toDate, int? searchPoliceStationId)
        {
            if (!fromDate.HasValue)
            {
                fromDate = DateTime.Today;
            }

            if (!toDate.HasValue)
            {
                toDate = DateTime.Today;
            }

            var user = HttpContext.GetClaimsPrincipal();
            var roleId = Convert.ToInt32(user.RoleId);
            var sectorId = Convert.ToInt32(user.SectorId);
            var zoneId = Convert.ToInt32(user.ZoneId);
            var divisionId = Convert.ToInt32(user.DivisionId);
            var policeStationId = Convert.ToInt32(user.PoliceStationId);
            var forTrafficCity = Convert.ToInt32(user.ForTraffic_City);

            if (policeStationId == 0 && searchPoliceStationId.HasValue)
            {
                roleId = 0;
                policeStationId = searchPoliceStationId.Value;
            }

            var lstEmployeeMaster = new List<EmployeeMasterViewModel>();

            if (forTrafficCity == 0)
            {
                var model = _unitOfWork.EmployeeMaster.GetEmployees(roleId, sectorId, zoneId, divisionId, policeStationId, fromDate.Value.Date, toDate.Value.Date)
                                                      .Where(x => x.IsActive == true && x.IsDeleted == false);
                foreach (var item in model)
                {
                    var emp = new EmployeeMasterViewModel();

                    emp.BuckleNo = item.BuckleNo;
                    emp.ContactNumber = item.ContactNumber;
                    emp.CreatedDate = item.CreatedDate;
                    emp.DesignationId = item.DesignationId;
                    emp.DesignationName = item.DesignationName;
                    emp.EmployeeId = item.EmployeeId;
                    emp.EmployeName = item.EmployeName;
                    emp.IsActive = item.IsActive;
                    emp.IsDeleted = item.IsDeleted;
                    emp.IsTraffic = item.IsTraffic;
                    emp.Name = item.Name;
                    emp.RoleId = item.RoleId;
                    emp.Todate = item.Todate;

                    if (item.DesignationId == 2 || item.DesignationId == 15)
                    {
                        emp.PoliceStationId = item.SectorId;
                        emp.PoliceStationName = item.SectorName;
                    }
                    else if (item.DesignationId == 3)
                    {
                        emp.PoliceStationId = item.ZoneId;
                        emp.PoliceStationName = item.ZoneName;
                    }
                    else if (item.DesignationId == 4)
                    {
                        emp.PoliceStationId = item.DivisionId;
                        emp.PoliceStationName = item.DivisionName;
                    }
                    else if (item.DesignationId >= 5 && item.DesignationId != 15)
                    {
                        emp.PoliceStationId = item.PoliceStationId;
                        emp.PoliceStationName = item.PoliceStationName;
                    }

                    lstEmployeeMaster.Add(emp);
                }
            }
            else if (forTrafficCity == 1)
            {
                var model = _unitOfWork.EmployeeMaster.GetEmployees(roleId, sectorId, zoneId, divisionId, policeStationId, fromDate.Value.Date, toDate.Value.Date)
                                                      .Where(x => x.IsActive == true && x.IsDeleted == false && x.IsTraffic == true);
                foreach (var item in model)
                {
                    var emp = new EmployeeMasterViewModel();

                    emp.BuckleNo = item.BuckleNo;
                    emp.ContactNumber = item.ContactNumber;
                    emp.CreatedDate = item.CreatedDate;
                    emp.DesignationId = item.DesignationId;
                    emp.DesignationName = item.DesignationName;
                    emp.EmployeeId = item.EmployeeId;
                    emp.EmployeName = item.EmployeName;
                    emp.IsActive = item.IsActive;
                    emp.IsDeleted = item.IsDeleted;
                    emp.IsTraffic = item.IsTraffic;
                    emp.Name = item.Name;
                    emp.RoleId = item.RoleId;
                    emp.Todate = item.Todate;

                    if (item.DesignationId == 2 || item.DesignationId == 15)
                    {
                        emp.PoliceStationId = item.SectorId;
                        emp.PoliceStationName = item.SectorName;
                    }
                    else if (item.DesignationId == 3)
                    {
                        emp.PoliceStationId = item.ZoneId;
                        emp.PoliceStationName = item.ZoneName;
                    }
                    else if (item.DesignationId == 4)
                    {
                        emp.PoliceStationId = item.DivisionId;
                        emp.PoliceStationName = item.DivisionName;
                    }
                    else if (item.DesignationId >= 5 && item.DesignationId != 15)
                    {
                        emp.PoliceStationId = item.PoliceStationId;
                        emp.PoliceStationName = item.PoliceStationName;
                    }
                    lstEmployeeMaster.Add(emp);
                }
            }
            else if (forTrafficCity == 2)
            {
                var model = _unitOfWork.EmployeeMaster.GetEmployees(roleId, sectorId, zoneId, divisionId, policeStationId, fromDate.Value.Date, toDate.Value.Date)
                                                      .Where(x => x.IsActive == true && x.IsDeleted == false && x.IsTraffic == false);
                foreach (var item in model)
                {
                    var emp = new EmployeeMasterViewModel();

                    emp.BuckleNo = item.BuckleNo;
                    emp.ContactNumber = item.ContactNumber;
                    emp.CreatedDate = item.CreatedDate;
                    emp.DesignationId = item.DesignationId;
                    emp.DesignationName = item.DesignationName;
                    emp.EmployeeId = item.EmployeeId;
                    emp.EmployeName = item.EmployeName;
                    emp.IsActive = item.IsActive;
                    emp.IsDeleted = item.IsDeleted;
                    emp.IsTraffic = item.IsTraffic;
                    emp.Name = item.Name;
                    emp.RoleId = item.RoleId;
                    emp.Todate = item.Todate;

                    if (item.DesignationId == 2 || item.DesignationId == 15)
                    {
                        emp.PoliceStationId = item.SectorId;
                        emp.PoliceStationName = item.SectorName;
                    }
                    else if (item.DesignationId == 3)
                    {
                        emp.PoliceStationId = item.ZoneId;
                        emp.PoliceStationName = item.ZoneName;
                    }
                    else if (item.DesignationId == 4)
                    {
                        emp.PoliceStationId = item.DivisionId;
                        emp.PoliceStationName = item.DivisionName;
                    }
                    else if (item.DesignationId >= 5 && item.DesignationId != 15)
                    {
                        emp.PoliceStationId = item.PoliceStationId;
                        emp.PoliceStationName = item.PoliceStationName;
                    }
                    lstEmployeeMaster.Add(emp);
                }
            }

            var responseData = lstEmployeeMaster.OrderByDescending(x => x.CreatedDate)
                                                .ThenBy(x => x.PoliceStationId)
                                                .Select(x => new
                                                {
                                                    x.EmployeeId,
                                                    x.PoliceStationName,
                                                    x.DesignationName,
                                                    x.BuckleNo,
                                                    x.EmployeName,
                                                    x.ContactNumber,
                                                    x.PrtiniyukatName,
                                                    Fromdate = Helper.ConvertDate(x.Fromdate.ToString()),
                                                    Todate = Helper.ConvertDate(x.Todate.ToString()),
                                                    x.PrtiniyukatPlace,
                                                    CreatedDate = Helper.ConvertDate(x.CreatedDate.ToString()),

                                                });

            return new JsonResult(new
            {
                Success = true,
                Headers = "Employee Master",
                Header_Title = "Employee Master",
                Header_Desc = $"તારીખ : {fromDate.Value.Date} થી : {toDate.Value.Date}",
                Content = responseData
            });
        }

        #endregion

        #region Post Methods

        [HttpPost("Save")]
        public JsonResult Save(Post_EmployeeMaster model)
        {
            try
            {
                if (model.EmployeeId != 0)
                {
                    _unitOfWork.EmployeeMaster.UpdateInternalTransffer(model.EmployeeId, model.TransfferTempId.Value, model.DesignationId.Value, model.ContactNumber);
                    _unitOfWork.Save();

                    return new JsonResult(new
                    {
                        IsValid = true,
                    });
                }

                return new JsonResult(new
                {
                    IsValid = false,
                    Error = ConstantsData.ErrDataNotFound,
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
