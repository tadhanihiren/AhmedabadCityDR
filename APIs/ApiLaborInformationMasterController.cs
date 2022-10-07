using AhmedabadCityDR.Interfaces;
using AhmedabadCityDR.Models.APIModels;
using AhmedabadCityDR.Models.TableModels;
using Microsoft.AspNetCore.Mvc;

namespace AhmedabadCityDR.APIs
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiLaborInformationMasterController : ControllerBase
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
        public ApiLaborInformationMasterController(IUnitOfWork unitOfWork)
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
                Content = _unitOfWork.LaborInformation.Find(x => x.LaborInformationId == id),
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

            var responseData = _unitOfWork.LaborInformation
                .GetLaborInformation(roleId, sectorId, zoneId, divisionId, policeStationId, fromDate.Value.Date, toDate.Value.Date)
                .OrderByDescending(x => x.CreatedDate)
                .ThenBy(x => x.PoliceStationId)
                .Select(x => new
                {
                    x.LaborInformationId,
                    x.PoliceStationName,
                    CreatedDate = x.CreatedDate.Value.ToString("dd/MM/yyyy"),
                    x.SubCategoryId,
                    x.SubCategoryName,
                    x.CheckedLabor,
                    x.CheckedPlace,
                    x.TotalLaborersVideography,
                    x.Workers_ARoll_BRollNumber,
                });

            return new JsonResult(new
            {
                Success = true,
                Headers = "Labor Information",
                Header_Title = "Labor Information",
                Header_Desc = $"તારીખ : {fromDate.Value.Date} થી : {toDate.Value.Date}",
                Content = responseData
            });
        }

        [HttpGet("Delete")]
        public JsonResult Delete(int id)
        {
            try
            {
                _unitOfWork.LaborInformation.DeleteById(id);

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
        public JsonResult Save(Post_LaborInformationMaster model)
        {
            try
            {
                if (model.LaborInformationId == 0)
                {
                    var newData = new TblLaborInformationMaster
                    {
                        PoliceStationId = model.PoliceStationId.Value,
                        SubCategoryId = model.SubCategoryId.Value,
                        CheckedPlace = model.CheckedPlace.Value,
                        CheckedLabor = model.CheckedLabor.Value,
                        TotalLaborersVideography = model.TotalLaborersVideography.Value,
                        WorkersArollBrollNumber = model.WorkersArollBrollNumber.Value,
                        IsActive = true,
                        IsDeleted = false,
                        CreatedDate = model.CreatedDate,
                        ModifiedDate = model.CreatedDate,
                        CreatedUserId = Convert.ToInt32(HttpContext.GetClaimsPrincipal().UserId),
                        ModifiedUserId = Convert.ToInt32(HttpContext.GetClaimsPrincipal().UserId),
                    };

                    _unitOfWork.LaborInformation.Add(newData);
                }
                else
                {
                    var data = _unitOfWork.LaborInformation.Find(x => x.LaborInformationId == model.LaborInformationId);

                    if (data == null)
                    {
                        return new JsonResult(new
                        {
                            IsValid = false,
                            Error = ConstantsData.ErrDataNotFound,
                        });
                    }

                    data.PoliceStationId = model.PoliceStationId.Value;
                    data.SubCategoryId = model.SubCategoryId.Value;
                    data.CheckedPlace = model.CheckedPlace.Value;
                    data.CheckedLabor = model.CheckedLabor.Value;
                    data.TotalLaborersVideography = model.TotalLaborersVideography.Value;
                    data.WorkersArollBrollNumber = model.WorkersArollBrollNumber.Value;
                    data.ModifiedDate = model.CreatedDate;
                    data.ModifiedUserId = Convert.ToInt32(HttpContext.GetClaimsPrincipal().UserId);

                    _unitOfWork.LaborInformation.Update(data, data.LaborInformationId);
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
