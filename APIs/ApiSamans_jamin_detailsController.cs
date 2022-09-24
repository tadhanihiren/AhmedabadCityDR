using AhmedabadCityDR.Interfaces;
using AhmedabadCityDR.Models.APIModels;
using AhmedabadCityDR.Models.TableModels;
using Microsoft.AspNetCore.Mvc;

namespace AhmedabadCityDR.APIs
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiSamans_jamin_detailsController : ControllerBase
    {
        #region Constants

        /// <summary>
        /// સમન્‍સ = 26
        /// </summary>
        private const int SamansCategoryId = 26;

        /// <summary>
        /// જામીન લાયક વોરંટ = 27
        /// </summary>
        private const int JaminCategoryId = 27;

        /// <summary>
        /// બિન જામીન લાયક વોરન્ટ  = 28
        /// </summary>
        private const int BinJaminCategoryId = 28;

        /// <summary>
        /// ફેમીલી કોર્ટથી મળતી નોટીસ CRPC ૧૨૫ (૩)  = 29
        /// </summary>
        private const int FamilyCourtPendingCategoryId = 29;

        /// <summary>
        /// અન્ય નોટીસ  = 30
        /// </summary>
        private const int NoticeCategoryId = 30;

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
        /// <param name="unitOfWork"></param>
        public ApiSamans_jamin_detailsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        #endregion

        #region Samans

        #region Get Methodes

        [HttpGet("GetSamansById")]
        public JsonResult GetSamansById(int? id)
        {
            return new JsonResult(new
            {
                Content = _unitOfWork.Samans_Details.Find(x => x.SamansId == id),
            });
        }

        [HttpGet("GetSamans")]
        public JsonResult GetSamans(DateTime? fromDate, DateTime? toDate, int? searchPoliceStationId)
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

            var responseData = _unitOfWork.Samans_Details
                .GetSamans(roleId, sectorId, zoneId, divisionId, policeStationId, fromDate.Value.Date, toDate.Value.Date, SamansCategoryId)
                .OrderByDescending(x => x.CreatedDate)
                .OrderBy(x => x.DivisionId)
                .ThenBy(x => x.PoliceStationId)
                .Select(x => new
                {
                    x.Samans_id,
                    x.PoliceStationName,
                    CreatedDate = x.CreatedDate.Value.ToString("dd/MM/yyyy"),
                    x.Today_old_pending,
                    x.Today_new,
                    x.Today_total,
                    x.Today_complete,
                    x.Today_non_complete,
                    x.Today_transfer,
                    x.Today_pending,
                });

            return new JsonResult(new
            {
                Success = true,
                Headers = "Samans_Details",
                Header_Title = "Samans_Details",
                Header_Desc = $"તારીખ : {fromDate.Value.Date} થી : {toDate.Value.Date}",
                Content = responseData
            });
        }

        #endregion

        #region Post Methods

        [HttpPost("SaveSamans")]
        public JsonResult SaveSamans(Post_Samans_Details model)
        {
            try
            {
                var user = HttpContext.GetClaimsPrincipal();

                if (model.PoliceStationId == null && Convert.ToInt32(user.PoliceStationId) != 0)
                {
                    model.PoliceStationId = Convert.ToInt32(user.PoliceStationId);
                }

                var oldData = _unitOfWork.Samans_Details.GetSamans(0,
                                                                   0,
                                                                   0,
                                                                   0,
                                                                   model.PoliceStationId.Value,
                                                                   model.CreatedDate.Value,
                                                                   model.CreatedDate.Value,
                                                                   SamansCategoryId).ToList();

                var today_total = Convert.ToInt32(model.TodayOldPending) + Convert.ToInt32(model.TodayNew);
                var today_complete = today_total - Convert.ToInt32(model.TodayComplete);
                var today_non_complete = today_complete - Convert.ToInt32(model.TodayNonComplete);
                var today_pending = today_non_complete - Convert.ToInt32(model.TodayTransfer);

                if (model.SamansId == 0 && oldData.Count == 0)
                {
                    var newData = new TblSamansDetail
                    {
                        PoliceStationId = model.PoliceStationId,
                        TodayOldPending = model.TodayOldPending,
                        TodayNew = model.TodayNew,
                        TodayTotal = today_total,
                        TodayComplete = model.TodayComplete,
                        TodayNonComplete = model.TodayNonComplete,
                        TodayTransfer = model.TodayTransfer,
                        TodayPending = today_pending,
                        CategoryId = SamansCategoryId,
                        IsActive = true,
                        IsDeleted = false,
                        CreatedDate = model.CreatedDate,
                        ModifiedDate = model.CreatedDate,
                        CreatedUserId = Convert.ToInt32(HttpContext.GetClaimsPrincipal().UserId),
                        ModifiedUserId = Convert.ToInt32(HttpContext.GetClaimsPrincipal().UserId),
                    };

                    _unitOfWork.Samans_Details.Add(newData);
                }
                else
                {
                    if (oldData != null)
                    {
                        model.SamansId = oldData[0].Samans_id;
                    }

                    var data = _unitOfWork.Samans_Details.Find(x => x.SamansId == model.SamansId);

                    if (data == null)
                    {
                        return new JsonResult(new
                        {
                            IsValid = false,
                            Error = ConstantsData.ErrDataNotFound,
                        });
                    }

                    data.TodayOldPending = model.TodayOldPending;
                    data.TodayNew = model.TodayNew;
                    data.TodayTotal = today_total;
                    data.TodayComplete = model.TodayComplete;
                    data.TodayNonComplete = model.TodayNonComplete;
                    data.TodayTransfer = model.TodayTransfer;
                    data.TodayPending = today_pending;
                    data.ModifiedDate = model.CreatedDate;
                    data.ModifiedUserId = Convert.ToInt32(HttpContext.GetClaimsPrincipal().UserId);

                    _unitOfWork.Samans_Details.Update(data, data.SamansId);
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

        #endregion

        #region Jamin

        #region Get Methodes

        [HttpGet("GetJaminById")]
        public JsonResult GetJaminById(int? id)
        {
            return new JsonResult(new
            {
                Content = _unitOfWork.Samans_Details.Find(x => x.SamansId == id),
            });
        }

        [HttpGet("GetJamin")]
        public JsonResult GetJamin(DateTime? fromDate, DateTime? toDate, int? searchPoliceStationId)
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

            var responseData = _unitOfWork.Samans_Details
                .GetSamans(roleId, sectorId, zoneId, divisionId, policeStationId, fromDate.Value.Date, toDate.Value.Date, JaminCategoryId)
                .OrderByDescending(x => x.CreatedDate)
                .OrderBy(x => x.DivisionId)
                .ThenBy(x => x.PoliceStationId)
                .Select(x => new
                {
                    x.Samans_id,
                    x.PoliceStationName,
                    CreatedDate = x.CreatedDate.Value.ToString("dd/MM/yyyy"),
                    x.Today_old_pending,
                    x.Today_new,
                    x.Today_total,
                    x.Today_complete,
                    x.Today_non_complete,
                    x.Today_transfer,
                    x.Today_pending,
                });

            return new JsonResult(new
            {
                Success = true,
                Headers = "Jamin_Details",
                Header_Title = "Jamin_Details",
                Header_Desc = $"તારીખ : {fromDate.Value.Date} થી : {toDate.Value.Date}",
                Content = responseData
            });
        }

        #endregion

        #region Post Methods

        [HttpPost("SaveJamin")]
        public JsonResult SaveJamin(Post_Samans_Details model)
        {
            try
            {
                var user = HttpContext.GetClaimsPrincipal();

                if (model.PoliceStationId == null && Convert.ToInt32(user.PoliceStationId) != 0)
                {
                    model.PoliceStationId = Convert.ToInt32(user.PoliceStationId);
                }

                var oldData = _unitOfWork.Samans_Details.GetSamans(0,
                                                                   0,
                                                                   0,
                                                                   0,
                                                                   model.PoliceStationId.Value,
                                                                   model.CreatedDate.Value,
                                                                   model.CreatedDate.Value,
                                                                   JaminCategoryId).ToList();

                var today_total = Convert.ToInt32(model.TodayOldPending) + Convert.ToInt32(model.TodayNew);
                var today_complete = today_total - Convert.ToInt32(model.TodayComplete);
                var today_non_complete = today_complete - Convert.ToInt32(model.TodayNonComplete);
                var today_pending = today_non_complete - Convert.ToInt32(model.TodayTransfer);

                if (model.SamansId == 0 && oldData.Count == 0)
                {
                    var newData = new TblSamansDetail
                    {
                        PoliceStationId = model.PoliceStationId,
                        TodayOldPending = model.TodayOldPending,
                        TodayNew = model.TodayNew,
                        TodayTotal = today_total,
                        TodayComplete = model.TodayComplete,
                        TodayNonComplete = model.TodayNonComplete,
                        TodayTransfer = model.TodayTransfer,
                        TodayPending = today_pending,
                        CategoryId = JaminCategoryId,
                        IsActive = true,
                        IsDeleted = false,
                        CreatedDate = model.CreatedDate,
                        ModifiedDate = model.CreatedDate,
                        CreatedUserId = Convert.ToInt32(HttpContext.GetClaimsPrincipal().UserId),
                        ModifiedUserId = Convert.ToInt32(HttpContext.GetClaimsPrincipal().UserId),
                    };

                    _unitOfWork.Samans_Details.Add(newData);
                }
                else
                {
                    if (oldData != null)
                    {
                        model.SamansId = oldData[0].Samans_id;
                    }

                    var data = _unitOfWork.Samans_Details.Find(x => x.SamansId == model.SamansId);

                    if (data == null)
                    {
                        return new JsonResult(new
                        {
                            IsValid = false,
                            Error = ConstantsData.ErrDataNotFound,
                        });
                    }

                    data.TodayOldPending = model.TodayOldPending;
                    data.TodayNew = model.TodayNew;
                    data.TodayTotal = today_total;
                    data.TodayComplete = model.TodayComplete;
                    data.TodayNonComplete = model.TodayNonComplete;
                    data.TodayTransfer = model.TodayTransfer;
                    data.TodayPending = today_pending;
                    data.ModifiedDate = model.CreatedDate;
                    data.ModifiedUserId = Convert.ToInt32(HttpContext.GetClaimsPrincipal().UserId);

                    _unitOfWork.Samans_Details.Update(data, data.SamansId);
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

        #endregion

        #region BinJamin

        #region Get Methodes

        [HttpGet("GetBinJaminById")]
        public JsonResult GetBinJaminById(int? id)
        {
            return new JsonResult(new
            {
                Content = _unitOfWork.Samans_Details.Find(x => x.SamansId == id),
            });
        }

        [HttpGet("GetBinJamin")]
        public JsonResult GetBinJamin(DateTime? fromDate, DateTime? toDate, int? searchPoliceStationId)
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

            var responseData = _unitOfWork.Samans_Details
                .GetSamans(roleId, sectorId, zoneId, divisionId, policeStationId, fromDate.Value.Date, toDate.Value.Date, BinJaminCategoryId)
                .OrderByDescending(x => x.CreatedDate)
                .OrderBy(x => x.DivisionId)
                .ThenBy(x => x.PoliceStationId)
                .Select(x => new
                {
                    x.Samans_id,
                    x.PoliceStationName,
                    CreatedDate = x.CreatedDate.Value.ToString("dd/MM/yyyy"),
                    x.Today_old_pending,
                    x.Today_new,
                    x.Today_total,
                    x.Today_complete,
                    x.Today_non_complete,
                    x.Today_transfer,
                    x.Today_pending,
                });

            return new JsonResult(new
            {
                Success = true,
                Headers = "BinJamin_Details",
                Header_Title = "BinJamin_Details",
                Header_Desc = $"તારીખ : {fromDate.Value.Date} થી : {toDate.Value.Date}",
                Content = responseData
            });
        }

        #endregion

        #region Post Methods

        [HttpPost("SaveBinJamin")]
        public JsonResult SaveBinJamin(Post_Samans_Details model)
        {
            try
            {
                var user = HttpContext.GetClaimsPrincipal();

                if (model.PoliceStationId == null && Convert.ToInt32(user.PoliceStationId) != 0)
                {
                    model.PoliceStationId = Convert.ToInt32(user.PoliceStationId);
                }

                var oldData = _unitOfWork.Samans_Details.GetSamans(0,
                                                                   0,
                                                                   0,
                                                                   0,
                                                                   model.PoliceStationId.Value,
                                                                   model.CreatedDate.Value,
                                                                   model.CreatedDate.Value,
                                                                   BinJaminCategoryId).ToList();

                var today_total = Convert.ToInt32(model.TodayOldPending) + Convert.ToInt32(model.TodayNew);
                var today_complete = today_total - Convert.ToInt32(model.TodayComplete);
                var today_non_complete = today_complete - Convert.ToInt32(model.TodayNonComplete);
                var today_pending = today_non_complete - Convert.ToInt32(model.TodayTransfer);

                if (model.SamansId == 0 && oldData.Count == 0)
                {
                    var newData = new TblSamansDetail
                    {
                        PoliceStationId = model.PoliceStationId,
                        TodayOldPending = model.TodayOldPending,
                        TodayNew = model.TodayNew,
                        TodayTotal = today_total,
                        TodayComplete = model.TodayComplete,
                        TodayNonComplete = model.TodayNonComplete,
                        TodayTransfer = model.TodayTransfer,
                        TodayPending = today_pending,
                        CategoryId = BinJaminCategoryId,
                        IsActive = true,
                        IsDeleted = false,
                        CreatedDate = model.CreatedDate,
                        ModifiedDate = model.CreatedDate,
                        CreatedUserId = Convert.ToInt32(HttpContext.GetClaimsPrincipal().UserId),
                        ModifiedUserId = Convert.ToInt32(HttpContext.GetClaimsPrincipal().UserId),
                    };

                    _unitOfWork.Samans_Details.Add(newData);
                }
                else
                {
                    if (oldData != null)
                    {
                        model.SamansId = oldData[0].Samans_id;
                    }

                    var data = _unitOfWork.Samans_Details.Find(x => x.SamansId == model.SamansId);

                    if (data == null)
                    {
                        return new JsonResult(new
                        {
                            IsValid = false,
                            Error = ConstantsData.ErrDataNotFound,
                        });
                    }

                    data.TodayOldPending = model.TodayOldPending;
                    data.TodayNew = model.TodayNew;
                    data.TodayTotal = today_total;
                    data.TodayComplete = model.TodayComplete;
                    data.TodayNonComplete = model.TodayNonComplete;
                    data.TodayTransfer = model.TodayTransfer;
                    data.TodayPending = today_pending;
                    data.ModifiedDate = model.CreatedDate;
                    data.ModifiedUserId = Convert.ToInt32(HttpContext.GetClaimsPrincipal().UserId);

                    _unitOfWork.Samans_Details.Update(data, data.SamansId);
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

        #endregion

        #region FamilyCourtPendingWarrent

        #region Get Methodes

        [HttpGet("GetFamilyCourtPendingById")]
        public JsonResult GetFamilyCourtPendingById(int? id)
        {
            return new JsonResult(new
            {
                Content = _unitOfWork.Samans_Details.Find(x => x.SamansId == id),
            });
        }

        [HttpGet("GetFamilyCourtPending")]
        public JsonResult GetFamilyCourtPending(DateTime? fromDate, DateTime? toDate, int? searchPoliceStationId)
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

            var responseData = _unitOfWork.Samans_Details
                .GetSamans(roleId, sectorId, zoneId, divisionId, policeStationId, fromDate.Value.Date, toDate.Value.Date, FamilyCourtPendingCategoryId)
                .OrderByDescending(x => x.CreatedDate)
                .OrderBy(x => x.DivisionId)
                .ThenBy(x => x.PoliceStationId)
                .Select(x => new
                {
                    x.Samans_id,
                    x.PoliceStationName,
                    CreatedDate = x.CreatedDate.Value.ToString("dd/MM/yyyy"),
                    x.Today_old_pending,
                    x.Today_new,
                    x.Today_total,
                    x.Today_complete,
                    x.Today_non_complete,
                    x.Today_transfer,
                    x.Today_pending,
                });

            return new JsonResult(new
            {
                Success = true,
                Headers = "FamilyCourtPendingWarrent",
                Header_Title = "FamilyCourtPendingWarrent",
                Header_Desc = $"તારીખ : {fromDate.Value.Date} થી : {toDate.Value.Date}",
                Content = responseData
            });
        }

        #endregion

        #region Post Methods

        [HttpPost("SaveFamilyCourtPending")]
        public JsonResult SaveFamilyCourtPending(Post_Samans_Details model)
        {
            try
            {
                var user = HttpContext.GetClaimsPrincipal();

                if (model.PoliceStationId == null && Convert.ToInt32(user.PoliceStationId) != 0)
                {
                    model.PoliceStationId = Convert.ToInt32(user.PoliceStationId);
                }

                var oldData = _unitOfWork.Samans_Details.GetSamans(0,
                                                                   0,
                                                                   0,
                                                                   0,
                                                                   model.PoliceStationId.Value,
                                                                   model.CreatedDate.Value,
                                                                   model.CreatedDate.Value,
                                                                   FamilyCourtPendingCategoryId).ToList();

                var today_total = Convert.ToInt32(model.TodayOldPending) + Convert.ToInt32(model.TodayNew);
                var today_complete = today_total - Convert.ToInt32(model.TodayComplete);
                var today_non_complete = today_complete - Convert.ToInt32(model.TodayNonComplete);
                var today_pending = today_non_complete - Convert.ToInt32(model.TodayTransfer);

                if (model.SamansId == 0 && oldData.Count == 0)
                {
                    var newData = new TblSamansDetail
                    {
                        PoliceStationId = model.PoliceStationId,
                        TodayOldPending = model.TodayOldPending,
                        TodayNew = model.TodayNew,
                        TodayTotal = today_total,
                        TodayComplete = model.TodayComplete,
                        TodayNonComplete = model.TodayNonComplete,
                        TodayTransfer = model.TodayTransfer,
                        TodayPending = today_pending,
                        CategoryId = FamilyCourtPendingCategoryId,
                        IsActive = true,
                        IsDeleted = false,
                        CreatedDate = model.CreatedDate,
                        ModifiedDate = model.CreatedDate,
                        CreatedUserId = Convert.ToInt32(HttpContext.GetClaimsPrincipal().UserId),
                        ModifiedUserId = Convert.ToInt32(HttpContext.GetClaimsPrincipal().UserId),
                    };

                    _unitOfWork.Samans_Details.Add(newData);
                }
                else
                {
                    if (oldData != null)
                    {
                        model.SamansId = oldData[0].Samans_id;
                    }

                    var data = _unitOfWork.Samans_Details.Find(x => x.SamansId == model.SamansId);

                    if (data == null)
                    {
                        return new JsonResult(new
                        {
                            IsValid = false,
                            Error = ConstantsData.ErrDataNotFound,
                        });
                    }

                    data.TodayOldPending = model.TodayOldPending;
                    data.TodayNew = model.TodayNew;
                    data.TodayTotal = today_total;
                    data.TodayComplete = model.TodayComplete;
                    data.TodayNonComplete = model.TodayNonComplete;
                    data.TodayTransfer = model.TodayTransfer;
                    data.TodayPending = today_pending;
                    data.ModifiedDate = model.CreatedDate;
                    data.ModifiedUserId = Convert.ToInt32(HttpContext.GetClaimsPrincipal().UserId);

                    _unitOfWork.Samans_Details.Update(data, data.SamansId);
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

        #endregion

        #region Notice

        #region Get Methodes

        [HttpGet("GetNoticeById")]
        public JsonResult GetNoticeById(int? id)
        {
            return new JsonResult(new
            {
                Content = _unitOfWork.Samans_Details.Find(x => x.SamansId == id),
            });
        }

        [HttpGet("GetNotice")]
        public JsonResult GetNotice(DateTime? fromDate, DateTime? toDate, int? searchPoliceStationId)
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

            var responseData = _unitOfWork.Samans_Details
                .GetSamans(roleId, sectorId, zoneId, divisionId, policeStationId, fromDate.Value.Date, toDate.Value.Date, NoticeCategoryId)
                .OrderByDescending(x => x.CreatedDate)
                .OrderBy(x => x.DivisionId)
                .ThenBy(x => x.PoliceStationId)
                .Select(x => new
                {
                    x.Samans_id,
                    x.PoliceStationName,
                    CreatedDate = x.CreatedDate.Value.ToString("dd/MM/yyyy"),
                    x.Today_old_pending,
                    x.Today_new,
                    x.Today_total,
                    x.Today_complete,
                    x.Today_non_complete,
                    x.Today_transfer,
                    x.Today_pending,
                });

            return new JsonResult(new
            {
                Success = true,
                Headers = "FamilyCourtPendingWarrent",
                Header_Title = "FamilyCourtPendingWarrent",
                Header_Desc = $"તારીખ : {fromDate.Value.Date} થી : {toDate.Value.Date}",
                Content = responseData
            });
        }

        #endregion

        #region Post Methods

        [HttpPost("SaveNotice")]
        public JsonResult SaveNotice(Post_Samans_Details model)
        {
            try
            {
                var user = HttpContext.GetClaimsPrincipal();

                if (model.PoliceStationId == null && Convert.ToInt32(user.PoliceStationId) != 0)
                {
                    model.PoliceStationId = Convert.ToInt32(user.PoliceStationId);
                }

                var oldData = _unitOfWork.Samans_Details.GetSamans(0,
                                                                   0,
                                                                   0,
                                                                   0,
                                                                   model.PoliceStationId.Value,
                                                                   model.CreatedDate.Value,
                                                                   model.CreatedDate.Value,
                                                                   NoticeCategoryId).ToList();

                var today_total = Convert.ToInt32(model.TodayOldPending) + Convert.ToInt32(model.TodayNew);
                var today_complete = today_total - Convert.ToInt32(model.TodayComplete);
                var today_non_complete = today_complete - Convert.ToInt32(model.TodayNonComplete);
                var today_pending = today_non_complete - Convert.ToInt32(model.TodayTransfer);

                if (model.SamansId == 0 && oldData.Count == 0)
                {
                    var newData = new TblSamansDetail
                    {
                        PoliceStationId = model.PoliceStationId,
                        TodayOldPending = model.TodayOldPending,
                        TodayNew = model.TodayNew,
                        TodayTotal = today_total,
                        TodayComplete = model.TodayComplete,
                        TodayNonComplete = model.TodayNonComplete,
                        TodayTransfer = model.TodayTransfer,
                        TodayPending = today_pending,
                        CategoryId = NoticeCategoryId,
                        IsActive = true,
                        IsDeleted = false,
                        CreatedDate = model.CreatedDate,
                        ModifiedDate = model.CreatedDate,
                        CreatedUserId = Convert.ToInt32(HttpContext.GetClaimsPrincipal().UserId),
                        ModifiedUserId = Convert.ToInt32(HttpContext.GetClaimsPrincipal().UserId),
                    };

                    _unitOfWork.Samans_Details.Add(newData);
                }
                else
                {
                    if (oldData != null)
                    {
                        model.SamansId = oldData[0].Samans_id;
                    }

                    var data = _unitOfWork.Samans_Details.Find(x => x.SamansId == model.SamansId);

                    if (data == null)
                    {
                        return new JsonResult(new
                        {
                            IsValid = false,
                            Error = ConstantsData.ErrDataNotFound,
                        });
                    }

                    data.TodayOldPending = model.TodayOldPending;
                    data.TodayNew = model.TodayNew;
                    data.TodayTotal = today_total;
                    data.TodayComplete = model.TodayComplete;
                    data.TodayNonComplete = model.TodayNonComplete;
                    data.TodayTransfer = model.TodayTransfer;
                    data.TodayPending = today_pending;
                    data.ModifiedDate = model.CreatedDate;
                    data.ModifiedUserId = Convert.ToInt32(HttpContext.GetClaimsPrincipal().UserId);

                    _unitOfWork.Samans_Details.Update(data, data.SamansId);
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

        #endregion
    }
}
