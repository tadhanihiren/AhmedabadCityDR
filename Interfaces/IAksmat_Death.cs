using AhmedabadCityDR.Models.TableModels;
using AhmedabadCityDR.Models.ViewModels;

namespace AhmedabadCityDR.Interfaces
{
    public interface IAksmat_Death : IGenericRepository<TblPart1_5Crime>
    {
        Aksmat_DeathViewModel FindByPoliceStaionNumber(int roleId, int sectorId, int zoneId, int divisionId, int policeStationId, int categoryId, string policeStationNumber);

        IEnumerable<Aksmat_DeathViewModel> GetAksmat_Death(int roleId, int sectorId, int zoneId, int divisionId, int policeStationId, DateTime fromDate, DateTime toDate, int categoryId);

        void DeleteById(int id);
    }
}