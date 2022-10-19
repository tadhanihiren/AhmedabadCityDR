namespace AhmedabadCityDR.Models.APIModels
{
    public class Post_TrafficEmployeeDetails
    {
        public int EmployeeId { get; set; }
        public string? BuckleNo { get; set; }
        public string? EmployeName { get; set; }
        public string? Name { get; set; }
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public string? ContactNumber { get; set; }
        public int? DesignationId { get; set; }
        public int? TempId { get; set; }
        public int? TransfferTempId { get; set; }
        public int? RoleId { get; set; }
        public int? SectorId { get; set; }
        public int? ZoneId { get; set; }
        public int? DivisionId { get; set; }
        public int? PoliceStationId { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? DivisionName { get; set; }
        public string? PoliceStationName { get; set; }
        public string? ZoneName { get; set; }
        public string? SectorName { get; set; }
        public string? DesignationName { get; set; }
        public bool? IsTraffic { get; set; }
        public string? PrtiniyukatName { get; set; }
        public string? Todate { get; set; }
        public string? Fromdate { get; set; }
        public string? PrtiniyukatPlace { get; set; }
    }
}
