using AhmedabadCityDR.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AhmedabadCityDR.Controllers
{
    public class AhmedabadTrafficController : Controller
    {
        #region Private Members

        /// <summary>
        /// Unit of work
        /// </summary>
        private readonly IUnitOfWork _unitOfWork;

        #endregion

        #region Constructors

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="iUnitOfWork">Unit of work</param>
        public AhmedabadTrafficController(IUnitOfWork iUnitOfWork)
        {
            _unitOfWork = iUnitOfWork;
        }

        #endregion

        /// <summary>
        /// Get list Designation
        /// </summary>
        /// <param name="DesignationId">DesignationId</param>
        /// <returns>Returns list of SelectListItem of Designation</returns>
        public List<SelectListItem> GetDesignation(int id)
        {
            var lstDesignation = _unitOfWork.DesignationMaster.GetAll()
                .Where(X => X.DesignationId <= id)
                .Select(X => new { X.DesignationId, X.DesignationName })
                .ToList();

            var designation = new List<SelectListItem>();

            foreach (var item in lstDesignation)
            {
                designation.Add(new SelectListItem { Value = item.DesignationId.ToString(), Text = item.DesignationName });
            }

            return designation;
        }

        public IActionResult Daily_Report_Traffic()
        {
            return View();
        }

        public IActionResult CrainWork_MonthlyReport()
        {
            return View();
        }

        public IActionResult HeadWise_MonthlyReport()
        {
            return View();
        }

        public IActionResult Part_1to5_MonthlyReport()
        {
            return View();
        }

        public IActionResult JET_Wards()
        {
            return View();
        }
        
        public IActionResult Jet_MonthlyReport()
        {
            return View();
        }

        public IActionResult Traffic_Employee_Details()
        {
            ViewBag.Designation = GetDesignation(15);
            return View();
        }

        public IActionResult Leave_Details()
        {
            return View();
        }

        public IActionResult Leave_Parat_Details()
        {
            return View();
        }

        public IActionResult Summury_Details()
        {
            return View();
        }

        public IActionResult Part1_5_Details()
        {
            return View();
        }

        public IActionResult Accidental_Details()
        {
            return View();
        }

        public IActionResult Place_Fine_Details()
        {
            return View();
        }

        public IActionResult MVACT_Details()
        {
            return View();
        }

        public IActionResult Tobaco_Details()
        {
            return View();
        }

        public IActionResult Crain_Work()
        {
            return View();
        }

        public IActionResult GhasChara()
        {
            return View();
        }

        public IActionResult E_Challan_Collection()
        {
            return View();
        }

        public IActionResult TRB_Home_Guard()
        {
            return View();
        }

        public IActionResult Signal_Details()
        {
            return View();
        }

        public IActionResult Signal_BlinkRing()
        {
            return View();
        }

        public IActionResult Traffic_Jam()
        {
            return View();
        }

        public IActionResult Traffic_Drive()
        {
            return View();
        }

        public IActionResult Intercept_Work_Details()
        {
            return View();
        }

        public IActionResult Inter_TF_Place()
        {
            return View();
        }

        public IActionResult TRB_HomeGuard_Jvano_PR()
        {
            return View();
        }

        public IActionResult Adhi_Bit_Incharge()
        {
            return View();
        }

        public IActionResult Bandobast_Details()
        {
            return View();
        }

        public IActionResult Vehicle_Checking()
        {
            return View();
        }

        public IActionResult JET_Place_Fine()
        {
            return View();
        }
    }
}