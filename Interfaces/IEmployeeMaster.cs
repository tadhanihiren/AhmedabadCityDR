using AhmedabadCityDR.Models.TableModels;

namespace AhmedabadCityDR.Interfaces
{
    /// <summary>
    /// Contains employee related data.
    /// </summary>
    public interface IEmployeeMaster : IGenericRepository<TblEmployeeMaster>
    {
        public Task<ClaimUser> AuthenticateUser(string userName, string Password);
    }
}