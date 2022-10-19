using AhmedabadCityDR.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AhmedabadCityDR.APIs
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiTrafficEmployeeMasterController : ControllerBase
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
        public ApiTrafficEmployeeMasterController(IUnitOfWork iUnitOfWork)
        {
            _unitOfWork = iUnitOfWork;
        }

        #endregion   

        #region Get Methodes

        [HttpGet("GetById")]
        public JsonResult GetById(int? id)
        {
            return new JsonResult(new
            {
                Content = _unitOfWork.TrafficEmployeeDetails.Find(x => x.EmployeeId == id),
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

            fromDate = DateTime.Today;
            toDate = DateTime.Today;

            var responseData = _unitOfWork.TrafficEmployeeDetails
                .GetTrafficEmployees(roleId, sectorId, zoneId, divisionId, policeStationId, fromDate.Value.Date, toDate.Value.Date)
                .OrderBy(x => x.PoliceStationId)
                .Select(x => new
                {
                    x.PoliceStationName,
                    x.DesignationName,
                    x.BuckleNo,
                    x.EmployeName,
                    x.ContactNumber,
                    x.PrtiniyukatName,
                    x.Fromdate,
                    x.Todate,
                    x.PrtiniyukatPlace,
                    CreatedDate = Helper.ConvertDate(x.CreatedDate.ToString()),
                });

            return new JsonResult(new
            {
                Success = true,
                Headers = "Employee Details",
                Header_Title = "Employee Details",
                Header_Desc = $"તારીખ : {fromDate.Value.Date} થી : {toDate.Value.Date}",
                Content = responseData
            });
        }

       
        #endregion
    }
}
