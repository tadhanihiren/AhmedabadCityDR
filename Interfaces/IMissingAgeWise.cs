using AhmedabadCityDR.Models.TableModels;
using AhmedabadCityDR.Models.ViewModels;

namespace AhmedabadCityDR.Interfaces
{
    public interface IMissingAgeWise : IGenericRepository<TblHistoryMissingAgeWiseChild>
    {
        IEnumerable<HistoryMissingagewiseViewModel> GetMissingAgeWise(int roleId, int sectorId, int zoneId, int divisionId, int policeStationId, DateTime fromDate, DateTime toDate);

    }
}
