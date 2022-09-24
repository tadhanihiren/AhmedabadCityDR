using AhmedabadCityDR.Interfaces;
using AhmedabadCityDR.Models.TableModels;
using AhmedabadCityDR.Models.ViewModels;
using Microsoft.Data.SqlClient;

namespace AhmedabadCityDR.Repository
{
    public class Bin_varsi_lashRepository : GenericRepository<TblPart1_5Crime>, IBin_varsi_lash
    {
        #region Private Members

        /// <summary>
        /// Context
        /// </summary>
        private readonly AhmCityDrDbContext _context;

        #endregion

        #region Constructors

        /// <summary>
        /// Constructors
        /// </summary>
        /// <param name="context">Context</param>
        public Bin_varsi_lashRepository(AhmCityDrDbContext context) : base(context)
        {
            _context = context;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Gets Bin_varsi_lash Crimes by police satation
        /// /// </summary>
        /// <param name="roleId">Role ID</param>
        /// <param name="sectorId">Sector ID</param>
        /// <param name="zoneId">Zone ID</param>
        /// <param name="divisionId">Division ID</param>
        /// <param name="policeStationId">Police station ID</param>
        /// <param name="categoryId">Category id</param>
        /// <param name="policeStationNumber">Police station Number</param>
        /// <returns>Returns Bin_varsi_lash or Null</returns>
        public Bin_varsi_lashViewModel FindByPoliceStaionNumber(int roleId, int sectorId, int zoneId, int divisionId, int policeStationId, int categoryId, string policeStationNumber)
        {
            var pRoleId = new SqlParameter("@RoleId", roleId);
            var pSectorId = new SqlParameter("@SectorId", sectorId);
            var pZoneId = new SqlParameter("@ZoneId", zoneId);
            var PDivisionId = new SqlParameter("@DivisionId", divisionId);
            var pPoliceStationId = new SqlParameter("@PoliceStationId", policeStationId);
            var pCategoryId = new SqlParameter("@CategoryId", categoryId);
            var pPoliceStationNumber = new SqlParameter("@GunhaRegisterNumber", policeStationNumber);

            return _context.Set<Bin_varsi_lashViewModel>()
                           .FromSqlRaw("exec Usp_tblpart1_5_crimes_sel_check @RoleId, @SectorId, @ZoneId, @DivisionId, @PoliceStationId, @CategoryId, @GunhaRegisterNumber", pRoleId, pSectorId, pZoneId, PDivisionId, pPoliceStationId, pCategoryId, pPoliceStationNumber)
                           .AsEnumerable()
                           .FirstOrDefault();
        }

        /// <summary>
        /// Gets Bin varsi lash Crimes
        /// /// </summary>
        /// <param name="roleId">Role ID</param>
        /// <param name="sectorId">Sector ID</param>
        /// <param name="zoneId">Zone ID</param>
        /// <param name="divisionId">Division ID</param>
        /// <param name="policeStationId">Police station ID</param>
        /// <param name="fromDate">From date</param>
        /// <param name="toDate">To date</param>
        /// <param name="categoryId">Category id</param>
        /// <returns>Returns list of Bin_varsi_lashViewModel</returns>
        public IEnumerable<Bin_varsi_lashViewModel> GetBin_varsi_lash(int roleId, int sectorId, int zoneId, int divisionId, int policeStationId, DateTime fromDate, DateTime toDate, int categoryId)
        {
            var pRoleId = new SqlParameter("@RoleId", roleId);
            var pSectorId = new SqlParameter("@SectorId", sectorId);
            var pZoneId = new SqlParameter("@ZoneId", zoneId);
            var PDivisionId = new SqlParameter("@DivisionId", divisionId);
            var pPoliceStationId = new SqlParameter("@PoliceStationId", policeStationId);
            var pFromDate = new SqlParameter("@FromDate", fromDate);
            var pToDate = new SqlParameter("@ToDate", toDate);
            var pCategoryId = new SqlParameter("@CategoryId", categoryId);

            return _context.Set<Bin_varsi_lashViewModel>()
                           .FromSqlRaw("exec USP_tblpart1_5_crimes_sel @RoleId, @SectorId, @ZoneId, @DivisionId, @PoliceStationId, @FromDate, @ToDate, @CategoryId", pRoleId, pSectorId, pZoneId, PDivisionId, pPoliceStationId, pFromDate, pToDate, pCategoryId)
                           .ToList();
        }

        #endregion
    }
}