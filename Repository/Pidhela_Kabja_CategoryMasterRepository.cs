using AhmedabadCityDR.Interfaces;
using AhmedabadCityDR.Models.TableModels;

namespace AhmedabadCityDR.Repository
{
    public class Pidhela_Kabja_CategoryMasterRepository : GenericRepository<TblPidhelaKabjaCategoryMaster>, IPidhela_Kabja_CategoryMaster
    {
        public Pidhela_Kabja_CategoryMasterRepository(AhmCityDrDbContext context) : base(context)
        {
        }
    }
}