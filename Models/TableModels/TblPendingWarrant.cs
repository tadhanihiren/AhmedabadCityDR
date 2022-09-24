using System.ComponentModel.DataAnnotations.Schema;

namespace AhmedabadCityDR.Models.TableModels
{
    [Keyless]
    [Table("tblPendingWarrant")]
    public partial class TblPendingWarrant
    {
        public int PendingId { get; set; }
        public int? PoliceStationId { get; set; }
        public int? SubCategoryId { get; set; }
        public int? LastPending { get; set; }
        public int? NewPending { get; set; }
        public int? Budgeted { get; set; }
        public int? WithoutBudgeted { get; set; }
        public int? Transfer { get; set; }
        public int? Pending { get; set; }
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? CreatedDate { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? ModifiedDate { get; set; }

        public int? CreatedUserId { get; set; }
        public int? ModifiedUserId { get; set; }

        [ForeignKey("PoliceStationId")]
        public virtual TblPoliceStationMaster? PoliceStation { get; set; }

        [ForeignKey("SubCategoryId")]
        public virtual TblSubCategoryMaster? SubCategory { get; set; }
    }
}