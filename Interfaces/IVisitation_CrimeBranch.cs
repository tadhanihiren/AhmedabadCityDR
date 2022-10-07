using AhmedabadCityDR.Models.TableModels;
using AhmedabadCityDR.Models.ViewModels;

namespace AhmedabadCityDR.Interfaces
{
    public interface IVisitation_CrimeBranch : IGenericRepository<TblVisitationCrimeBranch>
    {
        IEnumerable<Visitation_CrimeBranchViewModel> GetVisitationCrimeBranch(int roleId, int sectorId, int zoneId, int divisionId, int policeStationId, DateTime fromDate, DateTime toDate);
        public void DeleteById(int id);
    }
}
