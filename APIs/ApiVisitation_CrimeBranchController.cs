using AhmedabadCityDR.Interfaces;
using AhmedabadCityDR.Models.APIModels;
using AhmedabadCityDR.Models.TableModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AhmedabadCityDR.APIs
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiVisitation_CrimeBranchController : ControllerBase
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
        public ApiVisitation_CrimeBranchController(IUnitOfWork iUnitOfWork)
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
                Content = _unitOfWork.Visitation_CrimeBranch.Find(x => x.VisitationId == id),
            });
        }

        [HttpGet("Delete")]
        public JsonResult Delete(int id)
        {
            try
            {
                _unitOfWork.Visitation_CrimeBranch.DeleteById(id);

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

            var responseData = _unitOfWork.Visitation_CrimeBranch.GetVisitationCrimeBranch(roleId, sectorId, zoneId, divisionId, policeStationId, fromDate.Value.Date, toDate.Value.Date)
                 .OrderByDescending(x => x.CreatedDate)
                 .OrderBy(x => x.PoliceStationId)
                .Select(x => new
                {
                    x.VisitationId,
                    VisitDate = x.VisitDate.Value.ToString("dd/MM/yyyy"),
                    x.GUBATATA_CrimePlace,
                    x.PoliceStationName,
                    x.Visiter_OfficerName,
                    x.CrimeVisitPlace,
                    CreatedDate = x.CreatedDate.Value.ToString("dd/MM/yyyy"),
                });

            return new JsonResult(new
            {
                Success = true,
                Headers = "Visitation CrimeBranch",
                Header_Title = "Visitation CrimeBranch",
                Content = responseData
            });
        }
        #endregion

        #region Post Methods

        [HttpPost("Save")]
        public JsonResult Save(Post_Visitation_CrimeBranch model)
        {
            try
            {
                if (model.VisitationId == 0)
                {
                    var data = new TblVisitationCrimeBranch
                    {
                        PoliceStationId = model.PoliceStationId,
                        GubatataCrimePlace = model.GubatataCrimePlace,
                        VisitDate = model.VisitDate,
                        CrimeVisitPlace = model.CrimeVisitPlace,
                        VisiterOfficerName = model.VisiterOfficerName,
                        CreatedDate = model.CreatedDate,
                        ModifiedDate = model.CreatedDate,
                        CreatedUserId = Convert.ToInt32(HttpContext.GetClaimsPrincipal().UserId),
                        ModifiedUserId = Convert.ToInt32(HttpContext.GetClaimsPrincipal().UserId),
                        IsActive = true,
                        IsDeleted = false,
                    };

                    _unitOfWork.Visitation_CrimeBranch.Add(data);

                }
                else
                {
                    var data = _unitOfWork.Visitation_CrimeBranch.Find(x => x.VisitationId == model.VisitationId);

                    if (data == null)
                    {
                        return new JsonResult(new
                        {
                            IsValid = false,
                            Error = ConstantsData.ErrDataNotFound,
                        });
                    }
                    data.PoliceStationId = model.PoliceStationId;
                    data.GubatataCrimePlace = model.GubatataCrimePlace;
                    data.VisitDate = model.VisitDate;
                    data.CrimeVisitPlace = model.CrimeVisitPlace;
                    data.VisiterOfficerName = model.VisiterOfficerName;
                    data.ModifiedUserId = Convert.ToInt32(HttpContext.GetClaimsPrincipal().UserId);
                    data.IsActive = true;
                    data.IsDeleted = false;

                    _unitOfWork.Visitation_CrimeBranch.Update(data, data.VisitationId);
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
