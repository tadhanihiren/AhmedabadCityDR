using AhmedabadCityDR.Interfaces;
using AhmedabadCityDR.Models.TableModels;
using AhmedabadCityDR.Models.ViewModels;

namespace AhmedabadCityDR.Repository
{
    public partial class AhmCityDrDbContext : DbContext
    {
        #region Private Members

        private readonly IConfiguration _configuration;

        #endregion

        #region Constructors

        public AhmCityDrDbContext()
        {
        }

        public AhmCityDrDbContext(DbContextOptions<AhmCityDrDbContext> options, IConfiguration configuration)
            : base(options)
        {
            _configuration = configuration;
        }

        #endregion

        #region Properties

        public virtual DbSet<TblAccusedInformation> TblAccusedInformations { get; set; } = null!;
        public virtual DbSet<TblAccusedInformationHit> TblAccusedInformationHits { get; set; } = null!;
        public virtual DbSet<TblAdminCheckMaster> TblAdminCheckMasters { get; set; } = null!;
        public virtual DbSet<TblAdminWisePendingApplicationMaster> TblAdminWisePendingApplicationMasters { get; set; } = null!;
        public virtual DbSet<TblAtakKarelEsam> TblAtakKarelEsams { get; set; } = null!;
        public virtual DbSet<TblAtakayatiPagla> TblAtakayatiPaglas { get; set; } = null!;
        public virtual DbSet<TblAtakayatiPaglaHit> TblAtakayatiPaglaHits { get; set; } = null!;
        public virtual DbSet<TblAtakayatiPaglaSummary> TblAtakayatiPaglaSummaries { get; set; } = null!;
        public virtual DbSet<TblAtakayatiPaglaSummaryHit> TblAtakayatiPaglaSummaryHits { get; set; } = null!;
        public virtual DbSet<TblAtakayatidetail> TblAtakayatidetails { get; set; } = null!;
        public virtual DbSet<TblAtakayatidetailsHit> TblAtakayatidetailsHits { get; set; } = null!;
        public virtual DbSet<TblAtkayatiPagalaConsolidated> TblAtkayatiPagalaConsolidateds { get; set; } = null!;
        public virtual DbSet<TblAtkayatiPagalaConsolidatedBackup> TblAtkayatiPagalaConsolidatedBackups { get; set; } = null!;
        public virtual DbSet<TblAtkayatiPagalaConsolidatedHit> TblAtkayatiPagalaConsolidatedHits { get; set; } = null!;
        public virtual DbSet<TblAutoRickshawDetail> TblAutoRickshawDetails { get; set; } = null!;
        public virtual DbSet<TblAutoRickshawDetailsHit> TblAutoRickshawDetailsHits { get; set; } = null!;
        public virtual DbSet<TblBandobastDetailMaster> TblBandobastDetailMasters { get; set; } = null!;
        public virtual DbSet<TblBandobastDetailMasterHit> TblBandobastDetailMasterHits { get; set; } = null!;
        public virtual DbSet<TblBandobastTypeMaster> TblBandobastTypeMasters { get; set; } = null!;
        public virtual DbSet<TblCategoryMaster> TblCategoryMasters { get; set; } = null!;
        public virtual DbSet<TblCctvMaster> TblCctvMasters { get; set; } = null!;
        public virtual DbSet<TblCctvMasterHit> TblCctvMasterHits { get; set; } = null!;
        public virtual DbSet<TblCctvinstalled> TblCctvinstalleds { get; set; } = null!;
        public virtual DbSet<TblCctvinstalledHit> TblCctvinstalledHits { get; set; } = null!;
        public virtual DbSet<TblChangeColor> TblChangeColors { get; set; } = null!;
        public virtual DbSet<TblCheckAnswerDetail> TblCheckAnswerDetails { get; set; } = null!;
        public virtual DbSet<TblCheckDetail> TblCheckDetails { get; set; } = null!;
        public virtual DbSet<TblCityMaster> TblCityMasters { get; set; } = null!;
        public virtual DbSet<TblCriminalCountInformation> TblCriminalCountInformations { get; set; } = null!;
        public virtual DbSet<TblCriminalCountInformationHit> TblCriminalCountInformationHits { get; set; } = null!;
        public virtual DbSet<TblCriminalInformation> TblCriminalInformations { get; set; } = null!;
        public virtual DbSet<TblCriminalInformationHit> TblCriminalInformationHits { get; set; } = null!;
        public virtual DbSet<TblCrpc41camendmentMater> TblCrpc41camendmentMaters { get; set; } = null!;
        public virtual DbSet<TblCrpc41camendmentMaterHit> TblCrpc41camendmentMaterHits { get; set; } = null!;
        public virtual DbSet<TblCrpc41master> TblCrpc41masters { get; set; } = null!;
        public virtual DbSet<TblCrpc41masterHit> TblCrpc41masterHits { get; set; } = null!;
        public virtual DbSet<TblCurrentYearAgeWiseMissingChildDetail> TblCurrentYearAgeWiseMissingChildDetails { get; set; } = null!;
        public virtual DbSet<TblCurrentYearAgeWiseMissingChildDetailsHit> TblCurrentYearAgeWiseMissingChildDetailsHits { get; set; } = null!;
        public virtual DbSet<TblCurrentYearMissingChildDetail> TblCurrentYearMissingChildDetails { get; set; } = null!;
        public virtual DbSet<TblCurrentYearMissingChildDetailsHit> TblCurrentYearMissingChildDetailsHits { get; set; } = null!;
        public virtual DbSet<TblDcbPolicestationMaster> TblDcbPolicestationMasters { get; set; } = null!;
        public virtual DbSet<TblDcbPolicestationMasterHit> TblDcbPolicestationMasterHits { get; set; } = null!;
        public virtual DbSet<TblDesignationName> TblDesignationNames { get; set; } = null!;
        public virtual DbSet<TblDistributeVehical> TblDistributeVehicals { get; set; } = null!;
        public virtual DbSet<TblDistributeVehicalHit> TblDistributeVehicalHits { get; set; } = null!;
        public virtual DbSet<TblDivisionMaster> TblDivisionMasters { get; set; } = null!;
        public virtual DbSet<TblEGujakopMaster> TblEGujakopMasters { get; set; } = null!;
        public virtual DbSet<TblEGujakopMasterHit> TblEGujakopMasterHits { get; set; } = null!;
        public virtual DbSet<TblEGujkopDetail> TblEGujkopDetails { get; set; } = null!;
        public virtual DbSet<TblEmployeeMaster> TblEmployeeMasters { get; set; } = null!;
        public virtual DbSet<TblEmployeeMasterBackup> TblEmployeeMasterBackups { get; set; } = null!;
        public virtual DbSet<TblEmployeeMasterHit> TblEmployeeMasterHits { get; set; } = null!;
        public virtual DbSet<TblEquipment> TblEquipments { get; set; } = null!;
        public virtual DbSet<TblEquipmentsHit> TblEquipmentsHits { get; set; } = null!;
        public virtual DbSet<TblForm3A> TblForm3As { get; set; } = null!;
        public virtual DbSet<TblForm3AHit> TblForm3AHits { get; set; } = null!;
        public virtual DbSet<TblForm5Master> TblForm5Masters { get; set; } = null!;
        public virtual DbSet<TblGenderMaster> TblGenderMasters { get; set; } = null!;
        public virtual DbSet<TblHistoryMissingAgeWiseChild> TblHistoryMissingAgeWiseChildren { get; set; } = null!;
        public virtual DbSet<TblHistoryMissingAgeWiseChildHit> TblHistoryMissingAgeWiseChildHits { get; set; } = null!;
        public virtual DbSet<TblIndexPatrakMaster> TblIndexPatrakMasters { get; set; } = null!;
        public virtual DbSet<TblIpcGpcmaster> TblIpcGpcmasters { get; set; } = null!;
        public virtual DbSet<TblIpcGpcmasterHit> TblIpcGpcmasterHits { get; set; } = null!;
        public virtual DbSet<TblLaborInformationMaster> TblLaborInformationMasters { get; set; } = null!;
        public virtual DbSet<TblLaborInformationMasterHit> TblLaborInformationMasterHits { get; set; } = null!;
        public virtual DbSet<TblLeaveApplicationMaster> TblLeaveApplicationMasters { get; set; } = null!;
        public virtual DbSet<TblLeaveApplicationMasterHit> TblLeaveApplicationMasterHits { get; set; } = null!;
        public virtual DbSet<TblLeaveTypeMaster> TblLeaveTypeMasters { get; set; } = null!;
        public virtual DbSet<TblLeaveTypeMasterHit> TblLeaveTypeMasterHits { get; set; } = null!;
        public virtual DbSet<TblLoginMasterMobile> TblLoginMasterMobiles { get; set; } = null!;
        public virtual DbSet<TblMahekamMaster> TblMahekamMasters { get; set; } = null!;
        public virtual DbSet<TblMcrdetail> TblMcrdetails { get; set; } = null!;
        public virtual DbSet<TblMcrdetailsHit> TblMcrdetailsHits { get; set; } = null!;
        public virtual DbSet<TblMissingChildDetail> TblMissingChildDetails { get; set; } = null!;
        public virtual DbSet<TblMissingChildDetailsHist> TblMissingChildDetailsHists { get; set; } = null!;
        public virtual DbSet<TblMonthWiseReport> TblMonthWiseReports { get; set; } = null!;
        public virtual DbSet<TblMonthWiseReportHist> TblMonthWiseReportHists { get; set; } = null!;
        public virtual DbSet<TblNightEmployeeMaster> TblNightEmployeeMasters { get; set; } = null!;
        public virtual DbSet<TblNightEmployeeMasterHist> TblNightEmployeeMasterHists { get; set; } = null!;
        public virtual DbSet<TblNightRound> TblNightRounds { get; set; } = null!;
        public virtual DbSet<TblNightRoundHekoPomaster> TblNightRoundHekoPomasters { get; set; } = null!;
        public virtual DbSet<TblNightRoundHekoPomasterHist> TblNightRoundHekoPomasterHists { get; set; } = null!;
        public virtual DbSet<TblNightRoundHist> TblNightRoundHists { get; set; } = null!;
        public virtual DbSet<TblNightRountPersonCountMaster> TblNightRountPersonCountMasters { get; set; } = null!;
        public virtual DbSet<TblNightRountPersonCountMasterHist> TblNightRountPersonCountMasterHists { get; set; } = null!;
        public virtual DbSet<TblOfiiceWisePendingApplication> TblOfiiceWisePendingApplications { get; set; } = null!;
        public virtual DbSet<TblOfiiceWisePendingApplicationHist> TblOfiiceWisePendingApplicationHists { get; set; } = null!;
        public virtual DbSet<TblPart1_5Crime> TblPart15Crimes { get; set; } = null!;
        public virtual DbSet<TblPart15CrimesHist> TblPart15CrimesHists { get; set; } = null!;
        public virtual DbSet<TblPart16Counter> TblPart16Counters { get; set; } = null!;
        public virtual DbSet<TblPendingArjiCategory> TblPendingArjiCategories { get; set; } = null!;
        public virtual DbSet<TblPendingArjiDetail> TblPendingArjiDetails { get; set; } = null!;
        public virtual DbSet<TblPendingArjiDetailsHist> TblPendingArjiDetailsHists { get; set; } = null!;
        public virtual DbSet<TblPendingWarrant> TblPendingWarrants { get; set; } = null!;
        public virtual DbSet<TblPendingWarrantHist> TblPendingWarrantHists { get; set; } = null!;
        public virtual DbSet<TblPidhelaKabjaCategoryMaster> TblPidhelaKabjaCategoryMasters { get; set; } = null!;
        public virtual DbSet<TblPoliceStationMaster> TblPoliceStationMasters { get; set; } = null!;
        public virtual DbSet<TblPoliceStationVehicleChecking> TblPoliceStationVehicleCheckings { get; set; } = null!;
        public virtual DbSet<TblPoliceStationVehicleCheckingHist> TblPoliceStationVehicleCheckingHists { get; set; } = null!;
        public virtual DbSet<TblPoliceStationWisePendingApplication> TblPoliceStationWisePendingApplications { get; set; } = null!;
        public virtual DbSet<TblPoliceStationWisePendingApplicationHist> TblPoliceStationWisePendingApplicationHists { get; set; } = null!;
        public virtual DbSet<TblPoliceStationWiseVehical> TblPoliceStationWiseVehicals { get; set; } = null!;
        public virtual DbSet<TblPoliceStationWiseVehicalHist> TblPoliceStationWiseVehicalHists { get; set; } = null!;
        public virtual DbSet<TblProhibitionCrimeMaster> TblProhibitionCrimeMasters { get; set; } = null!;
        public virtual DbSet<TblProhibitionCrimeMasterCopy> TblProhibitionCrimeMasterCopies { get; set; } = null!;
        public virtual DbSet<TblProhibitionCrimeMasterHist> TblProhibitionCrimeMasterHists { get; set; } = null!;
        public virtual DbSet<TblProhibitionRaidCase> TblProhibitionRaidCases { get; set; } = null!;
        public virtual DbSet<TblProhibitionRaidCaseHit> TblProhibitionRaidCaseHits { get; set; } = null!;
        public virtual DbSet<TblRoleMaster> TblRoleMasters { get; set; } = null!;
        public virtual DbSet<TblSamansDetail> TblSamansDetails { get; set; } = null!;
        public virtual DbSet<TblSamansDetailsHit> TblSamansDetailsHits { get; set; } = null!;
        public virtual DbSet<TblSamelCategoryMaster> TblSamelCategoryMasters { get; set; } = null!;
        public virtual DbSet<TblSamelPatrakMaster> TblSamelPatrakMasters { get; set; } = null!;
        public virtual DbSet<TblSamelPatrakMasterHist> TblSamelPatrakMasterHists { get; set; } = null!;
        public virtual DbSet<TblSectorMaster> TblSectorMasters { get; set; } = null!;
        public virtual DbSet<TblStateMaster> TblStateMasters { get; set; } = null!;
        public virtual DbSet<TblStationery> TblStationeries { get; set; } = null!;
        public virtual DbSet<TblStationeryHist> TblStationeryHists { get; set; } = null!;
        public virtual DbSet<TblStatusMaster> TblStatusMasters { get; set; } = null!;
        public virtual DbSet<TblSubCategoryCount> TblSubCategoryCounts { get; set; } = null!;
        public virtual DbSet<TblSubCategoryMaster> TblSubCategoryMasters { get; set; } = null!;
        public virtual DbSet<TblTraffiCategoryMaster> TblTraffiCategoryMasters { get; set; } = null!;
        public virtual DbSet<TblTrafficAccidentalDetail> TblTrafficAccidentalDetails { get; set; } = null!;
        public virtual DbSet<TblTrafficAccidentalDetailsHist> TblTrafficAccidentalDetailsHists { get; set; } = null!;
        public virtual DbSet<TblTrafficCategorySummaryMaster> TblTrafficCategorySummaryMasters { get; set; } = null!;
        public virtual DbSet<TblTrafficCrainCategoryMaster> TblTrafficCrainCategoryMasters { get; set; } = null!;
        public virtual DbSet<TblTrafficCrainMaster> TblTrafficCrainMasters { get; set; } = null!;
        public virtual DbSet<TblTrafficCrainMasterHist> TblTrafficCrainMasterHists { get; set; } = null!;
        public virtual DbSet<TblTrafficCrainTypeMaster> TblTrafficCrainTypeMasters { get; set; } = null!;
        public virtual DbSet<TblTrafficCrainWorkMaster> TblTrafficCrainWorkMasters { get; set; } = null!;
        public virtual DbSet<TblTrafficCrainWorkMasterHist> TblTrafficCrainWorkMasterHists { get; set; } = null!;
        public virtual DbSet<TblTrafficDriveCategoryMaster> TblTrafficDriveCategoryMasters { get; set; } = null!;
        public virtual DbSet<TblTrafficDriveMaster> TblTrafficDriveMasters { get; set; } = null!;
        public virtual DbSet<TblTrafficDriveMasterHist> TblTrafficDriveMasterHists { get; set; } = null!;
        public virtual DbSet<TblTrafficEchallanCollection> TblTrafficEchallanCollections { get; set; } = null!;
        public virtual DbSet<TblTrafficEchallanCollectionHist> TblTrafficEchallanCollectionHists { get; set; } = null!;
        public virtual DbSet<TblTrafficGhasCharaMaster> TblTrafficGhasCharaMasters { get; set; } = null!;
        public virtual DbSet<TblTrafficGhasCharaMasterHist> TblTrafficGhasCharaMasterHists { get; set; } = null!;
        public virtual DbSet<TblTrafficInterceptCategoryMaster> TblTrafficInterceptCategoryMasters { get; set; } = null!;
        public virtual DbSet<TblTrafficInterceptSubCategoryMaster> TblTrafficInterceptSubCategoryMasters { get; set; } = null!;
        public virtual DbSet<TblTrafficInterceptWorkDetail> TblTrafficInterceptWorkDetails { get; set; } = null!;
        public virtual DbSet<TblTrafficInterceptWorkDetailsHist> TblTrafficInterceptWorkDetailsHists { get; set; } = null!;
        public virtual DbSet<TblTrafficIpc188> TblTrafficIpc188s { get; set; } = null!;
        public virtual DbSet<TblTrafficIpc188Hist> TblTrafficIpc188Hists { get; set; } = null!;
        public virtual DbSet<TblTrafficIpc283> TblTrafficIpc283s { get; set; } = null!;
        public virtual DbSet<TblTrafficIpc283Hist> TblTrafficIpc283Hists { get; set; } = null!;
        public virtual DbSet<TblTrafficJamDetailsAll> TblTrafficJamDetailsAlls { get; set; } = null!;
        public virtual DbSet<TblTrafficJamDetailsAllHist> TblTrafficJamDetailsAllHists { get; set; } = null!;
        public virtual DbSet<TblTrafficMahekamMaster> TblTrafficMahekamMasters { get; set; } = null!;
        public virtual DbSet<TblTrafficMahekamMasterHist> TblTrafficMahekamMasterHists { get; set; } = null!;
        public virtual DbSet<TblTrafficMvactdetail> TblTrafficMvactdetails { get; set; } = null!;
        public virtual DbSet<TblTrafficMvactdetailsHist> TblTrafficMvactdetailsHists { get; set; } = null!;
        public virtual DbSet<TblTrafficPart15Detail> TblTrafficPart15Details { get; set; } = null!;
        public virtual DbSet<TblTrafficPart15DetailsHist> TblTrafficPart15DetailsHists { get; set; } = null!;
        public virtual DbSet<TblTrafficPlaceFineDetail> TblTrafficPlaceFineDetails { get; set; } = null!;
        public virtual DbSet<TblTrafficPlaceFineDetailsHist> TblTrafficPlaceFineDetailsHists { get; set; } = null!;
        public virtual DbSet<TblTrafficPlaceFineDetailsJet> TblTrafficPlaceFineDetailsJets { get; set; } = null!;
        public virtual DbSet<TblTrafficPlaceFineDetailsJetHist> TblTrafficPlaceFineDetailsJetHists { get; set; } = null!;
        public virtual DbSet<TblTrafficPlaceFineDetailsJetNull> TblTrafficPlaceFineDetailsJetNulls { get; set; } = null!;
        public virtual DbSet<TblTrafficPlaceFineDetailsNull> TblTrafficPlaceFineDetailsNulls { get; set; } = null!;
        public virtual DbSet<TblTrafficPlaceFineMaster> TblTrafficPlaceFineMasters { get; set; } = null!;
        public virtual DbSet<TblTrafficPlaceFineMasterHist> TblTrafficPlaceFineMasterHists { get; set; } = null!;
        public virtual DbSet<TblTrafficPlaceItdetail> TblTrafficPlaceItdetails { get; set; } = null!;
        public virtual DbSet<TblTrafficPlaceItdetailsNull> TblTrafficPlaceItdetailsNulls { get; set; } = null!;
        public virtual DbSet<TblTrafficSignalBlinkerigh> TblTrafficSignalBlinkerighs { get; set; } = null!;
        public virtual DbSet<TblTrafficSignalBlinkerighHist> TblTrafficSignalBlinkerighHists { get; set; } = null!;
        public virtual DbSet<TblTrafficSignalMaster> TblTrafficSignalMasters { get; set; } = null!;
        public virtual DbSet<TblTrafficSignalMasterHist> TblTrafficSignalMasterHists { get; set; } = null!;
        public virtual DbSet<TblTrafficSummaryDetail> TblTrafficSummaryDetails { get; set; } = null!;
        public virtual DbSet<TblTrafficSummaryDetailsHist> TblTrafficSummaryDetailsHists { get; set; } = null!;
        public virtual DbSet<TblTrafficTobacoMaster> TblTrafficTobacoMasters { get; set; } = null!;
        public virtual DbSet<TblTrafficTobacoMasterHist> TblTrafficTobacoMasterHists { get; set; } = null!;
        public virtual DbSet<TblTrafficTrbHomeGuardMaster> TblTrafficTrbHomeGuardMasters { get; set; } = null!;
        public virtual DbSet<TblTrafficTrbHomeGuardMasterHist> TblTrafficTrbHomeGuardMasterHists { get; set; } = null!;
        public virtual DbSet<TblTrafficTrgAhgMaster> TblTrafficTrgAhgMasters { get; set; } = null!;
        public virtual DbSet<TblTrafficTrgAhgMasterHist> TblTrafficTrgAhgMasterHists { get; set; } = null!;
        public virtual DbSet<TblVehicleMaster> TblVehicleMasters { get; set; } = null!;
        public virtual DbSet<TblVisitationCrimeBranch> TblVisitationCrimeBranches { get; set; } = null!;
        public virtual DbSet<TblVisitationCrimeBranchHist> TblVisitationCrimeBranchHists { get; set; } = null!;
        public virtual DbSet<TblWardMaster> TblWardMasters { get; set; } = null!;
        public virtual DbSet<TblWardWiseJetDetail> TblWardWiseJetDetails { get; set; } = null!;
        public virtual DbSet<TblWardWiseJetDetailsHit> TblWardWiseJetDetailsHits { get; set; } = null!;
        public virtual DbSet<TblWheelerType> TblWheelerTypes { get; set; } = null!;
        public virtual DbSet<TblZoneMaster> TblZoneMasters { get; set; } = null!;
        public virtual DbSet<TbladhibitMaster> TbladhibitMasters { get; set; } = null!;
        public virtual DbSet<TbladhibitMasterHit> TbladhibitMasterHits { get; set; } = null!;
        public virtual DbSet<TbldetainMaster> TbldetainMasters { get; set; } = null!;
        public virtual DbSet<TbldetainMasterHit> TbldetainMasterHits { get; set; } = null!;
        public virtual DbSet<TblhistroryOfCurrentMissing> TblhistroryOfCurrentMissings { get; set; } = null!;
        public virtual DbSet<TblkacheriMaster> TblkacheriMasters { get; set; } = null!;
        public virtual DbSet<TblpendingjanvajogMaster> TblpendingjanvajogMasters { get; set; } = null!;
        public virtual DbSet<TblpendingjanvajogMasterHist> TblpendingjanvajogMasterHists { get; set; } = null!;
        public virtual DbSet<ViewAdminCheckMaster> ViewAdminCheckMasters { get; set; } = null!;
        public virtual DbSet<ViewCategorySubcategoryDailyReport> ViewCategorySubcategoryDailyReports { get; set; } = null!;
        public virtual DbSet<ViewCctvSel> ViewCctvSels { get; set; } = null!;
        public virtual DbSet<ViewCrpc41masterSel> ViewCrpc41masterSels { get; set; } = null!;
        public virtual DbSet<ViewCurrentYearAgeWiseMissingChildDetailsDailyReport> ViewCurrentYearAgeWiseMissingChildDetailsDailyReports { get; set; } = null!;
        public virtual DbSet<ViewCurrentYearAgeWiseMissingChildDetailsSel> ViewCurrentYearAgeWiseMissingChildDetailsSels { get; set; } = null!;
        public virtual DbSet<ViewDesignationNameSector> ViewDesignationNameSectors { get; set; } = null!;
        public virtual DbSet<ViewEmployeeMasterSel> ViewEmployeeMasterSels { get; set; } = null!;
        public virtual DbSet<ViewEmployeeMasterSel1> ViewEmployeeMasterSels1 { get; set; } = null!;
        public virtual DbSet<ViewForm9ASel> ViewForm9ASels { get; set; } = null!;
        public virtual DbSet<ViewHistroryOfCurrentMissingSel> ViewHistroryOfCurrentMissingSels { get; set; } = null!;
        public virtual DbSet<ViewJaminSamansSel> ViewJaminSamansSels { get; set; } = null!;
        public virtual DbSet<ViewLoginPoliceStationWiseSel> ViewLoginPoliceStationWiseSels { get; set; } = null!;
        public virtual DbSet<ViewMahekamNightRoundSel> ViewMahekamNightRoundSels { get; set; } = null!;
        public virtual DbSet<ViewMahekamPolicestationMasterSel> ViewMahekamPolicestationMasterSels { get; set; } = null!;
        public virtual DbSet<ViewMissingChildDetailsSel> ViewMissingChildDetailsSels { get; set; } = null!;
        public virtual DbSet<ViewMonthWiseReportSel> ViewMonthWiseReportSels { get; set; } = null!;
        public virtual DbSet<ViewNightRoundSel> ViewNightRoundSels { get; set; } = null!;
        public virtual DbSet<ViewPart15DetailsSel> ViewPart15DetailsSels { get; set; } = null!;
        public virtual DbSet<ViewPendingWarrentSel> ViewPendingWarrentSels { get; set; } = null!;
        public virtual DbSet<ViewPoliceStationVehicalSel> ViewPoliceStationVehicalSels { get; set; } = null!;
        public virtual DbSet<ViewReport19Sel> ViewReport19Sels { get; set; } = null!;
        public virtual DbSet<ViewReportspart15crime> ViewReportspart15crimes { get; set; } = null!;
        public virtual DbSet<ViewSectorZoneDivisionPolice> ViewSectorZoneDivisionPolices { get; set; } = null!;
        public virtual DbSet<ViewSectorZoneDivisionPoliceStation> ViewSectorZoneDivisionPoliceStations { get; set; } = null!;
        public virtual DbSet<ViewTblAccusedInformationSel> ViewTblAccusedInformationSels { get; set; } = null!;
        public virtual DbSet<ViewTblAdhibitDetail> ViewTblAdhibitDetails { get; set; } = null!;
        public virtual DbSet<ViewTblAtakatiPagalaConsolidatedAll> ViewTblAtakatiPagalaConsolidatedAlls { get; set; } = null!;
        public virtual DbSet<ViewTblAtakatiPagalaConsolidatedDisplay> ViewTblAtakatiPagalaConsolidatedDisplays { get; set; } = null!;
        public virtual DbSet<ViewTblAtakayatiPaglaSummarySel> ViewTblAtakayatiPaglaSummarySels { get; set; } = null!;
        public virtual DbSet<ViewTblAtakayatidetailsSel> ViewTblAtakayatidetailsSels { get; set; } = null!;
        public virtual DbSet<ViewTblAtakayatipaglaSel> ViewTblAtakayatipaglaSels { get; set; } = null!;
        public virtual DbSet<ViewTblAtkayatiPaglaDivisionPolicestation> ViewTblAtkayatiPaglaDivisionPolicestations { get; set; } = null!;
        public virtual DbSet<ViewTblAutoRickshawDetailsSel> ViewTblAutoRickshawDetailsSels { get; set; } = null!;
        public virtual DbSet<ViewTblBandobastDetailsSel> ViewTblBandobastDetailsSels { get; set; } = null!;
        public virtual DbSet<ViewTblCctvinstalledSel> ViewTblCctvinstalledSels { get; set; } = null!;
        public virtual DbSet<ViewTblCityMaster> ViewTblCityMasters { get; set; } = null!;
        public virtual DbSet<ViewTblCriminalCountInformationSel> ViewTblCriminalCountInformationSels { get; set; } = null!;
        public virtual DbSet<ViewTblCriminalInformationSel> ViewTblCriminalInformationSels { get; set; } = null!;
        public virtual DbSet<ViewTblCrpc41camendmentMaterSel> ViewTblCrpc41camendmentMaterSels { get; set; } = null!;
        public virtual DbSet<ViewTblCurrentYearMissingChildPolicestationCategoryGenderMasterSel> ViewTblCurrentYearMissingChildPolicestationCategoryGenderMasterSels { get; set; } = null!;
        public virtual DbSet<ViewTblDistributeVehicalSel> ViewTblDistributeVehicalSels { get; set; } = null!;
        public virtual DbSet<ViewTblDivisionMaster> ViewTblDivisionMasters { get; set; } = null!;
        public virtual DbSet<ViewTblDivisionMasterSel> ViewTblDivisionMasterSels { get; set; } = null!;
        public virtual DbSet<ViewTblEGujakopMasterSel> ViewTblEGujakopMasterSels { get; set; } = null!;
        public virtual DbSet<ViewTblEGujkopDetailsSel> ViewTblEGujkopDetailsSels { get; set; } = null!;
        public virtual DbSet<ViewTblForm3ASel> ViewTblForm3ASels { get; set; } = null!;
        public virtual DbSet<ViewTblIndexPatrakDetail> ViewTblIndexPatrakDetails { get; set; } = null!;
        public virtual DbSet<ViewTblLaborInformationMasterSel> ViewTblLaborInformationMasterSels { get; set; } = null!;
        public virtual DbSet<ViewTblLeaveApplicationLeavePoliceStation> ViewTblLeaveApplicationLeavePoliceStations { get; set; } = null!;
        public virtual DbSet<ViewTblLeaveApplicationLeaveTypePolicestationDesignationEmployeeMasterSel> ViewTblLeaveApplicationLeaveTypePolicestationDesignationEmployeeMasterSels { get; set; } = null!;
        public virtual DbSet<ViewTblLoginAuthenticationDetail> ViewTblLoginAuthenticationDetails { get; set; } = null!;
        public virtual DbSet<ViewTblMcrdetailsSel> ViewTblMcrdetailsSels { get; set; } = null!;
        public virtual DbSet<ViewTblMissingChildDetailsPolicestationGenderMasterSel> ViewTblMissingChildDetailsPolicestationGenderMasterSels { get; set; } = null!;
        public virtual DbSet<ViewTblNightEmployeeSel> ViewTblNightEmployeeSels { get; set; } = null!;
        public virtual DbSet<ViewTblNightRoundHekoPomasterSel> ViewTblNightRoundHekoPomasterSels { get; set; } = null!;
        public virtual DbSet<ViewTblNightRoundPersonCountMasterSel> ViewTblNightRoundPersonCountMasterSels { get; set; } = null!;
        public virtual DbSet<ViewTblNightRoundSel> ViewTblNightRoundSels { get; set; } = null!;
        public virtual DbSet<ViewTblOfficeWisePendingApplicationSel> ViewTblOfficeWisePendingApplicationSels { get; set; } = null!;
        public virtual DbSet<ViewTblPart15CrimesCountsOnly> ViewTblPart15CrimesCountsOnlies { get; set; } = null!;
        public virtual DbSet<ViewTblPart15CrimesSel> ViewTblPart15CrimesSels { get; set; } = null!;
        public virtual DbSet<ViewTblPendingArjiDetailsSel> ViewTblPendingArjiDetailsSels { get; set; } = null!;
        public virtual DbSet<ViewTblPlaceFineForNull> ViewTblPlaceFineForNulls { get; set; } = null!;
        public virtual DbSet<ViewTblPlaceFineForNullJet> ViewTblPlaceFineForNullJets { get; set; } = null!;
        public virtual DbSet<ViewTblPlaceFineItforNull> ViewTblPlaceFineItforNulls { get; set; } = null!;
        public virtual DbSet<ViewTblPlaceFineJetDetail> ViewTblPlaceFineJetDetails { get; set; } = null!;
        public virtual DbSet<ViewTblPlaceFineJetNull> ViewTblPlaceFineJetNulls { get; set; } = null!;
        public virtual DbSet<ViewTblPoliceStationMaster> ViewTblPoliceStationMasters { get; set; } = null!;
        public virtual DbSet<ViewTblPoliceStationMasterSel> ViewTblPoliceStationMasterSels { get; set; } = null!;
        public virtual DbSet<ViewTblPoliceStationWiseEmployeeSel> ViewTblPoliceStationWiseEmployeeSels { get; set; } = null!;
        public virtual DbSet<ViewTblPoliceStationWiseVehicalSel> ViewTblPoliceStationWiseVehicalSels { get; set; } = null!;
        public virtual DbSet<ViewTblProhibitionCrimeMasterSel> ViewTblProhibitionCrimeMasterSels { get; set; } = null!;
        public virtual DbSet<ViewTblProhibitionRaidCaseSel> ViewTblProhibitionRaidCaseSels { get; set; } = null!;
        public virtual DbSet<ViewTblSectorMaster> ViewTblSectorMasters { get; set; } = null!;
        public virtual DbSet<ViewTblSectorMasterSel> ViewTblSectorMasterSels { get; set; } = null!;
        public virtual DbSet<ViewTblStationerySel> ViewTblStationerySels { get; set; } = null!;
        public virtual DbSet<ViewTblSubCategoryMaster> ViewTblSubCategoryMasters { get; set; } = null!;
        public virtual DbSet<ViewTblTrafficAccidentalDetailsSel> ViewTblTrafficAccidentalDetailsSels { get; set; } = null!;
        public virtual DbSet<ViewTblTrafficCategoryItmassterBlank> ViewTblTrafficCategoryItmassterBlanks { get; set; } = null!;
        public virtual DbSet<ViewTblTrafficCategoryMassterBlank> ViewTblTrafficCategoryMassterBlanks { get; set; } = null!;
        public virtual DbSet<ViewTblTrafficCrainMasterSel> ViewTblTrafficCrainMasterSels { get; set; } = null!;
        public virtual DbSet<ViewTblTrafficCrainWorkMasterSel> ViewTblTrafficCrainWorkMasterSels { get; set; } = null!;
        public virtual DbSet<ViewTblTrafficDriveMaster> ViewTblTrafficDriveMasters { get; set; } = null!;
        public virtual DbSet<ViewTblTrafficGhasCharaMasterSel> ViewTblTrafficGhasCharaMasterSels { get; set; } = null!;
        public virtual DbSet<ViewTblTrafficInterceptSubCategoryMasterSel> ViewTblTrafficInterceptSubCategoryMasterSels { get; set; } = null!;
        public virtual DbSet<ViewTblTrafficInterceptWorkDetailsSel> ViewTblTrafficInterceptWorkDetailsSels { get; set; } = null!;
        public virtual DbSet<ViewTblTrafficIpc188Sel> ViewTblTrafficIpc188Sels { get; set; } = null!;
        public virtual DbSet<ViewTblTrafficIpc283Sel> ViewTblTrafficIpc283Sels { get; set; } = null!;
        public virtual DbSet<ViewTblTrafficJamDetailsNew> ViewTblTrafficJamDetailsNews { get; set; } = null!;
        public virtual DbSet<ViewTblTrafficMahekamMasterSel> ViewTblTrafficMahekamMasterSels { get; set; } = null!;
        public virtual DbSet<ViewTblTrafficMvactdetailsSel> ViewTblTrafficMvactdetailsSels { get; set; } = null!;
        public virtual DbSet<ViewTblTrafficPart15Detail> ViewTblTrafficPart15Details { get; set; } = null!;
        public virtual DbSet<ViewTblTrafficPlaceFineDetailsWheelerType> ViewTblTrafficPlaceFineDetailsWheelerTypes { get; set; } = null!;
        public virtual DbSet<ViewTblTrafficPlaceFineMasterSel> ViewTblTrafficPlaceFineMasterSels { get; set; } = null!;
        public virtual DbSet<ViewTblTrafficPlaceItfineDetailsWheelerType> ViewTblTrafficPlaceItfineDetailsWheelerTypes { get; set; } = null!;
        public virtual DbSet<ViewTblTrafficSignalBlinkRightSel> ViewTblTrafficSignalBlinkRightSels { get; set; } = null!;
        public virtual DbSet<ViewTblTrafficSignalMasterSel> ViewTblTrafficSignalMasterSels { get; set; } = null!;
        public virtual DbSet<ViewTblTrafficSummaryDetailsCategoryWise> ViewTblTrafficSummaryDetailsCategoryWises { get; set; } = null!;
        public virtual DbSet<ViewTblTrafficTobacoMasterSel> ViewTblTrafficTobacoMasterSels { get; set; } = null!;
        public virtual DbSet<ViewTblTrafficTrbHomeGuardMasterSel> ViewTblTrafficTrbHomeGuardMasterSels { get; set; } = null!;
        public virtual DbSet<ViewTblTrafficTrgAhgSel> ViewTblTrafficTrgAhgSels { get; set; } = null!;
        public virtual DbSet<ViewTblVisitationCrimeBranchMaster> ViewTblVisitationCrimeBranchMasters { get; set; } = null!;
        public virtual DbSet<ViewTblWardWiseDetailsPoliceStationWiseSelect> ViewTblWardWiseDetailsPoliceStationWiseSelects { get; set; } = null!;
        public virtual DbSet<ViewTblZoneMaster> ViewTblZoneMasters { get; set; } = null!;
        public virtual DbSet<ViewTblZoneMasterSel> ViewTblZoneMasterSels { get; set; } = null!;
        public virtual DbSet<ViewTbladminWisePendingApplicationSel> ViewTbladminWisePendingApplicationSels { get; set; } = null!;
        public virtual DbSet<ViewTbldetainMasterSel> ViewTbldetainMasterSels { get; set; } = null!;
        public virtual DbSet<ViewTblpendingjanvajogSel> ViewTblpendingjanvajogSels { get; set; } = null!;
        public virtual DbSet<ViewTblpendingwarrantSel> ViewTblpendingwarrantSels { get; set; } = null!;
        public virtual DbSet<ViewTblpolicestationwiseapplicationSel> ViewTblpolicestationwiseapplicationSels { get; set; } = null!;

