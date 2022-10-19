using AhmedabadCityDR.Interfaces;
using AhmedabadCityDR.Models.APIModels;
using AhmedabadCityDR.Models.TableModels;
using Microsoft.AspNetCore.Mvc;

namespace AhmedabadCityDR.APIs
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiPoliceStationWisePendingApplicationController : ControllerBase
    {
        #region Private Members

        /// <summary>
        /// Unit of work.
        /// </summary>
        private readonly IUnitOfWork _unitOfWork;

        #endregion

        #region Constructors

        /// <summary>
        /// Constructors
        /// </summary>
        public ApiPoliceStationWisePendingApplicationController(IUnitOfWork unitOfWork)
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
                Content = _unitOfWork.PoliceStationWisePendingApplication.Find(x => x.PoliceStationWisePendingApplicationId == id),
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


            var responseData = _unitOfWork.PoliceStationWisePendingApplication
                .GetPoliceStationWisePendingApplication(roleId, sectorId, zoneId, divisionId, policeStationId, fromDate.Value.Date, toDate.Value.Date)
                .Where(x => x.IsActive == true && x.IsDeleted == false)
                .OrderBy(x => x.PoliceStationId)
                .Select(x => new
                {
                    x.PoliceStationWisePendingApplicationId,
                    x.KacheriName,
                    x.PoliceStationName,
                    CreatedDate = x.CreatedDate.Value.ToString("dd/MM/yyyy"),
                    x.TenDaysBelow,
                    x.TenDaysAbove,
                    x.OneMonthAbove,
                    x.TwoMonthAbove,
                    x.ThreeMonthAbove,
                    x.SixMonthAbove,
                    x.OneYearAndAbove,
                });

            return new JsonResult(new
            {
                Success = true,
                Headers = "પો.સ્ટે વાઇઝ તથા કચેરી વાઇઝ પેન્ડીંગ અરજીઓનુ પત્રક",
                Header_Title = "PoliceStation Wise Pending Application",
                Header_Desc = $"તારીખ : {fromDate.Value.Date} થી : {toDate.Value.Date}",
                Content = responseData
            });
        }

        [HttpGet("Delete")]
        public JsonResult Delete(int id)
        {
            try
            {
                _unitOfWork.PoliceStationWisePendingApplication.DeleteById(id);

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
        public JsonResult Save(Post_PoliceStationWisePendingApplication model)
        {
            try
            {
                var user = HttpContext.GetClaimsPrincipal();

                if (model.PoliceStationId == null && Convert.ToInt32(user.PoliceStationId) != 0)
                {
                    model.PoliceStationId = Convert.ToInt32(user.PoliceStationId);
                }

                var oldData = _unitOfWork.PoliceStationWisePendingApplication.GetPoliceStationWisePendingApplication(0,
                                                                                                                     0,
                                                                                                                     0,
                                                                                                                     0,
                                                                                                                     model.PoliceStationId.Value,
                                                                                                                     model.CreatedDate.Value,
                                                                                                                     model.CreatedDate.Value)
                                                                              .Where(x => x.KacheriId == model.KacheriId && x.IsActive == true && x.IsDeleted == false).ToList();

                if (model.PoliceStationWisePendingApplicationId == 0 && oldData.Count == 0)
                {

                    var data = new TblPoliceStationWisePendingApplication
                    {
                        PoliceStationId = model.PoliceStationId,
                        KacheriId = model.KacheriId,
                        TenDaysBelow = model.TenDaysBelow,
                        TenDaysAbove = model.TenDaysAbove,
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

                    _unitOfWork.PoliceStationWisePendingApplication.Add(data);
                }
                else
                {
                    if (oldData.Count != 0)
                    {
                        model.PoliceStationWisePendingApplicationId = oldData[0].PoliceStationWisePendingApplicationId;
                    }

                    var data = _unitOfWork.PoliceStationWisePendingApplication.Find(x => x.PoliceStationWisePendingApplicationId == model.PoliceStationWisePendingApplicationId);

                    if (data == null)
                    {
                        return new JsonResult(new
                        {
                            IsValid = false,
                            Error = ConstantsData.ErrDataNotFound,
                        });
                    }

                    data.PoliceStationId = model.PoliceStationId;
                    data.KacheriId = model.KacheriId;
                    data.TenDaysBelow = model.TenDaysBelow;
                    data.TenDaysAbove = model.TenDaysAbove;
                    data.OneMonthAbove = model.OneMonthAbove;
                    data.TwoMonthAbove = model.TwoMonthAbove;
                    data.ThreeMonthAbove = model.ThreeMonthAbove;
                    data.SixMonthAbove = model.SixMonthAbove;
                    data.OneYearAndAbove = model.OneYearAndAbove;
                    data.ModifiedDate = model.CreatedDate;
                    data.ModifiedUserId = Convert.ToInt32(HttpContext.GetClaimsPrincipal().UserId);


                    _unitOfWork.PoliceStationWisePendingApplication.Update(data, data.PoliceStationWisePendingApplicationId);
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
