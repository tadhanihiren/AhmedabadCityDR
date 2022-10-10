using AhmedabadCityDR.Interfaces;
using AhmedabadCityDR.Models.APIModels;
using AhmedabadCityDR.Models.TableModels;
using Microsoft.AspNetCore.Mvc;

namespace AhmedabadCityDR.APIs
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiAutoRickshawDetailsMasterController : ControllerBase
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
        public ApiAutoRickshawDetailsMasterController(IUnitOfWork unitOfWork)
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
                Content = _unitOfWork.AutoRickshawDetail.Find(x => x.AutoRickshawId == id),
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

            var responseData = _unitOfWork.AutoRickshawDetail
                .GetAutoRickshawDetail(roleId, sectorId, zoneId, divisionId, policeStationId, fromDate.Value.Date, toDate.Value.Date)
                .Where(x => x.IsActive == true && x.IsDeleted == false)
                .OrderByDescending(x => x.CreatedDate)
                .ThenBy(x => x.PoliceStationId)
                .Select(x => new
                {
                    x.AutoRickshawId,
                    x.PoliceStationName,
                    CreatedDate = x.CreatedDate.Value.ToString("dd/MM/yyyy"),
                    x.AutoRickshawNo,
                    x.DriverName,
                    x.OwnerName,
                    x.LicenseNumber,
                    x.PermitNumber,
                    x.DriversBaseNo,
                    x.RCBook,
                    x.RCBook_Detail,
                    x.InsurancePolicy,
                    x.CheckingOperation,
                });

            return new JsonResult(new
            {
                Success = true,
                Headers = "AutoRickshawDetail",
                Header_Title = "AutoRickshawDetail",
                Header_Desc = $"તારીખ : {fromDate.Value.Date} થી : {toDate.Value.Date}",
                Content = responseData
            });
        }

        [HttpGet("Delete")]
        public JsonResult Delete(int id)
        {
            try
            {
                _unitOfWork.AutoRickshawDetail.DeleteById(id);

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
        public JsonResult Save(Post_AutoRickshawDetail model)
        {
            try
            {
                if (model.AutoRickshawId == 0)
                {
                    var newData = new TblAutoRickshawDetail
                    {
                        PoliceStationId = model.PoliceStationId,
                        AutoRickshawNo = model.AutoRickshawNo,
                        DriverName = model.DriverName,
                        OwnerName = model.OwnerName,
                        LicenseNumber = model.LicenseNumber,
                        PermitNumber = model.PermitNumber,
                        DriversBaseNo = model.DriversBaseNo,
                        Rcbook = model.RCBook,
                        RcbookDetail = model.RCBookDetail,
                        InsurancePolicy = model.InsurancePolicy,
                        CheckingOperation = model.CheckingOperation,
                        IsActive = true,
                        IsDeleted = false,
                        CreatedDate = model.CreatedDate,
                        ModifiedDate = model.CreatedDate,
                        CreatedUserId = Convert.ToInt32(HttpContext.GetClaimsPrincipal().UserId),
                        ModifiedUserId = Convert.ToInt32(HttpContext.GetClaimsPrincipal().UserId),
                    };

                    _unitOfWork.AutoRickshawDetail.Add(newData);
                }
                else
                {
                    var data = _unitOfWork.AutoRickshawDetail.Find(x => x.AutoRickshawId == model.AutoRickshawId);

                    if (data == null)
                    {
                        return new JsonResult(new
                        {
                            IsValid = false,
                            Error = ConstantsData.ErrDataNotFound,
                        });
                    }

                    data.PoliceStationId = model.PoliceStationId;
                    data.AutoRickshawNo = model.AutoRickshawNo;
                    data.DriverName = model.DriverName;
                    data.OwnerName = model.OwnerName;
                    data.LicenseNumber = model.LicenseNumber;
                    data.PermitNumber = model.PermitNumber;
                    data.DriversBaseNo = model.DriversBaseNo;
                    data.Rcbook = model.RCBook;
                    data.RcbookDetail = model.RCBookDetail;
                    data.InsurancePolicy = model.InsurancePolicy;
                    data.CheckingOperation = model.CheckingOperation;
                    data.ModifiedDate = model.CreatedDate;
                    data.ModifiedUserId = Convert.ToInt32(HttpContext.GetClaimsPrincipal().UserId);

                    _unitOfWork.AutoRickshawDetail.Update(data, data.AutoRickshawId);
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
