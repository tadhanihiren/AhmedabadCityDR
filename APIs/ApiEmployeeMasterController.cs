using AhmedabadCityDR.Interfaces;
using AhmedabadCityDR.Models.APIModels;
using AhmedabadCityDR.Models.TableModels;
using Microsoft.AspNetCore.Mvc;

namespace AhmedabadCityDR.APIs
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiEmployeeMasterController : ControllerBase
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
        public ApiEmployeeMasterController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        #endregion

        #region Get Methodes

        [HttpGet("GetById")]
        public JsonResult GetById(int? id)
        {
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

            if (policeStationId == 0 && searchPoliceStationId.HasValue)
            {
                roleId = 0;
                policeStationId = searchPoliceStationId.Value;
            }

            var responseData = _unitOfWork.EmployeeMaster
                .GetEmployees(roleId, sectorId, zoneId, divisionId, policeStationId, fromDate.Value.Date, toDate.Value.Date)
                .Where(x => x.IsActive == true && x.IsDeleted == false && x.IsTraffic == false)
                .OrderBy(x => x.CreatedDate)
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
                Headers = "EmployeeMaster",
                Header_Title = "EmployeeMaster",
                Header_Desc = $"તારીખ : {fromDate.Value.Date} થી : {toDate.Value.Date}",
                Content = responseData
            });
        }

        [HttpGet("Delete")]
        public JsonResult Delete(int id)
        {
            try
            {
                var data = _unitOfWork.EmployeeMaster.Find(x => x.EmployeeId == id);

                if (data == null)
                {
                    return new JsonResult(new
                    {
                        IsValid = false,
                        Error = ConstantsData.ErrDataNotFound,
                    });
                }

                data.IsActive = false;
                data.IsDeleted = true;
                data.ModifiedDate = DateTime.Now;
                data.ModifiedUserId = Convert.ToInt32(HttpContext.GetClaimsPrincipal().UserId);

                _unitOfWork.EmployeeMaster.Update(data, data.EmployeeId);
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

        #region Post Methods

        [HttpPost("Save")]
        public JsonResult Save(Post_EmployeeMaster model)
        {
            try
            {
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
                    var lastRecord = _unitOfWork.EmployeeMaster.GetAll()
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
                        RoleId = roleId,
                        SectorId = 0,
                        ZoneId = 0,
                        DivisionId = 0,
                        PoliceStationId = model.PoliceStationId,
                        IsActive = true,
                        IsDeleted = false,
                        IsTraffic = false,
                        CreatedDate = DateTime.Now,
                        ModifiedDate = DateTime.Now,
                        CreatedUserId = Convert.ToInt32(HttpContext.GetClaimsPrincipal().UserId),
                        ModifiedUserId = Convert.ToInt32(HttpContext.GetClaimsPrincipal().UserId),
                    };

                    _unitOfWork.EmployeeMaster.Add(newData);
                }
                else
                {
                    var data = _unitOfWork.EmployeeMaster.Find(x => x.EmployeeId == model.EmployeeId);

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
                    data.ModifiedDate = DateTime.Now;
                    data.ModifiedUserId = Convert.ToInt32(HttpContext.GetClaimsPrincipal().UserId);

                    _unitOfWork.EmployeeMaster.Update(data, data.EmployeeId);
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
