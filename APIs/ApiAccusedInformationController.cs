using AhmedabadCityDR.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AhmedabadCityDR.APIs
{
    [ApiController]
    [Route("api/[controller]")]
    public class ApiAccusedInformationController : ControllerBase
    {
        #region Private Members

        /// <summary>
        /// Unit of work.
        /// </summary>
        private readonly IUnitOfWork _unitOfWork;

        #endregion

        #region Constructors

        /// <summary>
        /// Constructors
        /// </summary>
        public ApiAccusedInformationController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        #endregion

        /// <summary>
        /// Get Accused Information.
        /// </summary>
        /// <param name="fromDate">From date</param>
        /// <param name="toDate">To date</param>
        /// <returns>Returns Accused Information or null</returns>
        [HttpGet("GetAccusedInformation")]
        public IActionResult Get(DateTime? fromDate, DateTime? toDate)
        {
            if (!fromDate.HasValue)
            {
                fromDate = DateTime.Now.Date;
            }

            if (!toDate.HasValue)
            {
                toDate = DateTime.Now.Date;
            }

            var user = HttpContext.GetClaimsPrincipal();

            int roleId = Convert.ToInt32(user.RoleId);
            int sectorId = Convert.ToInt32(user.SectorId);
            int zoneId = Convert.ToInt32(user.ZoneId);
            int divisionId = Convert.ToInt32(user.DivisionId);
            int policeStationId = Convert.ToInt32(user.PoliceStationId);

            var responseData = _unitOfWork.AccusedInformation.GetAccusedInformation(roleId, sectorId, zoneId, divisionId, policeStationId, fromDate.Value, toDate.Value);

            return new OkObjectResult(new
            {
                Success = true,
                Headers = "આરોપી માહિતી",
                Header_Title = "આરોપી માહિતી",
                Header_Desc = $"તારીખ : {fromDate.Value.Date} થી : {toDate.Value.Date}",
                Content = responseData
            });
        }
    }
}