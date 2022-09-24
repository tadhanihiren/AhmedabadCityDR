using AhmedabadCityDR.Models.TableModels;
using AhmedabadCityDR.Models.ViewModels;

namespace AhmedabadCityDR.Interfaces
{
    public interface IForm3A : IGenericRepository<TblForm3A>
    {
        IEnumerable<Form3AViewModel> GetForm3A(int roleId, int sectorId, int zoneId, int divisionId, int policeStationId, DateTime fromDate, DateTime toDate);
    }
}