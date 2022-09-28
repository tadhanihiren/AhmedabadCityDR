using AhmedabadCityDR.Models.TableModels;
using AhmedabadCityDR.Models.ViewModels;

namespace AhmedabadCityDR.Interfaces
{
    public interface ICRPC41Master : IGenericRepository<TblCrpc41master>
    {
        IEnumerable<CRPC41MasterViewModel> GetCRPC41(int roleId, int sectorId, int zoneId, int divisionId, int policeStationId, DateTime fromDate, DateTime toDate);

        void DeleteById(int id);
    }
}
