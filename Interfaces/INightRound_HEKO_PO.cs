using AhmedabadCityDR.Models.TableModels;
using AhmedabadCityDR.Models.ViewModels;

namespace AhmedabadCityDR.Interfaces
{
    public interface INightRound_HEKO_PO : IGenericRepository<TblNightRoundHekoPomaster>
    {
        IEnumerable<NightRound_HEKO_PO_ViewModel> GetNightRound_HEKO_PO (int roleId, int sectorId, int zoneId, int divisionId, int policeStationId, DateTime fromDate, DateTime toDate);
        public void DeleteById(int id);
    }
}
