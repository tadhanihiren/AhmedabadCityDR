using AhmedabadCityDR.Interfaces;
using AhmedabadCityDR.Models.TableModels;
using AhmedabadCityDR.Models.ViewModels;
using Microsoft.Data.SqlClient;

namespace AhmedabadCityDR.Repository
{
    public class ProhibitionRaidCaseRepository : GenericRepository<TblProhibitionRaidCase>, IProhibitionRaidCase
    {
        #region Private Members

        /// <summary>
        /// Context
        /// </summary>
        private readonly AhmCityDrDbContext _context;

        #endregion

        #region Constructors

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context">Context</param>
        public ProhibitionRaidCaseRepository(AhmCityDrDbContext context) : base(context)
        {
            _context = context;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Find Prohibition Raid Case by police satation
        /// </summary>
        /// <param name="roleId">Role ID</param>
        /// <param name="sectorId">Sector ID</param>
        /// <param name="zoneId">Zone ID</param>
        /// <param name="divisionId">Division ID</param>
        /// <param name="policeStationId">Police station ID</param>
        /// <param name="categoryId">Category id</param>
        /// <param name="policeStationNumber">Police station Number</param>
        /// <returns>Returns ProhibitionRaidCaseViewModel or Null</returns>
        public ProhibitionRaidCaseViewModel FindByPoliceStaionNumber(int roleId, int sectorId, int zoneId, int divisionId, int policeStationId, int categoryId, string policeStationNumber)
        {
            var pRoleId = new SqlParameter("@RoleId", roleId);
            var pSectorId = new SqlParameter("@SectorId", sectorId);
            var pZoneId = new SqlParameter("@ZoneId", zoneId);
            var PDivisionId = new SqlParameter("@DivisionId", divisionId);
            var pPoliceStationId = new SqlParameter("@PoliceStationId", policeStationId);
            var pCategoryId = new SqlParameter("@CategoryId", categoryId);
            var pPoliceStationNumber = new SqlParameter("@GunhaRegisterNumber", policeStationNumber);
            var pFromDate = new SqlParameter("@FromDate",DateTime.Now); 
            var pToDate = new SqlParameter("@ToDate",DateTime.Now); 

#pragma warning disable CS8603 // Possible null reference return.
            return _context.Set<ProhibitionRaidCaseViewModel>()
                           .FromSqlRaw("exec USP_tbl_ProhibitionRaidCase_SEL_Check @RoleId, @SectorId, @ZoneId, @DivisionId, @PoliceStationId, @FromDate, @ToDate, @CategoryId, @GunhaRegisterNumber",
                                       pRoleId,
                                       pSectorId,
                                       pZoneId,
                                       PDivisionId,
                                       pPoliceStationId,
                                       pFromDate,
                                       pToDate,
                                       pCategoryId,
                                       pPoliceStationNumber)
                           .AsEnumerable()
                           .Where(x => x.IsActive == true)
                           .FirstOrDefault();
#pragma warning restore CS8603 // Possible null reference return.
        }

        /// <summary>
        /// Gets Prohibition Raid Case
        /// /// </summary>
        /// <param name="roleId">Role ID</param>
        /// <param name="sectorId">Sector ID</param>
        /// <param name="zoneId">Zone ID</param>
        /// <param name="divisionId">Division ID</param>
        /// <param name="policeStationId">Police station ID</param>
        /// <param name="fromDate">From date</param>
        /// <param name="toDate">To date</param>
        /// <returns>Returns list of ProhibitionRaidCaseViewModel</returns>
        public IEnumerable<ProhibitionRaidCaseViewModel> GetProhibitionRaidCase(int roleId, int sectorId, int zoneId, int divisionId, int policeStationId, DateTime fromDate, DateTime toDate)
        {
            var pRoleId = new SqlParameter("@RoleId", roleId);
            var pSectorId = new SqlParameter("@SectorId", sectorId);
            var pZoneId = new SqlParameter("@ZoneId", zoneId);
            var PDivisionId = new SqlParameter("@DivisionId", divisionId);
            var pPoliceStationId = new SqlParameter("@PoliceStationId", policeStationId);
            var pFromDate = new SqlParameter("@FromDate", fromDate);
            var pToDate = new SqlParameter("@ToDate", toDate);

            return _context.Set<ProhibitionRaidCaseViewModel>()
                           .FromSqlRaw("exec USP_tbl_ProhibitionRaidCase_SEL @RoleId, @SectorId, @ZoneId, @DivisionId, @PoliceStationId, @FromDate, @ToDate", pRoleId, pSectorId, pZoneId, PDivisionId, pPoliceStationId, pFromDate, pToDate)
                           .AsEnumerable()
                           .Where(x => x.IsActive == true)
                           .ToList();
        }

        #endregion
    }
}
