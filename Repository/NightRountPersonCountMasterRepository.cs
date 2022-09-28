using AhmedabadCityDR.Interfaces;
using AhmedabadCityDR.Models.TableModels;
using AhmedabadCityDR.Models.ViewModels;
using Microsoft.Data.SqlClient;

namespace AhmedabadCityDR.Repository
{
    public class NightRountPersonCountMasterRepository : GenericRepository<TblNightRountPersonCountMaster>, INightRountPersonCountMaster
    {
        private readonly AhmCityDrDbContext _context;

        public NightRountPersonCountMasterRepository(AhmCityDrDbContext context) : base(context)
        {
            _context = context;
        }

        public void DeleteById(int id)
        {
            _context.Database.ExecuteSqlRaw($"SP_tblNightRountPersonCountMaster_DEL {id}");
        }

        public NightRountPersonCountMasterViewModel FindByPoliceStaionNumber(int roleId, int sectorId, int zoneId, int divisionId, int policeStationId, DateTime fromDate, DateTime toDate)
        {
            var pRoleId = new SqlParameter("@RoleId", roleId);
            var pSectorId = new SqlParameter("@SectorId", sectorId);
            var pZoneId = new SqlParameter("@ZoneId", zoneId);
            var PDivisionId = new SqlParameter("@DivisionId", divisionId);
            var pPoliceStationId = new SqlParameter("@PoliceStationId", policeStationId);
            var pFromDate = new SqlParameter("@FromDate", fromDate);
            var pToDate = new SqlParameter("@ToDate", toDate);

            return _context.Set<NightRountPersonCountMasterViewModel>()
                           .FromSqlRaw("exec Usp_tblpart1_5_crimes_sel_check @RoleId, @SectorId, @ZoneId, @DivisionId, @PoliceStationId, @FromDate, @ToDate", pRoleId, pSectorId, pZoneId, PDivisionId, pPoliceStationId, pFromDate, pToDate)
                           .AsEnumerable()
                           .FirstOrDefault();
        }

        public IEnumerable<NightRountPersonCountMasterViewModel> GetNightRountPersonCount(int roleId, int sectorId, int zoneId, int divisionId, int policeStationId, DateTime fromDate, DateTime toDate)
        {
            var pRoleId = new SqlParameter("@RoleId", roleId);
            var pSectorId = new SqlParameter("@SectorId", sectorId);
            var pZoneId = new SqlParameter("@ZoneId", zoneId);
            var PDivisionId = new SqlParameter("@DivisionId", divisionId);
            var pPoliceStationId = new SqlParameter("@PoliceStationId", policeStationId);
            var pFromDate = new SqlParameter("@FromDate", fromDate);
            var pToDate = new SqlParameter("@ToDate", toDate);

            return _context.Set<NightRountPersonCountMasterViewModel>()
                           .FromSqlRaw("exec USP_tblNightRountPersonCountMaster_SEL @RoleId, @SectorId, @ZoneId, @DivisionId, @PoliceStationId, @FromDate, @ToDate", pRoleId, pSectorId, pZoneId, PDivisionId, pPoliceStationId, pFromDate, pToDate)
                           .ToList();
        }
    }
}
