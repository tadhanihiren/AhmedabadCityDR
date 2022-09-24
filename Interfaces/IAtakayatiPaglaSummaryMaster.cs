using AhmedabadCityDR.Models.TableModels;
using AhmedabadCityDR.Models.ViewModels;

namespace AhmedabadCityDR.Interfaces
{
    public interface IAtakayatiPaglaSummaryMaster : IGenericRepository<TblAtakayatiPaglaSummary>
    {
        IEnumerable<AtakayatiPaglaSummaryViewModel> GetAtakayatiPaglaSummary(
            int roleId,
            int sectorId,
            int zoneId,
            int divisionId,
            int policeStationId,
            DateTime fromDate,
            DateTime toDate);
    }
}