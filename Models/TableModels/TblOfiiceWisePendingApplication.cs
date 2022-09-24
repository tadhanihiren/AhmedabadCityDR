using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AhmedabadCityDR.Models.TableModels
{
    [Table("tblOfiiceWisePendingApplication")]
    public partial class TblOfiiceWisePendingApplication
    {
        [Key]
        public int OfficeWisePendingApplicationId { get; set; }

        public int? PoliceStationId { get; set; }
        public int? CategoryId { get; set; }
        public int? TenDaysAbove { get; set; }
        public int? OneMonthAbove { get; set; }
        public int? TwoMonthAbove { get; set; }
        public int? ThreeMonthAbove { get; set; }
        public int? SixMonthAbove { get; set; }
        public int? OneYearAndAbove { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? CreatedDate { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? ModifiedDate { get; set; }

        public int? CreatedUserId { get; set; }
        public int? ModifiedUserId { get; set; }

        [ForeignKey("CategoryId")]
        [InverseProperty("TblOfiiceWisePendingApplications")]
        public virtual TblCategoryMaster? Category { get; set; }

        [ForeignKey("PoliceStationId")]
        [InverseProperty("TblOfiiceWisePendingApplications")]
        public virtual TblPoliceStationMaster? PoliceStation { get; set; }
    }
}