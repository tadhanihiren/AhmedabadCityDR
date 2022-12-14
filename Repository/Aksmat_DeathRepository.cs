using AhmedabadCityDR.Interfaces;
using AhmedabadCityDR.Models.TableModels;
using AhmedabadCityDR.Models.ViewModels;
using Microsoft.Data.SqlClient;

namespace AhmedabadCityDR.Repository
{
    public class Aksmat_DeathRepository : GenericRepository<TblPart1_5Crime>, IAksmat_Death
    {
        private readonly AhmCityDrDbContext _context;

        public Aksmat_DeathRepository(AhmCityDrDbContext context) : base(context)
        {
            _context = context;
        }
        public void DeleteById(int id)
        {
            _context.Database.ExecuteSqlRaw($"SP_tblPart1_5_Crimes_DEL {id}");
        }

        /// <summary>
        /// Gets Part Aksmat Death Crimes
        /// /// </summary>
        /// <param name="roleId">Role ID</param>
        /// <param name="sectorId">Sector ID</param>
        /// <param name="zoneId">Zone ID</param>
        /// <param name="divisionId">Division ID</param>
        /// <param name="policeStationId">Police station ID</param>
        /// <param name="fromDate">From date</param>
        /// <param name="toDate">To date</param>
        /// <param name="categoryId">Category id</param>
        /// <returns>Returns list of Part1_5CrimeViewModel</returns>
        public IEnumerable<Aksmat_DeathViewModel> GetAksmat_Death(int roleId, int sectorId, int zoneId, int divisionId, int policeStationId, DateTime fromDate, DateTime toDate, int categoryId)
        {
            var pRoleId = new SqlParameter("@RoleId", roleId);
            var pSectorId = new SqlParameter("@SectorId", sectorId);
            var pZoneId = new SqlParameter("@ZoneId", zoneId);
            var PDivisionId = new SqlParameter("@DivisionId", divisionId);
            var pPoliceStationId = new SqlParameter("@PoliceStationId", policeStationId);
            var pFromDate = new SqlParameter("@FromDate", fromDate);
            var pToDate = new SqlParameter("@ToDate", toDate);
            var pCategoryId = new SqlParameter("@CategoryId", categoryId);

            return _context.Set<Aksmat_DeathViewModel>()
                           .FromSqlRaw("exec USP_tblpart1_5_crimes_sel @RoleId, @SectorId, @ZoneId, @DivisionId, @PoliceStationId, @FromDate, @ToDate, @CategoryId", pRoleId, pSectorId, pZoneId, PDivisionId, pPoliceStationId, pFromDate, pToDate, pCategoryId)
                           .ToList();
        }

        public Aksmat_DeathViewModel FindByPoliceStaionNumber(int roleId, int sectorId, int zoneId, int divisionId, int policeStationId, int categoryId, string policeStationNumber)
        {
            var pRoleId = new SqlParameter("@RoleId", roleId);
            var pSectorId = new SqlParameter("@SectorId", sectorId);
            var pZoneId = new SqlParameter("@ZoneId", zoneId);
            var PDivisionId = new SqlParameter("@DivisionId", divisionId);
            var pPoliceStationId = new SqlParameter("@PoliceStationId", policeStationId);
            var pCategoryId = new SqlParameter("@CategoryId", categoryId);
            var pPoliceStationNumber = new SqlParameter("@GunhaRegisterNumber", policeStationNumber);

            return _context.Set<Aksmat_DeathViewModel>()
                           .FromSqlRaw("exec Usp_tblpart1_5_crimes_sel_check @RoleId, @SectorId, @ZoneId, @DivisionId, @PoliceStationId, @CategoryId, @GunhaRegisterNumber", pRoleId, pSectorId, pZoneId, PDivisionId, pPoliceStationId, pCategoryId, pPoliceStationNumber)
                           .AsEnumerable()
                           .FirstOrDefault();
        }
    }
}