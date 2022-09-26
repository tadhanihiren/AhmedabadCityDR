using AhmedabadCityDR.Models.TableModels;
using AhmedabadCityDR.Models.ViewModels;

namespace AhmedabadCityDR.Interfaces
{
    public interface IProhibitionRaidCase : IGenericRepository<TblProhibitionRaidCase>
    {
        ProhibitionRaidCaseViewModel FindByPoliceStaionNumber(int roleId, int sectorId, int zoneId, int divisionId, int policeStationId, int categoryId, string policeStationNumber);

        IEnumerable<ProhibitionRaidCaseViewModel> GetProhibitionRaidCase(int roleId, int sectorId, int zoneId, int divisionId, int policeStationId, DateTime fromDate, DateTime toDate);

        public void DeleteById(int id);
    }
}
