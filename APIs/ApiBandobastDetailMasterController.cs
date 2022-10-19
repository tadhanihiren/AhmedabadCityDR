using AhmedabadCityDR.Interfaces;
using AhmedabadCityDR.Models.APIModels;
using AhmedabadCityDR.Models.TableModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AhmedabadCityDR.APIs
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiBandobastDetailMasterController : ControllerBase
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
        public ApiBandobastDetailMasterController(IUnitOfWork iUnitOfWork)
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
                Content = _unitOfWork.BandobastDetail.Find(x => x.BandoBastId == id),
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



            var responseData = _unitOfWork.BandobastDetail
                .GetBandobastDetail(roleId, sectorId, zoneId, divisionId, policeStationId, fromDate.Value.Date, toDate.Value.Date)
                .OrderBy(x => x.PoliceStationId)
                .Where(x => x.IsActive== true && x.IsDeleted== false)
                .Select(x => new
                {
                    x.BandoBastId,
                    x.PoliceStationName,
                    CreatedDate = x.CreatedDate.Value.ToString("dd/MM/yyyy"),
                    x.ZoneId,
                    x.DivisionId,
                    x.PoliceStationId,
                    x.ZoneName,
                    x.DivisionName,
                    x.BandoBastPlace,
                    x.BandobastTypeId,
                    x.BandobastDetail_ForceNumber,
                    x.ShortDetail,
                });

            return new JsonResult(new
            {
                Success = true,
                Headers = "BandobastDetail",
                Header_Title = "BandobastDetail",
                Header_Desc = $"તારીખ : {fromDate.Value.Date} થી : {toDate.Value.Date}",
                Content = responseData
            });
        }

        [HttpGet("Delete")]
        public JsonResult Delete(int id)
        {
            try
            {
                _unitOfWork.BandobastDetail.DeleteById(id);

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

        #region Post Methodes

        [HttpPost("Save")]
        public JsonResult Save(Post_BandobastDetail model)
        {
            try
            {

                if (model.BandoBastId == 0)
                {
                    var data = new TblBandobastDetailMaster
                    {
                        PoliceStationId=model.PoliceStationId,
                        BandoBastPlace=model.BandoBastPlace,
                        BandobastTypeId=model.BandobastTypeId,
                        BandobastDetailForceNumber = model.BandobastDetailForceNumber,
                        ShortDetail=model.ShortDetail,
                        IsActive = true,
                        IsDeleted = false,
                        CreatedDate = model.CreatedDate,
                        ModifiedDate = model.CreatedDate,
                        CreatedUserId= Convert.ToInt32(HttpContext.GetClaimsPrincipal().UserId),
                        ModifiedUserId= Convert.ToInt32(HttpContext.GetClaimsPrincipal().UserId),
                       
                    };

                    _unitOfWork.BandobastDetail.Add(data);
                }
                else
                {
                    var data = _unitOfWork.BandobastDetail.Find(x => x.BandoBastId == model.BandoBastId);

                    if (data == null)
                    {
                        return new JsonResult(new
                        {
                            IsValid = false,
                            Error = ConstantsData.ErrDataNotFound,
                        });
                    }
                    data.PoliceStationId = model.PoliceStationId;
                    data.BandoBastPlace = model.BandoBastPlace;
                    data.BandobastTypeId = model.BandobastTypeId;
                    data.BandobastDetailForceNumber = model.BandobastDetailForceNumber;
                    data.ShortDetail = model.ShortDetail;
                    data.IsActive = true;
                    data.IsDeleted = false;
                    data.ModifiedDate = model.CreatedDate;
                    data.ModifiedUserId = Convert.ToInt32(HttpContext.GetClaimsPrincipal().UserId);

                    _unitOfWork.BandobastDetail.Update(data, data.BandoBastId);

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
