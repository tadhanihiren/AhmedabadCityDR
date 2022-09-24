using AhmedabadCityDR.Interfaces;
using AhmedabadCityDR.Models.TableModels;

namespace AhmedabadCityDR.Repository
{
    public class DesignationNameRepository : GenericRepository<TblDesignationName>, IDesignationName
    {
        public DesignationNameRepository(AhmCityDrDbContext context) : base(context)
        {
        }
    }
}
