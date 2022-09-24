using AhmedabadCityDR.Models.TableModels;
using AhmedabadCityDR.Models.ViewModels;

namespace AhmedabadCityDR.Interfaces
{
    public interface ISamans_Details : IGenericRepository<TblSamansDetail>
    {
        IEnumerable<Samans_DetailsViewModel> GetSamans(int roleId,
                                                       int sectorId,
                                                       int zoneId,
                                                       int divisionId,
                                                       int policeStationId,
                                                       DateTime fromDate,
                                                       DateTime toDate,
                                                       int categoryId);
    }
}
