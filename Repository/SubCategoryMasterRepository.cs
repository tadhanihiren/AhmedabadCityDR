using AhmedabadCityDR.Interfaces;
using AhmedabadCityDR.Models.TableModels;

namespace AhmedabadCityDR.Repository
{
    public class SubCategoryMasterRepository : GenericRepository<TblSubCategoryMaster>, ISubCategoryMaster
    {
        public SubCategoryMasterRepository(AhmCityDrDbContext context) : base(context)
        {
        }
    }
}