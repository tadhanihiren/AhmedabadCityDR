using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AhmedabadCityDR.Models.TableModels
{
    [Table("tblPendingArjiDetails")]
    public partial class TblPendingArjiDetail
    {
        [Key]
        public int PendingArjiDetailId { get; set; }

        public int? PendingArjiCategoryId { get; set; }
        public int? PoliceStationId { get; set; }

        [Column("Under_10Days")]
        public int? Under10days { get; set; }

        [Column("Above_10Days")]
        public int? Above10days { get; set; }

        [Column("Above_OneMonth")]
        public int? AboveOneMonth { get; set; }

        [Column("Above_TwoMonth")]
        public int? AboveTwoMonth { get; set; }

        [Column("Above_ThreeMonth")]
        public int? AboveThreeMonth { get; set; }

        [Column("Above_SixMonth")]
        public int? AboveSixMonth { get; set; }

        [Column("Above_OneYear")]
        public int? AboveOneYear { get; set; }

        public bool? IsActive { get; set; }
        public bool? IsDelete { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? CreatedDate { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? ModifiedDate { get; set; }

        public int? CreatedUserId { get; set; }
        public int? ModifiedUserId { get; set; }

        [ForeignKey("PendingArjiCategoryId")]
        [InverseProperty("TblPendingArjiDetails")]
        public virtual TblPendingArjiCategory? PendingArjiCategory { get; set; }

        [ForeignKey("PoliceStationId")]
        [InverseProperty("TblPendingArjiDetails")]
        public virtual TblPoliceStationMaster? PoliceStation { get; set; }
    }
}