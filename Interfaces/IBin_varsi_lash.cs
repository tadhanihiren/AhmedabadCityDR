using AhmedabadCityDR.Models.TableModels;
using AhmedabadCityDR.Models.ViewModels;

namespace AhmedabadCityDR.Interfaces
{
    public interface IBin_varsi_lash : IGenericRepository<TblPart1_5Crime>
    {
        Bin_varsi_lashViewModel FindByPoliceStaionNumber(int roleId, int sectorId, int zoneId, int divisionId, int policeStationId, int categoryId, string policeStationNumber);

        IEnumerable<Bin_varsi_lashViewModel> GetBin_varsi_lash(int roleId, int sectorId, int zoneId, int divisionId, int policeStationId, DateTime fromDate, DateTime toDate, int categoryId);
    }
}