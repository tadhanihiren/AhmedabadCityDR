using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AhmedabadCityDR.Models.TableModels
{
    [Table("tblForm5Master")]
    public partial class TblForm5Master
    {
        [Key]
        public int AtakayatiPagalaSummaryId { get; set; }

        public int? PoliceStationId { get; set; }
        public int? SubCategoryId { get; set; }
        public int? Today { get; set; }
        public int? Last { get; set; }
        public int? CurrentYear { get; set; }
        public int? LastYear { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? CreatedDate { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? ModifiedDate { get; set; }

        public int? CreateduserId { get; set; }
        public int? ModifiedUserId { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }

        [ForeignKey("PoliceStationId")]
        [InverseProperty("TblForm5Masters")]
        public virtual TblPoliceStationMaster? PoliceStation { get; set; }

        [ForeignKey("SubCategoryId")]
        [InverseProperty("TblForm5Masters")]
        public virtual TblSubCategoryMaster? SubCategory { get; set; }
    }
}