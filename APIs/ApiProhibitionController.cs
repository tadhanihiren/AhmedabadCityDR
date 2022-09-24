using AhmedabadCityDR.Interfaces;
using AhmedabadCityDR.Models.APIModels;
using AhmedabadCityDR.Models.TableModels;
using Microsoft.AspNetCore.Mvc;

namespace AhmedabadCityDR.APIs
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiProhibitionController : ControllerBase
    {
        #region Constants

        /// <summary>
        /// Part A catogory Id.
        /// Default : 1
        /// </summary>
        private const int PhohibutionCategoryID = 22;

        #endregion

        #region Private Methods

        /// <summary>
        /// Context.
        /// </summary>
        private readonly IUnitOfWork _unitOfWork;

        #endregion

        #region Constructors

        /// <summary>
        /// Constructors
        /// </summary>
        /// <param name="unitOfWork">Context</param>
        public ApiProhibitionController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        #endregion

        #region Get Methodes

        /// <summary>
        /// Gets Phohibution crime by id
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns>Returns json response</returns>
        [HttpGet("GetById")]
        public JsonResult GetById(int? id)
        {
            return new JsonResult(new
            {
                Content = _unitOfWork.Prohibition.Find(x => x.CrimesId == id),
            });
        }

        /// <summary>
        /// Gets Phohibution crime
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

            var responseData = _unitOfWork.Prohibition
                .GetProhibitionCrime(roleId, sectorId, zoneId, divisionId, policeStationId, fromDate.Value.Date, toDate.Value.Date, PhohibutionCategoryID)
                .OrderByDescending(x => x.CreatedDate)
                .OrderBy(x => x.SubCategoryId)
                .ThenBy(x => x.PoliceStationId)
                .Select(x => new
                {
                    x.CrimesId,
                    x.PoliceStationNumber,
                    x.PoliceStationName,
                    CreatedDate = x.CreatedDate.Value.ToString("dd/MM/yyyy"),
                    x.SubCategoryName,
                    x.Complainer,
                    x.Accused,
                    x.Gubatata,
                    x.Gujatata,
                    x.Gudatata,
                    x.CrimePlace,
                    x.CrimePurpose,
                    x.PersonNameWhoFiledCrime,
                    x.InvestigationOfficer,
                    x.ShortDetail,
                    x.LateComplaintReason,
                    x.HdiitsEntry,
                    x.SavendansilText,
                    x.BinSavendansilText,
                    x.Latitude,
                    x.Longitude,
                    x.Complainer_AccusedCriminalHistory,
                    x.IPCACT,
                });

            return new JsonResult(new
            {
                Success = true,
                Headers = "Phohibution crimes",
                Header_Title = "પ્રોહીબીશન કેસોની માહિતી",
                Header_Desc = $"તારીખ : {fromDate.Value.Date} થી : {toDate.Value.Date}",
                Content = responseData
            });
        }

        /// <summary>
        /// Delete record from Phohibution.
        /// </summary>
        /// <param name="id">Id</param>
        /// <returns>Returns json response</returns>
        [HttpGet("Delete")]
        public JsonResult Delete(int id)
        {
            try
            {
                var entity = _unitOfWork.Prohibition.Find(x => x.CrimesId == id);
                _unitOfWork.Prohibition.Delete(entity);
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
        /// Save Phohibution crime
        /// </summary>
        /// <param name="model">Phohibution crime</param>
        /// <returns>Returns response</returns>
        [HttpPost("Save")]
        public JsonResult Save(Post_Prohibition model)
        {
            try
            {
                _ = decimal.TryParse(model.Latitude, out var latitude);
                _ = decimal.TryParse(model.Longitude, out var longitude);
                _ = bool.TryParse(model.Savendansil, out var savendansil);
                _ = bool.TryParse(model.BinSavendansil, out var binSavendansil);

                var user = HttpContext.GetClaimsPrincipal();

                if (model.PoliceStationId == null && Convert.ToInt32(user.PoliceStationId) != 0)
                {
                    model.PoliceStationId = Convert.ToInt32(user.PoliceStationId);
                }

                var oldData = _unitOfWork.Prohibition.FindByPoliceStaionNumber(0,
                                                                               0,
                                                                               0,
                                                                               0,
                                                                               Convert.ToInt32(user.PoliceStationId),
                                                                               PhohibutionCategoryID,
                                                                               model.PoliceStationNumber);

                if (model.CrimesId == 0 && oldData == null)
                {
                    var newData = new TblPart1_5Crime
                    {
                        PoliceStationId = model.PoliceStationId,
                        PoliceStationNumber = model.PoliceStationNumber,
                        SubCategoryId = model.SubCategoryId,
                        Complainer = model.Complainer,
                        Accused = model.Accused,
                        Gubatata = model.Gubatata,
                        Gujatata = model.Gujatata,
                        Gudatata = model.Gudatata,
                        CrimePlace = model.CrimePlace,
                        CrimePurpose = model.CrimePurpose,
                        PersonNameWhoFiledCrime = model.PersonNameWhoFiledCrime,
                        InvestigationOfficer = model.InvestigationOfficer,
                        ShortDetail = model.ShortDetail,
                        LateComplaintReason = model.LateComplaintReason,
                        HdiitsEntry = model.HdiitsEntry,
                        Savendansil = savendansil,
                        BinSavendansil = binSavendansil,
                        ComplainerAccusedCriminalHistory = model.ComplainerAccusedCriminalHistory,
                        Latitude = latitude,
                        Longitude = longitude,
                        IsActive = true,
                        IsDelete = false,
                        CreatedDate = model.CreatedDate,
                        ModifiedDate = model.CreatedDate,
                        CreatedUserId = Convert.ToInt32(HttpContext.GetClaimsPrincipal().UserId),
                        ModifiedUserId = Convert.ToInt32(HttpContext.GetClaimsPrincipal().UserId),
                        Ipcact = model.Ipcact,
                        PidhelaKabjanaType = model.PidhelaKabjanaType
                    };

                    _unitOfWork.Prohibition.Add(newData);
                }
                else
                {
                    if (oldData != null)
                    {
                        model.CrimesId = oldData.CrimesId;
                    }

                    var data = _unitOfWork.Prohibition.Find(x => x.CrimesId == model.CrimesId);

                    if (data == null)
                    {
                        return new JsonResult(new
                        {
                            IsValid = false,
                            Error = ConstantsData.ErrDataNotFound,
                        });
                    }

                    data.PoliceStationId = model.PoliceStationId;
                    data.PoliceStationNumber = model.PoliceStationNumber;
                    data.Complainer = model.Complainer;
                    data.Accused = model.Accused;
                    data.Gubatata = model.Gubatata;
                    data.Gujatata = model.Gujatata;
                    data.Gudatata = model.Gudatata;
                    data.CrimePlace = model.CrimePlace;
                    data.CrimePurpose = model.CrimePurpose;
                    data.PersonNameWhoFiledCrime = model.PersonNameWhoFiledCrime;
                    data.InvestigationOfficer = model.InvestigationOfficer;
                    data.ShortDetail = model.ShortDetail;
                    data.LateComplaintReason = model.LateComplaintReason;
                    data.HdiitsEntry = model.HdiitsEntry;
                    data.Savendansil = savendansil;
                    data.BinSavendansil = binSavendansil;
                    data.ComplainerAccusedCriminalHistory = model.ComplainerAccusedCriminalHistory;
                    data.Latitude = longitude;
                    data.Longitude = longitude;
                    data.ModifiedDate = model.CreatedDate;
                    data.ModifiedUserId = Convert.ToInt32(HttpContext.GetClaimsPrincipal().UserId);
                    data.Ipcact = model.Ipcact;
                    data.PidhelaKabjanaType = model.PidhelaKabjanaType;

                    _unitOfWork.Prohibition.Update(data, data.CrimesId);
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