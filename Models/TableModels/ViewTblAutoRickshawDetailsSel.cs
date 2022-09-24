using System.ComponentModel.DataAnnotations.Schema;

namespace AhmedabadCityDR.Models.TableModels
{
    [Keyless]
    public partial class ViewTblAutoRickshawDetailsSel
    {
        public int AutoRickshawId { get; set; }
        public int PoliceStationId { get; set; }
        public string? PoliceStationName { get; set; }
        public string? AutoRickshawNo { get; set; }
        public string? DriverName { get; set; }
        public string? OwnerName { get; set; }
        public int? LicenseNumber { get; set; }
        public int? PermitNumber { get; set; }
        public int? DriversBaseNo { get; set; }

        [Column("RCBook")]
        public int? Rcbook { get; set; }

        [Column("RCBook_Detail")]
        public int? RcbookDetail { get; set; }

        public int? InsurancePolicy { get; set; }
        public int? CheckingOperation { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? CreatedDate { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? ModifiedDate { get; set; }

        public int ZoneId { get; set; }
        public int DivisionId { get; set; }
        public string? DivisionName { get; set; }
        public string? ZoneName { get; set; }
        public int SectorId { get; set; }
        public string? SectorName { get; set; }
    }
}