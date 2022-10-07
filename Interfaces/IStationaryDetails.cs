using AhmedabadCityDR.Models.TableModels;
using AhmedabadCityDR.Models.ViewModels;

namespace AhmedabadCityDR.Interfaces
{
    public interface IStationaryDetails : IGenericRepository<TblStationery>
    {
        public void DeleteById(int id);

        IEnumerable<StationaryMasterViewModel> GetStationary(int roleId, int sectorId, int zoneId, int divisionId, int policeStationId, DateTime fromDate, DateTime toDate);
    }
}
