using AhmedabadCityDR.Models.TableModels;
using AhmedabadCityDR.Models.ViewModels;

namespace AhmedabadCityDR.Interfaces
{
    public interface IHistoryOfCurrentYearMissing : IGenericRepository<TblhistroryOfCurrentMissing>
    {
        IEnumerable<HistoryCurrentMissingViewModel> GetHistoryCurrentMissing(int roleId, int sectorId, int zoneId, int divisionId, int policeStationId, DateTime fromDate, DateTime toDate);
    }
}
