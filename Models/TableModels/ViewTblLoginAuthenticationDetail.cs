using System.ComponentModel.DataAnnotations.Schema;

namespace AhmedabadCityDR.Models.TableModels
{
    [Keyless]
    public partial class ViewTblLoginAuthenticationDetail
    {
        public int SectorId { get; set; }
        public string? SectorName { get; set; }
        public int ZoneId { get; set; }
        public string? ZoneName { get; set; }
        public int DivisionId { get; set; }
        public string? DivisionName { get; set; }
        public int DesignationId { get; set; }
        public string? DesignationName { get; set; }
        public int PoliceStationId { get; set; }
        public string? PoliceStationName { get; set; }
        public int LoginId { get; set; }
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public string? ContactNo { get; set; }
        public string? Name { get; set; }
        public string? DeviceId { get; set; }

        [Column("ForTraffic_City")]
        public int? ForTrafficCity { get; set; }

        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }
        public bool IsMobileAccess { get; set; }
    }
}