        #endregion

        #region Private Methods

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

        #endregion

        #region protected Methods

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_configuration.GetConnectionString("dbConnection"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EmployeeMasterViewModel>().HasNoKey().Metadata.SetIsTableExcludedFromMigrations(true);
            modelBuilder.Entity<EGujkopDetailViewModel>().HasNoKey().Metadata.SetIsTableExcludedFromMigrations(true);
            modelBuilder.Entity<EGujakopMasterViewModel>().HasNoKey().Metadata.SetIsTableExcludedFromMigrations(true);
            modelBuilder.Entity<PendingArjiDetailViewModel>().HasNoKey().Metadata.SetIsTableExcludedFromMigrations(true);
            modelBuilder.Entity<PendingJanvaJogViewModel>().HasNoKey().Metadata.SetIsTableExcludedFromMigrations(true);
            modelBuilder.Entity<AutoRickshawDetailViewModel>().HasNoKey().Metadata.SetIsTableExcludedFromMigrations(true);
            modelBuilder.Entity<CRPC41CAmendmentMaterViewModel>().HasNoKey().Metadata.SetIsTableExcludedFromMigrations(true);
            modelBuilder.Entity<CCTVInstalledViewModel>().HasNoKey().Metadata.SetIsTableExcludedFromMigrations(true);
            modelBuilder.Entity<CCTVViewModel>().HasNoKey().Metadata.SetIsTableExcludedFromMigrations(true);
            modelBuilder.Entity<PoliceStationWisePendingApplicationViewModel>().HasNoKey().Metadata.SetIsTableExcludedFromMigrations(true);
            modelBuilder.Entity<PoliceStationWiseVehicalViewModel>().HasNoKey().Metadata.SetIsTableExcludedFromMigrations(true);
            modelBuilder.Entity<LaborInformationMasterViewModel>().HasNoKey().Metadata.SetIsTableExcludedFromMigrations(true);
            modelBuilder.Entity<StationaryMasterViewModel>().HasNoKey().Metadata.SetIsTableExcludedFromMigrations(true);
            modelBuilder.Entity<HistoryMissingagewiseViewModel>().HasNoKey().Metadata.SetIsTableExcludedFromMigrations(true);
            modelBuilder.Entity<MissingChildDetailsViewModel>().HasNoKey().Metadata.SetIsTableExcludedFromMigrations(true);
            modelBuilder.Entity<MCRDetailsViewModel>().HasNoKey().Metadata.SetIsTableExcludedFromMigrations(true);
            modelBuilder.Entity<DetainViewModel>().HasNoKey().Metadata.SetIsTableExcludedFromMigrations(true);
            modelBuilder.Entity<Visitation_CrimeBranchViewModel>().HasNoKey().Metadata.SetIsTableExcludedFromMigrations(true);
            modelBuilder.Entity<HistoryCurrentMissingViewModel>().HasNoKey().Metadata.SetIsTableExcludedFromMigrations(true);
            modelBuilder.Entity<VehicleCheckingMasterViewModel>().HasNoKey().Metadata.SetIsTableExcludedFromMigrations(true);
            modelBuilder.Entity<DcbPolicestationMasterViewModel>().HasNoKey().Metadata.SetIsTableExcludedFromMigrations(true);
            modelBuilder.Entity<CRPC41MasterViewModel>().HasNoKey().Metadata.SetIsTableExcludedFromMigrations(true);
            modelBuilder.Entity<NightRountPersonCountMasterViewModel>().HasNoKey().Metadata.SetIsTableExcludedFromMigrations(true);
            modelBuilder.Entity<NightEmployeeMasterViewModel>().HasNoKey().Metadata.SetIsTableExcludedFromMigrations(true);
            modelBuilder.Entity<LeaveApplicationMasterViewModel>().HasNoKey().Metadata.SetIsTableExcludedFromMigrations(true);
            modelBuilder.Entity<Samans_DetailsViewModel>().HasNoKey().Metadata.SetIsTableExcludedFromMigrations(true);
            modelBuilder.Entity<AtakayatiPaglaViewModel>().HasNoKey().Metadata.SetIsTableExcludedFromMigrations(true);
            modelBuilder.Entity<NightRound_HEKO_PO_ViewModel>().HasNoKey().Metadata.SetIsTableExcludedFromMigrations(true);
            modelBuilder.Entity<ProhibitionRaidCaseViewModel>().HasNoKey().Metadata.SetIsTableExcludedFromMigrations(true);
            modelBuilder.Entity<ProhibitionCrimeViewModel>().HasNoKey().Metadata.SetIsTableExcludedFromMigrations(true);
            modelBuilder.Entity<BandobastDetailsViewModel>().HasNoKey().Metadata.SetIsTableExcludedFromMigrations(true);
            modelBuilder.Entity<Bin_varsi_lashViewModel>().HasNoKey().Metadata.SetIsTableExcludedFromMigrations(true);
            modelBuilder.Entity<Form3AViewModel>().HasNoKey().Metadata.SetIsTableExcludedFromMigrations(true);
            modelBuilder.Entity<ProhibitionViewModel>().HasNoKey().Metadata.SetIsTableExcludedFromMigrations(true);
            modelBuilder.Entity<City_Crime_DetailsViewModel>().HasNoKey().Metadata.SetIsTableExcludedFromMigrations(true);
            modelBuilder.Entity<AtakayatiDetailsViewModel>().HasNoKey().Metadata.SetIsTableExcludedFromMigrations(true);
            modelBuilder.Entity<AtakayatiPaglaSummaryViewModel>().HasNoKey().Metadata.SetIsTableExcludedFromMigrations(true);
            modelBuilder.Entity<Part6CrimesViewModel>().HasNoKey().Metadata.SetIsTableExcludedFromMigrations(true);
            modelBuilder.Entity<Aksmat_DeathViewModel>().HasNoKey().Metadata.SetIsTableExcludedFromMigrations(true);
            modelBuilder.Entity<Login_UserNamePassWord_ViewModel>().HasNoKey().Metadata.SetIsTableExcludedFromMigrations(true);
            modelBuilder.Entity<NightRoundViewModel>().HasNoKey().Metadata.SetIsTableExcludedFromMigrations(true);
            modelBuilder.Entity<Part1_5CrimeViewModel>().HasNoKey().Metadata.SetIsTableExcludedFromMigrations(true);
            modelBuilder.Entity<DashboardCommonCityCount>().HasNoKey().Metadata.SetIsTableExcludedFromMigrations(true);
            modelBuilder.Entity<DashboardCommonTrafficCount>().HasNoKey().Metadata.SetIsTableExcludedFromMigrations(true);
            modelBuilder.Entity<DashboardCitySingalCount>().HasNoKey().Metadata.SetIsTableExcludedFromMigrations(true);
            modelBuilder.Entity<TrafficTotalAndAmount>().HasNoKey().Metadata.SetIsTableExcludedFromMigrations(true);
            modelBuilder.Entity<CrimeCountByDay>().HasNoKey().Metadata.SetIsTableExcludedFromMigrations(true);
            modelBuilder.Entity<ClaimUser>().HasNoKey().Metadata.SetIsTableExcludedFromMigrations(true);
            modelBuilder.Entity<AccusedInformationViewModel>().HasNoKey().Metadata.SetIsTableExcludedFromMigrations(true);
            modelBuilder.Entity<TrafficEmployeeViewModel>().HasNoKey().Metadata.SetIsTableExcludedFromMigrations(true);
            modelBuilder.Entity<Traffic_LeaveApplicationViewModel>().HasNoKey().Metadata.SetIsTableExcludedFromMigrations(true);

            modelBuilder.UseCollation("Latin1_General_CI_AI");

            modelBuilder.Entity<TblAccusedInformation>(entity =>
            {
                entity.Property(e => e.AccusedInformationId).ValueGeneratedNever();

                entity.HasOne(d => d.PoliceStation)
                    .WithMany(p => p.TblAccusedInformations)
                    .HasForeignKey(d => d.PoliceStationId)
                    .HasConstraintName(" FK_tblAccusedInformation_tblPoliceStationMaster");
            });

            modelBuilder.Entity<TblAdminCheckMaster>(entity =>
            {
                entity.HasOne(d => d.PoliceStation)
                    .WithMany(p => p.TblAdminCheckMasters)
                    .HasForeignKey(d => d.PoliceStationId)
                    .HasConstraintName(" FK_tblAdminCheckMaster_tblPoliceStationMaster");
            });

            modelBuilder.Entity<TblAdminWisePendingApplicationMaster>(entity =>
            {
                entity.HasOne(d => d.Kacheri)
                    .WithMany(p => p.TblAdminWisePendingApplicationMasters)
                    .HasForeignKey(d => d.KacheriId)
                    .HasConstraintName(" FK_tblAdminWisePendingApplicationMaster_tblkacheriMaster");

                entity.HasOne(d => d.PoliceStation)
                    .WithMany(p => p.TblAdminWisePendingApplicationMasters)
                    .HasForeignKey(d => d.PoliceStationId)
                    .HasConstraintName(" FK_tblAdminWisePendingApplicationMaster_tblPoliceStationMaster");
            });

            modelBuilder.Entity<TblAtakKarelEsam>(entity =>
            {
                entity.HasOne(d => d.PoliceStation)
                    .WithMany(p => p.TblAtakKarelEsams)
                    .HasForeignKey(d => d.PoliceStationId)
                    .HasConstraintName(" FK_tblAtakKarel_Esam_tblPoliceStationMaster");
            });

            modelBuilder.Entity<TblAtakayatiPagla>(entity =>
            {
                entity.Property(e => e.AtakayatiPagalaBackupId).ValueGeneratedNever();

                entity.HasOne(d => d.PoliceStation)
                    .WithMany(p => p.TblAtakayatiPaglas)
                    .HasForeignKey(d => d.PoliceStationId)
                    .HasConstraintName(" FK_tblAtakayatiPagla_tblPoliceStationMaster");
            });

            modelBuilder.Entity<TblAtakayatiPaglaSummary>(entity =>
            {
                entity.HasOne(d => d.IpcGpc)
                    .WithMany(p => p.TblAtakayatiPaglaSummaries)
                    .HasForeignKey(d => d.IpcGpcid)
                    .HasConstraintName(" FK_tblAtakayatiPaglaSummary_tblIPC_GPCMaster");

                entity.HasOne(d => d.PoliceStation)
                    .WithMany(p => p.TblAtakayatiPaglaSummaries)
                    .HasForeignKey(d => d.PoliceStationId)
                    .HasConstraintName(" FK_tblAtakayatiPaglaSummary_tblPoliceStationMaster");

                entity.HasOne(d => d.SubCategory)
                    .WithMany(p => p.TblAtakayatiPaglaSummaries)
                    .HasForeignKey(d => d.SubCategoryId)
                    .HasConstraintName(" FK_tblAtakayatiPaglaSummary_tblSubCategoryMaster");
            });

            modelBuilder.Entity<TblAtakayatidetail>(entity =>
            {
                entity.HasOne(d => d.PoliceStation)
                    .WithMany(p => p.TblAtakayatidetails)
                    .HasForeignKey(d => d.PoliceStationId)
                    .HasConstraintName(" FK_tblAtakayatidetails_tblPoliceStationMaster");

                entity.HasOne(d => d.SubCategory)
                    .WithMany(p => p.TblAtakayatidetails)
                    .HasForeignKey(d => d.SubCategoryId)
                    .HasConstraintName(" FK_tblAtakayatidetails_tblSubCategoryMaster");
            });

            modelBuilder.Entity<TblAtkayatiPagalaConsolidated>(entity =>
            {
                entity.HasOne(d => d.PoliceStation)
                    .WithMany(p => p.TblAtkayatiPagalaConsolidateds)
                    .HasForeignKey(d => d.PoliceStationId)
                    .HasConstraintName(" FK_tblAtkayatiPagalaConsolidated_tblPoliceStationMaster");
            });

            modelBuilder.Entity<TblAutoRickshawDetail>(entity =>
            {
                entity.HasOne(d => d.PoliceStation)
                    .WithMany(p => p.TblAutoRickshawDetails)
                    .HasForeignKey(d => d.PoliceStationId)
                    .HasConstraintName(" FK_tblAutoRickshawDetails_tblPoliceStationMaster");
            });

            modelBuilder.Entity<TblBandobastDetailMaster>(entity =>
            {
                entity.HasOne(d => d.BandobastType)
                    .WithMany(p => p.TblBandobastDetailMasters)
                    .HasForeignKey(d => d.BandobastTypeId)
                    .HasConstraintName(" FK_tblBandobastDetailMaster_tblBandobastTypeMaster");

                entity.HasOne(d => d.PoliceStation)
                    .WithMany(p => p.TblBandobastDetailMasters)
                    .HasForeignKey(d => d.PoliceStationId)
                    .HasConstraintName(" FK_tblBandobastDetailMaster_tblPoliceStationMaster1");
            });

            modelBuilder.Entity<TblCctvMaster>(entity =>
            {
                entity.HasOne(d => d.Equipments)
                    .WithMany(p => p.TblCctvMasters)
                    .HasForeignKey(d => d.EquipmentsId)
                    .HasConstraintName(" FK_tblCctvMaster_tblEquipments");

                entity.HasOne(d => d.PoliceStation)
                    .WithMany(p => p.TblCctvMasters)
                    .HasForeignKey(d => d.PoliceStationId)
                    .HasConstraintName(" FK_tblCctvMaster_tblPoliceStationMaster");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.TblCctvMasters)
                    .HasForeignKey(d => d.StatusId)
                    .HasConstraintName(" FK_tblCctvMaster_tblStatusMaster");
            });

