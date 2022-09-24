using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AhmedabadCityDR.Models.TableModels
{
    [Table("tblAdminCheckMaster")]
    public partial class TblAdminCheckMaster
    {
        [Key]
        [Column("AdminCheckID")]
        public int AdminCheckId { get; set; }

        public int? PoliceStationId { get; set; }
        public string? Remark { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? CreatedDate { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? ModifiedDate { get; set; }

        public int? CreatedUserId { get; set; }
        public int? ModifiedUserId { get; set; }

        [ForeignKey("PoliceStationId")]
        [InverseProperty("TblAdminCheckMasters")]
        public virtual TblPoliceStationMaster? PoliceStation { get; set; }
    }
}