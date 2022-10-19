using System.ComponentModel.DataAnnotations.Schema;

namespace AhmedabadCityDR.Models.ViewModels
{
    [Keyless, NotMapped]
    public class HistoryMissingagewiseViewModel
    {
        public int HistoryMissingAgeWiseId { get; set; }
        public string? PoliceStationName { get; set; }
        public int? PoliceStationId { get; set; }
        public int? Missingboy { get; set; }
        public int? Missinggirl { get; set; }
        public int? MissingChildDetails { get; set; }
        public int? Returnboy { get; set; }
        public int? Returngirl { get; set; }
        public int? ReturnChildDetails { get; set; }
        public int? Missing1to5Girl { get; set; }
        public int? Missing1to5boy { get; set; }
        public int? Missing6to12Girl { get; set; }
        public int? Missing6to12boy { get; set; }
        public int? Missing13to18Girl { get; set; }
        public int? Missing13to18boy { get; set; }
        public int? Return1to5Girl { get; set; }
        public int? Return1to5boy { get; set; }
        public int? Return6to12Girl { get; set; }
        public int? Return6to12boy { get; set; }
        public int? Return13to18Girl { get; set; }
        public int? Return13to18boy { get; set; }
        public int? Totalmissing { get; set; }
        public int? Totalreturn { get; set; }
        public int? Per { get; set; }
         public DateTime? CreatedDate { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDelete { get; set; }

    }
}
