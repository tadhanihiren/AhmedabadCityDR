using AhmedabadCityDR.Interfaces;
using AhmedabadCityDR.Models.APIModels;
using AhmedabadCityDR.Models.TableModels;
using AhmedabadCityDR.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AhmedabadCityDR.APIs
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiForm3AController : ControllerBase
    {
        #region Private Members

        /// <summary>
        /// IUnitOfWork.
        /// </summary>
        private readonly IUnitOfWork _iUnitOfWork;

        #endregion

        #region Constructors

        /// <summary>
        /// Constructors
        /// </summary>
        /// <param name="iUnitOfWork"></param>
        public ApiForm3AController(IUnitOfWork iUnitOfWork)
        {
            _iUnitOfWork = iUnitOfWork;
        }

        #endregion

        #region Get Methods

        [HttpGet("GetById")]
        public JsonResult GetById(int? id)
        {
            return new JsonResult(new
            {
                Content = _iUnitOfWork.Form3A.Find(x => x.AkasmatId == id),
            });
        }

        [HttpGet("Delete")]
        public JsonResult Delete(int id)
        {
            try
            {
                _iUnitOfWork.Form3A.DeleteById(id);

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

            var responseData = _iUnitOfWork.Form3A.GetForm3A(roleId, sectorId, zoneId, divisionId, policeStationId, fromDate.Value.Date, toDate.Value.Date)
                .OrderByDescending(x => x.CreatedDate)
                .OrderBy(x => x.PoliceStationId)
                .Select(x => new
                {
                    x.AkasmatId,
                    CreatedDate = x.CreatedDate.ToString("dd/MM/yyyy"),
                    x.PoliceStationName,
                    x.Complainant_accused,
                    x.Complainant_accusedName,
                    x.HistoryofPast,
                }); ;

            return new JsonResult(new
            {
                Success = true,
                Headers = "Form3A",
                Header_Title = "Form3A",
                Header_Desc = $"તારીખ : {fromDate.Value.Date} થી : {toDate.Value.Date}",
                Content = responseData
            });
        }

        #endregion

        #region Post Methods

        [HttpPost("Save")]
        public JsonResult Save(Post_Form3A form3A)
        {
            try
            {
                if (form3A.AkasmatId == 0)
                {
                    var data = new TblForm3A
                    {
                        PoliceStationId = form3A.PoliceStationId,
                        ComplainantAccused = form3A.ComplainantAccused,
                        ComplainantAccusedName = form3A.ComplainantAccusedName,
                        HistoryofPast = form3A.HistoryofPast,
                        CreatedDate = form3A.CreatedDate,
                        ModifiedDate = form3A.CreatedDate,
                        CreateduserId = Convert.ToInt32(HttpContext.GetClaimsPrincipal().UserId),
                        ModifiedUserId = Convert.ToInt32(HttpContext.GetClaimsPrincipal().UserId),
                        IsActive = true,
                        IsDeleted = false,
                    };

                    _iUnitOfWork.Form3A.Add(data);
                }
                else
                {
                    var data = _iUnitOfWork.Form3A.Find(x => x.AkasmatId == form3A.AkasmatId);

                    if (data == null)
                    {
                        return new JsonResult(new
                        {
                            IsValid = false,
                            Error = ConstantsData.ErrDataNotFound,
                        });
                    }
                    data.PoliceStationId = form3A.PoliceStationId;
                    data.ComplainantAccused = form3A.ComplainantAccused;
                    data.ComplainantAccusedName = form3A.ComplainantAccusedName;
                    data.HistoryofPast = form3A.HistoryofPast;
                    data.CreatedDate = form3A.CreatedDate;
                    data.ModifiedDate = form3A.CreatedDate;
                    data.ModifiedUserId = Convert.ToInt32(HttpContext.GetClaimsPrincipal().UserId);

                    _iUnitOfWork.Form3A.Update(data, data.AkasmatId);
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