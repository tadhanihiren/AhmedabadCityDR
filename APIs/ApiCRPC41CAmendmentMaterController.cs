using AhmedabadCityDR.Interfaces;
using AhmedabadCityDR.Models.APIModels;
using AhmedabadCityDR.Models.TableModels;
using Microsoft.AspNetCore.Mvc;

namespace AhmedabadCityDR.APIs
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiCRPC41CAmendmentMaterController : ControllerBase
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
        public ApiCRPC41CAmendmentMaterController(IUnitOfWork unitOfWork)
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
                Content = _unitOfWork.CRPC41CAmendmentMater.Find(x => x.Crpc41cid == id),
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

            var responseData = _unitOfWork.CRPC41CAmendmentMater
                .GetCRPC41C(roleId, sectorId, zoneId, divisionId, policeStationId, fromDate.Value.Date, toDate.Value.Date)
                .OrderByDescending(x => x.CreatedDate)
                .ThenBy(x => x.PoliceStationId)
                .Select(x => new
                {
                    x.CRPC41CId,
                    x.PoliceStationName,
                    CreatedDate = x.CreatedDate.Value.ToString("dd/MM/yyyy"),
                    x.Crimes_date,
                    x.JaherTarikh,
                    x.Dated,
                    x.Accused_name_address,
                    x.Address,
                    x.Cognizable_offens,
                    x.Victims_fingerprint,
                    x.Victims_fingerprint_Remark,
                    x.CRPC_41C,
                    x.Designation_Name,
                    x.Release_the_bail,
                    x.Depart_in_court,
                    x.Number_of_accused,
                });

            return new JsonResult(new
            {
                Success = true,
                Headers = "CRPC41C Amendment Mater",
                Header_Title = "CRPC41C Amendment Mater",
                Header_Desc = $"તારીખ : {fromDate.Value.Date} થી : {toDate.Value.Date}",
                Content = responseData
            });
        }

        [HttpGet("Delete")]
        public JsonResult Delete(int id)
        {
            try
            {
                _unitOfWork.CRPC41CAmendmentMater.DeleteById(id);

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
        public JsonResult Save(Post_CRPC41CAmendmentMater model)
        {
            try
            {
                _ = bool.TryParse(model.CognizableOffens, out var cognizableOffens);
                _ = bool.TryParse(model.VictimsFingerprint, out var victimsFingerprint);

                if (model.CRPC41CId == 0)
                {
                    var newData = new TblCrpc41camendmentMater
                    {
                        PoliceStationId = model.PoliceStationId,
                        CrimesDate = model.CrimesDate,
                        AccusedNameAddress = model.AccusedNameAddress,
                        Dated = model.Dated,
                        CognizableOffens = cognizableOffens,
                        VictimsFingerprint = victimsFingerprint,
                        VictimsFingerprintRemark = model.VictimsFingerprintRemark,
                        Crpc41c = model.CRPC41C,
                        DesignationName = model.DesignationName,
                        ReleaseTheBail = model.ReleaseTheBail,
                        DepartInCourt = model.DepartInCourt,
                        NumberOfAccused = model.NumberOfAccused,
                        JaherTarikh = model.JaherTarikh,
                        Address = model.Address,
                        IsActive = true,
                        IsDelete = false,
                        CreatedDate = model.CreatedDate,
                        ModifiedDate = model.CreatedDate,
                        CreatedUserId = Convert.ToInt32(HttpContext.GetClaimsPrincipal().UserId),
                        ModifiedUserId = Convert.ToInt32(HttpContext.GetClaimsPrincipal().UserId),
                    };

                    _unitOfWork.CRPC41CAmendmentMater.Add(newData);
                }
                else
                {
                    var data = _unitOfWork.CRPC41CAmendmentMater.Find(x => x.Crpc41cid == model.CRPC41CId);

                    if (data == null)
                    {
                        return new JsonResult(new
                        {
                            IsValid = false,
                            Error = ConstantsData.ErrDataNotFound,
                        });
                    }

                    data.CrimesDate = model.CrimesDate;
                    data.AccusedNameAddress = model.AccusedNameAddress;
                    data.Dated = model.Dated;
                    data.CognizableOffens = cognizableOffens;
                    data.VictimsFingerprint = victimsFingerprint;
                    data.VictimsFingerprintRemark = model.VictimsFingerprintRemark;
                    data.Crpc41c = model.CRPC41C;
                    data.DesignationName = model.DesignationName;
                    data.ReleaseTheBail = model.ReleaseTheBail;
                    data.DepartInCourt = model.DepartInCourt;
                    data.NumberOfAccused = model.NumberOfAccused;
                    data.JaherTarikh = model.JaherTarikh;
                    data.Address = model.Address;
                    data.PoliceStationId = model.PoliceStationId;
                    data.ModifiedDate = model.CreatedDate;
                    data.ModifiedUserId = Convert.ToInt32(HttpContext.GetClaimsPrincipal().UserId);

                    _unitOfWork.CRPC41CAmendmentMater.Update(data, data.Crpc41cid);
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
