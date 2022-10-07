using System.ComponentModel.DataAnnotations.Schema;

namespace AhmedabadCityDR.Models.ViewModels
{
    [Keyless,NotMapped]

    public class Visitation_CrimeBranchViewModel
    {
        public int VisitationId { get; set; }
        public int? PoliceStationId { get; set; }
        public string? PoliceStationName { get; set; }
        public string? GUBATATA_CrimePlace { get; set; }
        public string? CrimeVisitPlace { get; set; }
        public DateTime? VisitDate { get; set; }
        public string? Visiter_OfficerName { get; set; }
        public DateTime? CreatedDate { get; set; }

    }
}
