using AhmedabadCityDR.Interfaces;
using AhmedabadCityDR.Models.TableModels;
using AhmedabadCityDR.Models.ViewModels;
using Microsoft.Data.SqlClient;

namespace AhmedabadCityDR.Repository
{
    public class AtakayatiPaglaRepository : GenericRepository<TblAtakayatiPagla>, IAtakayatiPagla
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
        public AtakayatiPaglaRepository(AhmCityDrDbContext context) : base(context)
        {
            _context = context;
        }

        #endregion

        #region Public Methods

        public void DeleteById(int id)
        {
            _context.Database.ExecuteSqlRaw($"SP_tblAtakatiPagla_DEL {id}");
        }

        public IEnumerable<AtakayatiPaglaViewModel> GetAtakayatiPagla(int roleId, int sectorId, int zoneId, int divisionId, int policeStationId, DateTime fromDate, DateTime toDate)
        {
            var pRoleId = new SqlParameter("@RoleId", roleId);
            var pSectorId = new SqlParameter("@SectorId", sectorId);
            var pZoneId = new SqlParameter("@ZoneId", zoneId);
            var PDivisionId = new SqlParameter("@DivisionId", divisionId);
            var pPoliceStationId = new SqlParameter("@PoliceStationId", policeStationId);
            var pFromDate = new SqlParameter("@FromDate", fromDate);
            var pToDate = new SqlParameter("@ToDate", toDate);

            return _context.Set<AtakayatiPaglaViewModel>()
                           .FromSqlRaw("exec USP_tblAtakayatiPagla_SEL @RoleId, @SectorId, @ZoneId, @DivisionId, @PoliceStationId, @FromDate, @ToDate", pRoleId, pSectorId, pZoneId, PDivisionId, pPoliceStationId, pFromDate, pToDate)
                           .ToList();
        }

        #endregion
    }
}
