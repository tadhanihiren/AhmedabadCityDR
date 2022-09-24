using System.ComponentModel.DataAnnotations.Schema;

namespace AhmedabadCityDR.Models.ViewModels
{
    [Keyless, NotMapped]
    public class Form3AViewModel
    {
        public int AkasmatId { get; set; }
        public int? PoliceStationId { get; set; }
        public DateTime CreatedDate { get; set; }
        public string? PoliceStationName { get; set; }
        public string? Complainant_accused { get; set; }
        public string? Complainant_accusedName { get; set; }
        public string? HistoryofPast { get; set; }
    }
}