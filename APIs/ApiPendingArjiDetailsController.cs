using AhmedabadCityDR.Interfaces;
using AhmedabadCityDR.Models.APIModels;
using AhmedabadCityDR.Models.TableModels;
using Microsoft.AspNetCore.Mvc;

namespace AhmedabadCityDR.APIs
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiPendingArjiDetailsController : ControllerBase
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
        public ApiPendingArjiDetailsController(IUnitOfWork unitOfWork)
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
                Content = _unitOfWork.PendingArjiDetail.Find(x => x.PendingArjiDetailId == id),
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

            var responseData = _unitOfWork.PendingArjiDetail
                .GetPendingArjiDetails(roleId, sectorId, zoneId, divisionId, policeStationId, fromDate.Value.Date, toDate.Value.Date)
                .OrderByDescending(x => x.CreatedDate)
                .ThenBy(x => x.PoliceStationId)
                .Select(x => new
                {
                    x.PendingArjiDetailId,
                    x.PoliceStationName,
                    x.CategoryName,
                    x.Under_10Days,
                    x.Above_10Days,
                    x.Above_OneMonth,
                    x.Above_TwoMonth,
                    x.Above_ThreeMonth,
                    x.Above_SixMonth,
                    x.Above_OneYear,
                    CreatedDate = x.CreatedDate.Value.ToString("dd/MM/yyyy"),
                });

            return new JsonResult(new
            {
                Success = true,
                Headers = "PendingArjiDetail",
                Header_Title = "PendingArjiDetail",
                Header_Desc = $"તારીખ : {fromDate.Value.Date} થી : {toDate.Value.Date}",
                Content = responseData
            });
        }

        [HttpGet("Delete")]
        public JsonResult Delete(int id)
        {
            try
            {
                var modifiedUserId = Convert.ToInt32(HttpContext.GetClaimsPrincipal().UserId);
                _unitOfWork.PendingArjiDetail.DeleteById(id, false, true, modifiedUserId);

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
        public JsonResult Save(Post_PendingArjiDetail model)
        {
            try
            {
                if (model.PendingArjiDetailId == 0)
                {
                    var checkData = _unitOfWork.PendingArjiDetail.CheckPendingArjiDetails(model.CreatedDate.Value, model.PendingArjiCategoryId.Value)
                                                                 .Where(x => x.IsActive == true && x.PoliceStationId == model.PoliceStationId)
                                                                 .ToList();

                    if (checkData.Count > 0)
                    {
                        return new JsonResult(new
                        {
                            IsValid = false,
                            Error = ConstantsData.ErrCategoryRecordExists,
                        });
                    }

                    var newData = new TblPendingArjiDetail
                    {
                        PoliceStationId = model.PoliceStationId,
                        PendingArjiCategoryId = model.PendingArjiCategoryId,
                        Under10days = model.Under10Days,
                        Above10days = model.Above10Days,
                        AboveOneMonth = model.AboveOneMonth,
                        AboveTwoMonth = model.AboveTwoMonth,
                        AboveThreeMonth = model.AboveThreeMonth,
                        AboveSixMonth = model.AboveSixMonth,
                        AboveOneYear = model.AboveOneYear,
                        IsActive = true,
                        IsDelete = false,
                        CreatedDate = model.CreatedDate,
                        ModifiedDate = model.CreatedDate,
                        CreatedUserId = Convert.ToInt32(HttpContext.GetClaimsPrincipal().UserId),
                        ModifiedUserId = Convert.ToInt32(HttpContext.GetClaimsPrincipal().UserId),
                    };

                    _unitOfWork.PendingArjiDetail.Add(newData);
                }
                else
                {
                    var data = _unitOfWork.PendingArjiDetail.Find(x => x.PendingArjiDetailId == model.PendingArjiDetailId);

                    if (data == null)
                    {
                        return new JsonResult(new
                        {
                            IsValid = false,
                            Error = ConstantsData.ErrDataNotFound,
                        });
                    }

                    data.PendingArjiCategoryId = model.PendingArjiCategoryId;
                    data.Under10days = model.Under10Days;
                    data.Above10days = model.Above10Days;
                    data.AboveOneMonth = model.AboveOneMonth;
                    data.AboveTwoMonth = model.AboveTwoMonth;
                    data.AboveThreeMonth = model.AboveThreeMonth;
                    data.AboveSixMonth = model.AboveSixMonth;
                    data.AboveOneYear = model.AboveOneYear;
                    data.PoliceStationId = model.PoliceStationId;
                    data.ModifiedDate = model.CreatedDate;
                    data.ModifiedUserId = Convert.ToInt32(HttpContext.GetClaimsPrincipal().UserId);

                    _unitOfWork.PendingArjiDetail.Update(data, data.PendingArjiDetailId);
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
