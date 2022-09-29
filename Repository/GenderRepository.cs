using AhmedabadCityDR.Interfaces;
using AhmedabadCityDR.Models.TableModels;

namespace AhmedabadCityDR.Repository
{
    public class GenderRepository : GenericRepository<TblGenderMaster>, IGender
    {
        public GenderRepository(AhmCityDrDbContext context) : base(context)
        {
        }
    }
}
