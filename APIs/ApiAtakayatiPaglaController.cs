using AhmedabadCityDR.Interfaces;
using AhmedabadCityDR.Models.APIModels;
using AhmedabadCityDR.Models.TableModels;
using Microsoft.AspNetCore.Mvc;

namespace AhmedabadCityDR.APIs
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiAtakayatiPaglaController : ControllerBase
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
        /// <param name="unitOfWork"></param>
        public ApiAtakayatiPaglaController(IUnitOfWork unitOfWork)
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
                Content = _unitOfWork.AtakayatiPagla.Find(x => x.AtakayatiPagalaBackupId == id),
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

            var responseData = _unitOfWork.AtakayatiPagla
                .GetAtakayatiPagla(roleId, sectorId, zoneId, divisionId, policeStationId, fromDate.Value.Date, toDate.Value.Date)
                .OrderByDescending(x => x.CreatedDate)
                .ThenBy(x => x.PoliceStationId)
                .Select(x => new
                {
                    x.AtakayatiPagalaBackupId,
                    x.PoliceStationName,
                    CreatedDate = x.CreatedDate.Value.ToString("dd/MM/yyyy"),
                    x.CRPC107,
                    x.Prohi93,
                    x.CRPC109,
                    x.CRPC110,
                    x.BPACT122C,
                    x.BPACT124,
                    x.BPACT56,
                    x.BPACT57,
                    x.BPACT135_1,
                    x.BPACT142,
                    x.PASA,
                    x.Total,
                });

            return new JsonResult(new
            {
                Success = true,
                Headers = "AtakayatiPagla",
                Header_Title = "AtakayatiPagla",
                Header_Desc = $"તારીખ : {fromDate.Value.Date} થી : {toDate.Value.Date}",
                Content = responseData
            });
        }

        [HttpGet("Delete")]
        public JsonResult Delete(int id)
        {
            try
            {
                _unitOfWork.AtakayatiPagla.DeleteById(id);

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
        public JsonResult Save(Post_AtakayatiPagla model)
        {
            try
            {
                var user = HttpContext.GetClaimsPrincipal();

                if (model.PoliceStationId == null && Convert.ToInt32(user.PoliceStationId) != 0)
                {
                    model.PoliceStationId = Convert.ToInt32(user.PoliceStationId);
                }

                model.Total = model.BPACT122C +
                              model.BPACT124 +
                              model.BPACT1351 +
                              model.BPACT142 +
                              model.BPACT56 +
                              model.BPACT57 +
                              model.CRPC107 +
                              model.CRPC109 +
                              model.CRPC110 +
                              model.Prohi93;

                var oldData = _unitOfWork.AtakayatiPagla.GetAtakayatiPagla(0,
                                                                           0,
                                                                           0,
                                                                           0,
                                                                           model.PoliceStationId.Value,
                                                                           model.CreatedDate.Value,
                                                                           model.CreatedDate.Value)
                                                        .Where(x => x.IsActive == true && x.IsDeleted == false)
                                                        .ToList();

                if (model.AtakayatiPagalaBackupId == 0 && oldData.Count == 0)
                {
                    var lastRecord = _unitOfWork.AtakayatiPagla.GetAll()
                                                        .OrderByDescending(x => x.AtakayatiPagalaBackupId)
                                                        .Take(1).ToList();
                    var newData = new TblAtakayatiPagla
                    {
                        AtakayatiPagalaBackupId = lastRecord[0].AtakayatiPagalaBackupId + 1,
                        PoliceStationId = model.PoliceStationId,
                        Bpact122c = model.BPACT122C,
                        Bpact124 = model.BPACT124,
                        Bpact1351 = model.BPACT1351,
                        Bpact142 = model.BPACT142,
                        Bpact56 = model.BPACT56,
                        Bpact57 = model.BPACT57,
                        Crpc107 = model.CRPC107,
                        Crpc109 = model.CRPC109,
                        Crpc110 = model.CRPC110,
                        Pasa = model.PASA,
                        Prohi93 = model.Prohi93,
                        Total = model.Total,
                        IsActive = true,
                        IsDeleted = false,
                        CreatedDate = model.CreatedDate,
                        ModifiedDate = model.CreatedDate,
                        CreateduserId = Convert.ToInt32(HttpContext.GetClaimsPrincipal().UserId),
                        ModifiedUserId = Convert.ToInt32(HttpContext.GetClaimsPrincipal().UserId),
                    };

                    _unitOfWork.AtakayatiPagla.Add(newData);
                }
                else
                {
                    if (oldData != null)
                    {
                        model.AtakayatiPagalaBackupId = oldData[0].AtakayatiPagalaBackupId;
                    }

                    var data = _unitOfWork.AtakayatiPagla.Find(x => x.AtakayatiPagalaBackupId == model.AtakayatiPagalaBackupId);

                    if (data == null)
                    {
                        return new JsonResult(new
                        {
                            IsValid = false,
                            Error = ConstantsData.ErrDataNotFound,
                        });
                    }

                    data.PoliceStationId = model.PoliceStationId;
                    data.Bpact122c = model.BPACT122C;
                    data.Bpact124 = model.BPACT124;
                    data.Bpact1351 = model.BPACT1351;
                    data.Bpact142 = model.BPACT142;
                    data.Bpact56 = model.BPACT56;
                    data.Bpact57 = model.BPACT57;
                    data.CreatedDate = model.CreatedDate;
                    data.Crpc107 = model.CRPC107;
                    data.Crpc109 = model.CRPC109;
                    data.Crpc110 = model.CRPC110;
                    data.Pasa = model.PASA;
                    data.Prohi93 = model.Prohi93;
                    data.Total = model.Total;
                    data.IsActive = true;
                    data.IsDeleted = false;
                    data.ModifiedDate = model.CreatedDate;
                    data.ModifiedUserId = Convert.ToInt32(HttpContext.GetClaimsPrincipal().UserId);

                    _unitOfWork.AtakayatiPagla.Update(data, data.AtakayatiPagalaBackupId);
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
