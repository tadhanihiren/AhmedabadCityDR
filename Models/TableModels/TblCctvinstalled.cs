using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AhmedabadCityDR.Models.TableModels
{
    [Table("tbl_CCTVInstalled")]
    public partial class TblCctvinstalled
    {
        [Key]
        public int InstallId { get; set; }

        public int? PoliceStationId { get; set; }

        [Column("PTZ_installed")]
        public int? PtzInstalled { get; set; }

        [Column("BLT_installed")]
        public int? BltInstalled { get; set; }

        [Column("DM_installed")]
        public int? DmInstalled { get; set; }

        [Column("Total_installed")]
        public int? TotalInstalled { get; set; }

        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? CreatedDate { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? ModifiedDate { get; set; }

        public int? CreatedUserId { get; set; }
        public int? ModifiedUserId { get; set; }

        [ForeignKey("PoliceStationId")]
        [InverseProperty("TblCctvinstalleds")]
        public virtual TblPoliceStationMaster? PoliceStation { get; set; }
    }
}