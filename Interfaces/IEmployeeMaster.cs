using AhmedabadCityDR.Models.TableModels;
using AhmedabadCityDR.Models.ViewModels;

namespace AhmedabadCityDR.Interfaces
{
    /// <summary>
    /// Contains employee related data.
    /// </summary>
    public interface IEmployeeMaster : IGenericRepository<TblEmployeeMaster>
    {
        public Task<ClaimUser> AuthenticateUser(string userName, string Password);

        IEnumerable<EmployeeMasterViewModel> GetEmployees(int roleId, int sectorId, int zoneId, int divisionId, int policeStationId, DateTime fromDate, DateTime toDate);

        void UpdateInternalTransffer(int employeeId,int transfferPoliceStationId, int designationId,string contactNumber);
    }
}