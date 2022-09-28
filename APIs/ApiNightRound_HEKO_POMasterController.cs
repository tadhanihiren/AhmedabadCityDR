using AhmedabadCityDR.Interfaces;
using AhmedabadCityDR.Models.APIModels;
using AhmedabadCityDR.Models.TableModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AhmedabadCityDR.APIs
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiNightRound_HEKO_POMasterController : ControllerBase
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
        public ApiNightRound_HEKO_POMasterController(IUnitOfWork iUnitOfWork)
        {
            _unitOfWork = iUnitOfWork;
        }
        #endregion

        #region Get Methods

        [HttpGet("GetById")]
        public JsonResult GetById(int? id)
        {
            return new JsonResult(new
            {
                Content = _unitOfWork.NightRound_HEKO_PO.Find(x => x.NightRoundHekoPoid == id),
            });
        }

        [HttpGet("Delete")]
        public JsonResult Delete(int id)
        {
            try
            {
                _unitOfWork.NightRound_HEKO_PO.DeleteById(id);

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

            var responseData = _unitOfWork.NightRound_HEKO_PO.GetNightRound_HEKO_PO(roleId, sectorId, zoneId, divisionId, policeStationId, fromDate.Value.Date, toDate.Value.Date)
                 .OrderByDescending(x => x.CreatedDate)
                 .OrderBy(x => x.PoliceStationId)
                .Select(x => new
                {
                    x.NightRound_HEKO_POID,
                    x.PoliceStationName,
                    CreatedDate = x.CreatedDate.Value.ToString("dd/MM/yyyy"),
                    x.TotalOfMotarcycle,
                    x.MaofNumber,
                    x.NightRound_Heko_PONumber,
                    x.DefectNumber,
                    x.NotavailabelNumber,
                    x.Remark,

                });

            return new JsonResult(new
            {
                Success = true,
                Headers = "Night Round HEKO_PO",
                Header_Title = "Night Round HEKO_PO",
                Content = responseData
            });
        }
        #endregion

        #region Post Methods

        [HttpPost("Save")]
        public JsonResult Save(Post_NightRound_HEKO_PO model)
        {
            try
            {
                if (model.NightRoundHekoPoid == 0)
                {
                    var data = new TblNightRoundHekoPomaster
                    {
                        PoliceStationId = model.PoliceStationId,
                        TotalOfMotarcycle = model.TotalOfMotarcycle,
                        MaofNumber = model.MaofNumber,
                        NightRoundHekoPonumber = model.NightRoundHekoPonumber,
                        DefectNumber = model.DefectNumber,
                        NotavailabelNumber = model.NotavailabelNumber,
                        Remark = model.Remark,
                        CreatedDate = model.CreatedDate,
                        ModifiedDate = model.CreatedDate,
                        CreatedUserId = Convert.ToInt32(HttpContext.GetClaimsPrincipal().UserId),
                        ModifiedUserId = Convert.ToInt32(HttpContext.GetClaimsPrincipal().UserId),
                        IsActive = true,
                        IsDeleted = false,
                    };

                    _unitOfWork.NightRound_HEKO_PO.Add(data);
                    _unitOfWork.Save();
                }
                else
                {
                    var data = _unitOfWork.NightRound_HEKO_PO.Find(x => x.NightRoundHekoPoid == model.NightRoundHekoPoid);

                    if (data == null)
                    {
                        return new JsonResult(new
                        {
                            IsValid = false,
                            Error = ConstantsData.ErrDataNotFound,
                        });
                    }
                    data.PoliceStationId = model.PoliceStationId;
                    data.TotalOfMotarcycle = model.TotalOfMotarcycle;
                    data.MaofNumber = model.MaofNumber;
                    data.NightRoundHekoPonumber = model.NightRoundHekoPonumber;
                    data.DefectNumber = model.DefectNumber;
                    data.NotavailabelNumber = model.NotavailabelNumber;
                    data.Remark = model.Remark;
                    data.ModifiedDate = model.CreatedDate;
                    data.ModifiedUserId = Convert.ToInt32(HttpContext.GetClaimsPrincipal().UserId);
                    data.IsActive = true;
                    data.IsDeleted = false;

                    _unitOfWork.NightRound_HEKO_PO.Update(data, data.NightRoundHekoPoid);
                }

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
