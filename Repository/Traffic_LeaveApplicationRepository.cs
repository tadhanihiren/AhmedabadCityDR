using AhmedabadCityDR.Interfaces;
using AhmedabadCityDR.Models.TableModels;
using AhmedabadCityDR.Models.ViewModels;
using Microsoft.Data.SqlClient;

namespace AhmedabadCityDR.Repository
{
    public class Traffic_LeaveApplicationRepository : GenericRepository<TblLeaveApplicationMaster>, ITraffic_LeaveApplication
    {
        private readonly AhmCityDrDbContext _context;

        public Traffic_LeaveApplicationRepository(AhmCityDrDbContext context) : base(context)
        {
            _context = context;
        }

        public IEnumerable<Traffic_LeaveApplicationViewModel> GetTrafficLeaveApplication(DateTime? fromDate, DateTime? toDate, bool? istraffic)
        {
            var pFromDate = new SqlParameter("@FromDate", fromDate);
            var pToDate = new SqlParameter("@ToDate", toDate);
            var pIsTraffic = new SqlParameter("@isTraffic", istraffic);

            return _context.Set<Traffic_LeaveApplicationViewModel>()
                           .FromSqlRaw("exec SP_tblLeaveApplication_SEL_Continue_ALL @FromDate, @ToDate, @isTraffic", pFromDate, pToDate, pIsTraffic)
                           .ToList();
        }
    }
}
