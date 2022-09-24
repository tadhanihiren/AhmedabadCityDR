using AhmedabadCityDR.Models.TableModels;
using AhmedabadCityDR.Models.ViewModels;

namespace AhmedabadCityDR.Interfaces
{
    public interface ILoginMaster : IGenericRepository<TblLoginMasterMobile>
    {
        IEnumerable<Login_UserNamePassWord_ViewModel> GetLoginUsers();
    }
}