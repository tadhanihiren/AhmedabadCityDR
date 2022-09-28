using AhmedabadCityDR.Interfaces;
using AhmedabadCityDR.Models.TableModels;
using AhmedabadCityDR.Models.ViewModels;
using Microsoft.Data.SqlClient;

namespace AhmedabadCityDR.Repository
{
    public class DcbPolicestationMasterRepository : GenericRepository<TblDcbPolicestationMaster>, IDcbPolicestationMaster
    {
        private readonly AhmCityDrDbContext _context;

        public DcbPolicestationMasterRepository(AhmCityDrDbContext context) : base(context)
        {
            _context = context;
        }

        public void DeleteById(int id)
        {
            _context.Database.ExecuteSqlRaw($"SP_tblDCB_PolicestationMaster_DEL {id}");
        }
    }
}