            modelBuilder.Entity<TblCctvinstalled>(entity =>
            {
                entity.HasOne(d => d.PoliceStation)
                    .WithMany(p => p.TblCctvinstalleds)
                    .HasForeignKey(d => d.PoliceStationId)
                    .HasConstraintName(" FK_tbl_CCTVInstalled_tblPoliceStationMaster");
            });

            modelBuilder.Entity<TblChangeColor>(entity =>
            {
                entity.HasOne(d => d.Patrak)
                    .WithMany(p => p.TblChangeColors)
                    .HasForeignKey(d => d.PatrakId)
                    .HasConstraintName(" FK_tblChangeColor_tblIndexPatrakMaster");

                entity.HasOne(d => d.Policestation)
                    .WithMany(p => p.TblChangeColors)
                    .HasForeignKey(d => d.PolicestationId)
                    .HasConstraintName(" FK_tblChangeColor_tblPoliceStationMaster");
            });

            modelBuilder.Entity<TblCheckAnswerDetail>(entity =>
            {
                entity.Property(e => e.CheckAnswerId).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<TblCheckDetail>(entity =>
            {
                entity.Property(e => e.CheckId).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<TblCityMaster>(entity =>
            {
                entity.HasOne(d => d.State)
                    .WithMany(p => p.TblCityMasters)
                    .HasForeignKey(d => d.StateId)
                    .HasConstraintName(" FK_tblCityMaster_tblStateMaster");
            });

            modelBuilder.Entity<TblCriminalCountInformation>(entity =>
            {
                entity.HasOne(d => d.Category)
                    .WithMany(p => p.TblCriminalCountInformations)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName(" FK_tblCriminalCountInformation_tblCategoryMaster");

                entity.HasOne(d => d.PoliceStation)
                    .WithMany(p => p.TblCriminalCountInformations)
                    .HasForeignKey(d => d.PoliceStationId)
                    .HasConstraintName(" FK_tblCriminalCountInformation_tblPoliceStationMaster");
            });

            modelBuilder.Entity<TblCriminalInformation>(entity =>
            {
                entity.HasOne(d => d.Category)
                    .WithMany(p => p.TblCriminalInformations)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName(" FK_tblCriminalInformation_tblCategoryMaster");
            });

            modelBuilder.Entity<TblCrpc41camendmentMater>(entity =>
            {
                entity.HasOne(d => d.PoliceStation)
                    .WithMany(p => p.TblCrpc41camendmentMaters)
                    .HasForeignKey(d => d.PoliceStationId)
                    .HasConstraintName(" FK_tblCRPC41CAmendmentMater_tblPoliceStationMaster");
            });

            modelBuilder.Entity<TblCrpc41master>(entity =>
            {
                entity.HasOne(d => d.PoliceStation)
                    .WithMany(p => p.TblCrpc41masters)
                    .HasForeignKey(d => d.PoliceStationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName(" FK_tblCRPC41Master_tblPoliceStationMaster");
            });

            modelBuilder.Entity<TblCurrentYearAgeWiseMissingChildDetail>(entity =>
            {
                entity.HasOne(d => d.Category)
                    .WithMany(p => p.TblCurrentYearAgeWiseMissingChildDetails)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName(" FK_tblCurrentYearAgeWiseMissingChildDetails_tblCategoryMaster");

                entity.HasOne(d => d.Gender)
                    .WithMany(p => p.TblCurrentYearAgeWiseMissingChildDetails)
                    .HasForeignKey(d => d.GenderId)
                    .HasConstraintName(" FK_tblCurrentYearAgeWiseMissingChildDetails_tblGenderMaster");

                entity.HasOne(d => d.PoliceStation)
                    .WithMany(p => p.TblCurrentYearAgeWiseMissingChildDetails)
                    .HasForeignKey(d => d.PoliceStationId)
                    .HasConstraintName(" FK_tblCurrentYearAgeWiseMissingChildDetails_tblPoliceStationMaster");
            });

            modelBuilder.Entity<TblCurrentYearMissingChildDetail>(entity =>
            {
                entity.HasOne(d => d.Gender)
                    .WithMany(p => p.TblCurrentYearMissingChildDetails)
                    .HasForeignKey(d => d.GenderId)
                    .HasConstraintName(" FK_tblCurrentYearMissingChildDetails_tblGenderMaster");

                entity.HasOne(d => d.PoliceStation)
                    .WithMany(p => p.TblCurrentYearMissingChildDetails)
                    .HasForeignKey(d => d.PoliceStationId)
                    .HasConstraintName(" FK_tblCurrentYearMissingChildDetails_tblPoliceStationMaster");

                entity.HasOne(d => d.SubCategory)
                    .WithMany(p => p.TblCurrentYearMissingChildDetails)
                    .HasForeignKey(d => d.SubCategoryId)
                    .HasConstraintName(" FK_tblCurrentYearMissingChildDetails_tblSubCategoryMaster");
            });

            modelBuilder.Entity<TblDesignationName>(entity =>
            {
                entity.Property(e => e.DesignationId).ValueGeneratedNever();
            });

            modelBuilder.Entity<TblDistributeVehical>(entity =>
            {
                entity.HasOne(d => d.Category)
                    .WithMany(p => p.TblDistributeVehicals)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName(" FK_tblDistributeVehical_tblCategoryMaster");

                entity.HasOne(d => d.PoliceStation)
                    .WithMany(p => p.TblDistributeVehicals)
                    .HasForeignKey(d => d.PoliceStationId)
                    .HasConstraintName(" FK_tblDistributeVehical_tblPoliceStationMaster");
            });

            modelBuilder.Entity<TblDivisionMaster>(entity =>
            {
                entity.HasOne(d => d.Zone)
                    .WithMany(p => p.TblDivisionMasters)
                    .HasForeignKey(d => d.ZoneId)
                    .HasConstraintName(" FK_tblDivisionMaster_tblZoneMaster");
            });

            modelBuilder.Entity<TblEGujakopMaster>(entity =>
            {
                entity.HasOne(d => d.PoliceStation)
                    .WithMany(p => p.TblEGujakopMasters)
                    .HasForeignKey(d => d.PoliceStationId)
                    .HasConstraintName(" FK_tblE_GujakopMaster_tblPoliceStationMaster");
            });

            modelBuilder.Entity<TblEGujkopDetail>(entity =>
            {
                entity.HasOne(d => d.PoliceStation)
                    .WithMany(p => p.TblEGujkopDetails)
                    .HasForeignKey(d => d.PoliceStationId)
                    .HasConstraintName(" FK_tblE_GujkopDetails_tblPoliceStationMaster");
            });

            modelBuilder.Entity<TblEmployeeMaster>(entity =>
            {
                entity.Property(e => e.EmployeeId).ValueGeneratedNever();

                entity.HasOne(d => d.Designation)
                    .WithMany(p => p.TblEmployeeMasters)
                    .HasForeignKey(d => d.DesignationId)
                    .HasConstraintName(" FK_tblEmployeeMaster_tblDesignationName");

                entity.HasOne(d => d.Division)
                    .WithMany(p => p.TblEmployeeMasters)
                    .HasForeignKey(d => d.DivisionId)
                    .HasConstraintName(" FK_tblEmployeeMaster_tblDivisionMaster");

                entity.HasOne(d => d.PoliceStation)
                    .WithMany(p => p.TblEmployeeMasters)
                    .HasForeignKey(d => d.PoliceStationId)
                    .HasConstraintName(" FK_tblEmployeeMaster_tblPoliceStationMaster");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.TblEmployeeMasters)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName(" FK_tblEmployeeMaster_tblRoleMaster");

                entity.HasOne(d => d.Sector)
                    .WithMany(p => p.TblEmployeeMasters)
                    .HasForeignKey(d => d.SectorId)
                    .HasConstraintName(" FK_tblEmployeeMaster_tblSectorMaster");

                entity.HasOne(d => d.Zone)
                    .WithMany(p => p.TblEmployeeMasters)
                    .HasForeignKey(d => d.ZoneId)
                    .HasConstraintName(" FK_tblEmployeeMaster_tblZoneMaster");
            });

            modelBuilder.Entity<TblEmployeeMasterBackup>(entity =>
            {
                entity.HasOne(d => d.Designation)
                    .WithMany(p => p.TblEmployeeMasterBackups)
                    .HasForeignKey(d => d.DesignationId)
                    .HasConstraintName(" FK_tblEmployeeMasterBackup_tblDesignationName");

                entity.HasOne(d => d.Division)
                    .WithMany(p => p.TblEmployeeMasterBackups)
                    .HasForeignKey(d => d.DivisionId)
                    .HasConstraintName(" FK_tblEmployeeMasterBackup_tblDivisionMaster");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.TblEmployeeMasterBackups)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName(" FK_tblEmployeeMasterBackup_tblEmployeeMaster");

                entity.HasOne(d => d.PoliceStation)
                    .WithMany(p => p.TblEmployeeMasterBackups)
                    .HasForeignKey(d => d.PoliceStationId)
                    .HasConstraintName(" FK_tblEmployeeMasterBackup_tblPoliceStationMaster");

                entity.HasOne(d => d.Sector)
                    .WithMany(p => p.TblEmployeeMasterBackups)
                    .HasForeignKey(d => d.SectorId)
                    .HasConstraintName(" FK_tblEmployeeMasterBackup_tblSectorMaster");

                entity.HasOne(d => d.Zone)
                    .WithMany(p => p.TblEmployeeMasterBackups)
                    .HasForeignKey(d => d.ZoneId)
                    .HasConstraintName(" FK_tblEmployeeMasterBackup_tblZoneMaster");
            });

            modelBuilder.Entity<TblForm3A>(entity =>
            {
                entity.HasOne(d => d.PoliceStation)
                    .WithMany(p => p.TblForm3As)
                    .HasForeignKey(d => d.PoliceStationId)
                    .HasConstraintName(" FK_tblForm3A_tblPoliceStationMaster");
            });

            modelBuilder.Entity<TblForm5Master>(entity =>
            {
                entity.HasOne(d => d.PoliceStation)
                    .WithMany(p => p.TblForm5Masters)
                    .HasForeignKey(d => d.PoliceStationId)
                    .HasConstraintName(" FK_tblForm5Master_tblPoliceStationMaster");

                entity.HasOne(d => d.SubCategory)
                    .WithMany(p => p.TblForm5Masters)
                    .HasForeignKey(d => d.SubCategoryId)
                    .HasConstraintName(" FK_tblForm5Master_tblSubCategoryMaster");
            });

            modelBuilder.Entity<TblHistoryMissingAgeWiseChild>(entity =>
            {
                entity.HasOne(d => d.PoliceStation)
                    .WithMany(p => p.TblHistoryMissingAgeWiseChildren)
                    .HasForeignKey(d => d.PoliceStationId)
                    .HasConstraintName(" FK_tblHistoryMissingAgeWiseChild_tblPoliceStationMaster");
            });

            modelBuilder.Entity<TblIpcGpcmaster>(entity =>
            {
                entity.Property(e => e.IpcGpcid).ValueGeneratedNever();
            });

            modelBuilder.Entity<TblLaborInformationMaster>(entity =>
            {
                entity.HasOne(d => d.PoliceStation)
                    .WithMany(p => p.TblLaborInformationMasters)
                    .HasForeignKey(d => d.PoliceStationId)
                    .HasConstraintName(" FK_tblLaborInformationMaster_tblPoliceStationMaster");

                entity.HasOne(d => d.SubCategory)
                    .WithMany(p => p.TblLaborInformationMasters)
                    .HasForeignKey(d => d.SubCategoryId)
                    .HasConstraintName(" FK_tblLaborInformationMaster_tblSubCategoryMaster");
            });

            modelBuilder.Entity<TblLeaveApplicationMaster>(entity =>
            {
                entity.Property(e => e.LeaveApplicationId).ValueGeneratedNever();

                entity.HasOne(d => d.Designation)
                    .WithMany(p => p.TblLeaveApplicationMasterDesignations)
                    .HasForeignKey(d => d.DesignationId)
                    .HasConstraintName(" FK_tblLeaveApplicationMaster_tblDesignationName");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.TblLeaveApplicationMasters)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName(" FK_tblLeaveApplicationMaster_tblLeaveApplicationMaster");

                entity.HasOne(d => d.InchargeDesignation)
                    .WithMany(p => p.TblLeaveApplicationMasterInchargeDesignations)
                    .HasForeignKey(d => d.InchargeDesignationId)
                    .HasConstraintName(" FK_tblLeaveApplicationMaster_tblDesignationName1");

                entity.HasOne(d => d.InchargePoliceStation)
                    .WithMany(p => p.TblLeaveApplicationMasterInchargePoliceStations)
                    .HasForeignKey(d => d.InchargePoliceStationId)
                    .HasConstraintName(" FK_tblLeaveApplicationMaster_tblPoliceStationMaster1");

                entity.HasOne(d => d.PoliceStation)
                    .WithMany(p => p.TblLeaveApplicationMasterPoliceStations)
                    .HasForeignKey(d => d.PoliceStationId)
                    .HasConstraintName(" FK_tblLeaveApplicationMaster_tblPoliceStationMaster");
            });

            modelBuilder.Entity<TblLoginMasterMobile>(entity =>
            {
                entity.Property(e => e.LoginId).ValueGeneratedOnAdd();

                entity.HasOne(d => d.Designation)
                    .WithMany(p => p.TblLoginMasterMobiles)
                    .HasForeignKey(d => d.DesignationId)
                    .HasConstraintName(" FK_tblLoginMaster_Mobile_tblDesignationName");

                entity.HasOne(d => d.Division)
                    .WithMany(p => p.TblLoginMasterMobiles)
                    .HasForeignKey(d => d.DivisionId)
                    .HasConstraintName(" FK_tblLoginMaster_Mobile_tblDivisionMaster");

                entity.HasOne(d => d.PoliceStation)
                    .WithMany(p => p.TblLoginMasterMobiles)
                    .HasForeignKey(d => d.PoliceStationId)
                    .HasConstraintName(" FK_tblLoginMaster_Mobile_tblPoliceStationMaster");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.TblLoginMasterMobiles)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName(" FK_tblLoginMaster_Mobile_tblRoleMaster");

                entity.HasOne(d => d.Sector)
                    .WithMany(p => p.TblLoginMasterMobiles)
                    .HasForeignKey(d => d.SectorId)
                    .HasConstraintName(" FK_tblLoginMaster_Mobile_tblSectorMaster");

                entity.HasOne(d => d.Zone)
                    .WithMany(p => p.TblLoginMasterMobiles)
                    .HasForeignKey(d => d.ZoneId)
                    .HasConstraintName(" FK_tblLoginMaster_Mobile_tblZoneMaster");
            });

            modelBuilder.Entity<TblMahekamMaster>(entity =>
            {
                entity.HasOne(d => d.PoliceStation)
                    .WithMany(p => p.TblMahekamMasters)
                    .HasForeignKey(d => d.PoliceStationId)
                    .HasConstraintName(" FK_tblMahekamMaster_tblPoliceStationMaster");
            });

            modelBuilder.Entity<TblMcrdetail>(entity =>
            {
                entity.HasOne(d => d.PoliceStation)
                    .WithMany(p => p.TblMcrdetails)
                    .HasForeignKey(d => d.PoliceStationId)
                    .HasConstraintName(" FK_tblMCRDetails_tblPoliceStationMaster");
            });

            modelBuilder.Entity<TblMissingChildDetail>(entity =>
            {
                entity.HasOne(d => d.Gender)
                    .WithMany(p => p.TblMissingChildDetails)
                    .HasForeignKey(d => d.GenderId)
                    .HasConstraintName(" FK_tblMissingChildDetails_tblGenderMaster");

                entity.HasOne(d => d.PoliceStation)
                    .WithMany(p => p.TblMissingChildDetails)
                    .HasForeignKey(d => d.PoliceStationId)
                    .HasConstraintName(" FK_tblMissingChildDetails_tblPoliceStationMaster");
            });

            modelBuilder.Entity<TblMonthWiseReport>(entity =>
            {
                entity.HasOne(d => d.Category)
                    .WithMany(p => p.TblMonthWiseReports)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName(" FK_tblMonthWiseReport_tblCategoryMaster");
            });

            modelBuilder.Entity<TblNightEmployeeMaster>(entity =>
            {
                entity.Property(e => e.NightEmployeeId).ValueGeneratedNever();

                entity.HasOne(d => d.Designation)
                    .WithMany(p => p.TblNightEmployeeMasters)
                    .HasForeignKey(d => d.DesignationId)
                    .HasConstraintName(" FK_tblNightEmployeeMaster_tblDesignationName");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.TblNightEmployeeMasters)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName(" FK_tblNightEmployeeMaster_tblEmployeeMaster");

                entity.HasOne(d => d.PoliceStation)
                    .WithMany(p => p.TblNightEmployeeMasters)
                    .HasForeignKey(d => d.PoliceStationId)
                    .HasConstraintName(" FK_tblNightEmployeeMaster_tblPoliceStationMaster");
            });

