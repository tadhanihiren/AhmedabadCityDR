using AhmedabadCityDR.Interfaces;
using AhmedabadCityDR.Models.TableModels;

namespace AhmedabadCityDR.Repository
{
    public class GenericRepository : GenericRepository<TblGenderMaster>, IGender
    {
        public GenericRepository(AhmCityDrDbContext context) : base(context)
        {
        }
    }
}
