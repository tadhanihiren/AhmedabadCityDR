using System.ComponentModel.DataAnnotations.Schema;

namespace AhmedabadCityDR.Models.TableModels
{
    [Keyless]
    [Table("tblLeaveApplicationMaster_HITS")]
    public partial class TblLeaveApplicationMasterHit
    {
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
    }
}