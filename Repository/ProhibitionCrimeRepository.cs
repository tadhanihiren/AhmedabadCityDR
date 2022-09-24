using AhmedabadCityDR.Interfaces;
using AhmedabadCityDR.Models.TableModels;

namespace AhmedabadCityDR.Repository
{
    public class ProhibitionCrimeRepository : GenericRepository<TblProhibitionCrimeMaster>, IProhibitionCrime
    {
        public ProhibitionCrimeRepository(AhmCityDrDbContext context) : base(context)
        {
        }
    }
}
