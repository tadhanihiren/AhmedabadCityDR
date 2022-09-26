using AhmedabadCityDR.Interfaces;
using AhmedabadCityDR.Models.TableModels;
using AhmedabadCityDR.Models.ViewModels;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace AhmedabadCityDR.Repository
{
    public class Part1_5CrimeRepository : GenericRepository<TblPart1_5Crime>, IPart1_5Crime
    {
        #region Private Members

        /// <summary>
        /// Get context.
        /// </summary>
        private readonly AhmCityDrDbContext _context;

        #endregion

        #region Constructors

        /// <summary>
        /// Constructors
        /// </summary>
        /// <param name="context">Context</param>
        public Part1_5CrimeRepository(AhmCityDrDbContext context) : base(context)
        {
            _context = context;
        }

        #endregion

        #region Public Methods

        public void DeleteById(int id)
        {
            _context.Database.ExecuteSqlRaw($"SP_tblPart1_5_Crimes_DEL {id}");
        }

        /// <summary>
        /// Gets Part 1 to 5 Crimes
        /// /// </summary>
        /// <param name="roleId">Role ID</param>
        /// <param name="sectorId">Sector ID</param>
        /// <param name="zoneId">Zone ID</param>
        /// <param name="divisionId">Division ID</param>
        /// <param name="policeStationId">Police station ID</param>
        /// <param name="fromDate">From date</param>
        /// <param name="toDate">To date</param>
        /// <param name="categoryId">Category id</param>
        /// <returns>Returns list of Part1_5CrimeViewModel</returns>
        public IEnumerable<Part1_5CrimeViewModel> GetPart1_5Crime(int roleId, int sectorId, int zoneId, int divisionId, int policeStationId, DateTime fromDate, DateTime toDate, int categoryId)
        {
            var pRoleId = new SqlParameter("@RoleId", roleId);
            var pSectorId = new SqlParameter("@SectorId", sectorId);
            var pZoneId = new SqlParameter("@ZoneId", zoneId);
            var PDivisionId = new SqlParameter("@DivisionId", divisionId);
            var pPoliceStationId = new SqlParameter("@PoliceStationId", policeStationId);
            var pFromDate = new SqlParameter("@FromDate", fromDate);
            var pToDate = new SqlParameter("@ToDate", toDate);
            var pCategoryId = new SqlParameter("@CategoryId", categoryId);

            return _context.Set<Part1_5CrimeViewModel>()
                           .FromSqlRaw("exec USP_tblpart1_5_crimes_sel @RoleId, @SectorId, @ZoneId, @DivisionId, @PoliceStationId, @FromDate, @ToDate, @CategoryId", pRoleId, pSectorId, pZoneId, PDivisionId, pPoliceStationId, pFromDate, pToDate, pCategoryId)
                           .ToList();
        }

        /// <summary>
        /// Gets Part 1 to 5 Crimes by police satation
        /// /// </summary>
        /// <param name="roleId">Role ID</param>
        /// <param name="sectorId">Sector ID</param>
        /// <param name="zoneId">Zone ID</param>
        /// <param name="divisionId">Division ID</param>
        /// <param name="policeStationId">Police station ID</param>
        /// <param name="categoryId">Category id</param>
        /// <param name="policeStationNumber">Police station Number</param>
        /// <returns>Returns Part1_5Crime or Null</returns>
        public Part1_5CrimeViewModel FindByPoliceStaionNumber(int roleId, int sectorId, int zoneId, int divisionId, int policeStationId, int categoryId, string policeStationNumber)
        {
            var pRoleId = new SqlParameter("@RoleId", roleId);
            var pSectorId = new SqlParameter("@SectorId", sectorId);
            var pZoneId = new SqlParameter("@ZoneId", zoneId);
            var PDivisionId = new SqlParameter("@DivisionId", divisionId);
            var pPoliceStationId = new SqlParameter("@PoliceStationId", policeStationId);
            var pCategoryId = new SqlParameter("@CategoryId", categoryId);
            var pPoliceStationNumber = new SqlParameter("@GunhaRegisterNumber", policeStationNumber);

            return _context.Set<Part1_5CrimeViewModel>()
                           .FromSqlRaw("exec Usp_tblpart1_5_crimes_sel_check @RoleId, @SectorId, @ZoneId, @DivisionId, @PoliceStationId, @CategoryId, @GunhaRegisterNumber", pRoleId, pSectorId, pZoneId, PDivisionId, pPoliceStationId, pCategoryId, pPoliceStationNumber)
                           .AsEnumerable()
                           .FirstOrDefault();
        }

        #endregion
    }
}