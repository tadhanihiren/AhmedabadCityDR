using AhmedabadCityDR.Models.TableModels;
using AhmedabadCityDR.Models.ViewModels;

namespace AhmedabadCityDR.Interfaces
{
    public interface ITraffic_LeaveApplication : IGenericRepository<TblLeaveApplicationMaster>
    {
        IEnumerable<Traffic_LeaveApplicationViewModel> GetTrafficLeaveApplication(DateTime? fromDate, DateTime? toDate, bool? istraffic);
    }
}
