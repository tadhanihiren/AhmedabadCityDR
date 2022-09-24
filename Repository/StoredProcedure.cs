using AhmedabadCityDR.Interfaces;
using AhmedabadCityDR.Models.ViewModels;
using Microsoft.Data.SqlClient;

namespace AhmedabadCityDR.Repository
{
    public class StoredProcedure : IStoredProcedure
    {
        #region Private Members

        /// <summary>
        /// Context.
        /// </summary>
        private readonly AhmCityDrDbContext _context;

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context">AhmCityDrDbContext</param>
        public StoredProcedure(AhmCityDrDbContext context)
        {
            _context = context;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Gets count for city dashbord.
        /// </summary>
        /// <param name="roleId">Role ID</param>
        /// <param name="sectorId">Sector ID</param>
        /// <param name="zoneId">Zone ID</param>
        /// <param name="divisionId">Division ID</param>
        /// <param name="policeStationId">Police station ID</param>
        /// <param name="fromDate">From date</param>
        /// <param name="toDate">To date</param>
        /// <returns>Returns DashboardCityViewModel object</returns>
        async Task<DashboardCityViewModel> IStoredProcedure.GetCityDashboardCountAsync(int roleId, int sectorId, int zoneId, int divisionId, int policeStationId, DateTime fromDate, DateTime toDate)
        {
            var pRoleId = new SqlParameter("@RoleId", roleId);
            var pSectorId = new SqlParameter("@SectorId", sectorId);
            var pZoneId = new SqlParameter("@ZoneId", zoneId);
            var PDivisionId = new SqlParameter("@DivisionId", divisionId);
            var pPoliceStationId = new SqlParameter("@PoliceStationId", policeStationId);
            var pFromDate = new SqlParameter("@FromDate", fromDate);
            var pToDate = new SqlParameter("@ToDate", toDate);

            var cityCommonCount = await _context.Set<DashboardCommonCityCount>().FromSqlRaw("exec USP_AhmedabadCity_Dashboard_Common_Count @RoleId, @SectorId, @ZoneId, @DivisionId, @PoliceStationId, @FromDate, @ToDate", pRoleId, pSectorId, pZoneId, PDivisionId, pPoliceStationId, pFromDate, pToDate).ToListAsync();

            var crimeCountForTodayAndLastDay = await _context.Set<CrimeCountByDay>().FromSqlRaw("exec USP_Atkayatipagala_Today_Lastday_Crime_Count @RoleId, @SectorId, @ZoneId, @DivisionId, @PoliceStationId, @FromDate, @ToDate", pRoleId, pSectorId, pZoneId, PDivisionId, pPoliceStationId, pFromDate, pToDate).ToListAsync();

            #region Leave Application Count

            var pIsTraffic = new SqlParameter("@Istraffic", false);
            var leaveApplicationCount = await _context.Set<DashboardCitySingalCount>().FromSqlRaw("exec USP_LeaveApplication_Count @RoleId, @SectorId, @ZoneId, @DivisionId, @PoliceStationId, @FromDate, @ToDate, @Istraffic", pRoleId, pSectorId, pZoneId, PDivisionId, pPoliceStationId, pFromDate, pToDate, pIsTraffic).ToListAsync();

            #endregion

            SqlParameter pCategoryId;

            #region Part 1 to 5 Crimes Count

            pCategoryId = new SqlParameter("@CategoryId", 1);
            var Part1_5CrimesCount_Cat1 = await _context.Set<DashboardCitySingalCount>().FromSqlRaw("exec USP_Part1_5_Crimes_Count @RoleId, @SectorId, @ZoneId, @DivisionId, @PoliceStationId, @FromDate, @ToDate, @CategoryId", pRoleId, pSectorId, pZoneId, PDivisionId, pPoliceStationId, pFromDate, pToDate, pCategoryId).ToListAsync();
            pCategoryId = new SqlParameter("@CategoryId", 2);
            var Part1_5CrimesCount_Cat2 = await _context.Set<DashboardCitySingalCount>().FromSqlRaw("exec USP_Part1_5_Crimes_Count @RoleId, @SectorId, @ZoneId, @DivisionId, @PoliceStationId, @FromDate, @ToDate, @CategoryId", pRoleId, pSectorId, pZoneId, PDivisionId, pPoliceStationId, pFromDate, pToDate, pCategoryId).ToListAsync();
            pCategoryId = new SqlParameter("@CategoryId", 22);
            var Part1_5CrimesCount_Cat22 = await _context.Set<DashboardCitySingalCount>().FromSqlRaw("exec USP_Part1_5_Crimes_Count @RoleId, @SectorId, @ZoneId, @DivisionId, @PoliceStationId, @FromDate, @ToDate, @CategoryId", pRoleId, pSectorId, pZoneId, PDivisionId, pPoliceStationId, pFromDate, pToDate, pCategoryId).ToListAsync();
            pCategoryId = new SqlParameter("@CategoryId", 35);
            var Part1_5CrimesCount_Cat35 = await _context.Set<DashboardCitySingalCount>().FromSqlRaw("exec USP_Part1_5_Crimes_Count @RoleId, @SectorId, @ZoneId, @DivisionId, @PoliceStationId, @FromDate, @ToDate, @CategoryId", pRoleId, pSectorId, pZoneId, PDivisionId, pPoliceStationId, pFromDate, pToDate, pCategoryId).ToListAsync();

            #endregion

            #region Samans details Count

            pCategoryId = new SqlParameter("@CategoryId", 26);
            var SamansdetailsCount_Cat26 = await _context.Set<DashboardCitySingalCount>().FromSqlRaw("exec USP_View_Samans_Details_Count @RoleId, @SectorId, @ZoneId, @DivisionId, @PoliceStationId, @FromDate, @ToDate, @CategoryId", pRoleId, pSectorId, pZoneId, PDivisionId, pPoliceStationId, pFromDate, pToDate, pCategoryId).ToListAsync();
            pCategoryId = new SqlParameter("@CategoryId", 27);
            var SamansdetailsCount_Cat27 = await _context.Set<DashboardCitySingalCount>().FromSqlRaw("exec USP_View_Samans_Details_Count @RoleId, @SectorId, @ZoneId, @DivisionId, @PoliceStationId, @FromDate, @ToDate, @CategoryId", pRoleId, pSectorId, pZoneId, PDivisionId, pPoliceStationId, pFromDate, pToDate, pCategoryId).ToListAsync();
            pCategoryId = new SqlParameter("@CategoryId", 28);
            var SamansdetailsCount_Cat28 = await _context.Set<DashboardCitySingalCount>().FromSqlRaw("exec USP_View_Samans_Details_Count @RoleId, @SectorId, @ZoneId, @DivisionId, @PoliceStationId, @FromDate, @ToDate, @CategoryId", pRoleId, pSectorId, pZoneId, PDivisionId, pPoliceStationId, pFromDate, pToDate, pCategoryId).ToListAsync();
            pCategoryId = new SqlParameter("@CategoryId", 29);
            var SamansdetailsCount_Cat29 = await _context.Set<DashboardCitySingalCount>().FromSqlRaw("exec USP_View_Samans_Details_Count @RoleId, @SectorId, @ZoneId, @DivisionId, @PoliceStationId, @FromDate, @ToDate, @CategoryId", pRoleId, pSectorId, pZoneId, PDivisionId, pPoliceStationId, pFromDate, pToDate, pCategoryId).ToListAsync();
            pCategoryId = new SqlParameter("@CategoryId", 30);
            var SamansdetailsCount_Cat30 = await _context.Set<DashboardCitySingalCount>().FromSqlRaw("exec USP_View_Samans_Details_Count @RoleId, @SectorId, @ZoneId, @DivisionId, @PoliceStationId, @FromDate, @ToDate, @CategoryId", pRoleId, pSectorId, pZoneId, PDivisionId, pPoliceStationId, pFromDate, pToDate, pCategoryId).ToListAsync();

            #endregion

            var cityAllCount = new DashboardCityViewModel
            {
                Manjur_Mahekam = cityCommonCount.Where(X => X.Name.Contains("Manjur_Mahekam")).Select(x => x.Counts).FirstOrDefault(),
                Hajar_Mahekam = cityCommonCount.Where(X => X.Name.Contains("Manjur_Mahekam")).Select(x => x.Counts).FirstOrDefault(),
                Gum_thayel_balako_Stree_Purush = cityCommonCount.Where(X => X.Name.Contains("Gum_thayel_balako_Stree_Purush")).Select(x => x.Counts).FirstOrDefault(),
                Atkayati_paglani_mahiti = cityCommonCount.Where(X => X.Name.Contains("Atkayati_paglani_mahiti")).Select(x => x.Counts).FirstOrDefault(),
                Adhikari_shri_ni_night_round_mahiti = cityCommonCount.Where(X => X.Name.Contains("Adhikari_shri_ni_night_round_mahiti")).Select(x => x.Counts).FirstOrDefault(),
                Nashata_farta_aropi_ni_mahiti = cityCommonCount.Where(X => X.Name.Contains("Nashata_farta_aropi_ni_mahiti")).Select(x => x.Counts).FirstOrDefault(),
                Bandobast_ni_vigat_patrak = cityCommonCount.Where(X => X.Name.Contains("Bandobast_ni_vigat_patrak")).Select(x => x.Counts).FirstOrDefault(),
                Pending_janva_jognu_patrak = cityCommonCount.Where(X => X.Name.Contains("Pending_janva_jognu_patrak")).Select(x => x.Counts).FirstOrDefault(),
                ProhibitionQualityCase_Crime = cityCommonCount.Where(X => X.Name.Contains("ProhibitionQualityCase_Crime")).Select(x => x.Counts).FirstOrDefault(),
                Currentyear = cityCommonCount.Where(X => X.Name.Contains("Atakayatidetails_current_year_Count")).Select(x => x.Counts).FirstOrDefault(),
                Lastyear = cityCommonCount.Where(X => X.Name.Contains("Atakayatidetails_last_year_Count")).Select(x => x.Counts).FirstOrDefault(),
                Pending_arajinu_patrak = cityCommonCount.Where(X => X.Name.Contains("Pending_arajinu_patrak")).Select(x => x.Counts).FirstOrDefault(),
                DCB_po_station_ni_mahiti = cityCommonCount.Where(X => X.Name.Contains("DCB_po_station_ni_mahiti")).Select(x => x.Counts).FirstOrDefault(),
                Raja_Upar = leaveApplicationCount.Select(x => x.Counts).FirstOrDefault(),
                Part_1_To_5 = Part1_5CrimesCount_Cat1.Select(x => x.Counts).FirstOrDefault(),
                Part_6 = Part1_5CrimesCount_Cat2.Select(x => x.Counts).FirstOrDefault(),
                Prohibision = Part1_5CrimesCount_Cat22.Select(x => x.Counts).FirstOrDefault(),
                Akashmat_mot = Part1_5CrimesCount_Cat35.Select(x => x.Counts).FirstOrDefault(),
                Samans_jamin_layak_warant = SamansdetailsCount_Cat26.Select(x => x.Counts).FirstOrDefault(),
                Jamin_layak_warant = SamansdetailsCount_Cat27.Select(x => x.Counts).FirstOrDefault(),
                Bin_jamin_layak_warant = SamansdetailsCount_Cat28.Select(x => x.Counts).FirstOrDefault(),
                Family_court_thi_malti_notice = SamansdetailsCount_Cat29.Select(x => x.Counts).FirstOrDefault(),
                Anya_notice = SamansdetailsCount_Cat30.Select(x => x.Counts).FirstOrDefault(),
                Today = crimeCountForTodayAndLastDay.Select(x => x.Today).FirstOrDefault(),
                Last = crimeCountForTodayAndLastDay.Select(x => x.Yesterday).FirstOrDefault(),
            };

            cityAllCount.ChoKhhu_Hajar_Mahekam = cityAllCount.Manjur_Mahekam - cityAllCount.Raja_Upar;

            return cityAllCount;
        }

        /// <summary>
        /// Gets count for traffic dashbord.
        /// </summary>
        /// <param name="roleId">Role ID</param>
        /// <param name="sectorId">Sector ID</param>
        /// <param name="zoneId">Zone ID</param>
        /// <param name="divisionId">Division ID</param>
        /// <param name="policeStationId">Police station ID</param>
        /// <param name="fromDate">From date</param>
        /// <param name="toDate">To date</param>
        /// <returns>Returns DashboardCityViewModel object</returns>
        async Task<DashboardTrafficViewModel> IStoredProcedure.GetTrafficDashboardCountAsync(int roleId, int sectorId, int zoneId, int divisionId, int policeStationId, DateTime fromDate, DateTime toDate)
        {
            var pRoleId = new SqlParameter("@RoleId", roleId);
            var pSectorId = new SqlParameter("@SectorId", sectorId);
            var pZoneId = new SqlParameter("@ZoneId", zoneId);
            var PDivisionId = new SqlParameter("@DivisionId", divisionId);
            var pPoliceStationId = new SqlParameter("@PoliceStationId", policeStationId);
            var pFromDate = new SqlParameter("@FromDate", fromDate);
            var pToDate = new SqlParameter("@ToDate", toDate);

            var trafficCommonCount = await _context.Set<DashboardCommonTrafficCount>().FromSqlRaw("exec USP_AhmedabadTraffic_Dashboard_Common_Count @RoleId, @SectorId, @ZoneId, @DivisionId, @PoliceStationId, @FromDate, @ToDate", pRoleId, pSectorId, pZoneId, PDivisionId, pPoliceStationId, pFromDate, pToDate).ToListAsync();

            #region Leave Application Count

            var pIsTraffic = new SqlParameter("@Istraffic", true);
            var leaveApplicationCount = await _context.Set<DashboardCitySingalCount>().FromSqlRaw("exec USP_LeaveApplication_Count @RoleId, @SectorId, @ZoneId, @DivisionId, @PoliceStationId, @FromDate, @ToDate, @Istraffic", pRoleId, pSectorId, pZoneId, PDivisionId, pPoliceStationId, pFromDate, pToDate, pIsTraffic).ToListAsync();

            #endregion

            #region  Traffic Crain Work

            var pCrainTypeId = new SqlParameter("@TrafficCrainTypeId", 1);
            var sarkariCrane = await _context.Set<TrafficTotalAndAmount>().FromSqlRaw("exec USP_TrafficCrainWorkMaster_Amount_And_Count @RoleId, @SectorId, @ZoneId, @DivisionId, @PoliceStationId, @FromDate, @ToDate, @TrafficCrainTypeId", pRoleId, pSectorId, pZoneId, PDivisionId, pPoliceStationId, pFromDate, pToDate, pCrainTypeId).ToListAsync();
            pCrainTypeId = new SqlParameter("@TrafficCrainTypeId", 2);
            var praivateCrane = await _context.Set<TrafficTotalAndAmount>().FromSqlRaw("exec USP_TrafficCrainWorkMaster_Amount_And_Count @RoleId, @SectorId, @ZoneId, @DivisionId, @PoliceStationId, @FromDate, @ToDate, @TrafficCrainTypeId", pRoleId, pSectorId, pZoneId, PDivisionId, pPoliceStationId, pFromDate, pToDate, pCrainTypeId).ToListAsync();

            #endregion

            #region Traffic Place Details Count

            var pbandobastTypeId = new SqlParameter("@BandobastTypeId", 1);
            var vipCount = await _context.Set<DashboardCitySingalCount>().FromSqlRaw("exec Usp_Bandobastdetails_Category_wise_Count @RoleId, @SectorId, @ZoneId, @DivisionId, @PoliceStationId, @FromDate, @ToDate, @BandobastTypeId", pRoleId, pSectorId, pZoneId, PDivisionId, pPoliceStationId, pFromDate, pToDate, pbandobastTypeId).ToListAsync();
            pbandobastTypeId = new SqlParameter("@BandobastTypeId", 2);
            var festivalCount = await _context.Set<DashboardCitySingalCount>().FromSqlRaw("exec Usp_Bandobastdetails_Category_wise_Count @RoleId, @SectorId, @ZoneId, @DivisionId, @PoliceStationId, @FromDate, @ToDate, @BandobastTypeId", pRoleId, pSectorId, pZoneId, PDivisionId, pPoliceStationId, pFromDate, pToDate, pbandobastTypeId).ToListAsync();
            pbandobastTypeId = new SqlParameter("@BandobastTypeId", 3);
            var sabhaCount = await _context.Set<DashboardCitySingalCount>().FromSqlRaw("exec Usp_Bandobastdetails_Category_wise_Count @RoleId, @SectorId, @ZoneId, @DivisionId, @PoliceStationId, @FromDate, @ToDate, @BandobastTypeId", pRoleId, pSectorId, pZoneId, PDivisionId, pPoliceStationId, pFromDate, pToDate, pbandobastTypeId).ToListAsync();
            pbandobastTypeId = new SqlParameter("@BandobastTypeId", 4);
            var otherCount = await _context.Set<DashboardCitySingalCount>().FromSqlRaw("exec Usp_Bandobastdetails_Category_wise_Count @RoleId, @SectorId, @ZoneId, @DivisionId, @PoliceStationId, @FromDate, @ToDate, @BandobastTypeId", pRoleId, pSectorId, pZoneId, PDivisionId, pPoliceStationId, pFromDate, pToDate, pbandobastTypeId).ToListAsync();

            #endregion

            var trafficAllCount = new DashboardTrafficViewModel
            {
                Manjur_Mahekam = trafficCommonCount.Where(X => X.Name.Contains("Manjur_Mahekam")).Select(x => x.Counts).FirstOrDefault(),
                Hajar_Mahekam = trafficCommonCount.Where(X => X.Name.Contains("Manjur_Mahekam")).Select(x => x.Counts).FirstOrDefault(),
                Raja_Upar = leaveApplicationCount.Select(x => x.Counts).FirstOrDefault(),
                Part_1_5_Crime = trafficCommonCount.Where(X => X.Name.Contains("Traffic_Part1_5_Crime")).Select(x => x.Counts).FirstOrDefault(),
                Vahan_Akasmat = trafficCommonCount.Where(X => X.Name.Contains("Vahan_Akasmat")).Select(x => x.Counts).FirstOrDefault(),
                MVACT_207 = trafficCommonCount.Where(X => X.Name.Contains("MVACT_207")).Select(x => x.Counts).FirstOrDefault(),
                TabakuCase = trafficCommonCount.Where(X => X.Name.Contains("TabakuCase_Number")).Select(x => x.Counts).FirstOrDefault(),
                TabakuDand = trafficCommonCount.Where(X => X.Name.Contains("TabakuCase_Amount")).Select(x => x.Counts).FirstOrDefault(),
                Sarkari_Crane_Number = sarkariCrane.Select(x => x.Total).FirstOrDefault(),
                Sarkari_Crane_Amount = sarkariCrane.Select(x => x.Amount).FirstOrDefault(),
                Private_Crane_Number = praivateCrane.Select(x => x.Total).FirstOrDefault(),
                Private_Crane_Amount = praivateCrane.Select(x => x.Amount).FirstOrDefault(),
                DriveCaseNumber = trafficCommonCount.Where(X => X.Name.Contains("DriveCaseNumber")).Select(x => x.Counts).FirstOrDefault(),
                DriveCaseAmount = trafficCommonCount.Where(X => X.Name.Contains("DriveCaseAmount")).Select(x => x.Counts).FirstOrDefault(),
                Challan = trafficCommonCount.Where(X => X.Name.Contains("Challan")).Select(x => x.Counts).FirstOrDefault(),
                Totalplacefine = trafficCommonCount.Where(X => X.Name.Contains("TotalPlaceFine")).Select(x => x.Counts).FirstOrDefault(),
                E_Challan = trafficCommonCount.Where(X => X.Name.Contains("Challan_Online")).Select(x => x.Counts).FirstOrDefault(),
                E_Total = trafficCommonCount.Where(X => X.Name.Contains("Total_Online")).Select(x => x.Counts).FirstOrDefault(),
                VIP = vipCount.Select(x => x.Counts).FirstOrDefault(),
                Festival = festivalCount.Select(x => x.Counts).FirstOrDefault(),
                Sabha = sabhaCount.Select(x => x.Counts).FirstOrDefault(),
                Others = otherCount.Select(x => x.Counts).FirstOrDefault(),
            };

            trafficAllCount.ChoKhhu_Hajar_Mahekam = trafficAllCount.Manjur_Mahekam - trafficAllCount.Raja_Upar;
            trafficAllCount.Total_Crane_Number = trafficAllCount.Sarkari_Crane_Number + trafficAllCount.Private_Crane_Number;
            trafficAllCount.Total_Crane_Amount = trafficAllCount.Sarkari_Crane_Amount + trafficAllCount.Private_Crane_Amount;

            return trafficAllCount;
        }

        /// <summary>
        /// Gets Details Of Crimes.
        /// </summary>
        /// <param name="roleId">Role ID</param>
        /// <param name="sectorId">Sector ID</param>
        /// <param name="zoneId">Zone ID</param>
        /// <param name="divisionId">Division ID</param>
        /// <param name="policeStationId">Police station ID</param>
        /// <param name="fromDate">From date</param>
        /// <param name="toDate">To date</param>
        /// <returns>Returns City_Crime_DetailsViewModel object</returns>
        public IEnumerable<City_Crime_DetailsViewModel> GetDetailsOfCrimes(int roleId, int sectorId, int zoneId, int divisionId, int policeStationId, DateTime fromDate, DateTime toDate)
        {
            var pRoleId = new SqlParameter("@RoleId", roleId);
            var pSectorId = new SqlParameter("@SectorId", sectorId);
            var pZoneId = new SqlParameter("@ZoneId", zoneId);
            var PDivisionId = new SqlParameter("@DivisionId", divisionId);
            var pPoliceStationId = new SqlParameter("@PoliceStationId", policeStationId);
            var pFromDate = new SqlParameter("@FromDate", fromDate);
            var pToDate = new SqlParameter("@ToDate", toDate);

            return _context.Set<City_Crime_DetailsViewModel>()
               .FromSqlRaw("exec USP_CommaSepratedValues_SEL_ALL @RoleId, @SectorId, @ZoneId, @DivisionId, @PoliceStationId, @FromDate, @ToDate", pRoleId, pSectorId, pZoneId, PDivisionId, pPoliceStationId, pFromDate, pToDate)
               .ToList();
        }

        #endregion
    }
}