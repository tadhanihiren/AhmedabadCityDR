using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AhmedabadCityDR.Models.TableModels
{
    [Table("tblCategoryMaster")]
    public partial class TblCategoryMaster
    {
        public TblCategoryMaster()
        {
            TblCriminalCountInformations = new HashSet<TblCriminalCountInformation>();
            TblCriminalInformations = new HashSet<TblCriminalInformation>();
            TblCurrentYearAgeWiseMissingChildDetails = new HashSet<TblCurrentYearAgeWiseMissingChildDetail>();
            TblDistributeVehicals = new HashSet<TblDistributeVehical>();
            TblMonthWiseReports = new HashSet<TblMonthWiseReport>();
            TblOfiiceWisePendingApplications = new HashSet<TblOfiiceWisePendingApplication>();
            TblProhibitionRaidCases = new HashSet<TblProhibitionRaidCase>();
            TblSamansDetails = new HashSet<TblSamansDetail>();
            TblSubCategoryMasters = new HashSet<TblSubCategoryMaster>();
            TblVehicleMasters = new HashSet<TblVehicleMaster>();
        }

        [Key]
        public int CategoryId { get; set; }

        public string? CategoryName { get; set; }
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? CreatedDate { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? ModifiedDate { get; set; }

        public int? CreatedUserId { get; set; }
        public int? ModifiedUserId { get; set; }

        [InverseProperty("Category")]
        public virtual ICollection<TblCriminalCountInformation> TblCriminalCountInformations { get; set; }

        [InverseProperty("Category")]
        public virtual ICollection<TblCriminalInformation> TblCriminalInformations { get; set; }

        [InverseProperty("Category")]
        public virtual ICollection<TblCurrentYearAgeWiseMissingChildDetail> TblCurrentYearAgeWiseMissingChildDetails { get; set; }

        [InverseProperty("Category")]
        public virtual ICollection<TblDistributeVehical> TblDistributeVehicals { get; set; }

        [InverseProperty("Category")]
        public virtual ICollection<TblMonthWiseReport> TblMonthWiseReports { get; set; }

        [InverseProperty("Category")]
        public virtual ICollection<TblOfiiceWisePendingApplication> TblOfiiceWisePendingApplications { get; set; }

        [InverseProperty("Category")]
        public virtual ICollection<TblProhibitionRaidCase> TblProhibitionRaidCases { get; set; }

        [InverseProperty("Category")]
        public virtual ICollection<TblSamansDetail> TblSamansDetails { get; set; }

        [InverseProperty("Category")]
        public virtual ICollection<TblSubCategoryMaster> TblSubCategoryMasters { get; set; }

        [InverseProperty("Category")]
        public virtual ICollection<TblVehicleMaster> TblVehicleMasters { get; set; }
    }
}