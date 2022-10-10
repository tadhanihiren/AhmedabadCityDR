using AhmedabadCityDR.Models.TableModels;
using AhmedabadCityDR.Models.ViewModels;

namespace AhmedabadCityDR.Interfaces
{
    public interface ICRPC41CAmendmentMater : IGenericRepository<TblCrpc41camendmentMater>
    {
        IEnumerable<CRPC41CAmendmentMaterViewModel> GetCRPC41C(int roleId, int sectorId, int zoneId, int divisionId, int policeStationId, DateTime fromDate, DateTime toDate);

        void DeleteById(int id);
    }
}
