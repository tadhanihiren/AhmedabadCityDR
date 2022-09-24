using AhmedabadCityDR.Interfaces;
using AhmedabadCityDR.Models.TableModels;

namespace AhmedabadCityDR.Repository
{
    public class PoliceStationMasterRepository : GenericRepository<TblPoliceStationMaster>, IPoliceStationMaster
    {
        public PoliceStationMasterRepository(AhmCityDrDbContext context) : base(context)
        {
        }
    }
}