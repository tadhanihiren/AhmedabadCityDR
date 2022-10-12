using AhmedabadCityDR.Interfaces;
using AhmedabadCityDR.Models.TableModels;

namespace AhmedabadCityDR.Repository
{
    public class kacheriMasterRepository : GenericRepository<TblkacheriMaster>,IKacheriMaster
    {
        public kacheriMasterRepository(AhmCityDrDbContext context) : base(context)
        {
        }
    }
}
