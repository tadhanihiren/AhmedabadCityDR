using AhmedabadCityDR.Models.TableModels;
using AhmedabadCityDR.Models.ViewModels;

namespace AhmedabadCityDR.Interfaces
{
    public interface IPendingArjiDetail : IGenericRepository<TblPendingArjiDetail>
    {
        IEnumerable<PendingArjiDetailViewModel> GetPendingArjiDetails(int roleId, int sectorId, int zoneId, int divisionId, int policeStationId, DateTime fromDate, DateTime toDate);

        IEnumerable<PendingArjiDetailViewModel> CheckPendingArjiDetails(DateTime createdDate, int pendingArjiCategoryId);

        void DeleteById(int pendingArjiDetailId, bool isActive, bool isDelete, int modifiedUserId);
    }
}
