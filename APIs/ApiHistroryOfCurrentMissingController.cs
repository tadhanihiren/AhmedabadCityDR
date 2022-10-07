using AhmedabadCityDR.Interfaces;
using AhmedabadCityDR.Models.APIModels;
using AhmedabadCityDR.Models.TableModels;
using Microsoft.AspNetCore.Mvc;

namespace AhmedabadCityDR.APIs
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiHistroryOfCurrentMissingController : ControllerBase
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
        public ApiHistroryOfCurrentMissingController(IUnitOfWork iUnitOfWork)
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
                Content = _unitOfWork.HistoryOfCurrentYearMissing.Find(x => x.HistroryOfCurrentMissingId == id),
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

            fromDate = DateTime.Today;
            toDate = DateTime.Today;

            var responseData = _unitOfWork.HistoryOfCurrentYearMissing.GetHistoryCurrentMissing(roleId, sectorId, zoneId, divisionId, policeStationId, fromDate.Value.Date, toDate.Value.Date)
                 .OrderByDescending(x => x.CreatedDate)
                 .OrderBy(x => x.PoliceStationId)
                 .Select(x => new
                 {
                     x.HistroryOfCurrentMissingId,
                     x.PoliceStationName,
                     x.Missingboy,
                     x.Missinggirl,
                     x.Returnboy,
                     x.Returngirl,
                     x.Missingwoman,
                     x.Missingman,
                     x.ReturnWoman,
                     x.Returnman,
                     x.TotalmissingChild,
                     x.TotalRetrunChild,
                     x.TotalMissingPerson,
                     x.TotalReturnPerson,
                     CreatedDate = x.CreatedDate.Value.ToString("dd/MM/yyyy"),
                 });

            return new JsonResult(new
            {
                Success = true,
                Headers = "Histrory Of CurrentMissing",
                Header_Title = "Histrory Of CurrentMissing",
                Content = responseData
            });
        }
        #endregion

        #region Post Methods

        [HttpPost("Save")]
        public JsonResult Save(Post_HistoryOfCurrentYearMissing model)
        {
            try
            {
                if (model.HistroryOfCurrentMissingId == 0)
                {
                    var data = new TblhistroryOfCurrentMissing
                    {
                        PoliceStationId = model.PoliceStationId,
                        Missingboy = model.Missingboy,
                        Missinggirl = model.Missinggirl,
                        Returnboy = model.Missingboy,
                        Returngirl = model.Returngirl,
                        Missingwoman = model.Missingwoman,
                        Missingman = model.Missingman,
                        ReturnWoman = model.Returnman,
                        Returnman = model.Returnman,
                        TotalmissingChild = model.TotalmissingChild,
                        TotalRetrunChild = model.TotalRetrunChild,
                        TotalMissingPerson = model.TotalMissingPerson,
                        TotalReturnPerson = model.TotalReturnPerson,
                        CreatedDate = model.CreatedDate,
                        CreatedUserId = Convert.ToInt32(HttpContext.GetClaimsPrincipal().UserId),
                        ModifiedUserId = Convert.ToInt32(HttpContext.GetClaimsPrincipal().UserId),
                        IsActive = true,
                        IsDelete = false,
                    };

                    _unitOfWork.HistoryOfCurrentYearMissing.Add(data);

                }
                else
                {
                    var data = _unitOfWork.HistoryOfCurrentYearMissing.Find(x => x.HistroryOfCurrentMissingId == model.HistroryOfCurrentMissingId);

                    if (data == null)
                    {
                        return new JsonResult(new
                        {
                            IsValid = false,
                            Error = ConstantsData.ErrDataNotFound,
                        });
                    }
                    data.PoliceStationId = model.PoliceStationId;
                    data.Missingboy = model.Missingboy;
                    data.Missinggirl = model.Missinggirl;
                    data.Returnboy = model.Missingboy;
                    data.Returngirl = model.Returngirl;
                    data.Missingwoman = model.Missingwoman;
                    data.Missingman = model.Missingman;
                    data.ReturnWoman = model.Returnman;
                    data.Returnman = model.Returnman;
                    data.TotalmissingChild = model.TotalmissingChild;
                    data.TotalRetrunChild = model.TotalRetrunChild;
                    data.TotalMissingPerson = model.TotalMissingPerson;
                    data.TotalReturnPerson = model.TotalReturnPerson;
                    data.CreatedDate = model.CreatedDate;
                    data.ModifiedUserId = Convert.ToInt32(HttpContext.GetClaimsPrincipal().UserId);
                    data.IsActive = true;
                    data.IsDelete = false;

                    _unitOfWork.HistoryOfCurrentYearMissing.Update(data, data.HistroryOfCurrentMissingId);
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
