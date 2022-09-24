using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AhmedabadCityDR.Models.TableModels
{
    [Table("tblChangeColor")]
    public partial class TblChangeColor
    {
        [Key]
        public int EntryId { get; set; }

        public int? PatrakId { get; set; }
        public int? PolicestationId { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? CreatedDate { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? ModifiedDate { get; set; }

        public int? CreatedUserId { get; set; }
        public int? ModifiedUserId { get; set; }

        [ForeignKey("PatrakId")]
        [InverseProperty("TblChangeColors")]
        public virtual TblIndexPatrakMaster? Patrak { get; set; }

        [ForeignKey("PolicestationId")]
        [InverseProperty("TblChangeColors")]
        public virtual TblPoliceStationMaster? Policestation { get; set; }
    }
}