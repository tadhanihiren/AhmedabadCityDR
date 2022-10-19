using AhmedabadCityDR.Interfaces;
using AhmedabadCityDR.Models.APIModels;
using AhmedabadCityDR.Models.TableModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AhmedabadCityDR.APIs
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiCCTVController : ControllerBase
    {
        #region Constants

        private const string Co = "COMMISSIONERATE";
        private const string City = "AHMEDABAD";

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
        public ApiCCTVController(IUnitOfWork iUnitOfWork)
        {
            _unitOfWork = iUnitOfWork;
        }

        #endregion   

        #region Get Methodes

        [HttpGet("GetById")]
        public JsonResult GetById(int? id)
        {
            var content = _unitOfWork.CCTV.GetAll()
                                          .Where(x => x.CctvId == id)
                                          .Select(x => new
                                          {
                                              x.CctvId,
                                              x.PoliceStationId,
                                              CreatedDate = x.CreatedDate.Value.ToString("dd/MM/yyyy"),
                                              x.Range,
                                              x.CityDistict,
                                              x.Cluster,
                                              x.VenderName,
                                              x.PtzInstalled,
                                              x.BltInstalled,
                                              x.DmInstalled,
                                              x.TotalInstalled,
                                              x.PtzFuncational,
                                              x.BltFuncational,
                                              x.DmFuncational,
                                              x.TotalFuncation,
                                              x.PtzNotFuncational,
                                              x.BltNotFuncational,
                                              x.DmNotFuncational,
                                              x.TotalNotFuncation,
                                              x.Complaint1,
                                              ComplaintDate1 = Helper.ConvertDate(x.ComplaintDate1.ToString()),
                                              x.Complaint2,
                                              ComplaintDate2 = Helper.ConvertDate(x.ComplaintDate2.ToString()),
                                              x.Complaint3,
                                              ComplaintDate3 = Helper.ConvertDate(x.ComplaintDate3.ToString()),
                                              x.EquipmentsId,
                                              x.NatureofComplant,
                                              x.VisitedRemark,
                                              x.StatusId,
                                              ResolveDate = Helper.ConvertDate(x.ResolveDate.ToString()),
                                              x.Remark,
                                          })
                                          .FirstOrDefault();

            return new JsonResult(new { content });
        }

        [HttpGet("GetCCTV_Details")]
        public JsonResult GetCCTV_Details(int policeStationId)
        {
            var data = _unitOfWork.CCTVInstalled.GetAll()
                                                .Where(x => x.PoliceStationId == policeStationId && x.IsActive == true)
                                                .Select(x => new { x.PoliceStationId, x.PtzInstalled, x.BltInstalled, x.DmInstalled, x.TotalInstalled, Co, City })
                                                .FirstOrDefault();
            return new JsonResult(new { data });
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



            var responseData = _unitOfWork.CCTV
                .GetCCTV(roleId, sectorId, zoneId, divisionId, policeStationId, fromDate.Value.Date, toDate.Value.Date)
                .OrderBy(x => x.PoliceStationId)
                .Select(x => new
                {
                    x.CctvId,
                    x.PoliceStationName,
                    CreatedDate = x.CreatedDate.Value.ToString("dd/MM/yyyy"),
                    x.Range,
                    x.City_Distict,
                    x.Cluster,
                    x.VenderName,
                    x.PTZ_installed,
                    x.BLT_installed,
                    x.DM_installed,
                    x.Total_installed,
                    x.PTZ_funcational,
                    x.BLT_funcational,
                    x.DM_funcational,
                    x.Total_funcation,
                    x.PTZ_not_funcational,
                    x.BLT_not_funcational,
                    x.DM_not_funcational,
                    x.Total_not_funcation,
                    x.Complaint1,
                    ComplaintDate1 = Helper.ConvertDate(x.ComplaintDate1.ToString()),
                    x.Complaint2,
                    ComplaintDate2 = Helper.ConvertDate(x.ComplaintDate2.ToString()),
                    x.Complaint3,
                    ComplaintDate3 = Helper.ConvertDate(x.ComplaintDate3.ToString()),
                    x.type,
                    x.NatureofComplant,
                    x.Visited_Remark,
                    x.StatusType,
                    ResolveDate = Helper.ConvertDate(x.ResolveDate.ToString()),
                    x.Remark,
                });

            return new JsonResult(new
            {
                Success = true,
                Headers = "CCTV",
                Header_Title = "CCTV",
                Header_Desc = $"તારીખ : {fromDate.Value.Date} થી : {toDate.Value.Date}",
                Content = responseData
            });
        }

        [HttpGet("Delete")]
        public JsonResult Delete(int id)
        {
            try
            {
                _unitOfWork.CCTV.DeleteById(id);

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
        public JsonResult Save(Post_CCTV model)
        {
            try
            {
                DateTime? complaintDate1 = null;
                DateTime? complaintDate2 = null;
                DateTime? complaintDate3 = null;
                DateTime? resolveDate = null;

                if (DateTime.TryParse(model.ComplaintDate1, out var tempDate1))
                {
                    complaintDate1 = tempDate1;
                }
                if (DateTime.TryParse(model.ComplaintDate2, out var tempDate2))
                {
                    complaintDate2 = tempDate2;
                }
                if (DateTime.TryParse(model.ComplaintDate3, out var tempDate3))
                {
                    complaintDate3 = tempDate3;
                }
                if (DateTime.TryParse(model.ResolveDate, out var tempDate4))
                {
                    resolveDate = tempDate4;
                }

                if (model.CctvId == 0)
                {
                    var data = new TblCctvMaster
                    {
                        PoliceStationId = model.PoliceStationId,
                        Range = model.Range,
                        CityDistict = model.CityDistict,
                        Cluster = model.Cluster,
                        VenderName = model.VenderName,
                        PtzInstalled = model.PtzInstalled,
                        BltInstalled = model.BltInstalled,
                        DmInstalled = model.DmInstalled,
                        TotalInstalled = (model.PtzInstalled + model.BltInstalled + model.DmInstalled),
                        PtzFuncational = model.PtzFuncational,
                        BltFuncational = model.BltFuncational,
                        DmFuncational = model.DmFuncational,
                        TotalFuncation = (model.PtzFuncational + model.BltFuncational + model.DmFuncational),
                        PtzNotFuncational = model.PtzNotFuncational,
                        BltNotFuncational = model.BltNotFuncational,
                        DmNotFuncational = model.DmNotFuncational,
                        TotalNotFuncation = (model.PtzNotFuncational + model.BltNotFuncational + model.DmNotFuncational),
                        Complaint1 = model.Complaint1,
                        ComplaintDate1 = complaintDate1,
                        Complaint2 = model.Complaint2,
                        ComplaintDate2 = complaintDate2,
                        Complaint3 = model.Complaint3,
                        ComplaintDate3 = complaintDate3,
                        EquipmentsId = model.EquipmentsId,
                        NatureofComplant = model.NatureofComplant,
                        VisitedRemark = model.VisitedRemark,
                        StatusId = model.StatusId,
                        ResolveDate = resolveDate,
                        Remark = model.Remark,
                        CreatedDate = model.CreatedDate,
                        ModifiedDate = model.CreatedDate,
                        CreatedUserId = Convert.ToInt32(HttpContext.GetClaimsPrincipal().UserId),
                        ModifiedUserId = Convert.ToInt32(HttpContext.GetClaimsPrincipal().UserId),
                        IsActive = true,
                        IsDeleted = false,
                    };

                    _unitOfWork.CCTV.Add(data);
                }
                else
                {
                    var data = _unitOfWork.CCTV.Find(x => x.CctvId == model.CctvId);

                    if (data == null)
                    {
                        return new JsonResult(new
                        {
                            IsValid = false,
                            Error = ConstantsData.ErrDataNotFound,
                        });
                    }

                    data.PoliceStationId = model.PoliceStationId;
                    data.Range = model.Range;
                    data.CityDistict = model.CityDistict;
                    data.Cluster = model.Cluster;
                    data.VenderName = model.VenderName;
                    data.PtzInstalled = model.PtzInstalled;
                    data.BltInstalled = model.BltInstalled;
                    data.DmInstalled = model.DmInstalled;
                    data.TotalInstalled = (model.PtzInstalled + model.BltInstalled + model.DmInstalled);
                    data.PtzFuncational = model.PtzFuncational;
                    data.BltFuncational = model.BltFuncational;
                    data.DmFuncational = model.DmFuncational;
                    data.TotalFuncation = (model.PtzFuncational + model.BltFuncational + model.DmFuncational);
                    data.PtzNotFuncational = model.PtzNotFuncational;
                    data.BltNotFuncational = model.BltNotFuncational;
                    data.DmNotFuncational = model.BltNotFuncational;
                    data.TotalNotFuncation = (model.PtzNotFuncational + model.BltNotFuncational + model.DmNotFuncational);
                    data.Complaint1 = model.Complaint1;
                    data.ComplaintDate1 = complaintDate1;
                    data.Complaint2 = model.Complaint2;
                    data.ComplaintDate2 = complaintDate2;
                    data.Complaint3 = model.Complaint3;
                    data.ComplaintDate3 = complaintDate3;
                    data.EquipmentsId = model.EquipmentsId;
                    data.NatureofComplant = model.NatureofComplant;
                    data.VisitedRemark = model.VisitedRemark;
                    data.StatusId = model.StatusId;
                    data.ResolveDate = resolveDate;
                    data.Remark = model.Remark;
                    data.IsActive = true;
                    data.IsDeleted = false;
                    data.ModifiedDate = model.CreatedDate;
                    data.ModifiedUserId = Convert.ToInt32(HttpContext.GetClaimsPrincipal().UserId);

                    _unitOfWork.CCTV.Update(data, data.CctvId);

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
