using AhmedabadCityDR.Interfaces;
using AhmedabadCityDR.Models.APIModels;
using AhmedabadCityDR.Models.TableModels;
using Microsoft.AspNetCore.Mvc;

namespace AhmedabadCityDR.APIs
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiAksmat_DeathController : ControllerBase
    {
        #region Constants

        /// <summary>
        /// Aksmat Death catogory Id.
        /// Default : 35
        /// </summary>
        private const int AksmatDeathCategoryID = 35;

        /// <summary>
        /// Aksmat Death sub catogory Id.
        /// Default : 100
        /// </summary>
        private const int SubCategoryID = 100;

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
        /// <param name="iUnitOfWork"></param>
        public ApiAksmat_DeathController(IUnitOfWork iUnitOfWork)
        {
            _unitOfWork = iUnitOfWork;
        }

        #endregion

        #region Get Methods

        [HttpGet("GetById")]
        public IActionResult GetById(int? id)
        {
            return new OkObjectResult(new
            {
                Content = _unitOfWork.Aksmat_Death.Find(x => x.CrimesId == id),
            });
        }

        [HttpGet("Delete")]
        public JsonResult Delete(int id)
        {
            try
            {
                _unitOfWork.Aksmat_Death.DeleteById(id);

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

            var responseData = _unitOfWork.Aksmat_Death.GetAksmat_Death(roleId, sectorId, zoneId, divisionId, policeStationId, fromDate.Value.Date, toDate.Value.Date, AksmatDeathCategoryID)
             .OrderBy(x => x.PoliceStationId)
            .Select(x => new
            {
                x.CrimesId,
                x.PoliceStationNumber,
                x.PoliceStationName,
                CreatedDate = x.CreatedDate.Value.ToString("dd/MM/yyyy"),
                x.Complainer,
                x.Accused,
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
                Headers = "Aksmat_Death",
                Header_Title = "અકસ્માત મોત",
                Header_Desc = $"તારીખ : {fromDate.Value.Date} થી : {toDate.Value.Date}",
                Content = responseData
            });
        }

        #endregion

        #region Post Methodes

        [HttpPost("Save")]
        public JsonResult Save(Post_AksmatDeath model)
        {
            try
            {
                var user = HttpContext.GetClaimsPrincipal();

                var policeStationId = Convert.ToInt32(user.PoliceStationId);

                var oldData = _unitOfWork.Aksmat_Death.FindByPoliceStaionNumber(0,
                                                                                 0,
                                                                                 0,
                                                                                 0,
                                                                                 policeStationId,
                                                                                 AksmatDeathCategoryID,
                                                                                 model.PoliceStationNumber);

                if (model.CrimesId == 0 && oldData == null)
                {
                    var data = new TblPart1_5Crime
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
                        PersonNameWhoFiledCrime = model.PersonNameWhoFiledCrime,
                        InvestigationOfficer = model.InvestigationOfficer,
                        ShortDetail = model.ShortDetail,
                        HdiitsEntry = model.HdiitsEntry,
                        IsActive = true,
                        IsDelete = false,
                        CreatedDate = model.CreatedDate,
                        ModifiedDate = model.CreatedDate,
                        CreatedUserId = Convert.ToInt32(HttpContext.GetClaimsPrincipal().UserId),
                        ModifiedUserId = Convert.ToInt32(HttpContext.GetClaimsPrincipal().UserId),
                        Ipcact = model.Ipcact,
                    };

                    _unitOfWork.Aksmat_Death.Add(data);
                }
                else
                {
                    if (oldData != null)
                    {
                        model.CrimesId = oldData.CrimesId;
                    }
                    var data = _unitOfWork.Aksmat_Death.Find(x => x.CrimesId == model.CrimesId);

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
                    data.PersonNameWhoFiledCrime = model.PersonNameWhoFiledCrime;
                    data.InvestigationOfficer = model.InvestigationOfficer;
                    data.ShortDetail = model.ShortDetail;
                    data.HdiitsEntry = model.HdiitsEntry;
                    data.IsActive = true;
                    data.IsDelete = false;
                    data.ModifiedDate = model.CreatedDate;
                    data.ModifiedUserId = Convert.ToInt32(HttpContext.GetClaimsPrincipal().UserId);
                    data.Ipcact = model.Ipcact;

                    _unitOfWork.Aksmat_Death.Update(data, data.CrimesId);
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