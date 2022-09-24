using System.ComponentModel.DataAnnotations.Schema;

namespace AhmedabadCityDR.Models.TableModels
{
    [Keyless]
    [Table("tblDCB_PolicestationMaster_HITS")]
    public partial class TblDcbPolicestationMasterHit
    {
        [Column("DCBId")]
        public int Dcbid { get; set; }

        public string? ShortDetails { get; set; }
        public string? Operation { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? CreatedDate { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? ModifiedDate { get; set; }

        public int? CreatedUserId { get; set; }
        public int? ModifiedUserId { get; set; }
    }
}