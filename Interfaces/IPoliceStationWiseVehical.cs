using AhmedabadCityDR.Models.TableModels;
using AhmedabadCityDR.Models.ViewModels;

namespace AhmedabadCityDR.Interfaces
{
    public interface IPoliceStationWiseVehical : IGenericRepository<TblPoliceStationWiseVehical>
    {
        IEnumerable<PoliceStationWiseVehicalViewModel> GetPoliceStationWiseVehical(int roleId, int sectorId, int zoneId, int divisionId, int policeStationId, DateTime fromDate, DateTime toDate);

        void DeleteById(int id);
    }
}
