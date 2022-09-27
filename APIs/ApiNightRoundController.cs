using AhmedabadCityDR.Interfaces;
using AhmedabadCityDR.Models.APIModels;
using AhmedabadCityDR.Models.TableModels;
using Microsoft.AspNetCore.Mvc;

namespace AhmedabadCityDR.APIs
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiNightRoundController : ControllerBase
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
        public ApiNightRoundController(IUnitOfWork iUnitOfWork)
        {
            _unitOfWork = iUnitOfWork;
        }

        #endregion

        [HttpPost("Save")]
        public IActionResult Save(Post_NightRound model)
        {
            try
            {
                var user = HttpContext.GetClaimsPrincipal();

                var lastRecord = _unitOfWork.NightRound.GetAll()
                                   .OrderByDescending(x => x.NightRoundId)
                                   .Take(1).ToList();

                var newRecordId = lastRecord[0].NightRoundId + 1;

                if (model.NightRoundId == 0)
                {
                    var data = new TblNightRound();
                    data.NightRoundId = newRecordId;
                    {
                        data.PoliceStationId = model.PoliceStationId;
                        data.NightRoundOfficerName = model.NightRoundOfficerName;
                        data.GoingTime = model.GoingTime;
                        data.ReturnTime = model.ReturnTime;
                        data.NightRoundPlace = model.NightRoundPlace;
                        data.Remarks = model.Remarks;
                        data.IsActive = true;
                        data.IsDeleted = false;
                        data.CreatedDate = model.CreatedDate;
                        data.ModifiedDate = model.CreatedDate;
                        data.CreatedUserId = Convert.ToInt32(HttpContext.GetClaimsPrincipal().UserId);
                        data.ModifiedUserId = Convert.ToInt32(HttpContext.GetClaimsPrincipal().UserId);

                    };

                    _unitOfWork.NightRound.Add(data);
                    _unitOfWork.Save();

                }
                else
                {

                }


                return new JsonResult(new
                {
                    isValid = true,
                });
            }
            catch (Exception)
            {
                return new JsonResult(new
                {
                    isValid = false,
                });
            }
        }
    }
}
