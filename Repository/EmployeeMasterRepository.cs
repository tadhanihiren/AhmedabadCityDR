using AhmedabadCityDR.Interfaces;
using AhmedabadCityDR.Models.TableModels;
using AhmedabadCityDR.Models.ViewModels;
using Microsoft.Data.SqlClient;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace AhmedabadCityDR.Repository
{
    /// <summary>
    /// Contains employee related data.
    /// </summary>
    public class EmployeeMasterRepository : GenericRepository<TblEmployeeMaster>, IEmployeeMaster
    {
        #region Private Members

        /// <summary>
        /// Context.
        /// </summary>
        private readonly AhmCityDrDbContext _context;

        #endregion

        #region Constructors

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context">Context</param>
        public EmployeeMasterRepository(AhmCityDrDbContext context) : base(context)
        {
            _context = context;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Finde user By username and password.
        /// </summary>
        /// <param name="userName">Username</param>
        /// <param name="password">Password</param>
        /// <returns>Returns user details or Null</returns>
        public async Task<ClaimUser?> AuthenticateUser(string userName, string password)
        {
            if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(password))
            {
                return null;
            }

            var pUsername = new SqlParameter("@Username", userName);
            var pPassword = new SqlParameter("@Password", password);

            var user = await _context.Set<ClaimUser>().FromSqlRaw("exec USP_Employee_Login @Username, @Password", pUsername, pPassword).ToListAsync();

            return user.FirstOrDefault();
        }

        public IEnumerable<EmployeeMasterViewModel> GetEmployees(int roleId, int sectorId, int zoneId, int divisionId, int policeStationId, DateTime fromDate, DateTime toDate)
        {
            var pRoleId = new SqlParameter("@RoleId", roleId);
            var pSectorId = new SqlParameter("@SectorId", sectorId);
            var pZoneId = new SqlParameter("@ZoneId", zoneId);
            var PDivisionId = new SqlParameter("@DivisionId", divisionId);
            var pPoliceStationId = new SqlParameter("@PoliceStationId", policeStationId);
            var pFromDate = new SqlParameter("@FromDate", fromDate);
            var pToDate = new SqlParameter("@ToDate", toDate);

            return _context.Set<EmployeeMasterViewModel>()
                           .FromSqlRaw("exec USP_View_Employee_Master_SEL @RoleId, @SectorId, @ZoneId, @DivisionId, @PoliceStationId, @FromDate, @ToDate", pRoleId, pSectorId, pZoneId, PDivisionId, pPoliceStationId, pFromDate, pToDate)
                           .ToList();
        }

        public void UpdateInternalTransffer(int employeeId, int transfferPoliceStationId, int designationId, string contactNumber)
        {
            var pEmployeeId = new SqlParameter("@EmployeeId", employeeId);
            var pTransfferPoliceStationId = new SqlParameter("@TransfferPoliceStationId", transfferPoliceStationId);
            var pDesignationId = new SqlParameter("@DesignationId", designationId);
            var pContactNumber = new SqlParameter("@ContactNumber", contactNumber);

            _context.Database.ExecuteSqlRaw($"exec USP_tblChangePoliceStationMaster_UPD @EmployeeId, @TransfferPoliceStationId, @DesignationId, @ContactNumber", pEmployeeId, pTransfferPoliceStationId, pDesignationId, pContactNumber);
        }

        #endregion
    }
}