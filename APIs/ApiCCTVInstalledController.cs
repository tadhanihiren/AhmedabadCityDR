using AhmedabadCityDR.Interfaces;
using AhmedabadCityDR.Models.APIModels;
using AhmedabadCityDR.Models.TableModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AhmedabadCityDR.APIs
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiCCTVInstalledController : ControllerBase
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
        public ApiCCTVInstalledController(IUnitOfWork iUnitOfWork)
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
                Content = _unitOfWork.CCTVInstalled.Find(x => x.InstallId == id),
            });
        }

        [HttpGet("Get")]
        public JsonResult Get(int? searchPoliceStationId)
        {
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

            var responseData = _unitOfWork.CCTVInstalled.GetCCTVInstalled(roleId, sectorId, zoneId, divisionId, policeStationId, DateTime.Now, DateTime.Now)
                .Where(x => x.IsActive == true && x.IsDeleted == false)
                 .OrderBy(x => x.PoliceStationId)
                .Select(x => new
                {
                    x.InstallId,
                    CreatedDate = x.CreatedDate.Value.ToString("dd/MM/yyyy"),
                    x.PoliceStationName,
                    x.PTZ_installed,
                    x.BLT_installed,
                    x.DM_installed,
                    x.Total_installed,
                });

            return new JsonResult(new
            {
                Success = true,
                Headers = "Visitation CrimeBranch",
                Header_Title = "Visitation CrimeBranch",
                Content = responseData
            });
        }


        [HttpGet("Delete")]
        public JsonResult Delete(int id)
        {
            try
            {
                _unitOfWork.CCTVInstalled.DeleteById(id);

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

        #region Post Methodes

        [HttpPost("Save")]
        public JsonResult Save(Post_CCTVInstalled model)
        {
            try
            {
                var user = HttpContext.GetClaimsPrincipal();

                if (model.PoliceStationId == null && Convert.ToInt32(user.PoliceStationId) != 0)
                {
                    model.PoliceStationId = Convert.ToInt32(user.PoliceStationId);
                }

                var oldData = _unitOfWork.CCTVInstalled.GetAllCCTVInstalled().Where(x=> x.PoliceStationId == model.PoliceStationId).ToList();


                if (model.InstallId == 0 && oldData.Count == 0)
                {

                    var data = new TblCctvinstalled
                    {
                        PoliceStationId = model.PoliceStationId,
                        PtzInstalled = model.PtzInstalled,
                        BltInstalled = model.BltInstalled,
                        DmInstalled = model.DmInstalled,
                        TotalInstalled = (model.PtzInstalled + model.BltInstalled + model.DmInstalled),
                        IsActive = true,
                        IsDeleted = false,
                        CreatedDate = DateTime.Now,
                        ModifiedDate = DateTime.Now,
                        CreatedUserId = Convert.ToInt32(HttpContext.GetClaimsPrincipal().UserId),
                        ModifiedUserId = Convert.ToInt32(HttpContext.GetClaimsPrincipal().UserId),

                    };

                    _unitOfWork.CCTVInstalled.Add(data);
                }
                else
                {
                    if (oldData != null)
                    {
                        model.InstallId = oldData[0].InstallId;
                    }

                    var data = _unitOfWork.CCTVInstalled.Find(x => x.InstallId == model.InstallId);

                    if (data == null)
                    {
                        return new JsonResult(new
                        {
                            IsValid = false,
                            Error = ConstantsData.ErrDataNotFound,
                        });
                    }

                    data.PoliceStationId = model.PoliceStationId;
                    data.PtzInstalled = model.PtzInstalled;
                    data.BltInstalled = model.BltInstalled;
                    data.DmInstalled = model.DmInstalled;
                    data.TotalInstalled = (model.PtzInstalled + model.BltInstalled + model.DmInstalled);
                    data.IsActive = true;
                    data.IsDeleted = false;
                    data.ModifiedDate = DateTime.Now;
                    data.ModifiedUserId = Convert.ToInt32(HttpContext.GetClaimsPrincipal().UserId);

                    _unitOfWork.CCTVInstalled.Update(data, data.InstallId);

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
