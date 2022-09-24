using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AhmedabadCityDR.Models.TableModels
{
    [Table("tblEmployeeMaster")]
    public partial class TblEmployeeMaster
    {
        public TblEmployeeMaster()
        {
            TblEmployeeMasterBackups = new HashSet<TblEmployeeMasterBackup>();
            TblLeaveApplicationMasters = new HashSet<TblLeaveApplicationMaster>();
            TblNightEmployeeMasters = new HashSet<TblNightEmployeeMaster>();
        }

        [Key]
        public int EmployeeId { get; set; }

        public string? BuckleNo { get; set; }
        public string? EmployeName { get; set; }
        public string? Name { get; set; }
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public string? ContactNumber { get; set; }
        public string? PrtiniyukatName { get; set; }

        [Column("todate", TypeName = "datetime")]
        public DateTime? Todate { get; set; }

        [Column("fromdate", TypeName = "datetime")]
        public DateTime? Fromdate { get; set; }

        [StringLength(50)]
        public string? PrtiniyukatPlace { get; set; }

        public int? DesignationId { get; set; }
        public int? RoleId { get; set; }
        public int? SectorId { get; set; }
        public int? ZoneId { get; set; }
        public int? DivisionId { get; set; }
        public int? PoliceStationId { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? CreatedDate { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? ModifiedDate { get; set; }

        public int? CreatedUserId { get; set; }
        public int? ModifiedUserId { get; set; }
        public bool IsTraffic { get; set; }

        [ForeignKey("DesignationId")]
        [InverseProperty("TblEmployeeMasters")]
        public virtual TblDesignationName? Designation { get; set; }

        [ForeignKey("DivisionId")]
        [InverseProperty("TblEmployeeMasters")]
        public virtual TblDivisionMaster? Division { get; set; }

        [ForeignKey("PoliceStationId")]
        [InverseProperty("TblEmployeeMasters")]
        public virtual TblPoliceStationMaster? PoliceStation { get; set; }

        [ForeignKey("RoleId")]
        [InverseProperty("TblEmployeeMasters")]
        public virtual TblRoleMaster? Role { get; set; }

        [ForeignKey("SectorId")]
        [InverseProperty("TblEmployeeMasters")]
        public virtual TblSectorMaster? Sector { get; set; }

        [ForeignKey("ZoneId")]
        [InverseProperty("TblEmployeeMasters")]
        public virtual TblZoneMaster? Zone { get; set; }

        [InverseProperty("Employee")]
        public virtual ICollection<TblEmployeeMasterBackup> TblEmployeeMasterBackups { get; set; }

        [InverseProperty("Employee")]
        public virtual ICollection<TblLeaveApplicationMaster> TblLeaveApplicationMasters { get; set; }

        [InverseProperty("Employee")]
        public virtual ICollection<TblNightEmployeeMaster> TblNightEmployeeMasters { get; set; }
    }
}