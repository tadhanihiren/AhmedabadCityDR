using AhmedabadCityDR.Interfaces;
using AhmedabadCityDR.Models.TableModels;
using AhmedabadCityDR.Models.ViewModels;
using Microsoft.Data.SqlClient;

namespace AhmedabadCityDR.Repository
{
    public class PoliceStationWiseVehicalRepository : GenericRepository<TblPoliceStationWiseVehical>, IPoliceStationWiseVehical
    {
        private readonly AhmCityDrDbContext _context;

        public PoliceStationWiseVehicalRepository(AhmCityDrDbContext context) : base(context)
        {
            _context = context;
        }

        public void DeleteById(int id)
        {
            _context.Database.ExecuteSqlRaw($"SP_tblPoliceStationWiseVehical_DEL {id}");
        }

        public IEnumerable<PoliceStationWiseVehicalViewModel> GetPoliceStationWiseVehical(int roleId, int sectorId, int zoneId, int divisionId, int policeStationId, DateTime fromDate, DateTime toDate)
        {
            var pRoleId = new SqlParameter("@RoleId", roleId);
            var pSectorId = new SqlParameter("@SectorId", sectorId);
            var pZoneId = new SqlParameter("@ZoneId", zoneId);
            var PDivisionId = new SqlParameter("@DivisionId", divisionId);
            var pPoliceStationId = new SqlParameter("@PoliceStationId", policeStationId);
            var pFromDate = new SqlParameter("@FromDate", fromDate);
            var pToDate = new SqlParameter("@ToDate", toDate);

            return _context.Set<PoliceStationWiseVehicalViewModel>()
                           .FromSqlRaw("exec USP_tblPoliceStationWiseVehical_SEL @RoleId, @SectorId, @ZoneId, @DivisionId, @PoliceStationId, @FromDate, @ToDate", pRoleId, pSectorId, pZoneId, PDivisionId, pPoliceStationId, pFromDate, pToDate)
                           .AsEnumerable()
                           .Where(x => x.IsActive == true && x.IsDeleted == false)
                           .ToList();
        }
    }
}
