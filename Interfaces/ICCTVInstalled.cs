using AhmedabadCityDR.Models.TableModels;
using AhmedabadCityDR.Models.ViewModels;

namespace AhmedabadCityDR.Interfaces
{
    public interface ICCTVInstalled : IGenericRepository<TblCctvinstalled>
    {
        IEnumerable<CCTVInstalledViewModel> GetCCTVInstalled(int roleId, int sectorId, int zoneId, int divisionId, int policeStationId, DateTime fromDate, DateTime toDate);
        IEnumerable<CCTVInstalledViewModel> GetAllCCTVInstalled();
        void DeleteById(int id);
    }
}
