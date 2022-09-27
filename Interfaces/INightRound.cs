using AhmedabadCityDR.Models.TableModels;
using AhmedabadCityDR.Models.ViewModels;

namespace AhmedabadCityDR.Interfaces
{
    public interface INightRound : IGenericRepository<TblNightRound>
    {
        IEnumerable<NightRoundViewModel> GetNightRound(int roleId, int sectorId, int zoneId, int divisionId, int policeStationId, DateTime fromDate, DateTime toDate);
        public void DeleteById(int id);
    }
}
