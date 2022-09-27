namespace AhmedabadCityDR.Models.ViewModels
{
    public class NightEmployeeMasterViewModel
    {
        public int NightEmployeeId { get; set; }
        public int? DesignationId { get; set; }
        public string? DesignationName { get; set; }
        public string? GoingTime { get; set; }
        public string? ReturnTime { get; set; }
        public string? Remarks { get; set; }
        public int? CreatedUserId { get; set; }
        public int? ModifiedUserId { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }
        public int? EmployeeId { get; set; }
        public string? EmployeName { get; set; }
        public int? PoliceStationId { get; set; }
        public string? PoliceStationName { get; set; }
        public int? ZoneId { get; set; }
        public int? DivisionId { get; set; }
        public string? DivisionName { get; set; }
        public string? ZoneName { get; set; }
        public int? SectorId { get; set; }
        public string? SectorName { get; set; }
    }
}
