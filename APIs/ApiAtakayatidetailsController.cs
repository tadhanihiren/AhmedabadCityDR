using AhmedabadCityDR.Interfaces;
using AhmedabadCityDR.Models.APIModels;
using AhmedabadCityDR.Models.TableModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AhmedabadCityDR.APIs
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiAtakayatidetailsController : ControllerBase
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
        public ApiAtakayatidetailsController(IUnitOfWork iUnitOfWork)
        {
            _unitOfWork = iUnitOfWork;
        }

        #endregion

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
                Content = _unitOfWork.AtakayatiDetails.Find(x => x.AtakayatiPagalaSummaryId == id),
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
                roleId = 0;
                policeStationId = searchPoliceStationId.Value;
            }
            var responseData = _unitOfWork.AtakayatiDetails
                .GetAtakayatiDetails(roleId, sectorId, zoneId, divisionId, policeStationId, fromDate.Value.Date, toDate.Value.Date)
                .Select(x => new
                {
                    x.AtakayatiPagalaSummaryId,
                    x.PoliceStationName,
                    CreatedDate = x.CreatedDate.Value.ToString("dd/MM/yyyy"),
                    x.SubCategoryName,
                    x.CurrentYear,
                    x.LastYear,
                   x.CY_LY,
                });

            return new JsonResult(new
            {
                Success = true,
                Headers = "AtakayatiDetails",
                Header_Title = "અટકાયતી પગલાની વિગત-પત્રક નંબર–૫",
                Header_Desc = $"તારીખ : {fromDate.Value.Date} થી : {toDate.Value.Date}",
                Content = responseData
            });
        }

        /// <summary>
        /// Delete record from AtakayatiDetails
        /// </summary>
        /// <param name="id">Id</param>
        /// <returns>Returns json response</returns>
        [HttpGet("Delete")]
        public JsonResult Delete(int id)
        {
            try
            {
                _unitOfWork.AtakayatiDetails.DeleteById(id);

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

 


        #region Post Methods

        /// <summary>
        /// Save AtakayatiPaglaSummary
        /// </summary>
        /// <param name="model">Atakayati Pagla Summary</param>
        /// <returns></returns>
        [HttpPost("Save")]
        public IActionResult Save(Post_AtakayatiDetails model)
        {
            _ = int.TryParse(model.LastYear, out var lastyear);
            try
            {
                var user = HttpContext.GetClaimsPrincipal();

                var oldData = _unitOfWork.AtakayatiDetails.GetAtakayatiDetails(0,
                                                           0,
                                                           0,
                                                           0,
                                                           model.PoliceStationId.Value,
                                                           model.CreatedDate,
                                                           model.CreatedDate)
                                        .Where(x => x.IsActive == true && x.IsDeleted == false)
                                        .ToList();


                if (model.AtakayatiPagalaSummaryId == 0 && oldData.Count == 0)
                {
                    var atakayatidetail = new TblAtakayatidetail
                    {
                        PoliceStationId = model.PoliceStationId,
                        SubCategoryId = model.SubCategoryId,
                        Today = model.Today,
                        Last = model.Last,
                        CurrentYear = model.CurrentYear,
                        LastYear = lastyear,
                        CyLy=(model.CurrentYear-lastyear),
                        TY=model.TY,
                        IsActive = true,
                        IsDeleted = false,
                        CreatedDate = model.CreatedDate,
                        ModifiedDate=model.CreatedDate,
                        CreateduserId = Convert.ToInt32(HttpContext.GetClaimsPrincipal().UserId),
                        ModifiedUserId = Convert.ToInt32(HttpContext.GetClaimsPrincipal().UserId),
                    };

                    _unitOfWork.AtakayatiDetails.Add(atakayatidetail);
                }
                else
                {
                    if (oldData != null)
                    {
                        model.AtakayatiPagalaSummaryId = oldData[0].AtakayatiPagalaSummaryId;
                    }
                    var data = _unitOfWork.AtakayatiDetails.Find(x => x.AtakayatiPagalaSummaryId == model.AtakayatiPagalaSummaryId);

                    if (data == null)
                    {
                        return new JsonResult(new
                        {
                            IsValid = false,
                            Error = ConstantsData.ErrDataNotFound,
                        });
                    }
                    data.PoliceStationId = model.PoliceStationId;
                    data.SubCategoryId = model.SubCategoryId;
                    data.Today = model.Today;
                    data.Last = model.Last;
                    data.CurrentYear = model.CurrentYear;
                    data.LastYear = lastyear;
                    data.CyLy = (model.CurrentYear - lastyear);
                    data.TY = model.TY;
                    data.IsActive = true;
                    data.IsDeleted = false;
                    data.CreatedDate = model.CreatedDate;
                    data.ModifiedDate = model.CreatedDate;
                    data.ModifiedUserId = Convert.ToInt32(HttpContext.GetClaimsPrincipal().UserId);

                    _unitOfWork.AtakayatiDetails.Update(data, data.AtakayatiPagalaSummaryId);

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
