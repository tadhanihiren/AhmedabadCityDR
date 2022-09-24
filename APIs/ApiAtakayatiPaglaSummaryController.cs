using AhmedabadCityDR.Interfaces;
using AhmedabadCityDR.Models.APIModels;
using AhmedabadCityDR.Models.TableModels;
using Microsoft.AspNetCore.Mvc;

namespace AhmedabadCityDR.APIs
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiAtakayatiPaglaSummaryController : ControllerBase
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
        public ApiAtakayatiPaglaSummaryController(IUnitOfWork iUnitOfWork)
        {
            _unitOfWork = iUnitOfWork;
        }

        #endregion

        #region Get Methods

        /// <summary>
        /// Gets AtakayatiPaglaSummary
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns>Returns json response</returns>
        [HttpGet("GetById")]
        public JsonResult GetById(int? id)
        {
            return new JsonResult(new
            {
                Content = _unitOfWork.AtakayatiPaglaSummary.Find(x => x.AtakayatiPagalaSummaryId == id),
            });
        }

        /// <summary>
        /// Gets AtakayatiPaglaSummary
        /// </summary>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <returns>Returns json response</returns>
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
                policeStationId = searchPoliceStationId.Value;
            }

            var responseData = _unitOfWork.AtakayatiPaglaSummary
                .GetAtakayatiPaglaSummary(roleId, sectorId, zoneId, divisionId, policeStationId, fromDate.Value.Date, toDate.Value.Date)
                .Select(x => new
                {
                    x.AtakayatiPagalaSummaryId,
                    x.PoliceStationName,
                    CreatedDate = x.CreatedDate.Value.ToString("dd/MM/yyyy"),
                    x.SubCategoryName,
                    x.CurrentYear,
                    x.LastYear,
                });

            return new JsonResult(new
            {
                Success = true,
                Headers = "AtakayatiPaglaSummary",
                Header_Title = "અતકાયતિ પાગલા સારાંશ",
                Header_Desc = $"તારીખ : {fromDate.Value.Date} થી : {toDate.Value.Date}",
                Content = responseData
            });
        }

        /// <summary>
        /// Delete record from AtakayatiPaglaSummary
        /// </summary>
        /// <param name="id">Id</param>
        /// <returns>Returns json response</returns>
        [HttpGet("Delete")]
        public JsonResult Delete(int id)
        {
            try
            {
                var entity = _unitOfWork.AtakayatiPaglaSummary.Find(x => x.AtakayatiPagalaSummaryId == id);
                _unitOfWork.AtakayatiPaglaSummary.Delete(entity);
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

        #region Post Methods

        /// <summary>
        /// Save AtakayatiPaglaSummary
        /// </summary>
        /// <param name="model">Atakayati Pagla Summary</param>
        /// <returns></returns>
        [HttpPost("Save")]
        public IActionResult Save(Post_AtakayatiPaglaSummary model)
        {
            _ = int.TryParse(model.LastYear, out var lastyear);
            try
            {
                var user = HttpContext.GetClaimsPrincipal();
                var oldData = _unitOfWork.AtakayatiPaglaSummary.GetAtakayatiPaglaSummary(0, 0, 0, 0,
                                                                                         Convert.ToInt32(user.PoliceStationId),
                                                                                         model.CreatedDate,
                                                                                         model.CreatedDate)
                                                                .FirstOrDefault(x => x.SubCategoryId == model.SubCategoryId &&
                                                                                     x.IsActive == true &&
                                                                                     x.IsDeleted == false);

                if (model.AtakayatiPagalaSummaryId == 0 && oldData == null)
                {
                    var atakayatipaglasummary = new TblAtakayatiPaglaSummary
                    {
                        PoliceStationId = model.PoliceStationId,
                        IpcGpcid = 1,
                        SubCategoryId = model.SubCategoryId,
                        Todays = model.Todays,
                        Last = model.Last,
                        CurrentMonth = model.CurrentMonth,
                        LastMonth = model.LastMonth,
                        CurrentYear = model.CurrentYear,
                        LastYear = lastyear,
                        IsActive = true,
                        IsDeleted = false,
                        CreatedDate = model.CreatedDate,
                        CreateduserId = Convert.ToInt32(HttpContext.GetClaimsPrincipal().UserId),
                        ModifiedUserId = Convert.ToInt32(HttpContext.GetClaimsPrincipal().UserId),
                    };

                    _unitOfWork.AtakayatiPaglaSummary.Add(atakayatipaglasummary);
                }
                else
                {
                    if (oldData != null)
                    {
                        model.AtakayatiPagalaSummaryId = oldData.AtakayatiPagalaSummaryId;
                    }

                    var data = _unitOfWork.AtakayatiPaglaSummary.Find(x => x.AtakayatiPagalaSummaryId == model.AtakayatiPagalaSummaryId);

                    if (data == null)
                    {
                        return new JsonResult(new
                        {
                            IsValid = false,
                            Error = ConstantsData.ErrDataNotFound,
                        });
                    }

                    data.PoliceStationId = model.PoliceStationId;
                    data.IpcGpcid = 1;
                    data.SubCategoryId = model.SubCategoryId;
                    data.Todays = model.Todays;
                    data.Last = model.Last;
                    data.CurrentMonth = model.CurrentMonth;
                    data.LastMonth = model.LastMonth;
                    data.CurrentYear = model.CurrentYear;
                    data.LastYear = lastyear;
                    data.IsActive = true;
                    data.IsDeleted = false;
                    data.CreatedDate = model.CreatedDate;
                    data.ModifiedUserId = Convert.ToInt32(HttpContext.GetClaimsPrincipal().UserId);

                    _unitOfWork.AtakayatiPaglaSummary.Update(data, data.AtakayatiPagalaSummaryId);
                }

                _unitOfWork.Save();

                return new JsonResult(new
                {
                    isValid = true,
                });
            }
            catch (Exception)
            {
                return new JsonResult(new
                {
                    isValid = false,
                });
            }
        }

        #endregion
    }
}