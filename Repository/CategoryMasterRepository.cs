using AhmedabadCityDR.Interfaces;
using AhmedabadCityDR.Models.TableModels;

namespace AhmedabadCityDR.Repository
{
    public class CategoryMasterRepository : GenericRepository<TblCategoryMaster>, ICategoryMaster
    {
        public CategoryMasterRepository(AhmCityDrDbContext context) : base(context)
        {
        }
    }
}