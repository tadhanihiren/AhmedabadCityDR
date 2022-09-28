using AhmedabadCityDR.Interfaces;
using AhmedabadCityDR.Models.TableModels;
using AhmedabadCityDR.Models.ViewModels;
using Microsoft.Data.SqlClient;

namespace AhmedabadCityDR.Repository
{
    public class NightRound_HEKO_PO_Repository : GenericRepository<TblNightRoundHekoPomaster>, INightRound_HEKO_PO
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
        public NightRound_HEKO_PO_Repository(AhmCityDrDbContext context) : base(context)
        {
            _context = context;
        }

        #endregion
        public void DeleteById(int id)
        {
            _context.Database.ExecuteSqlRaw($"SP_tblNightRound_HEKO_POMaster_DEL {id}");
        }
        /// <summary>
        /// Gets night round
        /// </summary>
        /// <returns>Returns list of night round</returns>
        public IEnumerable<NightRound_HEKO_PO_ViewModel> GetNightRound_HEKO_PO(int roleId, int sectorId, int zoneId, int divisionId, int policeStationId, DateTime fromDate, DateTime toDate)
        {
            var pRoleId = new SqlParameter("@RoleId", roleId);
            var pSectorId = new SqlParameter("@SectorId", sectorId);
            var pZoneId = new SqlParameter("@ZoneId", zoneId);
            var PDivisionId = new SqlParameter("@DivisionId", divisionId);
            var pPoliceStationId = new SqlParameter("@PoliceStationId", policeStationId);
            var pFromDate = new SqlParameter("@FromDate", fromDate);
            var pToDate = new SqlParameter("@ToDate", toDate);

            return _context.Set<NightRound_HEKO_PO_ViewModel>().FromSqlRaw("exec USP_tblNightRound_HEKO_POMaster_SEL @RoleId, @SectorId, @ZoneId, @DivisionId, @PoliceStationId, @FromDate, @ToDate", pRoleId, pSectorId, pZoneId, PDivisionId, pPoliceStationId, pFromDate, pToDate).ToList();
        }


    }
}
