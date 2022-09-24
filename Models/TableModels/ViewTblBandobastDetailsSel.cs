using System.ComponentModel.DataAnnotations.Schema;

namespace AhmedabadCityDR.Models.TableModels
{
    [Keyless]
    public partial class ViewTblBandobastDetailsSel
    {
        public int BandoBastId { get; set; }
        public int ZoneId { get; set; }
        public string? ZoneName { get; set; }
        public int DivisionId { get; set; }
        public string? DivisionName { get; set; }
        public int PoliceStationId { get; set; }
        public string? PoliceStationName { get; set; }
        public string? BandoBastPlace { get; set; }

        [Column("BandobastDetail_ForceNumber")]
        public string? BandobastDetailForceNumber { get; set; }

        public string? ShortDetail { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? CreatedDate { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? ModifiedDate { get; set; }

        public int SectorId { get; set; }
        public string? SectorName { get; set; }
        public string? BandobastType { get; set; }
        public int? BandobastTypeId { get; set; }
        public bool IsTraffic { get; set; }
    }
}