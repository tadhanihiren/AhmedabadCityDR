using AhmedabadCityDR.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AhmedabadCityDR.APIs
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiCityCrimeDetailsController : ControllerBase
    {
        #region Private Members

        /// <summary>
        /// Context.
        /// </summary>
        private readonly IUnitOfWork _unitOfWork;

        #endregion

        #region Constructors

        public ApiCityCrimeDetailsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        #endregion

        #region Get Methodes

        [HttpGet("GetDetailsOfCrimes")]
        public JsonResult GetDetailsOfCrimes(DateTime? fromDate, DateTime? toDate)
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

            var responseData = _unitOfWork.StoredProcedure.GetDetailsOfCrimes(roleId, sectorId, zoneId, divisionId, policeStationId, fromDate.Value, toDate.Value)
                .Select(x => new { x.SubCategoryId, x.SubCategoryName, x.Total, x.PoliceStationName });

            return new JsonResult(new
            {
                Success = true,
                Headers = "Details Of Crimes",
                Header_Title = "Details Of Crimes",
                Header_Desc = $"તારીખ : {fromDate.Value.Date} થી : {toDate.Value.Date}",
                Content = responseData
            });
        }

        #endregion
    }
}