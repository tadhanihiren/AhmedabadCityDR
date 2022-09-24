using AhmedabadCityDR.Interfaces;
using AhmedabadCityDR.Models.TableModels;
using AhmedabadCityDR.Models.ViewModels;
using Microsoft.Data.SqlClient;

namespace AhmedabadCityDR.Repository
{
    public class AtakayatiPaglaSummaryRepository : GenericRepository<TblAtakayatiPaglaSummary>, IAtakayatiPaglaSummaryMaster
    {
        #region Private Memebers

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
        public AtakayatiPaglaSummaryRepository(AhmCityDrDbContext context) : base(context)
        {
            _context = context;
        }

        #endregion

        #region Public Methodes

        /// <summary>
        /// Gets Atakayati Pagla Summary
        /// /// </summary>
        /// <param name="roleId">Role ID</param>
        /// <param name="sectorId">Sector ID</param>
        /// <param name="zoneId">Zone ID</param>
        /// <param name="divisionId">Division ID</param>
        /// <param name="policeStationId">Police station ID</param>
        /// <param name="fromDate">From date</param>
        /// <param name="toDate">To date</param>
        /// <returns>Returns list of AtakayatiPaglaSummaryViewModel</returns>
        public IEnumerable<AtakayatiPaglaSummaryViewModel> GetAtakayatiPaglaSummary(int roleId, int sectorId, int zoneId, int divisionId, int policeStationId, DateTime fromDate, DateTime toDate)
        {
            var pRoleId = new SqlParameter("@RoleId", roleId);
            var pSectorId = new SqlParameter("@SectorId", sectorId);
            var pZoneId = new SqlParameter("@ZoneId", zoneId);
            var PDivisionId = new SqlParameter("@DivisionId", divisionId);
            var pPoliceStationId = new SqlParameter("@PoliceStationId", policeStationId);
            var pFromDate = new SqlParameter("@FromDate", fromDate);
            var pToDate = new SqlParameter("@ToDate", toDate);

            return _context.Set<AtakayatiPaglaSummaryViewModel>()
                           .FromSqlRaw("exec USP_tblAtakayatiPaglaSummary_SEL @RoleId, @SectorId, @ZoneId, @DivisionId, @PoliceStationId, @FromDate, @ToDate",
                                       pRoleId,
                                       pSectorId,
                                       pZoneId,
                                       PDivisionId,
                                       pPoliceStationId,
                                       pFromDate,
                                       pToDate)
                           .ToList();
        }

        #endregion
    }
}