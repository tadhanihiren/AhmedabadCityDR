using AhmedabadCityDR.Interfaces;
using AhmedabadCityDR.Models.APIModels;
using AhmedabadCityDR.Models.TableModels;
using Microsoft.AspNetCore.Mvc;

namespace AhmedabadCityDR.APIs
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiMissingChildDetailsController : ControllerBase
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
        public ApiMissingChildDetailsController(IUnitOfWork unitOfWork)
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
                Content = _unitOfWork.MissingChildDetails.Find(x => x.MissingChildId == id),
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

            var responseData = _unitOfWork.MissingChildDetails
                .GetMissingChildDetails(roleId, sectorId, zoneId, divisionId, policeStationId, fromDate.Value.Date, toDate.Value.Date)
                .Where(x => x.IsActive == true && x.IsDeleted == false)
                .OrderByDescending(x => x.CreatedDate)
                .ThenBy(x => x.PoliceStationId)
                .Select(x => new
                {
                    x.MissingChildId,
                    x.PoliceStationName,
                    CreatedDate = x.CreatedDate.Value.ToString("dd/MM/yyyy"),
                    x.MissingPersonName,
                    x.MissingReson,
                    x.Gender,
                    x.Age,
                    MissingDate = x.MissingDate.Value.ToString("dd/MM/yyyy"),
                    ReturnDate = GetDate(x.ReturnDate.Value.Date),
                    x.MissingApplicationNo_Date,
                    x.PublisherName_Address,
                    x.MobileNo,
                });

            return new JsonResult(new
            {
                Success = true,
                Headers = "MissingChildDetails",
                Header_Title = "MissingChildDetails",
                Header_Desc = $"તારીખ : {fromDate.Value.Date} થી : {toDate.Value.Date}",
                Content = responseData
            });
        }

        [HttpGet("Delete")]
        public JsonResult Delete(int id)
        {
            try
            {
                _unitOfWork.MissingChildDetails.DeleteById(id);

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
        public JsonResult Save(Post_MissingChildDetails model)
        {
            DateTime? returnDate = null;

            if (string.IsNullOrEmpty(model.ReturnDate) == false)
            {
                var isDate = DateTime.TryParse(model.ReturnDate, out DateTime newDate);

                if (isDate)
                {
                    returnDate = newDate;
                }
            }

            try
            {
                if (model.MissingChildId == 0)
                {
                    var newData = new TblMissingChildDetail
                    {
                        PoliceStationId = model.PoliceStationId,
                        MissingPersonName = model.MissingPersonName,
                        MissingReson = model.MissingReson,
                        GenderId = model.GenderId,
                        Age = model.Age,
                        MissingDate = model.MissingDate,
                        ReturnDate = returnDate,
                        MissingApplicationNoDate = model.MissingApplicationNoDate,
                        PublisherNameAddress = model.PublisherNameAddress,
                        MobileNo = model.MobileNo,
                        IsActive = true,
                        IsDeleted = false,
                        CreatedDate = model.CreatedDate,
                        ModifiedDate = model.CreatedDate,
                        CreatedUserId = Convert.ToInt32(HttpContext.GetClaimsPrincipal().UserId),
                        ModifiedUserId = Convert.ToInt32(HttpContext.GetClaimsPrincipal().UserId),
                    };

                    _unitOfWork.MissingChildDetails.Add(newData);
                }
                else
                {
                    var data = _unitOfWork.MissingChildDetails.Find(x => x.MissingChildId == model.MissingChildId);

                    if (data == null)
                    {
                        return new JsonResult(new
                        {
                            IsValid = false,
                            Error = ConstantsData.ErrDataNotFound,
                        });
                    }

                    data.PoliceStationId = model.PoliceStationId.Value;
                    data.PoliceStationId = model.PoliceStationId;
                    data.MissingPersonName = model.MissingPersonName;
                    data.MissingReson = model.MissingReson;
                    data.GenderId = model.GenderId;
                    data.Age = model.Age;
                    data.MissingDate = model.MissingDate;
                    data.ReturnDate = returnDate;
                    data.MissingApplicationNoDate = model.MissingApplicationNoDate;
                    data.PublisherNameAddress = model.PublisherNameAddress;
                    data.MobileNo = model.MobileNo;
                    data.ModifiedDate = model.CreatedDate;
                    data.ModifiedUserId = Convert.ToInt32(HttpContext.GetClaimsPrincipal().UserId);

                    _unitOfWork.MissingChildDetails.Update(data, data.MissingChildId);
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

        #region Private Methods

        private static DateOnly? GetDate(DateTime? date)
        {
            if (date.HasValue == true)
            {
                DateOnly? dateOnly = null;

                var isdate = DateOnly.TryParse(date.Value.Date.ToShortDateString(), out var newDateOnly);

                if (isdate == true)
                {
                    dateOnly = newDateOnly;
                }

                return dateOnly;
            }

            return null;
        }

        #endregion
    }
}
