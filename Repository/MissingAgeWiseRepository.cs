using AhmedabadCityDR.Interfaces;
using AhmedabadCityDR.Models.TableModels;
using AhmedabadCityDR.Models.ViewModels;
using Microsoft.Data.SqlClient;

namespace AhmedabadCityDR.Repository
{
    public class MissingAgeWiseRepository : GenericRepository<TblHistoryMissingAgeWiseChild>, IMissingAgeWise
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
        public MissingAgeWiseRepository(AhmCityDrDbContext context) : base(context)
        {
            _context = context;
        }
        #endregion
        /// <summary>
        /// Gets HistoryCurrentMissing
        /// </summary>
        /// <returns>Returns list of MissingAge Wise</returns>
        public IEnumerable<HistoryMissingagewiseViewModel> GetMissingAgeWise(int roleId, int sectorId, int zoneId, int divisionId, int policeStationId, DateTime fromDate, DateTime toDate)
        {
            var pRoleId = new SqlParameter("@RoleId", roleId);
            var pSectorId = new SqlParameter("@SectorId", sectorId);
            var pZoneId = new SqlParameter("@ZoneId", zoneId);
            var PDivisionId = new SqlParameter("@DivisionId", divisionId);
            var pPoliceStationId = new SqlParameter("@PoliceStationId", policeStationId);
            var pFromDate = new SqlParameter("@FromDate", fromDate);
            var pToDate = new SqlParameter("@ToDate", toDate);

            return _context.Set<HistoryMissingagewiseViewModel>().FromSqlRaw("exec USP_View_MissingChildDetails_SEL @RoleId, @SectorId, @ZoneId, @DivisionId, @PoliceStationId, @FromDate, @ToDate", pRoleId, pSectorId, pZoneId, PDivisionId, pPoliceStationId, pFromDate, pToDate).ToList();
        }
    }
}
