using AhmedabadCityDR.Interfaces;
using AhmedabadCityDR.Models.APIModels;
using AhmedabadCityDR.Models.TableModels;
using Microsoft.AspNetCore.Mvc;

namespace AhmedabadCityDR.APIs
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiMissingagewiseMasterController : ControllerBase
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
        public ApiMissingagewiseMasterController(IUnitOfWork iUnitOfWork)
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
                Content = _unitOfWork.HistoryOfMissingAgeWiseChaild.Find(x => x.HistoryMissingAgeWiseId == id),
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

            var responseData = _unitOfWork.HistoryOfMissingAgeWiseChaild
                .GetMissingAgeWise(roleId, sectorId, zoneId, divisionId, policeStationId, fromDate.Value.Date, toDate.Value.Date)
               .OrderBy(x => x.PoliceStationId)
                .Select(x => new
                {
                    x.HistoryMissingAgeWiseId,
                    x.PoliceStationName,
                    x.Missingboy,
                    x.Missinggirl,
                    x.MissingChildDetails,
                    x.Returnboy,
                    x.Returngirl,
                    x.ReturnChildDetails,
                    x.Missing1to5boy,
                    x.Missing1to5Girl,
                    x.Missing6to12boy,
                    x.Missing6to12Girl,
                    x.Missing13to18boy,
                    x.Missing13to18Girl,
                    x.Return1to5boy,
                    x.Return1to5Girl,
                    x.Return6to12boy,
                    x.Return6to12Girl,
                    x.Return13to18boy,
                    x.Return13to18Girl,
                    x.Totalmissing,
                    x.Totalreturn,
                    x.Per,
                });

            return new JsonResult(new
            {
                Success = true,
                Headers = "Missing Age Wise",
                Header_Title = "Missing Age Wise",
                Header_Desc = $"તારીખ : {fromDate.Value.Date} થી : {toDate.Value.Date}",
                Content = responseData
            });
        }
        #endregion

        #region Post Methods

        [HttpPost("Save")]
        public JsonResult Save(Post_HistoryMissingagewise model)
        {
            try
            {
                if (model.HistoryMissingAgeWiseId == 0)
                {
                    var data = new TblHistoryMissingAgeWiseChild
                    {
                        PoliceStationId = model.PoliceStationId,
                        CreatedDate = model.CreatedDate,
                        Missingboy = model.Missingboy,
                        Missinggirl = model.Missinggirl,
                        MissingChildDetails = (model.Missinggirl + model.Missingboy),
                        Returnboy = model.Returnboy,
                        Returngirl = model.Returngirl,
                        ReturnChildDetails = (model.Returngirl + model.Returnboy),
                        Missing1to5Girl = model.Missing1to5Girl,
                        Missing1to5boy = model.Missing1to5boy,
                        Missing6to12Girl = model.Missing6to12Girl,
                        Missing6to12boy = model.Missing6to12boy,
                        Missing13to18Girl = model.Missing13to18Girl,
                        Missing13to18boy = model.Missing13to18boy,
                        Return1to5Girl = model.Return1to5Girl,
                        Return1to5boy = model.Return1to5boy,
                        Return6to12Girl = model.Return6to12Girl,
                        Return6to12boy = model.Return6to12boy,
                        Return13to18Girl = model.Return13to18Girl,
                        Return13to18boy = model.Return13to18boy,
                        Per = model.Per,
                        Totalmissing = model.Totalmissing,
                        Totalreturn = model.Totalreturn,
                        CreatedUserId = Convert.ToInt32(HttpContext.GetClaimsPrincipal().UserId),
                        ModifiedUserId = Convert.ToInt32(HttpContext.GetClaimsPrincipal().UserId),
                        IsActive = true,
                        IsDelete = false,
                    };

                    _unitOfWork.HistoryOfMissingAgeWiseChaild.Add(data);

                }
                else
                {
                    var data = _unitOfWork.HistoryOfMissingAgeWiseChaild.Find(x => x.HistoryMissingAgeWiseId == model.HistoryMissingAgeWiseId);

                    if (data == null)
                    {
                        return new JsonResult(new
                        {
                            IsValid = false,
                            Error = ConstantsData.ErrDataNotFound,
                        });
                    }
                    data.PoliceStationId = model.PoliceStationId;
                    data.CreatedDate = model.CreatedDate;
                    data.Missingboy = model.Missingboy;
                    data.Missinggirl = model.Missinggirl;
                    data.MissingChildDetails = (model.Missinggirl + model.Missingboy);
                    data.Returnboy = model.Returnboy;
                    data.Returngirl = model.Returngirl;
                    data.ReturnChildDetails = (model.Returngirl + model.Returnboy);
                    data.Missing1to5Girl = model.Missing1to5Girl;
                    data.Missing1to5boy = model.Missing1to5boy;
                    data.Missing6to12Girl = model.Missing6to12Girl;
                    data.Missing6to12boy = model.Missing6to12boy; ;
                    data.Missing13to18Girl = model.Missing13to18Girl;
                    data.Missing13to18boy = model.Missing13to18boy;
                    data.Return1to5Girl = model.Return1to5Girl;
                    data.Return1to5boy = model.Return1to5boy;
                    data.Return6to12Girl = model.Return6to12Girl;
                    data.Return6to12boy = model.Return6to12boy;
                    data.Return13to18Girl = model.Return13to18Girl;
                    data.Return13to18boy = model.Return13to18boy;
                    data.Per = model.Per;
                    data.Totalmissing = model.Totalmissing;
                    data.Totalreturn = model.Totalreturn;
                    data.ModifiedUserId = Convert.ToInt32(HttpContext.GetClaimsPrincipal().UserId);
                    data.IsActive = true;
                    data.IsDelete = false;

                    _unitOfWork.HistoryOfMissingAgeWiseChaild.Update(data, data.HistoryMissingAgeWiseId);
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
