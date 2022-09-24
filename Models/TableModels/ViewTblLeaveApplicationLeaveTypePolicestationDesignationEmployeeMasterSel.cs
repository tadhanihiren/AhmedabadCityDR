using System.ComponentModel.DataAnnotations.Schema;

namespace AhmedabadCityDR.Models.TableModels
{
    [Keyless]
    public partial class ViewTblLeaveApplicationLeaveTypePolicestationDesignationEmployeeMasterSel
    {
        public string? PoliceStationName { get; set; }
        public string? LeaveTypeName { get; set; }
        public string? DesignationName { get; set; }

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
        public string? ShortName { get; set; }
        public string? EnglishName { get; set; }
        public int EmployeeId { get; set; }
        public string? EmployeName { get; set; }
        public string? Name { get; set; }
        public int DivisionId { get; set; }
        public string? DivisionName { get; set; }
        public int ZoneId { get; set; }
        public string? ZoneName { get; set; }
        public int SectorId { get; set; }
        public string? SectorName { get; set; }
        public string? InchargeEmployeeName { get; set; }
        public int InchargeDesignationId { get; set; }
        public string? InchargeDesignationName { get; set; }
        public int InchargeZoneId { get; set; }
        public string? InchargeZoneName { get; set; }
        public int InchargeSectorId { get; set; }
        public string? InchargeSectorName { get; set; }
        public int InchargeDivisionId { get; set; }
        public string? InchargeDivisionName { get; set; }
        public int InchargePoliceStationId { get; set; }
        public string? InchargePoliceStationName { get; set; }
    }
}