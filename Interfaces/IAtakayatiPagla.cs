using AhmedabadCityDR.Models.TableModels;
using AhmedabadCityDR.Models.ViewModels;

namespace AhmedabadCityDR.Interfaces
{
    public interface IAtakayatiPagla : IGenericRepository<TblAtakayatiPagla>
    {
        IEnumerable<AtakayatiPaglaViewModel> GetAtakayatiPagla(int roleId, int sectorId, int zoneId, int divisionId, int policeStationId, DateTime fromDate, DateTime toDate);

        public void DeleteById(int id);
    }
}
