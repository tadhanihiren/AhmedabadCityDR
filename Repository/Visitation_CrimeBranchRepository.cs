using AhmedabadCityDR.Interfaces;
using AhmedabadCityDR.Models.TableModels;
using AhmedabadCityDR.Models.ViewModels;
using Microsoft.Data.SqlClient;

namespace AhmedabadCityDR.Repository
{
    public class Visitation_CrimeBranchRepository : GenericRepository<TblVisitationCrimeBranch>, IVisitation_CrimeBranch
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
        public Visitation_CrimeBranchRepository(AhmCityDrDbContext context) : base(context)
        {
            _context = context;
        }
        public void DeleteById(int id)
        {
            _context.Database.ExecuteSqlRaw($"SP_tblVisitation_CrimeBranch_DEL {id}");
        }
        #endregion
        /// <summary>
        /// Gets Visitation Crime branch
        /// </summary>
        /// <returns>Returns list of Visitation Crime branch</returns>
        public IEnumerable<Visitation_CrimeBranchViewModel> GetVisitationCrimeBranch(int roleId, int sectorId, int zoneId, int divisionId, int policeStationId, DateTime fromDate, DateTime toDate)
        {
            var pRoleId = new SqlParameter("@RoleId", roleId);
            var pSectorId = new SqlParameter("@SectorId", sectorId);
            var pZoneId = new SqlParameter("@ZoneId", zoneId);
            var PDivisionId = new SqlParameter("@DivisionId", divisionId);
            var pPoliceStationId = new SqlParameter("@PoliceStationId", policeStationId);
            var pFromDate = new SqlParameter("@FromDate", fromDate);
            var pToDate = new SqlParameter("@ToDate", toDate);
            return _context.Set<Visitation_CrimeBranchViewModel>().FromSqlRaw("exec USP_View_tblVisitationCrimeBranch_SEL @RoleId, @SectorId, @ZoneId, @DivisionId, @PoliceStationId, @FromDate, @ToDate", pRoleId, pSectorId, pZoneId, PDivisionId, pPoliceStationId, pFromDate, pToDate)
                           .ToList();
        }
    }
}
