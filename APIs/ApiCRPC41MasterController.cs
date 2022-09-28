using AhmedabadCityDR.Interfaces;
using AhmedabadCityDR.Models.APIModels;
using AhmedabadCityDR.Models.TableModels;
using Microsoft.AspNetCore.Mvc;

namespace AhmedabadCityDR.APIs
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiCRPC41MasterController : ControllerBase
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
        public ApiCRPC41MasterController(IUnitOfWork unitOfWork)
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
                Content = _unitOfWork.CRPC41Master.Find(x => x.Crpcid == id),
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

            var responseData = _unitOfWork.CRPC41Master
                .GetCRPC41(roleId, sectorId, zoneId, divisionId, policeStationId, fromDate.Value.Date, toDate.Value.Date)
                .OrderByDescending(x => x.CreatedDate)
                .ThenBy(x => x.PoliceStationId)
                .Select(x => new
                {
                    x.CRPCId,
                    x.PoliceStationName,
                    CreatedDate = x.CreatedDate.Value.ToString("dd/MM/yyyy"),
                    x.CRPCNumber,
                    x.Crime,
                    x.AccusedName,
                    x.VehicalDetails,
                    x.AccusedDetails,
                    x.ShortDetails,
                });

            return new JsonResult(new
            {
                Success = true,
                Headers = "CRPC41Master",
                Header_Title = "CRPC41Master",
                Header_Desc = $"તારીખ : {fromDate.Value.Date} થી : {toDate.Value.Date}",
                Content = responseData
            });
        }

        [HttpGet("Delete")]
        public JsonResult Delete(int id)
        {
            try
            {
                _unitOfWork.CRPC41Master.DeleteById(id);

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
        public JsonResult Save(Post_CRPC41Master model)
        {
            try
            {
                if (model.CRPCId == 0)
                {
                    var newData = new TblCrpc41master
                    {
                        PoliceStationId = model.PoliceStationId.Value,
                        Crpcnumber = model.CRPCNumber,
                        Crime = model.Crime,
                        AccusedName = model.AccusedName,
                        VehicalDetails = model.VehicalDetails,
                        AccusedDetails = model.AccusedDetails,
                        ShortDetails = model.ShortDetails,
                        IsActive = true,
                        IsDelete = false,
                        CreatedDate = model.CreatedDate,
                        ModifiedDate = model.CreatedDate,
                        CreatedUserId = Convert.ToInt32(HttpContext.GetClaimsPrincipal().UserId),
                        ModifiedUserId = Convert.ToInt32(HttpContext.GetClaimsPrincipal().UserId),
                    };

                    _unitOfWork.CRPC41Master.Add(newData);
                }
                else
                {
                    var data = _unitOfWork.CRPC41Master.Find(x => x.Crpcid == model.CRPCId);

                    if (data == null)
                    {
                        return new JsonResult(new
                        {
                            IsValid = false,
                            Error = ConstantsData.ErrDataNotFound,
                        });
                    }

                    data.PoliceStationId = model.PoliceStationId.Value;
                    data.Crpcnumber = model.CRPCNumber;
                    data.Crime = model.Crime;
                    data.AccusedName = model.AccusedName;
                    data.VehicalDetails = model.VehicalDetails;
                    data.AccusedDetails = model.AccusedDetails;
                    data.ShortDetails = model.ShortDetails;
                    data.ModifiedDate = model.CreatedDate;
                    data.ModifiedUserId = Convert.ToInt32(HttpContext.GetClaimsPrincipal().UserId);

                    _unitOfWork.CRPC41Master.Update(data, data.Crpcid);
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
