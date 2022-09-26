using AhmedabadCityDR.Models.TableModels;
using AhmedabadCityDR.Models.ViewModels;

namespace AhmedabadCityDR.Interfaces
{
    public interface IPart1_5Crime : IGenericRepository<TblPart1_5Crime>
    {
        Part1_5CrimeViewModel FindByPoliceStaionNumber(int roleId, int sectorId, int zoneId, int divisionId, int policeStationId, int categoryId, string policeStationNumber);

        IEnumerable<Part1_5CrimeViewModel> GetPart1_5Crime(int roleId, int sectorId, int zoneId, int divisionId, int policeStationId, DateTime fromDate, DateTime toDate, int categoryId);

        void DeleteById(int id);
    }
}