using AhmedabadCityDR.Interfaces;
using AhmedabadCityDR.Models.APIModels;
using AhmedabadCityDR.Models.TableModels;
using Microsoft.AspNetCore.Mvc;

namespace AhmedabadCityDR.APIs
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiNightRountPersonCountMasterController : ControllerBase
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
        public ApiNightRountPersonCountMasterController(IUnitOfWork iUnitOfWork)
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
                Content = _unitOfWork.NightRountPersonCountMaster.Find(x => x.NightRoundPersonCountId == id),
            });
        }

        [HttpGet("Delete")]
        public JsonResult Delete(int id)
        {
            try
            {
                _unitOfWork.NightRountPersonCountMaster.DeleteById(id);

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

            var responseData = _unitOfWork.NightRountPersonCountMaster
                .GetNightRountPersonCount(roleId, sectorId, zoneId, divisionId, policeStationId, fromDate.Value.Date, toDate.Value.Date)
                .OrderBy(x => x.PoliceStationId)
                .Select(x => new
                {
                    x.NightRoundPersonCountId,
                    CreatedDate = x.CreatedDate.Value.ToString("dd/MM/yyyy"),
                    x.PoliceStationName,
                    x.PoliceStationId,
                    x.PresentMahekam,
                    x.NightRountPersonCount,
                    x.Percentage,
                    x.Remarks,
                });

            return new OkObjectResult(new
            {
                Success = true,
                Headers = "NightRountPersonCountMaster",
                Header_Title = "NightRountPersonCountMaster",
                Header_Desc = $"તારીખ : {fromDate.Value.Date} થી : {toDate.Value.Date}",
                Content = responseData
            });
        }

        #endregion

        #region Post Methodes

        [HttpPost("Save")]
        public JsonResult Save(Post_NightRountPersonCountMaster model)
        {
            try
            {
                var user = HttpContext.GetClaimsPrincipal();

                if (model.PoliceStationId == null && Convert.ToInt32(user.PoliceStationId) != 0)
                {
                    model.PoliceStationId = Convert.ToInt32(user.PoliceStationId);
                }

                var oldData = _unitOfWork.NightRountPersonCountMaster.FindByPoliceStaionNumber(0,
                                                                                               0,
                                                                                               0,
                                                                                               0,
                                                                                               model.PoliceStationId.Value,
                                                                                               model.CreatedDate.Value,
                                                                                               model.CreatedDate.Value);

                if (model.NightRoundPersonCountId == 0)
                {
                    var lastRecord = _unitOfWork.NightRountPersonCountMaster.GetAll().OrderByDescending(x => x.NightRoundPersonCountId).Take(1).ToList();
                    var newId = lastRecord[0].NightRoundPersonCountId + 1;

                    var data = new TblNightRountPersonCountMaster
                    {
                        NightRoundPersonCountId = newId,
                        PoliceStationId = model.PoliceStationId,
                        PresentMahekam = model.PresentMahekam,
                        NightRountPersonCount = model.NightRountPersonCount,
                        Percentage = model.Percentage,
                        Remarks = model.Remarks,
                        IsActive = true,
                        IsDeleted = false,
                        CreatedDate = model.CreatedDate,
                        ModifiedDate = model.CreatedDate,
                        CreatedUserId = Convert.ToInt32(HttpContext.GetClaimsPrincipal().UserId),
                        ModifiedUserId = Convert.ToInt32(HttpContext.GetClaimsPrincipal().UserId),
                    };

                    _unitOfWork.NightRountPersonCountMaster.Add(data);
                }
                else
                {
                    if (oldData != null)
                    {
                        model.NightRoundPersonCountId = oldData.NightRoundPersonCountId;
                    }

                    var data = _unitOfWork.NightRountPersonCountMaster.Find(x => x.NightRoundPersonCountId == model.NightRoundPersonCountId);

                    if (data == null)
                    {
                        return new JsonResult(new
                        {
                            IsValid = false,
                            Error = ConstantsData.ErrDataNotFound,
                        });
                    }

                    data.PoliceStationId = model.PoliceStationId;
                    data.PresentMahekam = model.PresentMahekam;
                    data.NightRountPersonCount = model.NightRountPersonCount;
                    data.Percentage = model.Percentage;
                    data.Remarks = model.Remarks;
                    data.IsActive = true;
                    data.IsDeleted = false;
                    data.ModifiedDate = model.CreatedDate;
                    data.ModifiedUserId = Convert.ToInt32(HttpContext.GetClaimsPrincipal().UserId);

                    _unitOfWork.NightRountPersonCountMaster.Update(data, data.NightRoundPersonCountId);
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
