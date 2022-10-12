using AhmedabadCityDR.Interfaces;
using AhmedabadCityDR.Models.APIModels;
using AhmedabadCityDR.Models.TableModels;
using Microsoft.AspNetCore.Mvc;

namespace AhmedabadCityDR.APIs
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiEGujakopMasterController : ControllerBase
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
        public ApiEGujakopMasterController(IUnitOfWork unitOfWork)
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
                Content = _unitOfWork.EGujakopMaster.Find(x => x.EGujakopId == id),
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

            var responseData = _unitOfWork.EGujakopMaster
                .GetEGujakopMaster(roleId, sectorId, zoneId, divisionId, policeStationId, fromDate.Value.Date, toDate.Value.Date)
                .Where(x => x.IsActive == true && x.IsDeleted == false)
                .OrderByDescending(x => x.CreatedDate)
                .ThenBy(x => x.PoliceStationId)
                .Select(x => new
                {
                    x.E_GujakopId,
                    x.PoliceStationName,
                    CreatedDate = x.CreatedDate.Value.ToString("dd/MM/yyyy"),
                    x.Part1to5number,
                    x.Part1to5E_Gujakop,
                    x.Part6number,
                    x.Part6E_Gujakop,
                    x.ProhiNumber,
                    x.ProhiE_Gujakop,
                    x.A_amNumber,
                    x.A_amE_Gujakop,
                    x.AcciendentNumber,
                    x.AcciendentE_Gujakop,
                    x.JanvajogNumber,
                    x.JanvajogE_Gujakop,
                });

            return new JsonResult(new
            {
                Success = true,
                Headers = "EGujakopMaster",
                Header_Title = "EGujakopMaster",
                Header_Desc = $"તારીખ : {fromDate.Value.Date} થી : {toDate.Value.Date}",
                Content = responseData
            });
        }

        [HttpGet("Delete")]
        public JsonResult Delete(int id)
        {
            try
            {
                _unitOfWork.EGujakopMaster.DeleteById(id);

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
        public JsonResult Save(Post_EGujakopMaster model)
        {
            try
            {
                if (model.EGujakopId == 0)
                {
                    var newData = new TblEGujakopMaster
                    {
                        PoliceStationId = model.PoliceStationId,
                        Part1to5number = model.Part1to5number,
                        Part1to5EGujakop = model.Part1to5EGujakop,
                        Part6number = model.Part6number,
                        Part6EGujakop = model.Part6EGujakop,
                        ProhiNumber = model.ProhiNumber,
                        ProhiEGujakop = model.ProhiEGujakop,
                        AAmNumber = model.AAmNumber,
                        AAmEGujakop = model.AAmEGujakop,
                        AcciendentNumber = model.AcciendentNumber,
                        AcciendentEGujakop = model.AcciendentEGujakop,
                        JanvajogNumber = model.JanvajogNumber,
                        JanvajogEGujakop = model.JanvajogEGujakop,
                        IsActive = true,
                        IsDeleted = false,
                        CreatedDate = model.CreatedDate,
                        ModifiedDate = model.CreatedDate,
                        CreatedUserId = Convert.ToInt32(HttpContext.GetClaimsPrincipal().UserId),
                        ModifiedUserId = Convert.ToInt32(HttpContext.GetClaimsPrincipal().UserId),
                    };

                    _unitOfWork.EGujakopMaster.Add(newData);
                }
                else
                {
                    var data = _unitOfWork.EGujakopMaster.Find(x => x.EGujakopId == model.EGujakopId);

                    if (data == null)
                    {
                        return new JsonResult(new
                        {
                            IsValid = false,
                            Error = ConstantsData.ErrDataNotFound,
                        });
                    }

                    data.PoliceStationId = model.PoliceStationId;
                    data.Part1to5number = model.Part1to5number;
                    data.Part1to5EGujakop = model.Part1to5EGujakop;
                    data.Part6number = model.Part6number;
                    data.Part6EGujakop = model.Part6EGujakop;
                    data.ProhiNumber = model.ProhiNumber;
                    data.ProhiEGujakop = model.ProhiEGujakop;
                    data.AAmNumber = model.AAmNumber;
                    data.AAmEGujakop = model.AAmEGujakop;
                    data.AcciendentNumber = model.AcciendentNumber;
                    data.AcciendentEGujakop = model.AcciendentEGujakop;
                    data.JanvajogNumber = model.JanvajogNumber;
                    data.JanvajogEGujakop = model.JanvajogEGujakop;
                    data.ModifiedDate = model.CreatedDate;
                    data.ModifiedUserId = Convert.ToInt32(HttpContext.GetClaimsPrincipal().UserId);

                    _unitOfWork.EGujakopMaster.Update(data, data.EGujakopId);
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
