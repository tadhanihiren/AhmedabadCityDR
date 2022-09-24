using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AhmedabadCityDR.Models.TableModels
{
    [Table("tblPoliceStationMaster")]
    public partial class TblPoliceStationMaster
    {
        public TblPoliceStationMaster()
        {
            TblAccusedInformations = new HashSet<TblAccusedInformation>();
            TblAdminCheckMasters = new HashSet<TblAdminCheckMaster>();
            TblAdminWisePendingApplicationMasters = new HashSet<TblAdminWisePendingApplicationMaster>();
            TblAtakKarelEsams = new HashSet<TblAtakKarelEsam>();
            TblAtakayatiPaglaSummaries = new HashSet<TblAtakayatiPaglaSummary>();
            TblAtakayatiPaglas = new HashSet<TblAtakayatiPagla>();
            TblAtakayatidetails = new HashSet<TblAtakayatidetail>();
            TblAtkayatiPagalaConsolidateds = new HashSet<TblAtkayatiPagalaConsolidated>();
            TblAutoRickshawDetails = new HashSet<TblAutoRickshawDetail>();
            TblBandobastDetailMasters = new HashSet<TblBandobastDetailMaster>();
            TblCctvMasters = new HashSet<TblCctvMaster>();
            TblCctvinstalleds = new HashSet<TblCctvinstalled>();
            TblChangeColors = new HashSet<TblChangeColor>();
            TblCriminalCountInformations = new HashSet<TblCriminalCountInformation>();
            TblCrpc41camendmentMaters = new HashSet<TblCrpc41camendmentMater>();
            TblCrpc41masters = new HashSet<TblCrpc41master>();
            TblCurrentYearAgeWiseMissingChildDetails = new HashSet<TblCurrentYearAgeWiseMissingChildDetail>();
            TblCurrentYearMissingChildDetails = new HashSet<TblCurrentYearMissingChildDetail>();
            TblDistributeVehicals = new HashSet<TblDistributeVehical>();
            TblEGujakopMasters = new HashSet<TblEGujakopMaster>();
            TblEGujkopDetails = new HashSet<TblEGujkopDetail>();
            TblEmployeeMasterBackups = new HashSet<TblEmployeeMasterBackup>();
            TblEmployeeMasters = new HashSet<TblEmployeeMaster>();
            TblForm3As = new HashSet<TblForm3A>();
            TblForm5Masters = new HashSet<TblForm5Master>();
            TblHistoryMissingAgeWiseChildren = new HashSet<TblHistoryMissingAgeWiseChild>();
            TblLaborInformationMasters = new HashSet<TblLaborInformationMaster>();
            TblLeaveApplicationMasterInchargePoliceStations = new HashSet<TblLeaveApplicationMaster>();
            TblLeaveApplicationMasterPoliceStations = new HashSet<TblLeaveApplicationMaster>();
            TblLoginMasterMobiles = new HashSet<TblLoginMasterMobile>();
            TblMahekamMasters = new HashSet<TblMahekamMaster>();
            TblMcrdetails = new HashSet<TblMcrdetail>();
            TblMissingChildDetails = new HashSet<TblMissingChildDetail>();
            TblNightEmployeeMasters = new HashSet<TblNightEmployeeMaster>();
            TblNightRoundHekoPomasters = new HashSet<TblNightRoundHekoPomaster>();
            TblNightRounds = new HashSet<TblNightRound>();
            TblNightRountPersonCountMasters = new HashSet<TblNightRountPersonCountMaster>();
            TblOfiiceWisePendingApplications = new HashSet<TblOfiiceWisePendingApplication>();
            TblPendingArjiDetails = new HashSet<TblPendingArjiDetail>();
            TblProhibitionCrimeMasterCopies = new HashSet<TblProhibitionCrimeMasterCopy>();
            TblProhibitionCrimeMasters = new HashSet<TblProhibitionCrimeMaster>();
            TblProhibitionRaidCases = new HashSet<TblProhibitionRaidCase>();
            TblSamansDetails = new HashSet<TblSamansDetail>();
            TblSamelPatrakMasters = new HashSet<TblSamelPatrakMaster>();
            TblStationeries = new HashSet<TblStationery>();
            TblTrafficPlaceFineMasters = new HashSet<TblTrafficPlaceFineMaster>();
            TblTrafficSignalBlinkerighs = new HashSet<TblTrafficSignalBlinkerigh>();
            TblTrafficSignalMasters = new HashSet<TblTrafficSignalMaster>();
            TblTrafficSummaryDetails = new HashSet<TblTrafficSummaryDetail>();
            TblTrafficTobacoMasters = new HashSet<TblTrafficTobacoMaster>();
            TblTrafficTrbHomeGuardMasters = new HashSet<TblTrafficTrbHomeGuardMaster>();
            TblTrafficTrgAhgMasters = new HashSet<TblTrafficTrgAhgMaster>();
            TblVisitationCrimeBranches = new HashSet<TblVisitationCrimeBranch>();
            TbladhibitMasters = new HashSet<TbladhibitMaster>();
            TbldetainMasters = new HashSet<TbldetainMaster>();
            TblhistroryOfCurrentMissings = new HashSet<TblhistroryOfCurrentMissing>();
            TblpendingjanvajogMasters = new HashSet<TblpendingjanvajogMaster>();
        }

        [Key]
        public int PoliceStationId { get; set; }

        public string? PoliceStationName { get; set; }
        public int? DivisionId { get; set; }
        public string? ShortName { get; set; }
        public string? EnglishName { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }

        [Column(TypeName = "date")]
        public DateTime? CreatedDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ModifiedDate { get; set; }

        public int? CreatedUserId { get; set; }
        public int? ModifiedUserId { get; set; }
        public int? ZoneId { get; set; }
        public int? CityId { get; set; }
        public int? SectorId { get; set; }
        public bool IsTraffic { get; set; }

        [InverseProperty("PoliceStation")]
        public virtual ICollection<TblAccusedInformation> TblAccusedInformations { get; set; }

        [InverseProperty("PoliceStation")]
        public virtual ICollection<TblAdminCheckMaster> TblAdminCheckMasters { get; set; }

        [InverseProperty("PoliceStation")]
        public virtual ICollection<TblAdminWisePendingApplicationMaster> TblAdminWisePendingApplicationMasters { get; set; }

        [InverseProperty("PoliceStation")]
        public virtual ICollection<TblAtakKarelEsam> TblAtakKarelEsams { get; set; }

        [InverseProperty("PoliceStation")]
        public virtual ICollection<TblAtakayatiPaglaSummary> TblAtakayatiPaglaSummaries { get; set; }

        [InverseProperty("PoliceStation")]
        public virtual ICollection<TblAtakayatiPagla> TblAtakayatiPaglas { get; set; }

        [InverseProperty("PoliceStation")]
        public virtual ICollection<TblAtakayatidetail> TblAtakayatidetails { get; set; }

        [InverseProperty("PoliceStation")]
        public virtual ICollection<TblAtkayatiPagalaConsolidated> TblAtkayatiPagalaConsolidateds { get; set; }

        [InverseProperty("PoliceStation")]
        public virtual ICollection<TblAutoRickshawDetail> TblAutoRickshawDetails { get; set; }

        [InverseProperty("PoliceStation")]
        public virtual ICollection<TblBandobastDetailMaster> TblBandobastDetailMasters { get; set; }

        [InverseProperty("PoliceStation")]
        public virtual ICollection<TblCctvMaster> TblCctvMasters { get; set; }

        [InverseProperty("PoliceStation")]
        public virtual ICollection<TblCctvinstalled> TblCctvinstalleds { get; set; }

        [InverseProperty("Policestation")]
        public virtual ICollection<TblChangeColor> TblChangeColors { get; set; }

        [InverseProperty("PoliceStation")]
        public virtual ICollection<TblCriminalCountInformation> TblCriminalCountInformations { get; set; }

        [InverseProperty("PoliceStation")]
        public virtual ICollection<TblCrpc41camendmentMater> TblCrpc41camendmentMaters { get; set; }

        [InverseProperty("PoliceStation")]
        public virtual ICollection<TblCrpc41master> TblCrpc41masters { get; set; }

        [InverseProperty("PoliceStation")]
        public virtual ICollection<TblCurrentYearAgeWiseMissingChildDetail> TblCurrentYearAgeWiseMissingChildDetails { get; set; }

        [InverseProperty("PoliceStation")]
        public virtual ICollection<TblCurrentYearMissingChildDetail> TblCurrentYearMissingChildDetails { get; set; }

        [InverseProperty("PoliceStation")]
        public virtual ICollection<TblDistributeVehical> TblDistributeVehicals { get; set; }

        [InverseProperty("PoliceStation")]
        public virtual ICollection<TblEGujakopMaster> TblEGujakopMasters { get; set; }

        [InverseProperty("PoliceStation")]
        public virtual ICollection<TblEGujkopDetail> TblEGujkopDetails { get; set; }

        [InverseProperty("PoliceStation")]
        public virtual ICollection<TblEmployeeMasterBackup> TblEmployeeMasterBackups { get; set; }

        [InverseProperty("PoliceStation")]
        public virtual ICollection<TblEmployeeMaster> TblEmployeeMasters { get; set; }

        [InverseProperty("PoliceStation")]
        public virtual ICollection<TblForm3A> TblForm3As { get; set; }

        [InverseProperty("PoliceStation")]
        public virtual ICollection<TblForm5Master> TblForm5Masters { get; set; }

        [InverseProperty("PoliceStation")]
        public virtual ICollection<TblHistoryMissingAgeWiseChild> TblHistoryMissingAgeWiseChildren { get; set; }

        [InverseProperty("PoliceStation")]
        public virtual ICollection<TblLaborInformationMaster> TblLaborInformationMasters { get; set; }

        [InverseProperty("InchargePoliceStation")]
        public virtual ICollection<TblLeaveApplicationMaster> TblLeaveApplicationMasterInchargePoliceStations { get; set; }

        [InverseProperty("PoliceStation")]
        public virtual ICollection<TblLeaveApplicationMaster> TblLeaveApplicationMasterPoliceStations { get; set; }

        [InverseProperty("PoliceStation")]
        public virtual ICollection<TblLoginMasterMobile> TblLoginMasterMobiles { get; set; }

        [InverseProperty("PoliceStation")]
        public virtual ICollection<TblMahekamMaster> TblMahekamMasters { get; set; }

        [InverseProperty("PoliceStation")]
        public virtual ICollection<TblMcrdetail> TblMcrdetails { get; set; }

        [InverseProperty("PoliceStation")]
        public virtual ICollection<TblMissingChildDetail> TblMissingChildDetails { get; set; }

        [InverseProperty("PoliceStation")]
        public virtual ICollection<TblNightEmployeeMaster> TblNightEmployeeMasters { get; set; }

        [InverseProperty("PoliceStation")]
        public virtual ICollection<TblNightRoundHekoPomaster> TblNightRoundHekoPomasters { get; set; }

        [InverseProperty("PoliceStation")]
        public virtual ICollection<TblNightRound> TblNightRounds { get; set; }

        [InverseProperty("PoliceStation")]
        public virtual ICollection<TblNightRountPersonCountMaster> TblNightRountPersonCountMasters { get; set; }

        [InverseProperty("PoliceStation")]
        public virtual ICollection<TblOfiiceWisePendingApplication> TblOfiiceWisePendingApplications { get; set; }

        [InverseProperty("PoliceStation")]
        public virtual ICollection<TblPendingArjiDetail> TblPendingArjiDetails { get; set; }

        [InverseProperty("PoliceStation")]
        public virtual ICollection<TblProhibitionCrimeMasterCopy> TblProhibitionCrimeMasterCopies { get; set; }

        [InverseProperty("PoliceStation")]
        public virtual ICollection<TblProhibitionCrimeMaster> TblProhibitionCrimeMasters { get; set; }

        [InverseProperty("PoliceStation")]
        public virtual ICollection<TblProhibitionRaidCase> TblProhibitionRaidCases { get; set; }

        [InverseProperty("PoliceStation")]
        public virtual ICollection<TblSamansDetail> TblSamansDetails { get; set; }

        [InverseProperty("PoliceStation")]
        public virtual ICollection<TblSamelPatrakMaster> TblSamelPatrakMasters { get; set; }

        [InverseProperty("PoliceStation")]
        public virtual ICollection<TblStationery> TblStationeries { get; set; }

        [InverseProperty("PoliceStation")]
        public virtual ICollection<TblTrafficPlaceFineMaster> TblTrafficPlaceFineMasters { get; set; }

        [InverseProperty("PoliceStation")]
        public virtual ICollection<TblTrafficSignalBlinkerigh> TblTrafficSignalBlinkerighs { get; set; }

        [InverseProperty("PoliceStation")]
        public virtual ICollection<TblTrafficSignalMaster> TblTrafficSignalMasters { get; set; }

        [InverseProperty("PoliceStation")]
        public virtual ICollection<TblTrafficSummaryDetail> TblTrafficSummaryDetails { get; set; }

        [InverseProperty("PoliceStation")]
        public virtual ICollection<TblTrafficTobacoMaster> TblTrafficTobacoMasters { get; set; }

        [InverseProperty("PoliceStation")]
        public virtual ICollection<TblTrafficTrbHomeGuardMaster> TblTrafficTrbHomeGuardMasters { get; set; }

        [InverseProperty("PoliceStation")]
        public virtual ICollection<TblTrafficTrgAhgMaster> TblTrafficTrgAhgMasters { get; set; }

        [InverseProperty("PoliceStation")]
        public virtual ICollection<TblVisitationCrimeBranch> TblVisitationCrimeBranches { get; set; }

        [InverseProperty("PoliceStation")]
        public virtual ICollection<TbladhibitMaster> TbladhibitMasters { get; set; }

        [InverseProperty("PoliceStation")]
        public virtual ICollection<TbldetainMaster> TbldetainMasters { get; set; }

        [InverseProperty("PoliceStation")]
        public virtual ICollection<TblhistroryOfCurrentMissing> TblhistroryOfCurrentMissings { get; set; }

        [InverseProperty("PoliceStation")]
        public virtual ICollection<TblpendingjanvajogMaster> TblpendingjanvajogMasters { get; set; }
    }
}