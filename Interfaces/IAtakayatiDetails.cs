using AhmedabadCityDR.Models.TableModels;
using AhmedabadCityDR.Models.ViewModels;

namespace AhmedabadCityDR.Interfaces
{
    public interface IAtakayatiDetails : IGenericRepository<TblAtakayatidetail>
    {
         IEnumerable<AtakayatiDetailsViewModel> GetAtakayatiDetails(int roleId, int sectorId, int zoneId, int divisionId, int policeStationId, DateTime fromDate, DateTime toDate);

    }
}
