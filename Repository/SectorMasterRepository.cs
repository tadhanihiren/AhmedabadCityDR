using AhmedabadCityDR.Interfaces;
using AhmedabadCityDR.Models.TableModels;

namespace AhmedabadCityDR.Repository
{
    public class SectorMasterRepository : GenericRepository<TblSectorMaster>, ISectorMaster
    {
        public SectorMasterRepository(AhmCityDrDbContext context) : base(context)
        {
        }
    }
}