using System.ComponentModel.DataAnnotations.Schema;

namespace AhmedabadCityDR.Models.ViewModels
{
    [Keyless, NotMapped]
    public class BandobastDetailsViewModel
    {
        public int BandoBastId { get; set; }
        public int? PoliceStationId { get; set; }
        public string? PoliceStationName { get; set; }
        public string? BandoBastPlace { get; set; }
        public int? BandobastTypeId { get; set; }
        public string? BandobastDetail_ForceNumber { get; set; }
        public string? ShortDetail { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int? CreatedUserId { get; set; }
        public int? ModifiedUserId { get; set; }
        public int? ZoneId { get; set; }
        public string? ZoneName { get; set; }
        public int? DivisionId { get; set; }
        public string? DivisionName { get; set; }
        public int? SectorId { get; set; }
        public string? SectorName { get; set; }

    }
}
