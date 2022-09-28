using AhmedabadCityDR.Models.TableModels;
using AhmedabadCityDR.Models.ViewModels;

namespace AhmedabadCityDR.Interfaces
{
    public interface IDcbPolicestationMaster : IGenericRepository<TblDcbPolicestationMaster>
    {
        void DeleteById(int id);
    }
}
