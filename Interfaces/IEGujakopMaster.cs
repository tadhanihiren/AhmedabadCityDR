using AhmedabadCityDR.Models.TableModels;
using AhmedabadCityDR.Models.ViewModels;

namespace AhmedabadCityDR.Interfaces
{
    public interface IEGujakopMaster : IGenericRepository<TblEGujakopMaster>
    {
        IEnumerable<EGujakopMasterViewModel> GetEGujakopMaster(int roleId, int sectorId, int zoneId, int divisionId, int policeStationId, DateTime fromDate, DateTime toDate);

        void DeleteById(int id);
    }
}