            modelBuilder.Entity<TblNightRound>(entity =>
            {
                entity.Property(e => e.NightRoundId).ValueGeneratedNever();

                entity.HasOne(d => d.Division)
                    .WithMany(p => p.TblNightRounds)
                    .HasForeignKey(d => d.DivisionId)
                    .HasConstraintName(" FK_tblNightRound_tblDivisionMaster");

                entity.HasOne(d => d.PoliceStation)
                    .WithMany(p => p.TblNightRounds)
                    .HasForeignKey(d => d.PoliceStationId)
                    .HasConstraintName(" FK_tblNightRound_tblPoliceStationMaster");

                entity.HasOne(d => d.Sector)
                    .WithMany(p => p.TblNightRounds)
                    .HasForeignKey(d => d.SectorId)
                    .HasConstraintName(" FK_tblNightRound_tblSectorMaster");

                entity.HasOne(d => d.Zone)
                    .WithMany(p => p.TblNightRounds)
                    .HasForeignKey(d => d.ZoneId)
                    .HasConstraintName(" FK_tblNightRound_tblZoneMaster");
            });

            modelBuilder.Entity<TblNightRoundHekoPomaster>(entity =>
            {
                entity.HasOne(d => d.PoliceStation)
                    .WithMany(p => p.TblNightRoundHekoPomasters)
                    .HasForeignKey(d => d.PoliceStationId)
                    .HasConstraintName(" FK_tblNightRound_HEKO_POMaster_tblPoliceStationMaster");
            });

