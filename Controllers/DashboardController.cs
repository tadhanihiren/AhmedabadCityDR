using AhmedabadCityDR.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AhmedabadCityDR.Controllers
{
    [Authorize]
    public class DashboardController : Controller
    {
        #region Pivate Members

        /// <summary>
        /// Unit of work.
        /// </summary>
        protected IUnitOfWork _iUnitOfWork;

        #endregion Pivate Members

        #region Constructors

        /// <summary>
        /// Constructor
        /// </summary>
        public DashboardController(IUnitOfWork iUnitOfWork)
        {
            _iUnitOfWork = iUnitOfWork;
        }

        #endregion Constructors

        #region Public Methods

        public async Task<IActionResult> Index(DateTime? fromDate, DateTime? toDate)
        {
            if (!fromDate.HasValue)
            {
                fromDate = DateTime.Now;
            }

            if (!toDate.HasValue)
            {
                toDate = DateTime.Now;
            }

            var user = HttpContext.GetClaimsPrincipal();

            int roleId = Convert.ToInt32(user.RoleId);
            int sectorId = Convert.ToInt32(user.SectorId);
            int zoneId = Convert.ToInt32(user.ZoneId);
            int divisionId = Convert.ToInt32(user.DivisionId);
            int policeStationId = Convert.ToInt32(user.PoliceStationId);
            var dashboardCityCount = await _iUnitOfWork.StoredProcedure.GetCityDashboardCountAsync(roleId, sectorId, zoneId, divisionId, policeStationId, fromDate.Value, toDate.Value);
            return View(dashboardCityCount);
        }

        public async Task<IActionResult> TrafficIndex(DateTime? fromDate, DateTime? toDate)
        {
            if (!fromDate.HasValue)
            {
                fromDate = DateTime.Now;
            }

            if (!toDate.HasValue)
            {
                toDate = DateTime.Now;
            }

            var user = HttpContext.GetClaimsPrincipal();

            int roleId = Convert.ToInt32(user.RoleId);
            int sectorId = Convert.ToInt32(user.SectorId);
            int zoneId = Convert.ToInt32(user.ZoneId);
            int divisionId = Convert.ToInt32(user.DivisionId);
            int policeStationId = Convert.ToInt32(user.PoliceStationId);

            var dashboardTrafficCount = await _iUnitOfWork.StoredProcedure.GetTrafficDashboardCountAsync(roleId, sectorId, zoneId, divisionId, policeStationId, fromDate.Value, toDate.Value);
            return View(dashboardTrafficCount);
        }

        public IActionResult City_Patrak_FillorNot()
        {
            return View();
        }

        public IActionResult Traffic_Patrak_FillorNot()
        {
            return View();
        }

        #endregion
    }
}