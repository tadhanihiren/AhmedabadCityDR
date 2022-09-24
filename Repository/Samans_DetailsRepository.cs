using AhmedabadCityDR.Interfaces;
using AhmedabadCityDR.Models.TableModels;
using AhmedabadCityDR.Models.ViewModels;
using Microsoft.Data.SqlClient;

namespace AhmedabadCityDR.Repository
{
    public class Samans_DetailsRepository : GenericRepository<TblSamansDetail>, ISamans_Details
    {
        private readonly AhmCityDrDbContext _context;

        public Samans_DetailsRepository(AhmCityDrDbContext context) : base(context)
        {
            _context = context;
        }

        public IEnumerable<Samans_DetailsViewModel> GetSamans(int roleId, int sectorId, int zoneId, int divisionId, int policeStationId, DateTime fromDate, DateTime toDate, int categoryId)
        {
            var pRoleId = new SqlParameter("@RoleId", roleId);
            var pSectorId = new SqlParameter("@SectorId", sectorId);
            var pZoneId = new SqlParameter("@ZoneId", zoneId);
            var PDivisionId = new SqlParameter("@DivisionId", divisionId);
            var pPoliceStationId = new SqlParameter("@PoliceStationId", policeStationId);
            var pFromDate = new SqlParameter("@FromDate", fromDate);
            var pToDate = new SqlParameter("@ToDate", toDate);

            return _context.Set<Samans_DetailsViewModel>()
                           .FromSqlRaw("exec SP_View_Samans_details_SEL @RoleId, @SectorId, @ZoneId, @DivisionId, @PoliceStationId, @FromDate, @ToDate", pRoleId, pSectorId, pZoneId, PDivisionId, pPoliceStationId, pFromDate, pToDate)
                           .AsEnumerable()
                           .Where(x => x.CategoryId == categoryId)
                           .ToList();
        }
    }
}
