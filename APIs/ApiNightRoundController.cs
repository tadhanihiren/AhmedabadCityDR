using AhmedabadCityDR.Interfaces;
using AhmedabadCityDR.Models.APIModels;
using AhmedabadCityDR.Models.TableModels;
using Microsoft.AspNetCore.Mvc;

namespace AhmedabadCityDR.APIs
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiNightRoundController : ControllerBase
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
        public ApiNightRoundController(IUnitOfWork iUnitOfWork)
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
                Content = _unitOfWork.NightRound.Find(x => x.NightRoundId == id),
            });
        }

        [HttpGet("Delete")]
        public JsonResult Delete(int id)
        {
            try
            {
                _unitOfWork.NightRound.DeleteById(id);

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

            var responseData = _unitOfWork.NightRound.GetNightRound(roleId, sectorId, zoneId, divisionId, policeStationId, fromDate.Value.Date, toDate.Value.Date)
                .OrderBy(x => x.PoliceStationId)
                .Select(x => new
                {
                    x.NightRoundId,
                    x.NightRoundOfficerName,
                    x.PoliceStationName,
                    x.CreatedDate,
                    x.GoingTime,
                    x.ReturnTime,
                    x.NightRoundPlace,
                    x.Remarks,

                });

            return new JsonResult(new
            {
                Success = true,
                Headers = "Night Round",
                Header_Title = "Night Round",
                Content = responseData
            });
        }
        #endregion


        [HttpPost("Save")]
        public IActionResult Save(Post_NightRound model)
        {
            try
            {
                var user = HttpContext.GetClaimsPrincipal();

                var lastRecord = _unitOfWork.NightRound.GetAll()
                                   .OrderByDescending(x => x.NightRoundId)
                                   .Take(1).ToList();

                var newRecordId = lastRecord[0].NightRoundId + 1;

                switch (model.DesignationId)
                {
                    case 1:
                        model.SectorId = model.TempId;

                        break;

                    case 2:
                        model.SectorId = model.TempId;

                        break;

                    case 3:
                        model.ZoneId = model.TempId;

                        break;

                    case 4:
                        model.DivisionId = model.TempId;

                        break;

                    case 5:
                        model.PoliceStationId = model.TempId;

                        break;

                    default:
                        break;
                }

                if (model.NightRoundId == 0)
                {
                    var data = new TblNightRound();
                    data.NightRoundId = newRecordId;
                    {
                        data.PoliceStationId = model.PoliceStationId;
                        data.NightRoundOfficerName = model.NightRoundOfficerName;
                        data.GoingTime = model.GoingTime;
                        data.ReturnTime = model.ReturnTime;
                        data.NightRoundPlace = model.NightRoundPlace;
                        data.Remarks = model.Remarks;
                        data.IsActive = true;
                        data.IsDeleted = false;
                        data.CreatedDate = model.CreatedDate;
                        data.ModifiedDate = model.CreatedDate;
                        data.CreatedUserId = Convert.ToInt32(HttpContext.GetClaimsPrincipal().UserId);
                        data.ModifiedUserId = Convert.ToInt32(HttpContext.GetClaimsPrincipal().UserId);
                        data.SectorId = model.SectorId;
                        data.ZoneId = model.ZoneId;
                        data.DivisionId = model.DivisionId;
                        data.DesignationId = model.DesignationId;
                    };

                    _unitOfWork.NightRound.Add(data);
                    _unitOfWork.Save();

                }
                else
                {
                                      
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
    }
}
