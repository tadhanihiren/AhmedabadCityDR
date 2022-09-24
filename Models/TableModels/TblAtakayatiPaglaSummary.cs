using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AhmedabadCityDR.Models.TableModels
{
    [Table("tblAtakayatiPaglaSummary")]
    public partial class TblAtakayatiPaglaSummary
    {
        [Key]
        public int AtakayatiPagalaSummaryId { get; set; }
        public int? PoliceStationId { get; set; }
        public int? SubCategoryId { get; set; }

        [Column("IPC_GPCId")]
        public int? IpcGpcid { get; set; }

        public int? Todays { get; set; }
        public int? Last { get; set; }
        public int? CurrentMonth { get; set; }
        public int? LastMonth { get; set; }
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

        [ForeignKey("IpcGpcid")]
        [InverseProperty("TblAtakayatiPaglaSummaries")]
        public virtual TblIpcGpcmaster? IpcGpc { get; set; }

        [ForeignKey("PoliceStationId")]
        [InverseProperty("TblAtakayatiPaglaSummaries")]
        public virtual TblPoliceStationMaster? PoliceStation { get; set; }

        [ForeignKey("SubCategoryId")]
        [InverseProperty("TblAtakayatiPaglaSummaries")]
        public virtual TblSubCategoryMaster? SubCategory { get; set; }
    }
}