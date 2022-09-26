using AhmedabadCityDR.Interfaces;
using AhmedabadCityDR.Models.TableModels;
using AhmedabadCityDR.Models.ViewModels;
using Microsoft.Data.SqlClient;

namespace AhmedabadCityDR.Repository
{
    public class ProhibitionCrimeRepository : GenericRepository<TblProhibitionCrimeMaster>, IProhibitionCrime
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
        public ProhibitionCrimeRepository(AhmCityDrDbContext context) : base(context)
        {
            _context = context;
        }
        #endregion

        public void DeleteById(int id)
        {
            _context.Database.ExecuteSqlRaw($"SP_tblProhibitioncrime_DEL {id}");
        }

        public IEnumerable<ProhibitionCrimeViewModel> GetProhibitionCrimes(int roleId, int sectorId, int zoneId, int divisionId, int policeStationId, DateTime fromDate, DateTime toDate)
        {
            var pRoleId = new SqlParameter("@RoleId", roleId);
            var pSectorId = new SqlParameter("@SectorId", sectorId);
            var pZoneId = new SqlParameter("@ZoneId", zoneId);
            var PDivisionId = new SqlParameter("@DivisionId", divisionId);
            var pPoliceStationId = new SqlParameter("@PoliceStationId", policeStationId);
            var pFromDate = new SqlParameter("@FromDate", fromDate);
            var pToDate = new SqlParameter("@ToDate", toDate);
          
            return _context.Set<ProhibitionCrimeViewModel>()
                           .FromSqlRaw("exec USP_tblProhibitionCrimeMaster_SEL @RoleId, @SectorId, @ZoneId, @DivisionId, @PoliceStationId, @FromDate, @ToDate", pRoleId, pSectorId, pZoneId, PDivisionId, pPoliceStationId, pFromDate, pToDate)
                           .ToList();
        }
    }
}
