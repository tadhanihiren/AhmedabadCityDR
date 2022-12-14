using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AhmedabadCityDR.Models.TableModels
{
    [Table("tblAdminWisePendingApplicationMaster")]
    public partial class TblAdminWisePendingApplicationMaster
    {
        [Key]
        public int AdminWisePendingApplicationId { get; set; }

        public int? PoliceStationId { get; set; }
        public int? KacheriId { get; set; }
        public int? TotalApplication { get; set; }

        [Column("bakiApplication")]
        public int? BakiApplication { get; set; }

        public int? TenDaysBelow { get; set; }
        public int? TenDaysAbove { get; set; }
        public int? OneMonthUnder { get; set; }
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

        [ForeignKey("KacheriId")]
        [InverseProperty("TblAdminWisePendingApplicationMasters")]
        public virtual TblkacheriMaster? Kacheri { get; set; }

        [ForeignKey("PoliceStationId")]
        [InverseProperty("TblAdminWisePendingApplicationMasters")]
        public virtual TblPoliceStationMaster? PoliceStation { get; set; }
    }
}