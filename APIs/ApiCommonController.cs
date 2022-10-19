using AhmedabadCityDR.Interfaces;
using AhmedabadCityDR.Models.TableModels;
using Microsoft.AspNetCore.Mvc;

namespace AhmedabadCityDR.APIs
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiCommonController : ControllerBase
    {
        #region Private Members

        /// <summary>
        /// Context.
        /// </summary>
        private readonly IUnitOfWork _unitOfWork;

        #endregion

        #region Constructors

        /// <summary>
        /// Constructor
        /// </summary>
        public ApiCommonController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        #endregion

        /// <summary>
        /// Gets Gender id and name.
        /// </summary>
        /// <returns>List of police stations</returns>
        [HttpGet("GetGender")]
        public JsonResult GetGender()
        {
            var lstGender = _unitOfWork.Gender.GetAll().Select(x => new { Value = x.GenderId, Text = x.Gender });

            return new JsonResult(lstGender);
        }

        /// <summary>
        /// Gets police station id and name.
        /// </summary>
        /// <returns>List of police stations</returns>
        [HttpGet("GetPoliceStation")]
        public JsonResult GetPoliceStation()
        {
            var user = HttpContext.GetClaimsPrincipal();
            var roleId = Convert.ToInt32(user.RoleId);
            var sectorId = Convert.ToInt32(user.SectorId);
            var zoneId = Convert.ToInt32(user.ZoneId);
            var divisionId = Convert.ToInt32(user.DivisionId);
            var policeStationId = Convert.ToInt32(user.PoliceStationId);

            var data = new List<TblPoliceStationMaster>();

            if (roleId <= 2 && roleId != 0)
            {
                data = _unitOfWork.PoliceStationMaster.GetAll()
                                                      .Where(x => x.IsTraffic == false)
                                                      .ToList();
            }

            if (roleId == 3 && sectorId != 0 && zoneId == 0 && divisionId == 0 && policeStationId == 0)
            {
                data = _unitOfWork.PoliceStationMaster.GetAll()
                                                      .Where(x => x.SectorId == sectorId && x.IsTraffic == false)
                                                      .ToList();
            }

            if (sectorId == 0 && zoneId != 0 && divisionId == 0 && policeStationId == 0)
            {
                data = _unitOfWork.PoliceStationMaster.GetAll()
                                                      .Where(x => x.ZoneId == zoneId && x.IsTraffic == false)
                                                      .ToList();
            }

            if (sectorId == 0 && zoneId == 0 && divisionId != 0 && policeStationId == 0)
            {
                data = _unitOfWork.PoliceStationMaster.GetAll()
                                                      .Where(x => x.DivisionId == divisionId && x.IsTraffic == false)
                                                      .ToList();
            }

            if (policeStationId != 0)
            {
                data = _unitOfWork.PoliceStationMaster.GetAll()
                                                      .Where(x => x.DivisionId == divisionId && x.IsTraffic == false)
                                                      .ToList();
            }

            return new JsonResult(data);
        }

        /// <summary>
        /// Gets all Designation id and name.
        /// </summary>
        /// <returns>List of police stations</returns>
        [HttpGet("GetAllDesignation")]
        public JsonResult GetAllDesignation()
        {
            var user = HttpContext.GetClaimsPrincipal();

            int roleId = Convert.ToInt32(user.RoleId);
            int zoneId = Convert.ToInt32(user.ZoneId);
            int divisionId = Convert.ToInt32(user.DivisionId);
            int policeStationId = Convert.ToInt32(user.PoliceStationId);


            var lstDesignation = _unitOfWork.DesignationMaster.GetAll()
                                                              .Select(x => new { Value = x.DesignationId, Text = x.DesignationName })
                                                              .ToList();
            return new JsonResult(lstDesignation);

        }

        /// <summary>
        /// Gets police station for Internal Transffer.
        /// </summary>
        /// <returns>Json</returns>
        [HttpGet("GetInternalTransfferPoliceStation")]
        public JsonResult? GetInternalTransfferPoliceStation(int? designationId)
        {
            var user = HttpContext.GetClaimsPrincipal();
            var roleId = Convert.ToInt32(user.RoleId);
            var sectorId = Convert.ToInt32(user.SectorId);
            var zoneId = Convert.ToInt32(user.ZoneId);
            var divisionId = Convert.ToInt32(user.DivisionId);
            var policeStationId = Convert.ToInt32(user.PoliceStationId);

            if (designationId == 2 || designationId == 15)
            {
                var lstPoliceStation = _unitOfWork.SectorMaster.GetAll()
                                                               .Where(x => x.SectorId != 0)
                                                               .Select(x => new { Value = x.SectorId, Text = x.SectorName });

                return new JsonResult(lstPoliceStation);
            }
            
            if (designationId == 3)
            {
                var lstPoliceStation = _unitOfWork.ZoneMaster.GetAll()
                                                             .Where(x => x.ZoneId != 0)
                                                             .Select(x => new { Value = x.ZoneId, Text = x.ZoneName });

                return new JsonResult(lstPoliceStation);
            }

            if (designationId == 4)
            {
                var lstPoliceStation = _unitOfWork.DivisionMaster.GetAll()
                                                                 .Where(x => x.DivisionId != 0)
                                                                 .Select(x => new { Value = x.DivisionId, Text = x.DivisionName });

                return new JsonResult(lstPoliceStation);
            }
            
            if (designationId >= 5 && designationId != 15)
            {
                var lstPoliceStation = _unitOfWork.PoliceStationMaster.GetAll()
                                                                      .Where(x => x.PoliceStationId != 0 && x.IsTraffic == false)
                                                                      .Select(x => new { Value = x.PoliceStationId, Text = x.PoliceStationName });

                return new JsonResult(lstPoliceStation);
            }

            return null;
        }

        /// <summary>
        /// Gets Designation id and name.
        /// </summary>
        /// <returns>List of police stations</returns>
        [HttpGet("GetDesignation")]
        public JsonResult GetDesignation()
        {
            var user = HttpContext.GetClaimsPrincipal();

            int roleId = Convert.ToInt32(user.RoleId);
            int zoneId = Convert.ToInt32(user.ZoneId);
            int divisionId = Convert.ToInt32(user.DivisionId);
            int policeStationId = Convert.ToInt32(user.PoliceStationId);

            if (policeStationId == 0 && (roleId == 2 || roleId == 1 || roleId == 3) && zoneId == 0 && divisionId == 0)
            {
                var lstDesignation = _unitOfWork.DesignationMaster.GetAll()
                                                                  .Where(x => x.DesignationId <= 6 || x.DesignationId == 15)
                                                                  .Select(x => new { x.DesignationId, x.DesignationName })
                                                                  .ToList();
                return new JsonResult(lstDesignation);
            }
            else if (zoneId != 0 && divisionId == 0 && policeStationId == 0 && roleId == 4)
            {
                var lstDesignation = _unitOfWork.DesignationMaster.GetAll()
                                                  .Where(x => x.DesignationId >= 3 && x.DesignationId <= 5)
                                                  .Select(x => new { x.DesignationId, x.DesignationName })
                                                  .ToList();
                return new JsonResult(lstDesignation);
            }

            else if (zoneId == 0 && divisionId != 0 && policeStationId == 0 && roleId == 5)
            {
                var lstDesignation = _unitOfWork.DesignationMaster.GetAll()
                                  .Where(x => x.DesignationId >= 4 && x.DesignationId <= 6)
                                  .Select(x => new { x.DesignationId, x.DesignationName })
                                  .ToList();
                return new JsonResult(lstDesignation);
            }
            else if (policeStationId != 0)
            {
                var lstDesignation = _unitOfWork.DesignationMaster.GetAll()
                  .Where(x => x.DesignationId >= 5 && x.DesignationId <= 6)
                  .Select(x => new { x.DesignationId, x.DesignationName })
                  .ToList();
                return new JsonResult(lstDesignation);
            }

            return new JsonResult(null);
        }

        /// <summary>
        /// Gets city police Sector id and name.
        /// </summary>
        /// <param name="designationId">Id</param>
        /// <returns>List of sector</returns>
        [HttpGet("GetCitySector")]
        public JsonResult? GetCitySector(int? designationId)
        {
            switch (designationId)
            {
                case 2:
                case 15:
                    var lstSector = _unitOfWork.SectorMaster.GetAll()
                                                            .Where(x => x.SectorId != 0)
                                                            .Select(x => new { Value = x.SectorId, Text = x.SectorName })
                                                            .ToList();
                    return new JsonResult(lstSector);

                case 3:
                    var lstZone = _unitOfWork.ZoneMaster.GetAll().Where(x => x.ZoneId != 0)
                                                        .Select(x => new { Value = x.ZoneId, Text = x.ZoneName })
                                                        .ToList();
                    return new JsonResult(lstZone);

                case 4:
                    var lstDivision = _unitOfWork.DivisionMaster.GetAll().Where(x => x.DivisionId != 0)
                                                                .Select(x => new { Value = x.DivisionId, Text = x.DivisionName })
                                                                .ToList();
                    return new JsonResult(lstDivision);

                case 5:
                case 6:
                    var lstPolicestation = _unitOfWork.PoliceStationMaster.GetAll().Where(x => x.PoliceStationId != 0 && x.IsTraffic == false)
                                                                          .Select(x => new { Value = x.PoliceStationId, Text = x.PoliceStationName })
                                                                          .ToList();
                    return new JsonResult(lstPolicestation);

                default:
                    return new JsonResult(null);
            }
        }

        /// <summary>
        /// Gets Sector id and name.
        /// </summary>
        /// <param name="designationId">Id</param>
        /// <returns>List of sector</returns>
        [HttpGet("GetSector")]
        public JsonResult? GetSector(int? designationId)
        {
            switch (designationId)
            {
                case 2:
                case 15:
                    var lstSector = _unitOfWork.SectorMaster.GetAll()
                                                            .Where(x => x.SectorId != 0)
                                                            .Select(x => new { Value = x.SectorId, Text = x.SectorName })
                                                            .ToList();
                    return new JsonResult(lstSector);

                case 3:
                    var lstZone = _unitOfWork.ZoneMaster.GetAll().Where(x => x.ZoneId != 0)
                                                        .Select(x => new { Value = x.ZoneId, Text = x.ZoneName })
                                                        .ToList();
                    return new JsonResult(lstZone);

                case 4:
                    var lstDivision = _unitOfWork.DivisionMaster.GetAll().Where(x => x.DivisionId != 0)
                                                                .Select(x => new { Value = x.DivisionId, Text = x.DivisionName })
                                                                .ToList();
                    return new JsonResult(lstDivision);

                case 5:
                case 6:
                    var lstPolicestation = _unitOfWork.PoliceStationMaster.GetAll().Where(x => x.PoliceStationId != 0)
                                                                          .Select(x => new { Value = x.PoliceStationId, Text = x.PoliceStationName })
                                                                          .ToList();
                    return new JsonResult(lstPolicestation);

                default:
                    return new JsonResult(null);
            }
        }

        /// <summary>
        /// Gets Employee id and name.
        /// </summary>
        /// <param name="policeStationId">PoliceStation Id</param>
        /// <param name="designationId">Designation Id</param>
        /// <returns>List of Employee</returns>
        [HttpGet("GetEmployee")]
        public JsonResult GetEmployee(int? policeStationId, int? designationId)
        {
            switch (designationId)
            {
                case 2:
                case 15:
                    var lstSector = _unitOfWork.EmployeeMaster.GetAll()
                                                              .Where(x => x.SectorId == policeStationId && x.DesignationId == designationId && x.IsActive == true && x.IsDeleted == false)
                                                              .Select(x => new { Value = x.EmployeeId, Text = x.EmployeName })
                                                              .ToList();
                    return new JsonResult(lstSector);

                case 3:
                    var lstZone = _unitOfWork.EmployeeMaster.GetAll()
                                                            .Where(x => x.ZoneId == policeStationId && x.DesignationId == designationId && x.IsActive == true && x.IsDeleted == false)
                                                            .Select(x => new { Value = x.EmployeeId, Text = x.EmployeName })
                                                            .ToList();
                    return new JsonResult(lstZone);

                case 4:
                    var lstDivision = _unitOfWork.EmployeeMaster.GetAll()
                                                                .Where(x => x.DivisionId == policeStationId && x.DesignationId == designationId && x.IsActive == true && x.IsDeleted == false)
                                                                .Select(x => new { Value = x.EmployeeId, Text = x.EmployeName })
                                                                .ToList();
                    return new JsonResult(lstDivision);

                default:
                    var lstPolicestation = _unitOfWork.EmployeeMaster.GetAll()
                                                                     .Where(x => x.PoliceStationId == policeStationId && x.DesignationId == designationId && x.IsActive == true && x.IsDeleted == false)
                                                                     .Select(x => new { Value = x.EmployeeId, Text = x.EmployeName })
                                                                     .ToList();
                    return new JsonResult(lstPolicestation);
            }
        }

        /// <summary>
        /// Gets Designation id and name.
        /// </summary>
        /// <returns>List of Designation Name</returns>
        [HttpGet("GetInchargeDesignation")]
        public JsonResult GetInchargeDesignation()
        {
            var lstDesignation = _unitOfWork.DesignationName.GetAll().Select(X => new { Value = X.DesignationId, Text = X.DesignationName }).ToList();
            return new JsonResult(lstDesignation);
        }

        /// <summary>
        /// Gets Incharge Sector
        /// </summary>
        /// <param name="inchargedesignationId">Incharge Designation Id</param>
        /// <returns>returns Incharge list</returns>
        [HttpGet("GetInchargeSector")]
        public JsonResult GetInchargeSector(int? inchargedesignationId)
        {
            switch (inchargedesignationId)
            {
                case 2:
                case 15:
                    var lstSector = _unitOfWork.SectorMaster.GetAll().Where(x => x.SectorId != 0).Select(x => new { Value = x.SectorId, Text = x.SectorName }).ToList();
                    return new JsonResult(lstSector);

                case 3:
                    var lstZone = _unitOfWork.ZoneMaster.GetAll().Where(x => x.ZoneId != 0).Select(x => new { Value = x.ZoneId, Text = x.ZoneName }).ToList();
                    return new JsonResult(lstZone);

                case 4:
                    var lstDivision = _unitOfWork.DivisionMaster.GetAll().Where(x => x.DivisionId != 0).Select(x => new { Value = x.DivisionId, Text = x.DivisionName }).ToList();
                    return new JsonResult(lstDivision);

                case 5:
                case 6:
                    var lstPolicestation = _unitOfWork.PoliceStationMaster.GetAll().Where(x => x.PoliceStationId != 0).Select(x => new { Value = x.PoliceStationId, Text = x.PoliceStationName }).ToList();
                    return new JsonResult(lstPolicestation);

                default:
                    return new JsonResult(null);
            }
        }

        /// <summary>
        /// Gets Employee id and name.
        /// </summary>
        /// <param name="inchargepoliceStationId">PoliceStation Id</param>
        /// <param name="inchargedesignationId">Designation Id</param>
        /// <returns>List of Employee</returns>
        [HttpGet("GetInchargeEmployee")]
        public JsonResult GetInchargeEmployee(int? inchargepoliceStationId, int? inchargedesignationId)
        {
            switch (inchargedesignationId)
            {
                case 2:
                case 15:
                    var lstSector = _unitOfWork.EmployeeMaster.GetAll()
                                                              .Where(x => x.SectorId == inchargepoliceStationId && x.DesignationId == inchargedesignationId && x.IsActive == true && x.IsDeleted == false)
                                                              .Select(x => new { Value = x.EmployeeId, Text = x.EmployeName })
                                                              .ToList();
                    return new JsonResult(lstSector);

                case 3:
                    var lstZone = _unitOfWork.EmployeeMaster.GetAll()
                                                            .Where(x => x.ZoneId == inchargepoliceStationId && x.DesignationId == inchargedesignationId && x.IsActive == true && x.IsDeleted == false)
                                                            .Select(x => new { Value = x.EmployeeId, Text = x.EmployeName })
                                                            .ToList();
                    return new JsonResult(lstZone);

                case 4:
                    var lstDivision = _unitOfWork.EmployeeMaster.GetAll()
                                                                .Where(x => x.DivisionId == inchargepoliceStationId && x.DesignationId == inchargedesignationId && x.IsActive == true && x.IsDeleted == false)
                                                                .Select(x => new { Value = x.EmployeeId, Text = x.EmployeName })
                                                                .ToList();
                    return new JsonResult(lstDivision);

                default:
                    var lstPolicestation = _unitOfWork.EmployeeMaster.GetAll()
                                                                     .Where(x => x.PoliceStationId == inchargepoliceStationId && x.DesignationId == inchargedesignationId && x.IsActive == true && x.IsDeleted == false)
                                                                     .Select(x => new { Value = x.EmployeeId, Text = x.EmployeName })
                                                                     .ToList();
                    return new JsonResult(lstPolicestation);
            }
        }

        /// <summary>
        /// Gets Leave id and name.
        /// </summary>
        /// <returns>List of Leave Type</returns>
        [HttpGet("GetLeaveType")]
        public JsonResult GetLeaveType()
        {
            var lstLeaveType = _unitOfWork.LeaveType.GetAll().Select(X => new { Value = X.LeaveTypeId, Text = X.LeaveTypeName }).ToList();
            return new JsonResult(lstLeaveType);
        }

        [HttpGet("Get_policeStationId_For_NightRound")]
        public JsonResult Get_policeStationId_For_NightRound(int? designationId)
        {
            switch (designationId)
            {
                case 1:
                    var lstSectorAll = _unitOfWork.SectorMaster.GetAll().Select(X => new { Value = X.SectorId, Text = X.SectorName }).ToList();
                    return new JsonResult(lstSectorAll);

                case 2:
                case 15:
                    var lstSector = _unitOfWork.SectorMaster.GetAll().Where(X => X.SectorId != 0).Select(X => new { Value = X.SectorId, Text = X.SectorName }).ToList();
                    return new JsonResult(lstSector);

                case 3:
                    var lstZone = _unitOfWork.ZoneMaster.GetAll().Where(X => X.ZoneId != 0).Select(X => new { Value = X.ZoneId, Text = X.ZoneName }).ToList();
                    return new JsonResult(lstZone);

                case 4:
                    var lstDivision = _unitOfWork.DivisionMaster.GetAll().Where(X => X.DivisionId != 0).Select(X => new { Value = X.DivisionId, Text = X.DivisionName }).ToList();
                    return new JsonResult(lstDivision);

                case 5:
                    var lstPolicestation = _unitOfWork.PoliceStationMaster.GetAll().Where(X => X.PoliceStationId != 0).Select(X => new { Value = X.PoliceStationId, Text = X.PoliceStationName }).ToList();
                    return new JsonResult(lstPolicestation);

                default:
                    break;
            }

            return new JsonResult(null);
        }

        [HttpGet("Get_DesignationId_For_NightEmployeeRound")]
        public JsonResult Get_DesignationId_For_NightEmployeeRound()
        {
            var lstSectorAll = _unitOfWork.DesignationMaster.GetAll()
                .Where(x => x.DesignationId >= 5 && x.DesignationId <= 14)
                .Select(X => new { Value = X.DesignationId, Text = X.DesignationName })
                .ToList();
            return new JsonResult(lstSectorAll);
        }

        [HttpGet("GetEmployeeForNARA")]
        public JsonResult GetEmployeeForNARA(int designationId, int policeStationId)
        {
            var lstSectorAll = _unitOfWork.EmployeeMaster.GetAll()
                .Where(x => x.IsActive == true && x.IsDeleted == false && x.PoliceStationId == policeStationId && x.DesignationId == designationId)
                .Select(X => new { Value = X.EmployeeId, Text = X.EmployeName })
                .ToList();
            return new JsonResult(lstSectorAll);
        }

        [HttpGet("GetDivision")]
        public JsonResult GetDivision(int zoneId)
        {
            var lstDivision = _unitOfWork.DivisionMaster.GetAll()
                .Where(x => x.ZoneId == zoneId && x.IsActive == true)
                .Select(x => new { Value = x.DivisionId, Text = x.DivisionName })
                .ToList();
            return new JsonResult(lstDivision);
        }

        [HttpGet("GetEquipments")]
        public JsonResult GetEquipments()
        {
            var lstDivision = _unitOfWork.Equipment.GetAll()
                .Select(x => new { Value = x.EquipmentsId, Text = x.Type })
                .ToList();
            return new JsonResult(lstDivision);
        }

        [HttpGet("GetStatus")]
        public JsonResult GetStatus()
        {
            var lstDivision = _unitOfWork.Status.GetAll()
                .Select(x => new { Value = x.StatusId, Text = x.StatusType })
                .ToList();
            return new JsonResult(lstDivision);
        }

        [HttpGet("GetPoliceStation_For_BandobastDetails")]
        public JsonResult GetPoliceStation_For_BandobastDetails(int divisionId)
        {
            var lstPolicestation = _unitOfWork.PoliceStationMaster.GetAll()
                .Where(x => x.DivisionId == divisionId && x.IsActive == true && x.IsTraffic == false)
                .Select(x => new { Value = x.PoliceStationId, Text = x.PoliceStationName })
                .ToList();
            return new JsonResult(lstPolicestation);
        }
    }
}