using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AhmedabadCityDR.Models.TableModels
{
    [Table("tblCctvMaster")]
    public partial class TblCctvMaster
    {
        [Key]
        public int CctvId { get; set; }

        public string? Range { get; set; }

        [Column("City_Distict")]
        public string? CityDistict { get; set; }

        [StringLength(50)]
        public string? Cluster { get; set; }

        public string? VenderName { get; set; }
        public int? PoliceStationId { get; set; }

        [Column("PTZ_installed")]
        public int? PtzInstalled { get; set; }

        [Column("BLT_installed")]
        public int? BltInstalled { get; set; }

        [Column("DM_installed")]
        public int? DmInstalled { get; set; }

        [Column("Total_installed")]
        public int? TotalInstalled { get; set; }

        [Column("PTZ_funcational")]
        public int? PtzFuncational { get; set; }

        [Column("BLT_funcational")]
        public int? BltFuncational { get; set; }

        [Column("DM_funcational")]
        public int? DmFuncational { get; set; }

        [Column("Total_funcation")]
        public int? TotalFuncation { get; set; }

        [Column("PTZ_not_funcational")]
        public int? PtzNotFuncational { get; set; }

        [Column("BLT_not_funcational")]
        public int? BltNotFuncational { get; set; }

        [Column("DM_not_funcational")]
        public int? DmNotFuncational { get; set; }

        [Column("Total_not_funcation")]
        public int? TotalNotFuncation { get; set; }

        public string? Complaint1 { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? ComplaintDate1 { get; set; }

        public string? Complaint2 { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? ComplaintDate2 { get; set; }

        public string? Complaint3 { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? ComplaintDate3 { get; set; }

        public int? EquipmentsId { get; set; }
        public string? NatureofComplant { get; set; }

        [Column("Visited_Remark")]
        public string? VisitedRemark { get; set; }

        public int? StatusId { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? ResolveDate { get; set; }

        public string? Remark { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? CreatedDate { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? ModifiedDate { get; set; }

        public int? CreatedUserId { get; set; }
        public int? ModifiedUserId { get; set; }

        [ForeignKey("EquipmentsId")]
        [InverseProperty("TblCctvMasters")]
        public virtual TblEquipment? Equipments { get; set; }

        [ForeignKey("PoliceStationId")]
        [InverseProperty("TblCctvMasters")]
        public virtual TblPoliceStationMaster? PoliceStation { get; set; }

        [ForeignKey("StatusId")]
        [InverseProperty("TblCctvMasters")]
        public virtual TblStatusMaster? Status { get; set; }
    }
}