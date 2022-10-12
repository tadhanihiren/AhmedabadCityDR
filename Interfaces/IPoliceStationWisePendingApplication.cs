using AhmedabadCityDR.Models.TableModels;
using AhmedabadCityDR.Models.ViewModels;

namespace AhmedabadCityDR.Interfaces
{
    public interface IPoliceStationWisePendingApplication : IGenericRepository<TblPoliceStationWisePendingApplication>
    {
        IEnumerable<PoliceStationWisePendingApplicationViewModel> GetPoliceStationWisePendingApplication(int roleId, int sectorId, int zoneId, int divisionId, int policeStationId, DateTime fromDate, DateTime toDate);
        void DeleteById(int id);

    }
}
