namespace AhmedabadCityDR.Models.APIModels
{
    public class Post_LoginMaster
    {
        public int LoginId { get; set; }
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public string? ContactNo { get; set; }
        public string? Name { get; set; }
        public string? DeviceId { get; set; }
        public int? RoleId { get; set; } = 0;
        public int? SectorId { get; set; } = 0;
        public int? ZoneId { get; set; } = 0;
        public int? DivisionId { get; set; } = 0;
        public int? PoliceStationId { get; set; } = 0;
        public int? ForTrafficCity { get; set; } = 0;
        public bool? IsActive { get; set; }
        public bool? IsDelete { get; set; }
        public bool? IsMobileAccess { get; set; }
        public int? CreatedUserId { get; set; }
        public int? ModifiedUserId { get; set; }
        public int? DesignationId { get; set; }
        public string? FierBaseId { get; set; }
        public int? TempId { get; set; }
    }
}