using AhmedabadCityDR.Interfaces;
using AhmedabadCityDR.Models.TableModels;

namespace AhmedabadCityDR.Repository
{
    public class DivisionMasterRepository : GenericRepository<TblDivisionMaster>, IDivisionMaster
    {
        public DivisionMasterRepository(AhmCityDrDbContext context) : base(context)
        {
        }
    }
}