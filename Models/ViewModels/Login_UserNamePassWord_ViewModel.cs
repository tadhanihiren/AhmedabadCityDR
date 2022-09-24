namespace AhmedabadCityDR.Models.ViewModels
{
    [Keyless]
    public class Login_UserNamePassWord_ViewModel
    {
        public int LoginId { get; set; }
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public string? ContactNo { get; set; }
        public string? Name { get; set; }
        public string? DeviceId { get; set; }
        public int? RoleId { get; set; }
        public int? SectorId { get; set; }
        public int? ZoneId { get; set; }
        public int? DivisionId { get; set; }
        public int? PoliceStationId { get; set; }
        public string? PoliceStationName { get; set; }
        public string? DivisionName { get; set; }
        public string? ZoneName { get; set; }
        public string? SectorName { get; set; }
    }
}