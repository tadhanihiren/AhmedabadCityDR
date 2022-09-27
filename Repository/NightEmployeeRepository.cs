using AhmedabadCityDR.Interfaces;
using AhmedabadCityDR.Models.TableModels;

namespace AhmedabadCityDR.Repository
{
    public class NightEmployeeRepository : GenericRepository<TblNightEmployeeMaster>, INightEmployeeMaster
    {
        private readonly AhmCityDrDbContext _context;

        public NightEmployeeRepository(AhmCityDrDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
