using System.ComponentModel.DataAnnotations.Schema;

namespace AhmedabadCityDR.Models.TableModels
{
    [Keyless]
    public partial class ViewEmployeeMasterSel1
    {
        public int LoginId { get; set; }
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public string? ContactNo { get; set; }
        public string? Name { get; set; }
        public string? DeviceId { get; set; }
        public string? RoleName { get; set; }
        public int? RoleId { get; set; }
        public string? SectorName { get; set; }
        public string? DivisionName { get; set; }
        public string? ZoneName { get; set; }
        public int? PoliceStationId { get; set; }
        public string? PoliceStationName { get; set; }

        [Column("ForTraffic_City")]
        public int? ForTrafficCity { get; set; }

        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }
        public bool IsMobileAccess { get; set; }
        public int? CreatedUserId { get; set; }
        public int? ModifiedUserId { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? CreatedDate { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? ModifiedDate { get; set; }

        public bool IsTraffic { get; set; }
        public int? SectorId { get; set; }
        public int? ZoneId { get; set; }
        public int? DivisionId { get; set; }
    }
}