using AhmedabadCityDR.Interfaces;
using AhmedabadCityDR.Models.TableModels;

namespace AhmedabadCityDR.Repository
{
    public class LeaveTypeMasterRepository : GenericRepository<TblLeaveTypeMaster>, ILeaveTypeMaster
    {
        public LeaveTypeMasterRepository(AhmCityDrDbContext context) : base(context)
        {
        }
    }
}
