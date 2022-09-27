using AhmedabadCityDR.Interfaces;
using AhmedabadCityDR.Models.TableModels;

namespace AhmedabadCityDR.Repository
{
    public class NightRoundRepository : GenericRepository<TblNightRound>, INightRound
    {
        private readonly AhmCityDrDbContext _context;

        public NightRoundRepository(AhmCityDrDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
