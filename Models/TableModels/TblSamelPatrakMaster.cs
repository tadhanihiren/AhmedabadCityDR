using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AhmedabadCityDR.Models.TableModels
{
    [Table("tblSamelPatrakMaster")]
    public partial class TblSamelPatrakMaster
    {
        [Key]
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

        [ForeignKey("PatrakId")]
        [InverseProperty("TblSamelPatrakMasters")]
        public virtual TblIndexPatrakMaster? Patrak { get; set; }

        [ForeignKey("PoliceStationId")]
        [InverseProperty("TblSamelPatrakMasters")]
        public virtual TblPoliceStationMaster? PoliceStation { get; set; }
    }
}