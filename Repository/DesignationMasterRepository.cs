using AhmedabadCityDR.Interfaces;
using AhmedabadCityDR.Models.TableModels;

namespace AhmedabadCityDR.Repository
{
    public class DesignationMasterRepository : GenericRepository<TblDesignationName>, IDesignationMaster
    {
        public DesignationMasterRepository(AhmCityDrDbContext context) : base(context)
        {
        }
    }
}