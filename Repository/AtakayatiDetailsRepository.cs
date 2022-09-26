using AhmedabadCityDR.Interfaces;
using AhmedabadCityDR.Models.TableModels;
using AhmedabadCityDR.Models.ViewModels;
using Microsoft.Data.SqlClient;

namespace AhmedabadCityDR.Repository
{
    public class AtakayatiDetailsRepository : GenericRepository<TblAtakayatidetail>,IAtakayatiDetails
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
        public AtakayatiDetailsRepository(AhmCityDrDbContext context) : base(context)
        {
            _context = context;
        }

        #endregion

        public void DeleteById(int id)
        {
            _context.Database.ExecuteSqlRaw($"SP_tblAtakayatidetails_DEL {id}");
        }

        public IEnumerable<AtakayatiDetailsViewModel> GetAtakayatiDetails(int roleId, int sectorId, int zoneId, int divisionId, int policeStationId, DateTime fromDate, DateTime toDate)
        {
            var pRoleId = new SqlParameter("@RoleId", roleId);
            var pSectorId = new SqlParameter("@SectorId", sectorId);
            var pZoneId = new SqlParameter("@ZoneId", zoneId);
            var PDivisionId = new SqlParameter("@DivisionId", divisionId);
            var pPoliceStationId = new SqlParameter("@PoliceStationId", policeStationId);
            var pFromDate = new SqlParameter("@FromDate", fromDate);
            var pToDate = new SqlParameter("@ToDate", toDate);

            return _context.Set<AtakayatiDetailsViewModel>()
                           .FromSqlRaw("exec USP_tblAtakayatidetails_SEL @RoleId, @SectorId, @ZoneId, @DivisionId, @PoliceStationId, @FromDate, @ToDate",
                                       pRoleId,
                                       pSectorId,
                                       pZoneId,
                                       PDivisionId,
                                       pPoliceStationId,
                                       pFromDate,
                                       pToDate)
                           .ToList();
        }
    }
}