            modelBuilder.Entity<TblNightRountPersonCountMaster>(entity =>
            {
                entity.Property(e => e.NightRoundPersonCountId).ValueGeneratedNever();

                entity.HasOne(d => d.PoliceStation)
                    .WithMany(p => p.TblNightRountPersonCountMasters)
                    .HasForeignKey(d => d.PoliceStationId)
                    .HasConstraintName(" FK_tblNightRountPersonCountMaster_tblPoliceStationMaster");
            });

            modelBuilder.Entity<TblOfiiceWisePendingApplication>(entity =>
            {
                entity.HasOne(d => d.Category)
                    .WithMany(p => p.TblOfiiceWisePendingApplications)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName(" FK_tblOfiiceWisePendingApplication_tblCategoryMaster");

                entity.HasOne(d => d.PoliceStation)
                    .WithMany(p => p.TblOfiiceWisePendingApplications)
                    .HasForeignKey(d => d.PoliceStationId)
                    .HasConstraintName(" FK_tblOfiiceWisePendingApplication_tblPoliceStationMaster");
            });

            modelBuilder.Entity<TblPart1_5Crime>(entity =>
            {
                entity.Property(e => e.CrimesId).ValueGeneratedOnAdd();

                entity.HasOne(d => d.PoliceStation)
                    .WithMany()
                    .HasForeignKey(d => d.PoliceStationId)
                    .HasConstraintName(" FK_tblPart1_5_Crimes_tblPoliceStationMaster");

                entity.HasOne(d => d.SubCategory)
                    .WithMany()
                    .HasForeignKey(d => d.SubCategoryId)
                    .HasConstraintName(" FK_tblPart1_5_Crimes_tblSubCategoryMaster");
            });

