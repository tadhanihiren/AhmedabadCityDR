using AhmedabadCityDR.Models.TableModels;
using AhmedabadCityDR.Models.ViewModels;

namespace AhmedabadCityDR.Interfaces
{
    public interface IProhibition : IGenericRepository<TblPart1_5Crime>
    {
        ProhibitionViewModel FindByPoliceStaionNumber(int roleId, int sectorId, int zoneId, int divisionId, int policeStationId, int categoryId, string policeStationNumber);

        IEnumerable<ProhibitionViewModel> GetProhibitionCrime(int roleId, int sectorId, int zoneId, int divisionId, int policeStationId, DateTime fromDate, DateTime toDate, int categoryId);
        void DeleteById(int id);
    }
}