using AhmedabadCityDR.Interfaces;
using AhmedabadCityDR.Models.APIModels;
using AhmedabadCityDR.Models.TableModels;
using Microsoft.AspNetCore.Mvc;

namespace AhmedabadCityDR.APIs
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiTrafficEmployeeMasterController : ControllerBase
    {
        #region Private Members

        /// <summary>
        /// IUnitOfWork.
        /// </summary>
        private readonly IUnitOfWork _unitOfWork;

        #endregion

        #region Constructors

        /// <summary>
        /// Constructors
        /// </summary>
        /// <param name="iUnitOfWork"></param>
        public ApiTrafficEmployeeMasterController(IUnitOfWork iUnitOfWork)
        {
            _unitOfWork = iUnitOfWork;
        }

        #endregion   

        #region Get Methodes

        [HttpGet("GetById")]
        public JsonResult GetById(int? id)
        {
            return new JsonResult(new
            {
                Content = _unitOfWork.TrafficEmployeeDetails.Find(x => x.EmployeeId == id),
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

            if (policeStationId == 0 && searchPoliceStationId.HasValue)
            {
                roleId = 0;
                policeStationId = searchPoliceStationId.Value;
            }

            fromDate = DateTime.Today;
            toDate = DateTime.Today;

            var responseData = _unitOfWork.TrafficEmployeeDetails
                .GetTrafficEmployees(roleId, sectorId, zoneId, divisionId, policeStationId, fromDate.Value.Date, toDate.Value.Date)
                .Where(x => x.IsActive == true && x.IsDeleted == false && x.IsTraffic == true)
                .OrderBy(x => x.PoliceStationId)
                .Select(x => new
                {
                    x.EmployeeId,
                    x.PoliceStationName,
                    x.DesignationName,
                    x.BuckleNo,
                    x.EmployeName,
                    x.ContactNumber,
                    x.PrtiniyukatName,
                    x.Fromdate,
                    x.Todate,
                    x.PrtiniyukatPlace,
                    CreatedDate = Helper.ConvertDate(x.CreatedDate.ToString()),
                });

            return new JsonResult(new
            {
                Success = true,
                Headers = "Traffic Employee Details",
                Header_Title = "Traffic Employee Details",
                Header_Desc = $"તારીખ : {fromDate.Value.Date} થી : {toDate.Value.Date}",
                Content = responseData
            });
        }

        [HttpGet("Delete")]
        public JsonResult Delete(int id)
        {
            try
            {
                _unitOfWork.TrafficEmployeeDetails.DeleteById(id);

                return new JsonResult(new
                {
                    IsValid = true,
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
        #region Post Methods

        [HttpPost("Save")]
        public JsonResult Save(Post_TrafficEmployeeDetails model)
        {
            try
            {
                DateTime? fromDate = null;
                DateTime? toDate = null;

                if (!string.IsNullOrEmpty(model.Fromdate))
                {
                    if (DateTime.TryParse(model.Fromdate, out var date))
                    {
                        fromDate = date;
                    }
                }

                if (!string.IsNullOrEmpty(model.Todate))
                {
                    if (DateTime.TryParse(model.Todate, out var date))
                    {
                        toDate = date;
                    }
                }

                var roleId = 0;

                roleId = model.DesignationId switch
                {
                    1 => 2,
                    2 => 3,
                    3 => 4,
                    4 => 5,
                    5 => 6,
                    6 => 7,
                    7 => 8,
                    8 => 9,
                    _ => 10,
                };

                if (model.EmployeeId == 0)
                {
                    var lastRecord = _unitOfWork.TrafficEmployeeDetails.GetAll()
                                                                       .OrderByDescending(x => x.EmployeeId)
                                                                       .Take(1).ToList();


                    var newRecordId = lastRecord[0].EmployeeId + 1;

                    var newData = new TblEmployeeMaster
                    {
                        EmployeeId = newRecordId,
                        DesignationId = model.DesignationId,
                        BuckleNo = model.BuckleNo,
                        EmployeName = model.EmployeName,
                        Name = model.EmployeName,
                        ContactNumber = model.ContactNumber,
                        PrtiniyukatName = model.PrtiniyukatName,
                        PrtiniyukatPlace = model.PrtiniyukatPlace,
                        Fromdate = fromDate,
                        Todate = toDate,
                        RoleId = roleId,
                        SectorId = 0,
                        ZoneId = 0,
                        DivisionId = 0,
                        PoliceStationId = model.PoliceStationId,
                        IsActive = true,
                        IsDeleted = false,
                        IsTraffic = true,
                        CreatedDate = model.CreatedDate,
                        ModifiedDate = model.CreatedDate,
                        CreatedUserId = Convert.ToInt32(HttpContext.GetClaimsPrincipal().UserId),
                        ModifiedUserId = Convert.ToInt32(HttpContext.GetClaimsPrincipal().UserId),
                    };

                    _unitOfWork.TrafficEmployeeDetails.Add(newData);
                }
                else
                {
                    var data = _unitOfWork.TrafficEmployeeDetails.Find(x => x.EmployeeId == model.EmployeeId);

                    if (data == null)
                    {
                        return new JsonResult(new
                        {
                            IsValid = false,
                            Error = ConstantsData.ErrDataNotFound,
                        });
                    }

                    data.PoliceStationId = model.PoliceStationId;
                    data.DesignationId = model.DesignationId;
                    data.BuckleNo = model.BuckleNo;
                    data.EmployeName = model.EmployeName;
                    data.ContactNumber = model.ContactNumber;
                    data.PrtiniyukatName = model.PrtiniyukatName;
                    data.PrtiniyukatPlace = model.PrtiniyukatPlace;
                    data.Fromdate = fromDate;
                    data.Todate = toDate;
                    data.ModifiedDate = model.CreatedDate;
                    data.ModifiedUserId = Convert.ToInt32(HttpContext.GetClaimsPrincipal().UserId);

                    _unitOfWork.TrafficEmployeeDetails.Update(data, data.EmployeeId);
                }

                _unitOfWork.Save();

                return new JsonResult(new
                {
                    IsValid = true,
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
