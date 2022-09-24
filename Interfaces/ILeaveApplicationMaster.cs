using AhmedabadCityDR.Models.TableModels;
using AhmedabadCityDR.Models.ViewModels;

namespace AhmedabadCityDR.Interfaces
{
    public interface ILeaveApplicationMaster : IGenericRepository<TblLeaveApplicationMaster>
    {
        IEnumerable<LeaveApplicationMasterViewModel> GetLeaveApplication(DateTime? fromDate, DateTime? toDate, bool? istraffic);
    }
}
