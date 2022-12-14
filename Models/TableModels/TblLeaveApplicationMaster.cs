using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AhmedabadCityDR.Models.TableModels
{
    [Table("tblLeaveApplicationMaster")]
    public partial class TblLeaveApplicationMaster
    {
        [Key]
        [Column("LeaveApplicationID")]
        public int LeaveApplicationId { get; set; }

        public int? PoliceStationId { get; set; }
        public int? DesignationId { get; set; }
        public int? LeaveTypeId { get; set; }
        public int? EmployeeId { get; set; }
        public string? Name { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? FromDate { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? ToDate { get; set; }

        public string? TotalDays { get; set; }
        public string? Remarks { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? CreatedDate { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? ModifiedDate { get; set; }

        public int? CreatedUserId { get; set; }
        public int? ModifiedUserId { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDelete { get; set; }
        public int? InchargeDesignationId { get; set; }
        public int? InchargePoliceStationId { get; set; }
        public int? InchargeEmployeeId { get; set; }
        public int? SectorId { get; set; }
        public int? ZoneId { get; set; }
        public int? DivisionId { get; set; }
        public int? InchargeSectorId { get; set; }
        public int? InchargeZoneId { get; set; }
        public int? InchargeDivisionId { get; set; }

        [ForeignKey("DesignationId")]
        [InverseProperty("TblLeaveApplicationMasterDesignations")]
        public virtual TblDesignationName? Designation { get; set; }

        [ForeignKey("EmployeeId")]
        [InverseProperty("TblLeaveApplicationMasters")]
        public virtual TblEmployeeMaster? Employee { get; set; }

        [ForeignKey("InchargeDesignationId")]
        [InverseProperty("TblLeaveApplicationMasterInchargeDesignations")]
        public virtual TblDesignationName? InchargeDesignation { get; set; }

        [ForeignKey("InchargePoliceStationId")]
        [InverseProperty("TblLeaveApplicationMasterInchargePoliceStations")]
        public virtual TblPoliceStationMaster? InchargePoliceStation { get; set; }

        [ForeignKey("PoliceStationId")]
        [InverseProperty("TblLeaveApplicationMasterPoliceStations")]
        public virtual TblPoliceStationMaster? PoliceStation { get; set; }
    }
}