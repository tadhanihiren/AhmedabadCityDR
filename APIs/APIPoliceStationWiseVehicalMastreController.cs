using AhmedabadCityDR.Interfaces;
using AhmedabadCityDR.Models.APIModels;
using AhmedabadCityDR.Models.TableModels;
using Microsoft.AspNetCore.Mvc;

namespace AhmedabadCityDR.APIs
{
    [Route("api/[controller]")]
    [ApiController]
    public class APIPoliceStationWiseVehicalMastreController : ControllerBase
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
        public APIPoliceStationWiseVehicalMastreController(IUnitOfWork unitOfWork)
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
                Content = _unitOfWork.PoliceStationWiseVehical.Find(x => x.PoliceStationwiseVehicalId == id),
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

            var responseData = _unitOfWork.PoliceStationWiseVehical
                .GetPoliceStationWiseVehical(roleId, sectorId, zoneId, divisionId, policeStationId, fromDate.Value.Date, toDate.Value.Date)
                .OrderByDescending(x => x.CreatedDate)
                .ThenBy(x => x.PoliceStationId)
                .Select(x => new
                {
                    x.PoliceStationwiseVehicalId,
                    x.PoliceStationName,
                    CreatedDate = Helper.ConvertDate(x.CreatedDate.ToString()),
                    x.Jeeps_Total,
                    x.Jeeps_OFFroad,
                    Jeeps_date = Helper.ConvertDate(x.Jeeps_date.ToString()),
                    x.Mobile_total,
                    x.Mobile_offroad,
                    Mobile_date = Helper.ConvertDate(x.Mobile_date.ToString()),
                    x.Cycling_total,
                    x.Cycling_offroad,
                    Cycling_date = Helper.ConvertDate(x.Cycling_date.ToString()),
                });

            return new JsonResult(new
            {
                Success = true,
                Headers = "Police Station Wise Vehical",
                Header_Title = "Police Station Wise Vehical",
                Header_Desc = $"તારીખ : {fromDate.Value.Date} થી : {toDate.Value.Date}",
                Content = responseData
            });
        }

        [HttpGet("Delete")]
        public JsonResult Delete(int id)
        {
            try
            {
                _unitOfWork.PoliceStationWiseVehical.DeleteById(id);

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
        public JsonResult Save(Post_PoliceStationWiseVehical model)
        {
            try
            {
                model.PoliceStationId ??= Convert.ToInt32(HttpContext.GetClaimsPrincipal().PoliceStationId);

                if (model.PoliceStationwiseVehicalId == 0)
                {
                    var lstPoliceStationVehicle = _unitOfWork.PoliceStationWiseVehical.GetAll()
                                                                                      .Where(x => x.IsActive == true && x.PoliceStationId == model.PoliceStationId)
                                                                                      .ToList();

                    foreach (var item in lstPoliceStationVehicle)
                    {
                        _unitOfWork.PoliceStationWiseVehical.DeleteById(item.PoliceStationwiseVehicalId);
                        _unitOfWork.Save();
                    }

                    var newData = new TblPoliceStationWiseVehical
                    {
                        PoliceStationId = model.PoliceStationId,
                        JeepsTotal = model.JeepsTotal,
                        JeepsOffroad = model.JeepsOFFroad,
                        JeepsDate = model.JeepsDate,
                        MobileTotal = model.MobileTotal,
                        MobileOffroad = model.MobileOffroad,
                        MobileDate = model.MobileDate,
                        CyclingTotal = model.CyclingTotal,
                        CyclingOffroad = model.CyclingOffroad,
                        CyclingDate = model.CyclingDate,
                        IsActive = true,
                        IsDeleted = false,
                        CreatedDate = model.CreatedDate,
                        ModifiedDate = model.CreatedDate,
                        CreatedUserId = Convert.ToInt32(HttpContext.GetClaimsPrincipal().UserId),
                        ModifiedUserId = Convert.ToInt32(HttpContext.GetClaimsPrincipal().UserId),
                    };

                    _unitOfWork.PoliceStationWiseVehical.Add(newData);
                }
                else
                {
                    var data = _unitOfWork.PoliceStationWiseVehical.Find(x => x.PoliceStationwiseVehicalId == model.PoliceStationwiseVehicalId);

                    if (data == null)
                    {
                        return new JsonResult(new
                        {
                            IsValid = false,
                            Error = ConstantsData.ErrDataNotFound,
                        });
                    }

                    data.JeepsTotal = model.JeepsTotal;
                    data.JeepsOffroad = model.JeepsOFFroad;
                    data.JeepsDate = model.JeepsDate;
                    data.MobileTotal = model.MobileTotal;
                    data.MobileOffroad = model.MobileOffroad;
                    data.MobileDate = model.MobileDate;
                    data.CyclingTotal = model.CyclingTotal;
                    data.CyclingOffroad = model.CyclingOffroad;
                    data.CyclingDate = model.CyclingDate;
                    data.PoliceStationId = model.PoliceStationId;
                    data.ModifiedDate = model.CreatedDate;
                    data.ModifiedUserId = Convert.ToInt32(HttpContext.GetClaimsPrincipal().UserId);

                    _unitOfWork.PoliceStationWiseVehical.Update(data, data.PoliceStationwiseVehicalId);
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
