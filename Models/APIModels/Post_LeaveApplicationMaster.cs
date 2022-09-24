namespace AhmedabadCityDR.Models.APIModels
{
    public class Post_LeaveApplicationMaster
    {
        public int LeaveApplicationID { get; set; } = 0;
        public int? DesignationId { get; set; }
        public int? LeaveTypeId { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public string? TotalDays { get; set; }
        public string? Remarks { get; set; }
        public int? InchargeDesignationId { get; set; }
        public int? InchargePoliceStationId { get; set; }
        public int? EmployeeId { get; set; }
        public int? InchargeEmployeeId { get; set; }
        public int? TempSZDPId { get; set; }
        public int? InchargeZoneId { get; set; }
        public int? TempInchargeSectorId { get; set; }
        public int? InchargeSectorId { get; set; }
        public int? InchargeDivisionId { get; set; }
    }
}
