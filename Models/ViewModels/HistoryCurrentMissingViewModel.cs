using System.ComponentModel.DataAnnotations.Schema;

namespace AhmedabadCityDR.Models.ViewModels
{
    [Keyless, NotMapped]

    public class HistoryCurrentMissingViewModel
    {
        public int HistroryOfCurrentMissingId { get; set; }
        public int? PoliceStationId { get; set; }
        public int? Missingboy { get; set; }
        public int? Missinggirl { get; set; }
        public int? Returnboy { get; set; }
        public int? Returngirl { get; set; }
        public int? Missingwoman { get; set; }
        public int? Missingman { get; set; }
        public int? ReturnWoman { get; set; }
        public int? Returnman { get; set; }
        public int? TotalmissingChild { get; set; }
        public int? TotalRetrunChild { get; set; }
        public int? TotalMissingPerson { get; set; }
        public int? TotalReturnPerson { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? PoliceStationName { get; set; }

    }
}
