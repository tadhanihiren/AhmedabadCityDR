using System.ComponentModel.DataAnnotations.Schema;

namespace AhmedabadCityDR.Models.ViewModels
{
    [Keyless, NotMapped]
    public class Aksmat_DeathViewModel
    {
        public string? PoliceStationName { get; set; }
        public string? PoliceStationNumber { get; set; }
        public int CrimesId { get; set; }
        public string? Complainer { get; set; }
        public string? Accused { get; set; }
        public string? Gubatata { get; set; }
        public string? Gujatata { get; set; }
        public string? Gudatata { get; set; }
        public string? CrimePlace { get; set; }
        public string? PersonNameWhoFiledCrime { get; set; }
        public string? InvestigationOfficer { get; set; }
        public string? ShortDetail { get; set; }
        public string? HdiitsEntry { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDelete { get; set; }
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
        public int? PoliceStationId { get; set; }
        public string? IPCACT { get; set; }
    }
}