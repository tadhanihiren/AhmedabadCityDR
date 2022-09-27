using AhmedabadCityDR.Models.TableModels;
using AhmedabadCityDR.Models.ViewModels;

namespace AhmedabadCityDR.Interfaces
{
    public interface INightEmployeeMaster : IGenericRepository<TblNightEmployeeMaster>
    {
        IEnumerable<NightEmployeeMasterViewModel> GetNightEmployee(int roleId, int sectorId, int zoneId, int divisionId, int policeStationId, DateTime fromDate, DateTime toDate);

        public void DeleteById(int id);
    }
}
