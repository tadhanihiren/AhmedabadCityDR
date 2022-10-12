using AhmedabadCityDR.Interfaces;
using AhmedabadCityDR.Models.TableModels;
using AhmedabadCityDR.Models.ViewModels;
using Microsoft.Data.SqlClient;

namespace AhmedabadCityDR.Repository
{
    public class PendingArjiDetailRepository : GenericRepository<TblPendingArjiDetail>, IPendingArjiDetail
    {
        private readonly AhmCityDrDbContext _context;

        public PendingArjiDetailRepository(AhmCityDrDbContext context) : base(context)
        {
            _context = context;
        }

        public IEnumerable<PendingArjiDetailViewModel> CheckPendingArjiDetails(DateTime createdDate, int pendingArjiCategoryId)
        {
            var pCreatedDate = new SqlParameter("@CreatedDate", createdDate);
            var pPendingArjiCategoryId = new SqlParameter("@PendingArjiCategoryId", pendingArjiCategoryId);

            return _context.Set<PendingArjiDetailViewModel>()
                           .FromSqlRaw("exec USP_tblPendingArjiDetails_Category_SEL @CreatedDate, @PendingArjiCategoryId", pCreatedDate, pPendingArjiCategoryId)
                           .ToList();
        }

        public void DeleteById(int pendingArjiDetailId, bool isActive, bool isDelete, int modifiedUserId)
        {
            _context.Database.ExecuteSqlRaw($"sp_PendingArjiDetails_DEL {pendingArjiDetailId},{isActive},{isDelete},{modifiedUserId}");

        }

        public IEnumerable<PendingArjiDetailViewModel> GetPendingArjiDetails(int roleId, int sectorId, int zoneId, int divisionId, int policeStationId, DateTime fromDate, DateTime toDate)
        {
            var pRoleId = new SqlParameter("@RoleId", roleId);
            var pSectorId = new SqlParameter("@SectorId", sectorId);
            var pZoneId = new SqlParameter("@ZoneId", zoneId);
            var PDivisionId = new SqlParameter("@DivisionId", divisionId);
            var pPoliceStationId = new SqlParameter("@PoliceStationId", policeStationId);
            var pFromDate = new SqlParameter("@FromDate", fromDate);
            var pToDate = new SqlParameter("@ToDate", toDate);

            return _context.Set<PendingArjiDetailViewModel>()
                           .FromSqlRaw("exec USP_tblPendingArjiDetails_SEL @RoleId, @SectorId, @ZoneId, @DivisionId, @PoliceStationId, @FromDate, @ToDate", pRoleId, pSectorId, pZoneId, PDivisionId, pPoliceStationId, pFromDate, pToDate)
                           .ToList();
        }
    }
}
