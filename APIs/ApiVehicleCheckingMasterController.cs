using AhmedabadCityDR.Interfaces;
using AhmedabadCityDR.Models.APIModels;
using AhmedabadCityDR.Models.TableModels;
using Microsoft.AspNetCore.Mvc;

namespace AhmedabadCityDR.APIs
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiVehicleCheckingMasterController : ControllerBase
    {
        #region Private Members

        /// <summary>
        /// UnitOfWork.
        /// </summary>
        private readonly IUnitOfWork _unitOfWork;

        #endregion

        #region Constructors

        /// <summary>
        /// Constructors
        /// </summary>
        /// <param name="unitOfWork"></param>
        public ApiVehicleCheckingMasterController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        #endregion

        #region Get Methodes

        [HttpGet("GetById")]
        public JsonResult GetById(int? id)
        {
            return new JsonResult(new
            {
                Content = _unitOfWork.VehicleCheckingMaster.Find(x => x.VehicleCheckingId == id),
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

            var responseData = _unitOfWork.VehicleCheckingMaster
                .GetVehicleCheckingMaster(roleId, sectorId, zoneId, divisionId, policeStationId, fromDate.Value.Date, toDate.Value.Date)
                .Where(x => x.IsActive == true && x.IsDeleted == false)
                .OrderBy(x => x.VehicleCheckingId)
                .Select(x => new
                {
                    x.VehicleCheckingId,
                    x.PoliceStationName,
                    CreatedDate = x.CreatedDate.Value.ToString("dd/MM/yyyy"),
                    x.SubCategoryName,
                    x.Checktwowheeler,
                    x.Checkthreewheeler,
                    x.dandtwowheeler,
                    x.detain,
                    x.Remarks,
                });

            return new JsonResult(new
            {
                Success = true,
                Headers = "VehicleCheckingMaster",
                Header_Title = "VehicleCheckingMaster",
                Header_Desc = $"તારીખ : {fromDate.Value.Date} થી : {toDate.Value.Date}",
                Content = responseData
            });
        }

        [HttpGet("Delete")]
        public JsonResult Delete(int id)
        {
            try
            {
                _unitOfWork.VehicleCheckingMaster.DeleteById(id);

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

        [HttpPost("Save")]
        public JsonResult Save(Post_VehicleCheckingMaster model)
        {
            try
            {
                var user = HttpContext.GetClaimsPrincipal();

                if (model.PoliceStationId == null && Convert.ToInt32(user.PoliceStationId) != 0)
                {
                    model.PoliceStationId = Convert.ToInt32(user.PoliceStationId);
                }

                var oldData = _unitOfWork.VehicleCheckingMaster.GetVehicleCheckingMaster(0,
                                                                                         0,
                                                                                         0,
                                                                                         0,
                                                                                         model.PoliceStationId.Value,
                                                                                         model.CreatedDate.Value,
                                                                                         model.CreatedDate.Value)
                                                                .Where(x => x.IsActive == true && x.IsDeleted == false)
                                                                .ToList();

                if (model.VehicleCheckingId == 0 && oldData.Count == 0)
                {
                    var newData = new TblPoliceStationVehicleChecking
                    {
                        SubCategoryId = model.SubCategoryId,
                        PoliceStationId = model.PoliceStationId,
                        Checktwowheeler = model.Checktwowheeler,
                        Dandtwowheeler = model.dandtwowheeler,
                        Checkthreewheeler = model.Checkthreewheeler,
                        Dandthreewheeler = model.dandthreewheeler,
                        Checkfourwheeler = model.Checkfourwheeler,
                        Dandfourwheeler = model.dandfourwheeler,
                        Detain = model.detain,
                        Remarks = model.Remarks,
                        IsActive = true,
                        IsDeleted = false,
                        CreatedDate = model.CreatedDate,
                        ModifiedDate = model.CreatedDate,
                        CreateduserId = Convert.ToInt32(HttpContext.GetClaimsPrincipal().UserId),
                        ModifiedUserId = Convert.ToInt32(HttpContext.GetClaimsPrincipal().UserId),
                    };

                    _unitOfWork.VehicleCheckingMaster.Add(newData);
                }
                else
                {
                    if (oldData != null)
                    {
                        model.VehicleCheckingId = oldData[0].VehicleCheckingId;
                    }

                    var data = _unitOfWork.VehicleCheckingMaster.Find(x => x.VehicleCheckingId == model.VehicleCheckingId);

                    if (data == null)
                    {
                        return new JsonResult(new
                        {
                            IsValid = false,
                            Error = ConstantsData.ErrDataNotFound,
                        });
                    }

                    data.SubCategoryId = model.SubCategoryId;
                    data.PoliceStationId = model.PoliceStationId;
                    data.Checktwowheeler = model.Checktwowheeler;
                    data.Dandtwowheeler = model.dandtwowheeler;
                    data.Checkthreewheeler = model.Checkthreewheeler;
                    data.Dandthreewheeler = model.dandthreewheeler;
                    data.Checkfourwheeler = model.Checkfourwheeler;
                    data.Dandfourwheeler = model.dandfourwheeler;
                    data.Detain = model.detain;
                    data.Remarks = model.Remarks;
                    data.ModifiedDate = model.CreatedDate;
                    data.ModifiedUserId = Convert.ToInt32(HttpContext.GetClaimsPrincipal().UserId);

                    _unitOfWork.VehicleCheckingMaster.Update(data, data.VehicleCheckingId);
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
