using AhmedabadCityDR.Interfaces;
using AhmedabadCityDR.Models.TableModels;

namespace AhmedabadCityDR.Repository
{
    public class ZoneMasterRepository : GenericRepository<TblZoneMaster>, IZoneMaster
    {
        public ZoneMasterRepository(AhmCityDrDbContext context) : base(context)
        {
        }
    }
}