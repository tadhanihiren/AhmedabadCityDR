using AhmedabadCityDR.Interfaces;
using AhmedabadCityDR.Models.TableModels;
using AhmedabadCityDR.Models.ViewModels;
using Microsoft.Data.SqlClient;

namespace AhmedabadCityDR.Repository
{
    public class PoliceStationWisePendingApplicationRepository : GenericRepository<TblPoliceStationWisePendingApplication>, IPoliceStationWisePendingApplication
    {
        #region Private Memebers

        /// <summary>
        /// Gets Context.
        /// </summary>
        private readonly AhmCityDrDbContext _context;

        #endregion

        #region Constructors

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context">Context</param>
        public PoliceStationWisePendingApplicationRepository(AhmCityDrDbContext context) : base(context)
        {
            _context = context;
        }

        #endregion

        public void DeleteById(int id)
        {
            _context.Database.ExecuteSqlRaw($"SP_tblPoliceStationWisePendingApplication_DEL {id}");
        }

        #region Public Methods

        /// <summary>
        /// Gets Accused Information
        /// /// </summary>
        /// <param name="roleId">Role ID</param>
        /// <param name="sectorId">Sector ID</param>
        /// <param name="zoneId">Zone ID</param>
        /// <param name="divisionId">Division ID</param>
        /// <param name="policeStationId">Police station ID</param>
        /// <param name="fromDate">From date</param>
        /// <param name="toDate">To date</param>
        /// <returns>Returns list of AccusedInformationViewModel</returns>
        public IEnumerable<PoliceStationWisePendingApplicationViewModel> GetPoliceStationWisePendingApplication(int roleId, int sectorId, int zoneId, int divisionId, int policeStationId, DateTime fromDate, DateTime toDate)
        {
            var pRoleId = new SqlParameter("@RoleId", roleId);
            var pSectorId = new SqlParameter("@SectorId", sectorId);
            var pZoneId = new SqlParameter("@ZoneId", zoneId);
            var PDivisionId = new SqlParameter("@DivisionId", divisionId);
            var pPoliceStationId = new SqlParameter("@PoliceStationId", policeStationId);
            var pFromDate = new SqlParameter("@FromDate", fromDate);
            var pToDate = new SqlParameter("@ToDate", toDate);

            return _context.Set<PoliceStationWisePendingApplicationViewModel>().FromSqlRaw("exec USP_tblPoliceStationWisePendingApplication_SEL @RoleId, @SectorId, @ZoneId, @DivisionId, @PoliceStationId, @FromDate, @ToDate", pRoleId, pSectorId, pZoneId, PDivisionId, pPoliceStationId, pFromDate, pToDate).ToList();
        }

        #endregion

    }
}
