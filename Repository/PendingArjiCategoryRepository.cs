using AhmedabadCityDR.Interfaces;
using AhmedabadCityDR.Models.TableModels;

namespace AhmedabadCityDR.Repository
{
    public class PendingArjiCategoryRepository : GenericRepository<TblPendingArjiCategory>, IPendingArjiCategory
    {
        public PendingArjiCategoryRepository(AhmCityDrDbContext context) : base(context)
        {
        }
    }
}
