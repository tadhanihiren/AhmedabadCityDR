using AhmedabadCityDR.Interfaces;
using AhmedabadCityDR.Models.APIModels;
using AhmedabadCityDR.Models.TableModels;
using Microsoft.AspNetCore.Mvc;

namespace AhmedabadCityDR.APIs
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiPendingJanvaJogController : ControllerBase
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
        public ApiPendingJanvaJogController(IUnitOfWork unitOfWork)
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
                Content = _unitOfWork.PendingJanvaJog.Find(x => x.PendingJanvaJog == id),
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

            var responseData = _unitOfWork.PendingJanvaJog
                .GetPendingJanvaJog(roleId, sectorId, zoneId, divisionId, policeStationId, fromDate.Value.Date, toDate.Value.Date)
                .OrderByDescending(x => x.CreatedDate)
                .ThenBy(x => x.PoliceStationId)
                .Select(x => new
                {
                    x.PendingJanvaJog,
                    x.PoliceStationName,
                    CreatedDate = x.CreatedDate.Value.ToString("dd/MM/yyyy"),
                    x.OneMonthAbove,
                    x.OneMonthUnder,
                    x.TwoMonthAbove,
                    x.ThreeMonthAbove,
                    x.SixMonthAbove,
                    x.OneYearAndAbove,
                });

            return new JsonResult(new
            {
                Success = true,
                Headers = "PendingJanvaJog",
                Header_Title = "PendingJanvaJog",
                Header_Desc = $"તારીખ : {fromDate.Value.Date} થી : {toDate.Value.Date}",
                Content = responseData
            });
        }

        [HttpGet("Delete")]
        public JsonResult Delete(int id)
        {
            try
            {
                _unitOfWork.PendingJanvaJog.DeleteById(id);

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
        public JsonResult Save(Post_PendingJanvaJog model)
        {
            try
            {
                var user = HttpContext.GetClaimsPrincipal();

                if (model.PoliceStationId == null && Convert.ToInt32(user.PoliceStationId) != 0)
                {
                    model.PoliceStationId = Convert.ToInt32(user.PoliceStationId);
                }

                var oldData = _unitOfWork.PendingJanvaJog.GetPendingJanvaJog(0,
                                                                             0,
                                                                             0,
                                                                             0,
                                                                             model.PoliceStationId.Value,
                                                                             model.CreatedDate.Value,
                                                                             model.CreatedDate.Value).ToList();

                if (model.PendingJanvaJog == 0 && oldData.Count == 0)
                {
                    var newData = new TblpendingjanvajogMaster
                    {
                        PoliceStationId = model.PoliceStationId,
                        OneMonthUnder = model.OneMonthUnder,
                        OneMonthAbove = model.OneMonthAbove,
                        TwoMonthAbove = model.TwoMonthAbove,
                        ThreeMonthAbove = model.ThreeMonthAbove,
                        SixMonthAbove = model.SixMonthAbove,
                        OneYearAndAbove = model.OneYearAndAbove,
                        IsActive = true,
                        IsDeleted = false,
                        CreatedDate = model.CreatedDate,
                        ModifiedDate = model.CreatedDate,
                        CreatedUserId = Convert.ToInt32(HttpContext.GetClaimsPrincipal().UserId),
                        ModifiedUserId = Convert.ToInt32(HttpContext.GetClaimsPrincipal().UserId),
                    };

                    _unitOfWork.PendingJanvaJog.Add(newData);
                }
                else
                {
                    if (oldData != null)
                    {
                        model.PendingJanvaJog = oldData[0].PendingJanvaJog.Value;
                    }

                    var data = _unitOfWork.PendingJanvaJog.Find(x => x.PendingJanvaJog == model.PendingJanvaJog);

                    if (data == null)
                    {
                        return new JsonResult(new
                        {
                            IsValid = false,
                            Error = ConstantsData.ErrDataNotFound,
                        });
                    }

                    data.PoliceStationId = model.PoliceStationId;
                    data.OneMonthUnder = model.OneMonthUnder;
                    data.OneMonthAbove = model.OneMonthAbove;
                    data.TwoMonthAbove = model.TwoMonthAbove;
                    data.ThreeMonthAbove = model.ThreeMonthAbove;
                    data.SixMonthAbove = model.SixMonthAbove;
                    data.OneYearAndAbove = model.OneYearAndAbove;
                    data.ModifiedDate = model.CreatedDate;
                    data.ModifiedUserId = Convert.ToInt32(HttpContext.GetClaimsPrincipal().UserId);

                    _unitOfWork.PendingJanvaJog.Update(data, data.PendingJanvaJog);
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
