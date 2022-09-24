using System.ComponentModel.DataAnnotations.Schema;

namespace AhmedabadCityDR.Models.TableModels
{
    [Keyless]
    [Table("tbldetainMaster_HITS")]
    public partial class TbldetainMasterHit
    {
        public int DetainId { get; set; }
        public int? PoliceStationId { get; set; }
        public int? SubCategoryId { get; set; }

        [Column("psnccount")]
        public int? Psnccount { get; set; }

        [Column("tsnccount")]
        public int? Tsnccount { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? CreatedDate { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? ModifiedDate { get; set; }

        public int? CreateduserId { get; set; }
        public int? ModifiedUserId { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
    }
}