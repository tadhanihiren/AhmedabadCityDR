using System.ComponentModel.DataAnnotations.Schema;

namespace AhmedabadCityDR.Models.ViewModels
{
    [Keyless, NotMapped]
    public class NightRoundViewModel
    {
        public int NightRoundId { get; set; }
        public string? NightRoundOfficerName { get; set; }
        public string? GoingTime { get; set; }
        public string? ReturnTime { get; set; }
        public string? NightRoundPlace { get; set; }
        public string? Remarks { get; set; }
        public int? PoliceStationId { get; set; }
        public string? PoliceStationName { get; set; }
        public DateTime? CreatedDate { get; set; }

    }
}
