using AhmedabadCityDR.Interfaces;
using AhmedabadCityDR.Models.APIModels;
using AhmedabadCityDR.Models.TableModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AhmedabadCityDR.APIs
{
    [Route("api/[controller]")]
    [ApiController]
    ///Test
    public class ApiAccusedInformationMasterController : ControllerBase
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
        public ApiAccusedInformationMasterController(IUnitOfWork iUnitOfWork)
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
                Content = _unitOfWork.AccusedInformation.Find(x => x.AccusedInformationId == id),
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

            var responseData = _unitOfWork.AccusedInformation
                .GetAccusedInformation(roleId, sectorId, zoneId, divisionId, policeStationId, fromDate.Value.Date, toDate.Value.Date)
                .Where( x => x.SectorId==1 || x.SectorId==2)
                .OrderBy(x => x.PoliceStationId)
                .Select(x => new
                {
                    x.AccusedInformationId,
                    x.PoliceStationName,
                    x.TotalCaches,
                    x.AvailableCaches,
                    x.NotAvailableCachesReasonRemarks,
                    x.TotalAccused,
                    x.ArrestedAccused,
                    x.RemainingArrestedAccused,
                    x.CRPCSection_7_UnderProcedure,
                    x.CRPCSection_8_UnderProcedure,
                    x.CRPCSection_83_UnderProcedure,
                    x.CRPCSection_299_UnderProcedure,
                    x.IPC_174_UnderProcedure,
                    CreatedDate = x.CreatedDate.Value.ToString("dd/MM/yyyy"),
                });

            return new JsonResult(new
            {
                Success = true,
                Headers = "AccusedInformation",
                Header_Title = "AccusedInformation",
                Header_Desc = $"તારીખ : {fromDate.Value.Date} થી : {toDate.Value.Date}",
                Content = responseData
            });
        }

        [HttpGet("Delete")]
        public JsonResult Delete(int id)
        {
            try
            {
                _unitOfWork.AccusedInformation.DeleteById(id);

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
        public JsonResult Save(Post_AccusedInformation model)
        {
            try
            {
                model.PoliceStationId ??= Convert.ToInt32(HttpContext.GetClaimsPrincipal().PoliceStationId);                                    

                if (model.AccusedInformationId == 0)
                {
                    var lastRecord = _unitOfWork.AccusedInformation.GetAll().OrderByDescending(x => x.AccusedInformationId).Take(1).ToList();
                    var newId = lastRecord[0].AccusedInformationId + 1;

                    var lstAccusedInformation = _unitOfWork.AccusedInformation.GetAll()
                                                                                     .Where(x => x.IsActive == true && x.PoliceStationId == model.PoliceStationId)
                                                                                     .ToList();

                    foreach (var item in lstAccusedInformation)
                    {
                        _unitOfWork.AccusedInformation.DeleteById(item.AccusedInformationId);
                        _unitOfWork.Save();
                    }
                    var data = new TblAccusedInformation
                    {
                        AccusedInformationId = newId,
                        PoliceStationId = model.PoliceStationId,
                        TotalCaches = model.TotalCaches,
                        AvailableCaches = model.AvailableCaches,
                        NotAvailableCachesReasonRemarks = model.NotAvailableCachesReasonRemarks,
                        TotalAccused = model.TotalAccused,
                        ArrestedAccused = model.ArrestedAccused,
                        RemainingArrestedAccused = model.RemainingArrestedAccused,
                        Crpcsection7UnderProcedure = model.Crpcsection7UnderProcedure,
                        Crpcsection8UnderProcedure = model.Crpcsection8UnderProcedure,
                        Crpcsection83UnderProcedure = model.Crpcsection83UnderProcedure,
                        Crpcsection299UnderProcedure = model.Crpcsection299UnderProcedure,
                        Ipc174UnderProcedure = model.Ipc174UnderProcedure,
                        IsActive = true,
                        IsDeleted = false,
                        CreatedDate = model.CreatedDate,
                        ModifiedDate = model.CreatedDate,
                        CreatedUserId = Convert.ToInt32(HttpContext.GetClaimsPrincipal().UserId),
                        ModifiedUserId = Convert.ToInt32(HttpContext.GetClaimsPrincipal().UserId),

                    };

                    _unitOfWork.AccusedInformation.Add(data);
                }
                else
                {
                    var data = _unitOfWork.AccusedInformation.Find(x => x.AccusedInformationId == model.AccusedInformationId);

                    if (data == null)
                    {
                        return new JsonResult(new
                        {
                            IsValid = false,
                            Error = ConstantsData.ErrDataNotFound,
                        });
                    }
                    data.PoliceStationId = model.PoliceStationId;
                    data.TotalCaches = model.TotalCaches;
                    data.AvailableCaches = model.AvailableCaches;
                    data.NotAvailableCachesReasonRemarks = model.NotAvailableCachesReasonRemarks;
                    data.TotalAccused = model.TotalAccused;
                    data.ArrestedAccused = model.ArrestedAccused;
                    data.RemainingArrestedAccused = model.RemainingArrestedAccused;
                    data.Crpcsection7UnderProcedure = model.Crpcsection7UnderProcedure;
                    data.Crpcsection8UnderProcedure = model.Crpcsection8UnderProcedure;
                    data.Crpcsection83UnderProcedure = model.Crpcsection83UnderProcedure;
                    data.Crpcsection299UnderProcedure = model.Crpcsection299UnderProcedure;
                    data.Ipc174UnderProcedure = model.Ipc174UnderProcedure;
                    data.ModifiedUserId = Convert.ToInt32(HttpContext.GetClaimsPrincipal().UserId);
                    data.IsActive = true;
                    data.IsDeleted = false;

                    _unitOfWork.AccusedInformation.Update(data, data.AccusedInformationId);
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
