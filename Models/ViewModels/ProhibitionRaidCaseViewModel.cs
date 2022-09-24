using System.ComponentModel.DataAnnotations.Schema;

namespace AhmedabadCityDR.Models.ViewModels
{
    [Keyless, NotMapped]
    public class ProhibitionRaidCaseViewModel
    {
        public int ProhibitionRaidCaseId { get; set; }
        public int CategoryId { get; set; }
        public string? CategoryName { get; set; }
        public string? IPACT { get; set; }
        public string? Gubatata { get; set; }
        public string? CrimePlace { get; set; }
        public string? RaidTimeCriminalName { get; set; }
        public string? RaidingPartyEmployeeName { get; set; }
        public string? InvestigationOfficerName { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int? CreatedUserId { get; set; }
        public int? ModifiedUserId { get; set; }
        public int PoliceStationId { get; set; }
        public string? PoliceStationName { get; set; }
        public int DivisionId { get; set; }
        public string DivisionName { get; set; }
        public int ZoneId { get; set; }
        public string? ZoneName { get; set; }
        public int SectorId { get; set; }
        public string? SectorName { get; set; }
        public string? PoliceStationNumber { get; set; }
    }
}
