using AhmedabadCityDR.Interfaces;
using AhmedabadCityDR.Models.APIModels;
using AhmedabadCityDR.Models.TableModels;
using Microsoft.AspNetCore.Mvc;

namespace AhmedabadCityDR.APIs
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiNightEmployeeMasterController : ControllerBase
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
        public ApiNightEmployeeMasterController(IUnitOfWork iUnitOfWork)
        {
            _unitOfWork = iUnitOfWork;
        }

        #endregion

        #region Get Methods

        [HttpGet("GetById")]
        public IActionResult GetById(int? id)
        {
            return new OkObjectResult(new
            {
                Content = _unitOfWork.NightEmployeeMaster.Find(x => x.NightEmployeeId == id),
            });
        }

        [HttpGet("Delete")]
        public JsonResult Delete(int id)
        {
            try
            {
                _unitOfWork.NightEmployeeMaster.DeleteById(id);

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

        [HttpGet("Get")]
        public IActionResult Get(DateTime? fromDate, DateTime? toDate, int? policestationId)
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

            int roleId = Convert.ToInt32(user.RoleId);
            int sectorId = Convert.ToInt32(user.SectorId);
            int zoneId = Convert.ToInt32(user.ZoneId);
            int divisionId = Convert.ToInt32(user.DivisionId);
            int policeStationId = Convert.ToInt32(user.PoliceStationId);

            if (policeStationId == 0 && policestationId.HasValue)
            {
                roleId = 0;
                policeStationId = policestationId.Value;
            }

            var responseData = _unitOfWork.NightEmployeeMaster
                .GetNightEmployee(roleId, sectorId, zoneId, divisionId, policeStationId, fromDate.Value.Date, toDate.Value.Date)
                .OrderBy(x => x.PoliceStationId)
                .Select(x => new
                {
                    x.NightEmployeeId,
                    x.EmployeeId,
                    x.PoliceStationName,
                    x.PoliceStationId,
                    x.EmployeName,
                    CreatedDate = x.CreatedDate.Value.ToString("dd/MM/yyyy"),
                    x.DesignationId,
                    x.DesignationName,
                    x.GoingTime,
                    x.ReturnTime,
                    x.Remarks,
                });

            return new OkObjectResult(new
            {
                Success = true,
                Headers = "NightEmployee",
                Header_Title = "NightEmployee",
                Header_Desc = $"તારીખ : {fromDate.Value.Date} થી : {toDate.Value.Date}",
                Content = responseData
            });
        }

        #endregion

        #region Post Methodes

        [HttpPost("Save")]
        public JsonResult Save(Post_NightEmployeeMaster model)
        {
            try
            {
                if (model.NightEmployeeId == 0)
                {
                    var lastRecord = _unitOfWork.NightEmployeeMaster.GetAll().OrderByDescending(x => x.NightEmployeeId).Take(1).ToList();
                    var newId = lastRecord[0].NightEmployeeId + 1;

                    var data = new TblNightEmployeeMaster
                    {
                        NightEmployeeId = newId,
                        PoliceStationId = model.PoliceStationId,
                        EmployeeId = model.EmployeeId,
                        DesignationId = model.DesignationId,
                        GoingTime = model.GoingTime,
                        ReturnTime = model.ReturnTime,
                        Remarks = model.Remarks,
                        IsActive = true,
                        IsDelete = false,
                        CreatedDate = model.CreatedDate,
                        ModifiedDate = model.CreatedDate,
                        CreatedUserId = Convert.ToInt32(HttpContext.GetClaimsPrincipal().UserId),
                        ModifiedUserId = Convert.ToInt32(HttpContext.GetClaimsPrincipal().UserId),
                    };

                    _unitOfWork.NightEmployeeMaster.Add(data);
                }
                else
                {
                    var data = _unitOfWork.NightEmployeeMaster.Find(x => x.NightEmployeeId == model.NightEmployeeId);

                    if (data == null)
                    {
                        return new JsonResult(new
                        {
                            IsValid = false,
                            Error = ConstantsData.ErrDataNotFound,
                        });
                    }

                    data.PoliceStationId = model.PoliceStationId;
                    data.EmployeeId = model.EmployeeId;
                    data.DesignationId = model.DesignationId;
                    data.GoingTime = model.GoingTime;
                    data.ReturnTime = model.ReturnTime;
                    data.Remarks = model.Remarks;
                    data.IsActive = true;
                    data.IsDelete = false;
                    data.ModifiedDate = model.CreatedDate;
                    data.ModifiedUserId = Convert.ToInt32(HttpContext.GetClaimsPrincipal().UserId);

                    _unitOfWork.NightEmployeeMaster.Update(data, data.NightEmployeeId);
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