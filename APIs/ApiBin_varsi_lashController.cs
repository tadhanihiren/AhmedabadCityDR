using AhmedabadCityDR.Interfaces;
using AhmedabadCityDR.Models.APIModels;
using AhmedabadCityDR.Models.TableModels;
using Microsoft.AspNetCore.Mvc;

namespace AhmedabadCityDR.APIs
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiBin_varsi_lashController : ControllerBase
    {
        #region Constants

        /// <summary>
        ///  Bin varsi lash catogory Id.
        /// Default : 36
        /// </summary>
        private const int CategoryID = 36;

        /// <summary>
        ///  Bin varsi lash sub catogory Id.
        /// Default : 101
        /// </summary>
        private const int SubCategoryID = 101;

        #endregion

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
        /// <param name="unitOfWork"></param>
        public ApiBin_varsi_lashController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        #endregion

        #region Get Methodes

        /// <summary>
        /// Gets Bin varsi lash by id
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns>Returns json response</returns>
        [HttpGet("GetById")]
        public JsonResult GetById(int? id)
        {
            return new JsonResult(new
            {
                Content = _unitOfWork.Bin_varsi_lash.Find(x => x.CrimesId == id),
            });
        }

        /// <summary>
        /// Gets Bin varsi lash.
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

            var responseData = _unitOfWork.Bin_varsi_lash
                .GetBin_varsi_lash(roleId, sectorId, zoneId, divisionId, policeStationId, fromDate.Value.Date, toDate.Value.Date, CategoryID)
                .OrderByDescending(x => x.CreatedDate)
                .OrderBy(x => x.SubCategoryId)
                .ThenBy(x => x.PoliceStationId)
                .Select(x => new
                {
                    x.CrimesId,
                    x.PoliceStationNumber,
                    x.PoliceStationName,
                    CreatedDate = x.CreatedDate.Value.ToString("dd/MM/yyyy"),
                    x.Complainer,
                    x.Gubatata,
                    x.Gujatata,
                    x.Gudatata,
                    x.CrimePlace,
                    x.PersonNameWhoFiledCrime,
                    x.InvestigationOfficer,
                    x.ShortDetail,
                    x.HdiitsEntry,
                    x.IPCACT,
                });

            return new JsonResult(new
            {
                Success = true,
                Headers = "Bin varsi lash",
                Header_Title = "બિન વારસિ મૃત શરીર",
                Header_Desc = $"તારીખ : {fromDate.Value.Date} થી : {toDate.Value.Date}",
                Content = responseData
            });
        }

        /// <summary>
        /// Delete record from Bin varsi lash.
        /// </summary>
        /// <param name="id">Id</param>
        /// <returns>Returns json response</returns>
        [HttpGet("Delete")]
        public JsonResult Delete(int id)
        {
            try
            {
                _unitOfWork.Bin_varsi_lash.DeleteById(id);

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
        /// Save Bin varsi lash
        /// </summary>
        /// <param name="model">Bin varsi lash</param>
        /// <returns>Returns response</returns>
        [HttpPost("Save")]
        public JsonResult Save(Post_Bin_varsi_lash model)
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

                var oldData = _unitOfWork.Bin_varsi_lash.FindByPoliceStaionNumber(0,
                                                                                  0,
                                                                                  0,
                                                                                  0,
                                                                                  model.PoliceStationId.Value,
                                                                                  CategoryID,
                                                                                  model.PoliceStationNumber);

                if (model.CrimesId == 0 && oldData == null)
                {
                    var newData = new TblPart1_5Crime
                    {
                        PoliceStationId = model.PoliceStationId,
                        PoliceStationNumber = model.PoliceStationNumber,
                        SubCategoryId = SubCategoryID,
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

                    _unitOfWork.Bin_varsi_lash.Add(newData);
                }
                else
                {
                    if (oldData != null)
                    {
                        model.CrimesId = oldData.CrimesId;
                    }

                    var data = _unitOfWork.Bin_varsi_lash.Find(x => x.CrimesId == model.CrimesId);

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
                    data.SubCategoryId = SubCategoryID;
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
                    data.Latitude = latitude;
                    data.Longitude = longitude;
                    data.IsActive = true;
                    data.IsDelete = false;
                    data.ModifiedDate = model.CreatedDate;
                    data.ModifiedUserId = Convert.ToInt32(HttpContext.GetClaimsPrincipal().UserId);
                    data.Ipcact = model.Ipcact;
                    data.PidhelaKabjanaType = model.PidhelaKabjanaType;

                    _unitOfWork.Bin_varsi_lash.Update(data, data.CrimesId);
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