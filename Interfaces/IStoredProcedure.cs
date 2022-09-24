using AhmedabadCityDR.Models.ViewModels;

namespace AhmedabadCityDR.Interfaces
{
    public interface IStoredProcedure
    {
        Task<DashboardCityViewModel> GetCityDashboardCountAsync(int roleId, int sectorId, int zoneId, int divisionId, int policeStationId, DateTime fromDate, DateTime toDate);

        Task<DashboardTrafficViewModel> GetTrafficDashboardCountAsync(int roleId, int sectorId, int zoneId, int divisionId, int policeStationId, DateTime fromDate, DateTime toDate);

        IEnumerable<City_Crime_DetailsViewModel> GetDetailsOfCrimes(int roleId, int sectorId, int zoneId, int divisionId, int policeStationId, DateTime fromDate, DateTime toDate);
    }
}