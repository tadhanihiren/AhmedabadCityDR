using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AhmedabadCityDR.Models.TableModels
{
    [Table("tblAtakayatidetails")]
    public partial class TblAtakayatidetail
    {
        [Key]
        public int AtakayatiPagalaSummaryId { get; set; }

        public int? PoliceStationId { get; set; }
        public int? SubCategoryId { get; set; }
        public int? Today { get; set; }
        public int? Last { get; set; }

        [Column("T_Y")]
        public int? TY { get; set; }

        public int? CurrentYear { get; set; }
        public int? LastYear { get; set; }

        [Column("CY_LY")]
        public int? CyLy { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? CreatedDate { get; set; }

        public int? CreateduserId { get; set; }
        public int? ModifiedUserId { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? ModifiedDate { get; set; }

        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }

        [ForeignKey("PoliceStationId")]
        [InverseProperty("TblAtakayatidetails")]
        public virtual TblPoliceStationMaster? PoliceStation { get; set; }

        [ForeignKey("SubCategoryId")]
        [InverseProperty("TblAtakayatidetails")]
        public virtual TblSubCategoryMaster? SubCategory { get; set; }
    }
}