using System.ComponentModel.DataAnnotations.Schema;

namespace AhmedabadCityDR.Models.TableModels
{
    [Keyless]
    public partial class ViewTblLeaveApplicationLeavePoliceStation
    {
        [Column("LeaveApplicationID")]
        public int LeaveApplicationId { get; set; }

        public int? PoliceStationId { get; set; }
        public int? DesignationId { get; set; }
        public int? LeaveTypeId { get; set; }

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
        public string? PoliceStationName { get; set; }
        public string? InchrgePoliceStationName { get; set; }
        public string? DesignationName { get; set; }
        public string? InchargeDesignationName { get; set; }
        public string? EmployeName { get; set; }
        public int? EmployeeId { get; set; }
        public int? InchargeEmployeeId { get; set; }
        public string? InchargeEmployeName { get; set; }
        public string? LeaveTypeName { get; set; }
        public int ZoneId { get; set; }
        public int SectorId { get; set; }
        public string? SectorName { get; set; }
        public string? ZoneName { get; set; }
        public string? DivisionName { get; set; }
        public int DivisionId { get; set; }
        public bool Expr1 { get; set; }
        public int InchargeZoneId { get; set; }
        public string? InchargeZoneName { get; set; }
        public int InchargeSectorId { get; set; }
        public string? InchargeSectorName { get; set; }
        public int InchargeDivisionId { get; set; }
        public string? InchargeDivisionName { get; set; }
        public bool IsTraffic { get; set; }
        public int CheckDivisionId { get; set; }
        public string? CheckDivisionName { get; set; }
        public int CheckZoneId { get; set; }
        public string? CheckZoneName { get; set; }
        public int CheckSectorId { get; set; }
        public string? CheckSectorName { get; set; }
    }
}