            modelBuilder.Entity<TblPart16Counter>(entity =>
            {
                entity.Property(e => e.Part156Id).ValueGeneratedOnAdd();

                entity.HasOne(d => d.Category)
                    .WithMany()
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName(" FK_tblPart_1_6_Counter_tblCategoryMaster");

                entity.HasOne(d => d.Division)
                    .WithMany()
                    .HasForeignKey(d => d.DivisionId)
                    .HasConstraintName(" FK_tblPart_1_6_Counter_tblDivisionMaster");

                entity.HasOne(d => d.PoliceStation)
                    .WithMany()
                    .HasForeignKey(d => d.PoliceStationId)
                    .HasConstraintName(" FK_tblPart_1_6_Counter_tblPoliceStationMaster");

                entity.HasOne(d => d.Sector)
                    .WithMany()
                    .HasForeignKey(d => d.SectorId)
                    .HasConstraintName(" FK_tblPart_1_6_Counter_tblSectorMaster");

                entity.HasOne(d => d.SubCategory)
                    .WithMany()
                    .HasForeignKey(d => d.SubCategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName(" FK_tblPart_1_6_Counter_tblSubCategoryMaster");

                entity.HasOne(d => d.Zone)
                    .WithMany()
                    .HasForeignKey(d => d.ZoneId)
                    .HasConstraintName(" FK_tblPart_1_6_Counter_tblZoneMaster");
            });

            modelBuilder.Entity<TblPendingArjiDetail>(entity =>
            {
                entity.HasOne(d => d.PendingArjiCategory)
                    .WithMany(p => p.TblPendingArjiDetails)
                    .HasForeignKey(d => d.PendingArjiCategoryId)
                    .HasConstraintName(" FK_tblPendingArjiDetails_tblPendingArjiCategory");

                entity.HasOne(d => d.PoliceStation)
                    .WithMany(p => p.TblPendingArjiDetails)
                    .HasForeignKey(d => d.PoliceStationId)
                    .HasConstraintName(" FK_tblPendingArjiDetails_tblPoliceStationMaster");
            });

            modelBuilder.Entity<TblPendingArjiDetailsHist>(entity =>
            {
                entity.Property(e => e.PendingArjiDetailId).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<TblPendingWarrant>(entity =>
            {
                entity.HasOne(d => d.PoliceStation)
                    .WithMany()
                    .HasForeignKey(d => d.PoliceStationId)
                    .HasConstraintName(" FK_tblPendingWarrant_tblPoliceStationMaster");

                entity.HasOne(d => d.SubCategory)
                    .WithMany()
                    .HasForeignKey(d => d.SubCategoryId)
                    .HasConstraintName(" FK_tblPendingWarrant_tblSubCategoryMaster");
            });

            modelBuilder.Entity<TblPoliceStationMaster>(entity =>
            {
                entity.HasKey(e => e.PoliceStationId)
                    .HasName("PK_tblPoliceStationMaster_1");
            });

            modelBuilder.Entity<TblPoliceStationVehicleChecking>(entity =>
            {
                entity.Property(e => e.VehicleCheckingId).ValueGeneratedOnAdd();

                entity.HasOne(d => d.PoliceStation)
                    .WithMany()
                    .HasForeignKey(d => d.PoliceStationId)
                    .HasConstraintName(" FK_tblPoliceStation_VehicleChecking_tblPoliceStationMaster");

                entity.HasOne(d => d.SubCategory)
                    .WithMany()
                    .HasForeignKey(d => d.SubCategoryId)
                    .HasConstraintName(" FK_tblPoliceStation_VehicleChecking_tblSubCategoryMaster");
            });

            modelBuilder.Entity<TblPoliceStationWisePendingApplication>(entity =>
            {
                entity.Property(e => e.PoliceStationWisePendingApplicationId).ValueGeneratedOnAdd();

                entity.HasOne(d => d.Kacheri)
                    .WithMany()
                    .HasForeignKey(d => d.KacheriId)
                    .HasConstraintName(" FK_tblPoliceStationWisePendingApplication_tblkacheriMaster");

                entity.HasOne(d => d.PoliceStation)
                    .WithMany()
                    .HasForeignKey(d => d.PoliceStationId)
                    .HasConstraintName(" FK_tblPoliceStationWisePendingApplication_tblPoliceStationMaster");
            });

            modelBuilder.Entity<TblPoliceStationWiseVehical>(entity =>
            {
                entity.Property(e => e.PoliceStationwiseVehicalId).ValueGeneratedOnAdd();

                entity.HasOne(d => d.PoliceStation)
                    .WithMany()
                    .HasForeignKey(d => d.PoliceStationId)
                    .HasConstraintName(" FK_tblPoliceStationWiseVehical_tblPoliceStationMaster");
            });

            modelBuilder.Entity<TblProhibitionCrimeMaster>(entity =>
            {
                entity.HasOne(d => d.PoliceStation)
                    .WithMany(p => p.TblProhibitionCrimeMasters)
                    .HasForeignKey(d => d.PoliceStationId)
                    .HasConstraintName(" FK_tblProhibitionCrimeMaster_tblPoliceStationMaster1");
            });

            modelBuilder.Entity<TblProhibitionCrimeMasterCopy>(entity =>
            {
                entity.HasOne(d => d.PoliceStation)
                    .WithMany(p => p.TblProhibitionCrimeMasterCopies)
                    .HasForeignKey(d => d.PoliceStationId)
                    .HasConstraintName(" FK_tblProhibitionCrimeMaster_Copy_tblPoliceStationMaster");
            });

            modelBuilder.Entity<TblProhibitionRaidCase>(entity =>
            {
                entity.HasOne(d => d.Category)
                    .WithMany(p => p.TblProhibitionRaidCases)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName(" FK_tbl_ProhibitionRaidCase_tblCategoryMaster");

                entity.HasOne(d => d.PoliceStation)
                    .WithMany(p => p.TblProhibitionRaidCases)
                    .HasForeignKey(d => d.PoliceStationId)
                    .HasConstraintName(" FK_tbl_ProhibitionRaidCase_tblPoliceStationMaster");
            });

            modelBuilder.Entity<TblSamansDetail>(entity =>
            {
                entity.HasOne(d => d.Category)
                    .WithMany(p => p.TblSamansDetails)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName(" FK_tbl_samans_details_tblCategoryMaster");

                entity.HasOne(d => d.PoliceStation)
                    .WithMany(p => p.TblSamansDetails)
                    .HasForeignKey(d => d.PoliceStationId)
                    .HasConstraintName(" FK_tbl_samans_details_tblPoliceStationMaster");
            });

            modelBuilder.Entity<TblSamansDetailsHit>(entity =>
            {
                entity.Property(e => e.SamansId).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<TblSamelPatrakMaster>(entity =>
            {
                entity.HasOne(d => d.Patrak)
                    .WithMany(p => p.TblSamelPatrakMasters)
                    .HasForeignKey(d => d.PatrakId)
                    .HasConstraintName(" FK_tblSamelPatrakMaster_tblSamelCategoryMaster");

                entity.HasOne(d => d.PoliceStation)
                    .WithMany(p => p.TblSamelPatrakMasters)
                    .HasForeignKey(d => d.PoliceStationId)
                    .HasConstraintName(" FK_tblSamelPatrakMaster_tblPoliceStationMaster");
            });

            modelBuilder.Entity<TblSectorMaster>(entity =>
            {
                entity.HasOne(d => d.City)
                    .WithMany(p => p.TblSectorMasters)
                    .HasForeignKey(d => d.CityId)
                    .HasConstraintName(" FK_tblSectorMaster_tblCityMaster");
            });

            modelBuilder.Entity<TblStationery>(entity =>
            {
                entity.HasOne(d => d.PoliceStation)
                    .WithMany(p => p.TblStationeries)
                    .HasForeignKey(d => d.PoliceStationId)
                    .HasConstraintName(" FK_tblStationery_tblPoliceStationMaster");
            });

            modelBuilder.Entity<TblSubCategoryMaster>(entity =>
            {
                entity.HasOne(d => d.Category)
                    .WithMany(p => p.TblSubCategoryMasters)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName(" FK_tblSubCategoryMaster_tblCategoryMaster");
            });

            modelBuilder.Entity<TblTrafficAccidentalDetail>(entity =>
            {
                entity.Property(e => e.TrafficAccidentalId).ValueGeneratedNever();
            });

            modelBuilder.Entity<TblTrafficCrainMaster>(entity =>
            {
                entity.Property(e => e.TrafficCrainId).ValueGeneratedNever();
            });

            modelBuilder.Entity<TblTrafficCrainWorkMaster>(entity =>
            {
                entity.HasOne(d => d.TrafficCrain)
                    .WithMany(p => p.TblTrafficCrainWorkMasters)
                    .HasForeignKey(d => d.TrafficCrainId)
                    .HasConstraintName(" FK_tblTrafficCrainWorkMaster_tblTrafficCrainMaster");
            });

            modelBuilder.Entity<TblTrafficDriveMaster>(entity =>
            {
                entity.HasOne(d => d.TrafficDriveCatgeory)
                    .WithMany(p => p.TblTrafficDriveMasters)
                    .HasForeignKey(d => d.TrafficDriveCatgeoryId)
                    .HasConstraintName(" FK_tblTrafficDriveMaster_tblTrafficDriveCategoryMaster1");
            });

            modelBuilder.Entity<TblTrafficInterceptSubCategoryMaster>(entity =>
            {
                entity.HasOne(d => d.TrafficInterceptCategory)
                    .WithMany(p => p.TblTrafficInterceptSubCategoryMasters)
                    .HasForeignKey(d => d.TrafficInterceptCategoryId)
                    .HasConstraintName(" FK_tblTrafficInterceptSubCategoryMaster_tblTrafficInterceptCategoryMaster");
            });

            modelBuilder.Entity<TblTrafficIpc283Hist>(entity =>
            {
                entity.Property(e => e.TrafficIpcid).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<TblTrafficPlaceFineDetail>(entity =>
            {
                entity.HasOne(d => d.TrafficCategory)
                    .WithMany(p => p.TblTrafficPlaceFineDetails)
                    .HasForeignKey(d => d.TrafficCategoryId)
                    .HasConstraintName(" FK_tblTrafficPlaceFineDetails_tblTraffiCategoryMaster");
            });

            modelBuilder.Entity<TblTrafficPlaceFineDetailsJet>(entity =>
            {
                entity.HasOne(d => d.TrafficCategory)
                    .WithMany(p => p.TblTrafficPlaceFineDetailsJets)
                    .HasForeignKey(d => d.TrafficCategoryId)
                    .HasConstraintName(" FK_tblTrafficPlaceFineDetailsJET_tblTraffiCategoryMaster");

                entity.HasOne(d => d.Ward)
                    .WithMany(p => p.TblTrafficPlaceFineDetailsJets)
                    .HasForeignKey(d => d.WardId)
                    .HasConstraintName(" FK_tblTrafficPlaceFineDetailsJET_tblWardMaster");

                entity.HasOne(d => d.WheelerType)
                    .WithMany(p => p.TblTrafficPlaceFineDetailsJets)
                    .HasForeignKey(d => d.WheelerTypeId)
                    .HasConstraintName(" FK_tblTrafficPlaceFineDetailsJET_tblWheelerType");
            });

            modelBuilder.Entity<TblTrafficPlaceFineDetailsJetNull>(entity =>
            {
                entity.HasOne(d => d.TrafficCategory)
                    .WithMany(p => p.TblTrafficPlaceFineDetailsJetNulls)
                    .HasForeignKey(d => d.TrafficCategoryId)
                    .HasConstraintName(" FK_tblTrafficPlaceFineDetailsJET_NULL_tblTraffiCategoryMaster");

                entity.HasOne(d => d.Ward)
                    .WithMany(p => p.TblTrafficPlaceFineDetailsJetNulls)
                    .HasForeignKey(d => d.WardId)
                    .HasConstraintName(" FK_tblTrafficPlaceFineDetailsJET_NULL_tblWardMaster");

                entity.HasOne(d => d.WheelerType)
                    .WithMany(p => p.TblTrafficPlaceFineDetailsJetNulls)
                    .HasForeignKey(d => d.WheelerTypeId)
                    .HasConstraintName(" FK_tblTrafficPlaceFineDetailsJET_NULL_tblWheelerType");
            });

            modelBuilder.Entity<TblTrafficPlaceFineMaster>(entity =>
            {
                entity.HasOne(d => d.PoliceStation)
                    .WithMany(p => p.TblTrafficPlaceFineMasters)
                    .HasForeignKey(d => d.PoliceStationId)
                    .HasConstraintName(" FK_tblTrafficPlaceFineMaster_tblPoliceStationMaster");
            });

            modelBuilder.Entity<TblTrafficPlaceItdetail>(entity =>
            {
                entity.HasOne(d => d.TrafficCategory)
                    .WithMany(p => p.TblTrafficPlaceItdetails)
                    .HasForeignKey(d => d.TrafficCategoryId)
                    .HasConstraintName(" FK_tblTrafficPlaceITDetails_tblTraffiCategoryMaster");

                entity.HasOne(d => d.WheelerType)
                    .WithMany(p => p.TblTrafficPlaceItdetails)
                    .HasForeignKey(d => d.WheelerTypeId)
                    .HasConstraintName(" FK_tblTrafficPlaceITDetails_tblWheelerType");
            });

            modelBuilder.Entity<TblTrafficPlaceItdetailsNull>(entity =>
            {
                entity.Property(e => e.InterTfName).IsFixedLength();
            });

            modelBuilder.Entity<TblTrafficSignalBlinkerigh>(entity =>
            {
                entity.HasOne(d => d.PoliceStation)
                    .WithMany(p => p.TblTrafficSignalBlinkerighs)
                    .HasForeignKey(d => d.PoliceStationId)
                    .HasConstraintName(" FK_tblTrafficSignalBlinkerigh_tblPoliceStationMaster");
            });

            modelBuilder.Entity<TblTrafficSignalMaster>(entity =>
            {
                entity.HasOne(d => d.PoliceStation)
                    .WithMany(p => p.TblTrafficSignalMasters)
                    .HasForeignKey(d => d.PoliceStationId)
                    .HasConstraintName(" FK_tblTrafficSignalMaster_tblPoliceStationMaster");
            });

            modelBuilder.Entity<TblTrafficSummaryDetail>(entity =>
            {
                entity.HasOne(d => d.PoliceStation)
                    .WithMany(p => p.TblTrafficSummaryDetails)
                    .HasForeignKey(d => d.PoliceStationId)
                    .HasConstraintName(" FK_tblTrafficSummaryDetails_tblPoliceStationMaster");
            });

            modelBuilder.Entity<TblTrafficTobacoMaster>(entity =>
            {
                entity.HasOne(d => d.PoliceStation)
                    .WithMany(p => p.TblTrafficTobacoMasters)
                    .HasForeignKey(d => d.PoliceStationId)
                    .HasConstraintName(" FK_tblTrafficTobacoMaster_tblPoliceStationMaster");
            });

            modelBuilder.Entity<TblTrafficTrbHomeGuardMaster>(entity =>
            {
                entity.Property(e => e.TrafficTrbHomeGuardId).ValueGeneratedNever();

                entity.HasOne(d => d.PoliceStation)
                    .WithMany(p => p.TblTrafficTrbHomeGuardMasters)
                    .HasForeignKey(d => d.PoliceStationId)
                    .HasConstraintName(" FK_tblTraffic_TRB_HomeGuard_Master_tblPoliceStationMaster");
            });

            modelBuilder.Entity<TblTrafficTrgAhgMaster>(entity =>
            {
                entity.HasOne(d => d.PoliceStation)
                    .WithMany(p => p.TblTrafficTrgAhgMasters)
                    .HasForeignKey(d => d.PoliceStationId)
                    .HasConstraintName(" FK_tblTraffic_TRG_AHG_Master_tblPoliceStationMaster");
            });

            modelBuilder.Entity<TblVehicleMaster>(entity =>
            {
                entity.HasOne(d => d.Category)
                    .WithMany(p => p.TblVehicleMasters)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName(" FK_tblVehicleMaster_tblCategoryMaster");
            });

            modelBuilder.Entity<TblVisitationCrimeBranch>(entity =>
            {
                entity.HasOne(d => d.PoliceStation)
                    .WithMany(p => p.TblVisitationCrimeBranches)
                    .HasForeignKey(d => d.PoliceStationId)
                    .HasConstraintName(" FK_tblVisitation_CrimeBranch_tblPoliceStationMaster");
            });

            modelBuilder.Entity<TblWardWiseJetDetail>(entity =>
            {
                entity.HasOne(d => d.Ward)
                    .WithMany(p => p.TblWardWiseJetDetails)
                    .HasForeignKey(d => d.WardId)
                    .HasConstraintName(" FK_tblWardWiseJetDetails_tblWardMaster");
            });

            modelBuilder.Entity<TblWheelerType>(entity =>
            {
                entity.Property(e => e.WheelerTypeId).ValueGeneratedNever();
            });

            modelBuilder.Entity<TbladhibitMaster>(entity =>
            {
                entity.HasOne(d => d.PoliceStation)
                    .WithMany(p => p.TbladhibitMasters)
                    .HasForeignKey(d => d.PoliceStationId)
                    .HasConstraintName(" FK_tbladhibitMaster_tblPoliceStationMaster");
            });

            modelBuilder.Entity<TbldetainMaster>(entity =>
            {
                entity.HasOne(d => d.PoliceStation)
                    .WithMany(p => p.TbldetainMasters)
                    .HasForeignKey(d => d.PoliceStationId)
                    .HasConstraintName(" FK_tbldetainMaster_tblPoliceStationMaster");

                entity.HasOne(d => d.SubCategory)
                    .WithMany(p => p.TbldetainMasters)
                    .HasForeignKey(d => d.SubCategoryId)
                    .HasConstraintName(" FK_tbldetainMaster_tblSubCategoryMaster");
            });

            modelBuilder.Entity<TblhistroryOfCurrentMissing>(entity =>
            {
                entity.HasOne(d => d.PoliceStation)
                    .WithMany(p => p.TblhistroryOfCurrentMissings)
                    .HasForeignKey(d => d.PoliceStationId)
                    .HasConstraintName(" FK_tblhistroryOfCurrentMissing_tblPoliceStationMaster");
            });

            modelBuilder.Entity<TblpendingjanvajogMaster>(entity =>
            {
                entity.HasOne(d => d.PoliceStation)
                    .WithMany(p => p.TblpendingjanvajogMasters)
                    .HasForeignKey(d => d.PoliceStationId)
                    .HasConstraintName(" FK_tblpendingjanvajogMaster_tblPoliceStationMaster");
            });

            modelBuilder.Entity<ViewAdminCheckMaster>(entity =>
            {
                entity.ToView("View_AdminCheckMaster");
            });

            modelBuilder.Entity<ViewCategorySubcategoryDailyReport>(entity =>
            {
                entity.ToView("View_Category_Subcategory_DailyReport");
            });

            modelBuilder.Entity<ViewCctvSel>(entity =>
            {
                entity.ToView("View_CCTV_SEL");
            });

            modelBuilder.Entity<ViewCrpc41masterSel>(entity =>
            {
                entity.ToView("View_CRPC41Master_SEL");
            });

            modelBuilder.Entity<ViewCurrentYearAgeWiseMissingChildDetailsDailyReport>(entity =>
            {
                entity.ToView("View_CurrentYearAgeWiseMissingChildDetails_DailyReport");
            });

            modelBuilder.Entity<ViewCurrentYearAgeWiseMissingChildDetailsSel>(entity =>
            {
                entity.ToView("View_CurrentYearAgeWiseMissingChildDetails_SEL");
            });

            modelBuilder.Entity<ViewDesignationNameSector>(entity =>
            {
                entity.ToView("View_DesignationName_Sector");
            });

            modelBuilder.Entity<ViewEmployeeMasterSel>(entity =>
            {
                entity.ToView("View_Employee_Master_SEL");
            });

            modelBuilder.Entity<ViewEmployeeMasterSel1>(entity =>
            {
                entity.ToView("View_EmployeeMaster_SEL");
            });

            modelBuilder.Entity<ViewForm9ASel>(entity =>
            {
                entity.ToView("View_form9_A_SEL");
            });

            modelBuilder.Entity<ViewHistroryOfCurrentMissingSel>(entity =>
            {
                entity.ToView("View_histroryOfCurrentMissing_SEL");
            });

            modelBuilder.Entity<ViewJaminSamansSel>(entity =>
            {
                entity.ToView("View_Jamin_Samans_SEL");
            });

            modelBuilder.Entity<ViewLoginPoliceStationWiseSel>(entity =>
            {
                entity.ToView("View_Login_PoliceStationWise_SEL");
            });

            modelBuilder.Entity<ViewMahekamNightRoundSel>(entity =>
            {
                entity.ToView("View_mahekamNightRound_SEL");
            });

            modelBuilder.Entity<ViewMahekamPolicestationMasterSel>(entity =>
            {
                entity.ToView("View_Mahekam_PolicestationMaster_SEL");
            });

            modelBuilder.Entity<ViewMissingChildDetailsSel>(entity =>
            {
                entity.ToView("View_MissingChildDetails_SEL");
            });

            modelBuilder.Entity<ViewMonthWiseReportSel>(entity =>
            {
                entity.ToView("View_MonthWiseReport_SEL");

                entity.Property(e => e.MonthWiseReportId).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<ViewNightRoundSel>(entity =>
            {
                entity.ToView("View_NightRound_SEL");
            });

            modelBuilder.Entity<ViewPart15DetailsSel>(entity =>
            {
                entity.ToView("View_Part1_5_Details_SEL");
            });

            modelBuilder.Entity<ViewPendingWarrentSel>(entity =>
            {
                entity.ToView("View_PendingWarrent_SEL");
            });

            modelBuilder.Entity<ViewPoliceStationVehicalSel>(entity =>
            {
                entity.ToView("View_PoliceStation_Vehical_SEL");
            });

            modelBuilder.Entity<ViewReport19Sel>(entity =>
            {
                entity.ToView("View_REPORT(19)_SEL");
            });

            modelBuilder.Entity<ViewReportspart15crime>(entity =>
            {
                entity.ToView("View_reportspart1_5crime");
            });

            modelBuilder.Entity<ViewSectorZoneDivisionPolice>(entity =>
            {
                entity.ToView("View_Sector_Zone_Division_Police");
            });

            modelBuilder.Entity<ViewSectorZoneDivisionPoliceStation>(entity =>
            {
                entity.ToView("View_Sector_ZOne_Division_PoliceStation");
            });

            modelBuilder.Entity<ViewTblAccusedInformationSel>(entity =>
            {
                entity.ToView("View_tblAccusedInformation_SEL");
            });

            modelBuilder.Entity<ViewTblAdhibitDetail>(entity =>
            {
                entity.ToView("View_tblAdhibit_Details");
            });

            modelBuilder.Entity<ViewTblAtakatiPagalaConsolidatedAll>(entity =>
            {
                entity.ToView("View_tblAtakatiPagalaConsolidated_ALL");
            });

            modelBuilder.Entity<ViewTblAtakatiPagalaConsolidatedDisplay>(entity =>
            {
                entity.ToView("View_tblAtakatiPagalaConsolidated_Display");
            });

            modelBuilder.Entity<ViewTblAtakayatiPaglaSummarySel>(entity =>
            {
                entity.ToView("View_tblAtakayatiPaglaSummary_SEL");
            });

            modelBuilder.Entity<ViewTblAtakayatidetailsSel>(entity =>
            {
                entity.ToView("View_tblAtakayatidetails_SEL");
            });

            modelBuilder.Entity<ViewTblAtakayatipaglaSel>(entity =>
            {
                entity.ToView("View_tblAtakayatipagla_SEL");
            });

            modelBuilder.Entity<ViewTblAtkayatiPaglaDivisionPolicestation>(entity =>
            {
                entity.ToView("View_tblAtkayatiPagla_Division_Policestation");
            });

            modelBuilder.Entity<ViewTblAutoRickshawDetailsSel>(entity =>
            {
                entity.ToView("View_tblAutoRickshawDetails_SEL");
            });

            modelBuilder.Entity<ViewTblBandobastDetailsSel>(entity =>
            {
                entity.ToView("View_tblBandobastDetails_SEL");
            });

            modelBuilder.Entity<ViewTblCctvinstalledSel>(entity =>
            {
                entity.ToView("View_tblCCTVInstalled_SEL");
            });

            modelBuilder.Entity<ViewTblCityMaster>(entity =>
            {
                entity.ToView("View_tblCityMaster");
            });

            modelBuilder.Entity<ViewTblCriminalCountInformationSel>(entity =>
            {
                entity.ToView("View_tblCriminalCountInformation_SEL");
            });

            modelBuilder.Entity<ViewTblCriminalInformationSel>(entity =>
            {
                entity.ToView("View_tblCriminalInformation_SEL");
            });

            modelBuilder.Entity<ViewTblCrpc41camendmentMaterSel>(entity =>
            {
                entity.ToView("View_tblCRPC41CAmendmentMater_SEL");
            });

            modelBuilder.Entity<ViewTblCurrentYearMissingChildPolicestationCategoryGenderMasterSel>(entity =>
            {
                entity.ToView("View_tblCurrentYearMissingChild_Policestation_Category_GenderMaster_SEL");
            });

            modelBuilder.Entity<ViewTblDistributeVehicalSel>(entity =>
            {
                entity.ToView("View_tblDistributeVehical_SEL");
            });

            modelBuilder.Entity<ViewTblDivisionMaster>(entity =>
            {
                entity.ToView("View_tblDivisionMaster");
            });

            modelBuilder.Entity<ViewTblDivisionMasterSel>(entity =>
            {
                entity.ToView("View_tblDivisionMaster_SEL");

                entity.Property(e => e.DivisionId).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<ViewTblEGujakopMasterSel>(entity =>
            {
                entity.ToView("View_tblE_GujakopMaster_SEL");
            });

            modelBuilder.Entity<ViewTblEGujkopDetailsSel>(entity =>
            {
                entity.ToView("View_tblE_GujkopDetails_SEL");
            });

            modelBuilder.Entity<ViewTblForm3ASel>(entity =>
            {
                entity.ToView("View_tblForm3A_SEL");
            });

            modelBuilder.Entity<ViewTblIndexPatrakDetail>(entity =>
            {
                entity.ToView("View_tblIndexPatrak_details");
            });

            modelBuilder.Entity<ViewTblLaborInformationMasterSel>(entity =>
            {
                entity.ToView("View_tblLaborInformationMaster_SEL");
            });

            modelBuilder.Entity<ViewTblLeaveApplicationLeavePoliceStation>(entity =>
            {
                entity.ToView("View_tblLeaveApplication_Leave_PoliceStation");
            });

            modelBuilder.Entity<ViewTblLeaveApplicationLeaveTypePolicestationDesignationEmployeeMasterSel>(entity =>
            {
                entity.ToView("View_tblLeaveApplication_LeaveType_Policestation_Designation_EmployeeMaster_SEL");
            });

            modelBuilder.Entity<ViewTblLoginAuthenticationDetail>(entity =>
            {
                entity.ToView("View_tblLoginAuthentication_Details");
            });

            modelBuilder.Entity<ViewTblMcrdetailsSel>(entity =>
            {
                entity.ToView("View_tblMCRDetails_SEL");
            });

            modelBuilder.Entity<ViewTblMissingChildDetailsPolicestationGenderMasterSel>(entity =>
            {
                entity.ToView("View_tblMissingChildDetails_Policestation_GenderMaster_SEL");
            });

            modelBuilder.Entity<ViewTblNightEmployeeSel>(entity =>
            {
                entity.ToView("View_tblNightEmployee_SEL");
            });

            modelBuilder.Entity<ViewTblNightRoundHekoPomasterSel>(entity =>
            {
                entity.ToView("View_tblNightRound_HEKO_POMaster_SEL");
            });

            modelBuilder.Entity<ViewTblNightRoundPersonCountMasterSel>(entity =>
            {
                entity.ToView("View_tblNightRoundPersonCountMaster_SEL");
            });

            modelBuilder.Entity<ViewTblNightRoundSel>(entity =>
            {
                entity.ToView("View_tblNightRound_SEL");
            });

            modelBuilder.Entity<ViewTblOfficeWisePendingApplicationSel>(entity =>
            {
                entity.ToView("View_tblOfficeWisePendingApplication_SEL");
            });

            modelBuilder.Entity<ViewTblPart15CrimesCountsOnly>(entity =>
            {
                entity.ToView("View_tblPart1_5_Crimes_Counts_Only");
            });

            modelBuilder.Entity<ViewTblPart15CrimesSel>(entity =>
            {
                entity.ToView("View_tblPart1_5_Crimes_SEL");
            });

            modelBuilder.Entity<ViewTblPendingArjiDetailsSel>(entity =>
            {
                entity.ToView("View_tblPendingArjiDetails_SEL");
            });

            modelBuilder.Entity<ViewTblPlaceFineForNull>(entity =>
            {
                entity.ToView("View_tblPlaceFineFor_Null");
            });

            modelBuilder.Entity<ViewTblPlaceFineForNullJet>(entity =>
            {
                entity.ToView("View_tblPlaceFineFor_Null_JET");
            });

            modelBuilder.Entity<ViewTblPlaceFineItforNull>(entity =>
            {
                entity.ToView("View_tblPlaceFineITFor_Null");

                entity.Property(e => e.InterTfName).IsFixedLength();
            });

            modelBuilder.Entity<ViewTblPlaceFineJetDetail>(entity =>
            {
                entity.ToView("View_tblPlaceFineJet_Details");
            });

            modelBuilder.Entity<ViewTblPlaceFineJetNull>(entity =>
            {
                entity.ToView("View_tblPlaceFineJET_NULL");
            });

            modelBuilder.Entity<ViewTblPoliceStationMaster>(entity =>
            {
                entity.ToView("View_tblPoliceStationMaster");
            });

            modelBuilder.Entity<ViewTblPoliceStationMasterSel>(entity =>
            {
                entity.ToView("View_tblPoliceStationMaster_SEL");
            });

            modelBuilder.Entity<ViewTblPoliceStationWiseEmployeeSel>(entity =>
            {
                entity.ToView("View_tblPoliceStationWise_Employee_SEL");
            });

            modelBuilder.Entity<ViewTblPoliceStationWiseVehicalSel>(entity =>
            {
                entity.ToView("View_tblPoliceStationWiseVehical_SEL");
            });

            modelBuilder.Entity<ViewTblProhibitionCrimeMasterSel>(entity =>
            {
                entity.ToView("View_tblProhibitionCrimeMaster_SEL");
            });

            modelBuilder.Entity<ViewTblProhibitionRaidCaseSel>(entity =>
            {
                entity.ToView("view_tbl_ProhibitionRaidCase_SEL");
            });

            modelBuilder.Entity<ViewTblSectorMaster>(entity =>
            {
                entity.ToView("View_tblSectorMaster");
            });

            modelBuilder.Entity<ViewTblSectorMasterSel>(entity =>
            {
                entity.ToView("View_tblSectorMaster_SEL");

                entity.Property(e => e.SectorId).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<ViewTblStationerySel>(entity =>
            {
                entity.ToView("View_tblStationery_SEL");
            });

            modelBuilder.Entity<ViewTblSubCategoryMaster>(entity =>
            {
                entity.ToView("View_tblSubCategoryMaster");
            });

            modelBuilder.Entity<ViewTblTrafficAccidentalDetailsSel>(entity =>
            {
                entity.ToView("View_tblTrafficAccidentalDetails_SEL");
            });

            modelBuilder.Entity<ViewTblTrafficCategoryItmassterBlank>(entity =>
            {
                entity.ToView("View_tblTrafficCategoryITMasster_Blank");

                entity.Property(e => e.InterTfName).IsFixedLength();
            });

            modelBuilder.Entity<ViewTblTrafficCategoryMassterBlank>(entity =>
            {
                entity.ToView("View_tblTrafficCategoryMasster_Blank");
            });

            modelBuilder.Entity<ViewTblTrafficCrainMasterSel>(entity =>
            {
                entity.ToView("View_tblTrafficCrainMaster_SEL");
            });

            modelBuilder.Entity<ViewTblTrafficCrainWorkMasterSel>(entity =>
            {
                entity.ToView("View_tblTrafficCrainWorkMaster_SEL");
            });

            modelBuilder.Entity<ViewTblTrafficDriveMaster>(entity =>
            {
                entity.ToView("View_tblTrafficDriveMaster");
            });

            modelBuilder.Entity<ViewTblTrafficGhasCharaMasterSel>(entity =>
            {
                entity.ToView("View_tblTrafficGhasCharaMaster_SEL");
            });

            modelBuilder.Entity<ViewTblTrafficInterceptSubCategoryMasterSel>(entity =>
            {
                entity.ToView("View_tblTrafficInterceptSubCategoryMaster_SEL");
            });

            modelBuilder.Entity<ViewTblTrafficInterceptWorkDetailsSel>(entity =>
            {
                entity.ToView("View_tblTrafficInterceptWorkDetails_SEL");
            });

            modelBuilder.Entity<ViewTblTrafficIpc188Sel>(entity =>
            {
                entity.ToView("View_tblTrafficIPC_188_SEL");
            });

            modelBuilder.Entity<ViewTblTrafficIpc283Sel>(entity =>
            {
                entity.ToView("View_tblTrafficIPC_283_SEL");
            });

            modelBuilder.Entity<ViewTblTrafficJamDetailsNew>(entity =>
            {
                entity.ToView("View_tblTrafficJam_Details_New");
            });

            modelBuilder.Entity<ViewTblTrafficMahekamMasterSel>(entity =>
            {
                entity.ToView("View_tblTrafficMahekamMaster_SEL");
            });

            modelBuilder.Entity<ViewTblTrafficMvactdetailsSel>(entity =>
            {
                entity.ToView("View_tblTrafficMVACTDetails_SEL");
            });

            modelBuilder.Entity<ViewTblTrafficPart15Detail>(entity =>
            {
                entity.ToView("View_tblTrafficPart1_5_Details");
            });

            modelBuilder.Entity<ViewTblTrafficPlaceFineDetailsWheelerType>(entity =>
            {
                entity.ToView("View_tblTrafficPlaceFineDetails_WheelerType");
            });

            modelBuilder.Entity<ViewTblTrafficPlaceFineMasterSel>(entity =>
            {
                entity.ToView("View_tblTrafficPlaceFineMaster_SEL");
            });

            modelBuilder.Entity<ViewTblTrafficPlaceItfineDetailsWheelerType>(entity =>
            {
                entity.ToView("View_tblTrafficPlaceITFineDetails_WheelerType");
            });

            modelBuilder.Entity<ViewTblTrafficSignalBlinkRightSel>(entity =>
            {
                entity.ToView("View_tblTrafficSignalBlinkRight_SEL");
            });

            modelBuilder.Entity<ViewTblTrafficSignalMasterSel>(entity =>
            {
                entity.ToView("View_tblTrafficSignalMaster_SEL");
            });

            modelBuilder.Entity<ViewTblTrafficSummaryDetailsCategoryWise>(entity =>
            {
                entity.ToView("View_tblTrafficSummaryDetails_CategoryWise");
            });

            modelBuilder.Entity<ViewTblTrafficTobacoMasterSel>(entity =>
            {
                entity.ToView("View_tblTrafficTobacoMaster_SEL");
            });

            modelBuilder.Entity<ViewTblTrafficTrbHomeGuardMasterSel>(entity =>
            {
                entity.ToView("View_tblTraffic_TRB_HomeGuard_Master_SEL");
            });

            modelBuilder.Entity<ViewTblTrafficTrgAhgSel>(entity =>
            {
                entity.ToView("View_tblTraffic_TRG_AHG_SEL");
            });

            modelBuilder.Entity<ViewTblVisitationCrimeBranchMaster>(entity =>
            {
                entity.ToView("View_tblVisitation_CrimeBranchMaster");
            });

            modelBuilder.Entity<ViewTblWardWiseDetailsPoliceStationWiseSelect>(entity =>
            {
                entity.ToView("View_tblWardWiseDetails_PoliceStationWise_Select");
            });

            modelBuilder.Entity<ViewTblZoneMaster>(entity =>
            {
                entity.ToView("View_tblZoneMaster");
            });

            modelBuilder.Entity<ViewTblZoneMasterSel>(entity =>
            {
                entity.ToView("View_tblZoneMaster_SEL");

                entity.Property(e => e.ZoneId).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<ViewTbladminWisePendingApplicationSel>(entity =>
            {
                entity.ToView("view_tbladminWisePendingApplication_SEL");
            });

            modelBuilder.Entity<ViewTbldetainMasterSel>(entity =>
            {
                entity.ToView("View_tbldetainMaster_SEL");
            });

            modelBuilder.Entity<ViewTblpendingjanvajogSel>(entity =>
            {
                entity.ToView("View_tblpendingjanvajog_SEL");
            });

            modelBuilder.Entity<ViewTblpendingwarrantSel>(entity =>
            {
                entity.ToView("View_tblpendingwarrant_SEL");
            });

            modelBuilder.Entity<ViewTblpolicestationwiseapplicationSel>(entity =>
            {
                entity.ToView("View_tblpolicestationwiseapplication_SEL");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        #endregion
    }
}