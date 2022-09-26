using AhmedabadCityDR.Models.TableModels;
using AhmedabadCityDR.Models.ViewModels;

namespace AhmedabadCityDR.Interfaces
{
    public interface IProhibitionCrime : IGenericRepository<TblProhibitionCrimeMaster>
    {
        IEnumerable<ProhibitionCrimeViewModel> GetProhibitionCrimes(int roleId, int sectorId, int zoneId, int divisionId, int policeStationId, DateTime fromDate, DateTime toDate);

        public void DeleteById(int id);
    }
}
