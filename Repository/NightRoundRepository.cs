using AhmedabadCityDR.Interfaces;
using AhmedabadCityDR.Models.TableModels;
using AhmedabadCityDR.Models.ViewModels;
using Microsoft.Data.SqlClient;

namespace AhmedabadCityDR.Repository
{
    public class NightRoundRepository : GenericRepository<TblNightRound>, INightRound
    {

        #region Private Memebers

        /// <summary>
        /// Get context.
        /// </summary>
        private readonly AhmCityDrDbContext _context;

        #endregion

        #region Constructors

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context">Context</param>
        public NightRoundRepository(AhmCityDrDbContext context) : base(context)
        {
            _context = context;
        }

        #endregion
        #region Public Methods

        public void DeleteById(int id)
        {
            _context.Database.ExecuteSqlRaw($"SP_tblNightRound_DEL {id}");
        }

        /// <summary>
        /// Gets night round
        /// </summary>
        /// <returns>Returns list of night round</returns>
        public IEnumerable<NightRoundViewModel> GetNightRound(int roleId, int sectorId, int zoneId, int divisionId, int policeStationId, DateTime fromDate, DateTime toDate)
        {
            var pRoleId = new SqlParameter("@RoleId", roleId);
            var pSectorId = new SqlParameter("@SectorId", sectorId);
            var pZoneId = new SqlParameter("@ZoneId", zoneId);
            var PDivisionId = new SqlParameter("@DivisionId", divisionId);
            var pPoliceStationId = new SqlParameter("@PoliceStationId", policeStationId);
            var pFromDate = new SqlParameter("@FromDate", fromDate);
            var pToDate = new SqlParameter("@ToDate", toDate);

            return _context.Set<NightRoundViewModel>().FromSqlRaw("exec SP_tblNightRound_SEL @RoleId, @SectorId, @ZoneId, @DivisionId, @PoliceStationId, @FromDate, @ToDate", pRoleId, pSectorId, pZoneId, PDivisionId, pPoliceStationId, pFromDate, pToDate).ToList();
        }

        #endregion
    }
}
