using AhmedabadCityDR.Interfaces;
using AhmedabadCityDR.Models.APIModels;
using AhmedabadCityDR.Models.TableModels;
using Microsoft.AspNetCore.Mvc;

namespace AhmedabadCityDR.APIs
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiProhibitionRaidCaseController : ControllerBase
    {
        #region Constants

        /// <summary>
        /// Prohibition catogory Id.
        /// Default : 37
        /// </summary>
        private const int CategoryID = 37;

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
        public ApiProhibitionRaidCaseController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        #endregion

        #region Get Methodes

        /// <summary>
        /// Gets Prohibition Raid Case by id
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns>Returns json response</returns>
        [HttpGet("GetById")]
        public JsonResult GetById(int? id)
        {
            return new JsonResult(new
            {
                Content = _unitOfWork.ProhibitionRaidCase.Find(x => x.ProhibitionRaidCaseId == id),
            });
        }

        /// <summary>
        /// Gets Prohibition Raid Case
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

            var responseData = _unitOfWork.ProhibitionRaidCase
                .GetProhibitionRaidCase(roleId, sectorId, zoneId, divisionId, policeStationId, fromDate.Value.Date, toDate.Value.Date)
                .OrderByDescending(x => x.CreatedDate)
                .ThenBy(x => x.PoliceStationId)
                .Select(x => new
                {
                    x.ProhibitionRaidCaseId,
                    x.PoliceStationNumber,
                    x.PoliceStationName,
                    x.IPACT,
                    CreatedDate = x.CreatedDate.Value.ToString("dd/MM/yyyy"),
                    x.Gubatata,
                    x.CrimePlace,
                    x.RaidTimeCriminalName,
                    x.RaidingPartyEmployeeName,
                    x.InvestigationOfficerName,
                });

            return new JsonResult(new
            {
                Success = true,
                Headers = "Prohibition Raid Case",
                Header_Title = "પ્રોહીબીશન રેઈડ કેસ",
                Header_Desc = $"તારીખ : {fromDate.Value.Date} થી : {toDate.Value.Date}",
                Content = responseData
            });
        }

        /// <summary>
        /// Delete record from Prohibition Raid Case.
        /// </summary>
        /// <param name="id">Id</param>
        /// <returns>Returns json response</returns>
        [HttpGet("Delete")]
        public JsonResult Delete(int id)
        {
            try
            {
                var entity = _unitOfWork.ProhibitionRaidCase.Find(x => x.ProhibitionRaidCaseId == id);
                _unitOfWork.ProhibitionRaidCase.Delete(entity);
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
        /// Save Prohibition Raid Case.
        /// </summary>
        /// <param name="model">part 1 to 5 crime</param>
        /// <returns>Returns response</returns>
        [HttpPost("Save")]
        public JsonResult Save(Post_ProhibitionRaidCase model)
        {
            try
            {
                var user = HttpContext.GetClaimsPrincipal();

                if (model.PoliceStationId == null && Convert.ToInt32(user.PoliceStationId) != 0)
                {
                    model.PoliceStationId = Convert.ToInt32(user.PoliceStationId);
                }

                var oldData = _unitOfWork.ProhibitionRaidCase.FindByPoliceStaionNumber(0,
                                                                                       0,
                                                                                       0,
                                                                                       0,
                                                                                       Convert.ToInt32(user.PoliceStationId),
                                                                                       CategoryID,
                                                                                       model.PoliceStationNumber);

                if (model.ProhibitionRaidCaseId == 0 && oldData == null)
                {
                    var newData = new TblProhibitionRaidCase
                    {
                        PoliceStationId = model.PoliceStationId,
                        CategoryId = CategoryID,
                        PoliceStationNumber = model.PoliceStationNumber,
                        Ipact = model.IPACT,
                        Gubatata = model.Gubatata,
                        CrimePlace = model.CrimePlace,
                        RaidTimeCriminalName = model.RaidTimeCriminalName,
                        RaidingPartyEmployeeName = model.RaidingPartyEmployeeName,
                        InvestigationOfficerName = model.InvestigationOfficerName,
                        CreatedDate = model.CreatedDate,
                        ModifiedDate = model.CreatedDate,
                        CreatedUserId = Convert.ToInt32(user.UserId),
                        ModifiedUserId = Convert.ToInt32(user.UserId),
                        IsActive = true,
                        IsDeleted = false,
                    };

                    _unitOfWork.ProhibitionRaidCase.Add(newData);
                }
                else
                {
                    if (oldData != null)
                    {
                        model.ProhibitionRaidCaseId = oldData.ProhibitionRaidCaseId;
                    }

                    var data = _unitOfWork.ProhibitionRaidCase.Find(x => x.ProhibitionRaidCaseId == model.ProhibitionRaidCaseId);

                    if (data == null)
                    {
                        return new JsonResult(new
                        {
                            IsValid = false,
                            Error = ConstantsData.ErrDataNotFound,
                        });
                    }

                    data.PoliceStationId = model.PoliceStationId;
                    data.CategoryId = CategoryID;
                    data.PoliceStationNumber = model.PoliceStationNumber;
                    data.Ipact = model.IPACT;
                    data.Gubatata = model.Gubatata;
                    data.CrimePlace = model.CrimePlace;
                    data.RaidTimeCriminalName = model.RaidTimeCriminalName;
                    data.RaidingPartyEmployeeName = model.RaidingPartyEmployeeName;
                    data.InvestigationOfficerName = model.InvestigationOfficerName;
                    data.ModifiedDate = model.CreatedDate;
                    data.ModifiedUserId = Convert.ToInt32(user.UserId);
                    data.IsActive = true;
                    data.IsDeleted = false;

                    _unitOfWork.ProhibitionRaidCase.Update(data, data.ProhibitionRaidCaseId);
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
