using AhmedabadCityDR.Interfaces;
using AhmedabadCityDR.Models.APIModels;
using AhmedabadCityDR.Models.TableModels;
using Microsoft.AspNetCore.Mvc;

namespace AhmedabadCityDR.APIs
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiStationaryMasterController : ControllerBase
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
        public ApiStationaryMasterController(IUnitOfWork iUnitOfWork)
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
                Content = _unitOfWork.StationaryDetails.Find(x => x.StationaryId == id),
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

            var responseData = _unitOfWork.StationaryDetails
                .GetStationary(roleId, sectorId, zoneId, divisionId, policeStationId, fromDate.Value.Date, toDate.Value.Date)
                .OrderByDescending(x => x.CreatedDate)
                .ThenBy(x => x.PoliceStationId)
                .Select(x => new
                {
                    x.StationaryId,
                    x.PoliceStationName,
                    CreatedDate = x.CreatedDate.Value.ToString("dd/MM/yyyy"),
                    x.Telephone,
                    x.Computer,
                    x.Giswan_Connectivity,
                    x.Fax_machine,
                    x.Xerox_machine,
                    x.Other_Stationary_Stocks,
                    x.IsActive,
                    x.IsDelete,
                });

            return new JsonResult(new
            {
                Success = true,
                Headers = "Stationary Details",
                Header_Title = "Stationary Details",
                Header_Desc = $"તારીખ : {fromDate.Value.Date} થી : {toDate.Value.Date}",
                Content = responseData
            });
        }

        [HttpGet("Delete")]
        public JsonResult Delete(int id)
        {
            try
            {
                _unitOfWork.StationaryDetails.DeleteById(id);

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
        public JsonResult Save(Post_StationaryMaster model)
        {
            try
            {
                model.PoliceStationId ??= Convert.ToInt32(HttpContext.GetClaimsPrincipal().PoliceStationId);

                if (model.StationaryId == 0)
                {

                    var lstStationery = _unitOfWork.StationaryDetails.GetAll().Where(x => x.PoliceStationId == model.PoliceStationId).ToList();

                    foreach (var item in lstStationery)
                    {
                        item.IsActive = false;
                        item.IsDelete = false;
                        item.ModifiedDate = model.CreatedDate;
                        item.ModifiedUserId = Convert.ToInt32(HttpContext.GetClaimsPrincipal().UserId);

                        _unitOfWork.StationaryDetails.Update(item, item.StationaryId);
                        _unitOfWork.Save();
                    }

                    var data = new TblStationery
                    {
                        PoliceStationId = model.PoliceStationId,
                        CreatedDate = model.CreatedDate,
                        Telephone = model.Telephone,
                        Computer = model.Computer,
                        GiswanConnectivity = model.GiswanConnectivity,
                        FaxMachine = model.FaxMachine,
                        XeroxMachine = model.XeroxMachine,
                        OtherStationaryStocks = model.OtherStationaryStocks,
                        ModifiedDate = model.CreatedDate,
                        CreatedUserId = Convert.ToInt32(HttpContext.GetClaimsPrincipal().UserId),
                        ModifiedUserId = Convert.ToInt32(HttpContext.GetClaimsPrincipal().UserId),
                        IsActive = true,
                        IsDelete = false
                    };

                    _unitOfWork.StationaryDetails.Add(data);

                }
                else
                {
                    var data = _unitOfWork.StationaryDetails.Find(x => x.StationaryId == model.StationaryId);

                    if (data == null)
                    {
                        return new JsonResult(new
                        {
                            IsValid = false,
                            Error = ConstantsData.ErrDataNotFound,
                        });
                    }

                    data.PoliceStationId = model.PoliceStationId.Value;
                    data.Telephone = model.Telephone;
                    data.Computer = model.Computer;
                    data.GiswanConnectivity = model.GiswanConnectivity;
                    data.FaxMachine = model.FaxMachine;
                    data.XeroxMachine = model.XeroxMachine;
                    data.OtherStationaryStocks = model.OtherStationaryStocks;
                    data.ModifiedDate = model.CreatedDate;
                    data.ModifiedUserId = Convert.ToInt32(HttpContext.GetClaimsPrincipal().UserId);

                    _unitOfWork.StationaryDetails.Update(data, data.StationaryId);
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
