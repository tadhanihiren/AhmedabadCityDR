using System.ComponentModel.DataAnnotations.Schema;

namespace AhmedabadCityDR.Models.TableModels
{
    [Keyless]
    [Table("tblSamelPatrakMaster_HIST")]
    public partial class TblSamelPatrakMasterHist
    {
        public int SamelId { get; set; }
        public int? PatrakId { get; set; }
        public int? PoliceStationId { get; set; }
        public int? SamelCategoryId { get; set; }
        public int? CreatedUserId { get; set; }
        public int? ModifiedUserId { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? CreatedDate { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? ModifiedDate { get; set; }
    }
}