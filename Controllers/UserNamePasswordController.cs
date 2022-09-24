using AhmedabadCityDR.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AhmedabadCityDR.Controllers
{
    public class UserNamePasswordController : Controller
    {
        private readonly IUnitOfWork _iUnitOfWork;

        public UserNamePasswordController(IUnitOfWork iUnitOfWork)
        {
            _iUnitOfWork = iUnitOfWork;
        }

        public IActionResult UserName_Password()
        {
            var lstDesignation = _iUnitOfWork.DesignationMaster.GetAll()
                .Where(X => X.DesignationId <= 6)
                .Select(X => new { X.DesignationId, X.DesignationName })
                .ToList();

            var designation = new List<SelectListItem>();

            foreach (var item in lstDesignation)
            {
                designation.Add(new SelectListItem { Value = item.DesignationId.ToString(), Text = item.DesignationName });
            }

            ViewBag.Designation = designation;

            return View();
        }

        [HttpGet]
        public IActionResult GetSector_Zone_Division_PoliceStationId(int? DesignationId)
        {
            switch (DesignationId)
            {
                case 1:
                    var lstSectorAll = _iUnitOfWork.SectorMaster.GetAll().Select(X => new { Value = X.SectorId, Text = X.SectorName }).ToList();
                    return Json(lstSectorAll);

                case 2:
                    var lstSector = _iUnitOfWork.SectorMaster.GetAll().Where(X => X.SectorId != 0).Select(X => new { X.SectorId, text = X.SectorName }).ToList();
                    return Json(lstSector);

                case 3:
                    var lstZone = _iUnitOfWork.ZoneMaster.GetAll().Where(X => X.ZoneId != 0).Select(X => new { Value = X.ZoneId, Text = X.ZoneName }).ToList();
                    return Json(lstZone);

                case 4:
                    var lstDivision = _iUnitOfWork.DivisionMaster.GetAll().Where(X => X.DivisionId != 0).Select(X => new { Value = X.DivisionId, Text = X.DivisionName }).ToList();
                    return Json(lstDivision);

                case 5:
                case 6:
                    var lstPolicestation = _iUnitOfWork.PoliceStationMaster.GetAll().Where(X => X.PoliceStationId != 0).Select(X => new { Value = X.PoliceStationId, Text = X.PoliceStationName }).ToList();
                    return Json(lstPolicestation);

                default:
                    break;
            }

            return Json(null);
        }
    }
}