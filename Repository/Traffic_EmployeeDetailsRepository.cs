using AhmedabadCityDR.Interfaces;
using AhmedabadCityDR.Models.TableModels;
using AhmedabadCityDR.Models.ViewModels;
using Microsoft.Data.SqlClient;

namespace AhmedabadCityDR.Repository
{
    public class Traffic_EmployeeDetailsRepository : GenericRepository<TblEmployeeMaster>, ITrafficEmployeeDetails
    {
        private readonly AhmCityDrDbContext _context;

        public Traffic_EmployeeDetailsRepository(AhmCityDrDbContext context) : base(context)
        {
            _context = context;
        }
        public void DeleteById(int id)
        {
            _context.Database.ExecuteSqlRaw($"SP_tblEmployeeMaster_DEL {id}");
        }

        public IEnumerable<TrafficEmployeeViewModel> GetTrafficEmployees(int roleId, int sectorId, int zoneId, int divisionId, int policeStationId, DateTime fromDate, DateTime toDate)
        {
            var pRoleId = new SqlParameter("@RoleId", roleId);
            var pSectorId = new SqlParameter("@SectorId", sectorId);
            var pZoneId = new SqlParameter("@ZoneId", zoneId);
            var PDivisionId = new SqlParameter("@DivisionId", divisionId);
            var pPoliceStationId = new SqlParameter("@PoliceStationId", policeStationId);
            var pFromDate = new SqlParameter("@FromDate", fromDate);
            var pToDate = new SqlParameter("@ToDate", toDate);

            return _context.Set<TrafficEmployeeViewModel>()
                           .FromSqlRaw("exec USP_View_Employee_Master_SEL @RoleId, @SectorId, @ZoneId, @DivisionId, @PoliceStationId, @FromDate, @ToDate", pRoleId, pSectorId, pZoneId, PDivisionId, pPoliceStationId, pFromDate, pToDate)
                           .ToList();
        }
    }
}
