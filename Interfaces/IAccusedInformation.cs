using AhmedabadCityDR.Models.TableModels;
using AhmedabadCityDR.Models.ViewModels;

namespace AhmedabadCityDR.Interfaces
{
    public interface IAccusedInformation : IGenericRepository<TblAccusedInformation>
    {
        IEnumerable<AccusedInformationViewModel> GetAccusedInformation(int roleId, int sectorId, int zoneId, int divisionId, int policeStationId, DateTime fromDate, DateTime toDate);
    }
}