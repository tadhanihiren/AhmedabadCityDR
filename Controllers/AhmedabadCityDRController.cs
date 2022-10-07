using AhmedabadCityDR.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AhmedabadCityDR.Controllers
{
    public class AhmedabadCityDRController : Controller
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
        public AhmedabadCityDRController(IUnitOfWork iUnitOfWork)
        {
            _unitOfWork = iUnitOfWork;
        }

        #endregion

        /// <summary>
        /// Gets list sub category <Value , Text>
        /// </summary>
        /// <param name="subCategoryId">Category Id</param>
        /// <returns>Returns list of SelectListItem of sub category</returns>
        public List<SelectListItem> GetSubcategory(int? subCategoryId)
        {
            var lstSubcategory = _unitOfWork.SubCategoryMaster.GetAll();

            if (subCategoryId != null)
            {
                lstSubcategory = _unitOfWork.SubCategoryMaster.GetAll()
                    .Where(x => x.CategoryId == subCategoryId.Value);
            }

            var subcategory = new List<SelectListItem>();

            foreach (var item in lstSubcategory)
            {
                subcategory.Add(new SelectListItem { Value = item.SubCategoryId.ToString(), Text = item.SubCategoryName });
            }

            return subcategory;
        }

        /// <summary>
        /// Gets list Pidhela Kabja <Value , Text>
        /// </summary>
        /// <returns>Returns list of SelectListItem of Pidhela Kabja</returns>
        public List<SelectListItem> GetPidhelaKabja()
        {
            var lstPidhelaKabja = _unitOfWork.Pidhela_Kabja_CategoryMaster.GetAll();

            var pidhelaKabja = new List<SelectListItem>();

            foreach (var item in lstPidhelaKabja)
            {
                pidhelaKabja.Add(new SelectListItem { Value = item.PidhelaKabjaCategoryName, Text = item.PidhelaKabjaCategoryName });
            }
            return pidhelaKabja;
        }

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

            ViewBag.Designation = designation;

            return designation;
        }

        public IActionResult Daily_Report()
        {
            return View();
        }

        public IActionResult Employee_Details()
        {
            return View();
        }

        public IActionResult AtakayatiPaglaSummary()
        {
            ViewBag.SubCategory = GetSubcategory(25);
            return View();
        }

        public IActionResult City_Crime_Details()
        {
            return View();
        }

        public IActionResult Part1_5_Crime()
        {
            ViewBag.SubCategory = GetSubcategory(1);
            ViewBag.PidhelaKabja = GetPidhelaKabja();
            return View();
        }

        public IActionResult Part_6_Crimes()
        {
            ViewBag.SubCategory = GetSubcategory(2);
            ViewBag.PidhelaKabja = GetPidhelaKabja();
            return View();
        }

        public IActionResult Aksmat_Death()
        {
            return View();
        }

        public IActionResult Prohibition()
        {
            ViewBag.SubCategory = GetSubcategory(22);
            ViewBag.PidhelaKabja = GetPidhelaKabja();
            return View();
        }

        public IActionResult Form3A()
        {
            return View();
        }

        public IActionResult Bin_Varsi_Lash()
        {
            return View();
        }

        public IActionResult ProhibitionRaidCase()
        {
            return View();
        }

        public IActionResult Prohibition_Crime()
        {
            return View();
        }

        public IActionResult Atakayati_Details()
        {
            ViewBag.SubCategory = GetSubcategory(24);
            return View();
        }

        public IActionResult Atakayati_Pagla()
        {
            ViewBag.SubCategory = GetSubcategory(24);
            return View();
        }

        public IActionResult Samans_Details()
        {
            return View();
        }

        public IActionResult Samans_Jamin_Details()
        {
            return View();
        }

        public IActionResult Samans_Binjamin_Details()
        {
            return View();
        }

        public IActionResult Samans_FamilyCourt_Details()
        {
            return View();
        }

        public IActionResult Samans_Notice_Details()
        {
            return View();
        }

        public IActionResult LeaveApplication()
        {
            return View();
        }

        public IActionResult Leave_Parat()
        {
            return View();
        }

        public IActionResult Night_Round()
        {
            ViewBag.Designation = GetDesignation(5);
            return View();
        }

        public IActionResult Night_Employee_Round()
        {
            return View();
        }

        public IActionResult Night_Round_Person_Count()
        {
            return View();
        }

        public IActionResult NightRound_HEKO_PO()
        {
            return View();
        }

        public IActionResult CRPC()
        {
            return View();
        }

        public IActionResult DCB_PoliceStation()
        {
            return View();
        }

        public IActionResult CrimeBranch_Visit()
        {
            return View();
        }

        public IActionResult Vehicle_Checking()
        {
            ViewBag.SubCategory = GetSubcategory(33);
            return View();
        }

        public IActionResult Detain()
        {
            ViewBag.SubCategory = GetSubcategory(34);
            return View();
        }

        public IActionResult MCR_Details()
        {
            return View();
        }

        public IActionResult Missing_Chaild_Details()
        {
            return View();
        }

        public IActionResult HistoryOfCurrentMissing()
        {
            return View();
        }

        public IActionResult HistoryCurrentYear_Agewise_Missing()
        {
            return View();
        }

        public IActionResult Stationary_Details()
        {
            return View();
        }

        public IActionResult PoliceStation_Wise_Vehical()
        {
            return View();
        }

        public IActionResult Accused_Information()
        {
            return View();
        }

        public IActionResult Labor_Information()
        {
            ViewBag.SubCategory = GetSubcategory(31);
            return View();
        }

        public IActionResult CRPC41C_Amendment()
        {
            return View();
        }

        public IActionResult AutoRikshaw_Details()
        {
            return View();
        }

        public IActionResult Pending_Janvajog()
        {
            return View();
        }

        public IActionResult Pending_Arji_Details()
        {
            return View();
        }

        public IActionResult Bandobast_Details()
        {
            return View();
        }

        public IActionResult E_Gujkop()
        {
            return View();
        }

        public IActionResult CCTV_Installed()
        {
            return View();
        }

        public IActionResult CCTV()
        {
            return View();
        }

        public IActionResult E_Gujkop_Details()
        {
            return View();
        }

        public IActionResult E_FIR_Details()
        {
            return View();
        }
    }
}