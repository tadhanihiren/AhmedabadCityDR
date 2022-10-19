using AhmedabadCityDR.Interfaces;
using AhmedabadCityDR.Models.APIModels;
using AhmedabadCityDR.Models.TableModels;
using Microsoft.AspNetCore.Mvc;

namespace AhmedabadCityDR.APIs
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiEGujkopDetailsController : ControllerBase
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
        public ApiEGujkopDetailsController(IUnitOfWork unitOfWork)
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
                Content = _unitOfWork.EGujkopDetail.Find(x => x.EGujkopDetailsId == id),
            });
        }

        [HttpGet("Get")]
        public JsonResult Get(DateTime? fromDate, DateTime? toDate)
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

            var responseData = _unitOfWork.EGujkopDetail
                .GetEGujkopDetails(roleId, sectorId, zoneId, divisionId, policeStationId, fromDate.Value.Date, toDate.Value.Date)
                .OrderByDescending(x => x.CreatedDate)
                .ThenBy(x => x.PoliceStationId)
                .Select(x => new
                {
                    x.E_GujkopDetailsId,
                    x.PoliceStationName,
                    CreatedDate = x.CreatedDate.Value.ToString("dd/MM/yyyy"),
                    x.PoliceStationKhate_Nondhayel_FIR,
                    x.E_Gujkop_FIR_Entry,
                    x.PoliceStationKhate_Nondhayel_Panchnamu,
                    x.Panchnama_EGujop_Entry,
                    x.AtakKarel_Isam,
                    x.AtakKarel_Isam_EGujkop_Entry,
                    x.AtakKarel_Isam_Egujkop_PhotoUpload,
                    x.Post_Khate_Mudamal_Pavti_Fadi,
                    x.Mudamal_Pavti_EGujkop_Entry,
                    x.Chargesheet_ManjurKarel,
                    x.Chargsheet_EGujkop_Entry,
                    x.ServiceSheet_EGujkop_Entry,
                    x.PostKhate_Hajar_EmployeeName,
                    x.Employee_healthcard_Entry,
                    x.Missing_Janvajog,
                    x.Missing_Janvajog_EGujkop_Entry,
                    x.Missing_Janvajog_PhotoUpload,
                    x.MissingChild_FIRNumber,
                    x.MissingChild_PhotoUpload,
                    x.PocketCop_MobileDevice_Number,
                    x.NumberOf_PocketCop_Device_login,
                });

            return new JsonResult(new
            {
                Success = true,
                Headers = "EGujkopDetail",
                Header_Title = "EGujkopDetail",
                Header_Desc = $"તારીખ : {fromDate.Value.Date} થી : {toDate.Value.Date}",
                Content = responseData
            });
        }

        [HttpGet("Delete")]
        public JsonResult Delete(int id)
        {
            try
            {
                _unitOfWork.EGujkopDetail.DeleteById(id);

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
        public JsonResult Save(Post_EGujkopDetail model)
        {
            try
            {
                model.PoliceStationId ??= Convert.ToInt32(HttpContext.GetClaimsPrincipal().PoliceStationId);

                if (model.EGujkopDetailsId == 0)
                {
                    var newData = new TblEGujkopDetail
                    {
                        PoliceStationId = model.PoliceStationId,
                        PoliceStationKhateNondhayelFir = model.PoliceStationKhateNondhayelFIR,
                        EGujkopFirEntry = model.EGujkopFIREntry,
                        PoliceStationKhateNondhayelPanchnamu = model.PoliceStationKhateNondhayelPanchnamu,
                        PanchnamaEgujopEntry = model.PanchnamaEGujopEntry,
                        AtakKarelIsam = model.AtakKarelIsam,
                        AtakKarelIsamEgujkopEntry = model.AtakKarelIsamEGujkopEntry,
                        AtakKarelIsamEgujkopPhotoUpload = model.AtakKarelIsamEgujkopPhotoUpload,
                        PostKhateMudamalPavtiFadi = model.PostKhateMudamalPavtiFadi,
                        MudamalPavtiEgujkopEntry = model.MudamalPavtiEGujkopEntry,
                        ChargesheetManjurKarel = model.ChargesheetManjurKarel,
                        ChargsheetEgujkopEntry = model.ChargsheetEGujkopEntry,
                        ServiceSheetEgujkopEntry = model.ServiceSheetEGujkopEntry,
                        ServiceSheetBuckleNoName = model.ServiceSheetBuckleNoName,
                        PostKhateHajarEmployeeName = model.PostKhateHajarEmployeeName,
                        HealthcardBuckleNoName = model.HealthcardBuckleNoName,
                        EmployeeHealthcardEntry = model.EmployeeHealthcardEntry,
                        MissingJanvajog = model.MissingJanvajog,
                        MissingJanvajogEgujkopEntry = model.MissingJanvajogEGujkopEntry,
                        MissingJanvajogPhotoUpload = model.MissingJanvajogPhotoUpload,
                        MissingChildFirnumber = model.MissingChildFIRNumber,
                        MissingChildPhotoUpload = model.MissingChildPhotoUpload,
                        PocketCopMobileDeviceNumber = model.PocketCopMobileDeviceNumber,
                        NumberOfPocketCopDeviceLogin = model.NumberOfPocketCopDeviceLogin,
                        DataEntry = model.DataEntry,
                        IsActive = true,
                        IsDelete = false,
                        CreatedDate = model.CreatedDate,
                        ModifiedDate = model.CreatedDate,
                        CreatedUserId = Convert.ToInt32(HttpContext.GetClaimsPrincipal().UserId),
                        ModifiedUserId = Convert.ToInt32(HttpContext.GetClaimsPrincipal().UserId),
                    };

                    _unitOfWork.EGujkopDetail.Add(newData);
                }
                else
                {
                    var data = _unitOfWork.EGujkopDetail.Find(x => x.EGujkopDetailsId == model.EGujkopDetailsId);

                    if (data == null)
                    {
                        return new JsonResult(new
                        {
                            IsValid = false,
                            Error = ConstantsData.ErrDataNotFound,
                        });
                    }

                    data.PoliceStationId = model.PoliceStationId;
                    data.PoliceStationKhateNondhayelFir = model.PoliceStationKhateNondhayelFIR;
                    data.EGujkopFirEntry = model.EGujkopFIREntry;
                    data.PoliceStationKhateNondhayelPanchnamu = model.PoliceStationKhateNondhayelPanchnamu;
                    data.PanchnamaEgujopEntry = model.PanchnamaEGujopEntry;
                    data.AtakKarelIsam = model.AtakKarelIsam;
                    data.AtakKarelIsamEgujkopEntry = model.AtakKarelIsamEGujkopEntry;
                    data.AtakKarelIsamEgujkopPhotoUpload = model.AtakKarelIsamEgujkopPhotoUpload;
                    data.PostKhateMudamalPavtiFadi = model.PostKhateMudamalPavtiFadi;
                    data.MudamalPavtiEgujkopEntry = model.MudamalPavtiEGujkopEntry;
                    data.ChargesheetManjurKarel = model.ChargesheetManjurKarel;
                    data.ChargsheetEgujkopEntry = model.ChargsheetEGujkopEntry;
                    data.ServiceSheetEgujkopEntry = model.ServiceSheetEGujkopEntry;
                    data.ServiceSheetBuckleNoName = model.ServiceSheetBuckleNoName;
                    data.PostKhateHajarEmployeeName = model.PostKhateHajarEmployeeName;
                    data.HealthcardBuckleNoName = model.HealthcardBuckleNoName;
                    data.EmployeeHealthcardEntry = model.EmployeeHealthcardEntry;
                    data.MissingJanvajog = model.MissingJanvajog;
                    data.MissingJanvajogEgujkopEntry = model.MissingJanvajogEGujkopEntry;
                    data.MissingJanvajogPhotoUpload = model.MissingJanvajogPhotoUpload;
                    data.MissingChildFirnumber = model.MissingChildFIRNumber;
                    data.MissingChildPhotoUpload = model.MissingChildPhotoUpload;
                    data.PocketCopMobileDeviceNumber = model.PocketCopMobileDeviceNumber;
                    data.NumberOfPocketCopDeviceLogin = model.NumberOfPocketCopDeviceLogin;
                    data.DataEntry = model.DataEntry;
                    data.ModifiedDate = model.CreatedDate;
                    data.ModifiedUserId = Convert.ToInt32(HttpContext.GetClaimsPrincipal().UserId);

                    _unitOfWork.EGujkopDetail.Update(data, data.EGujkopDetailsId);
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
