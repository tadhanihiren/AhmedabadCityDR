using System.ComponentModel.DataAnnotations.Schema;

namespace AhmedabadCityDR.Models.ViewModels
{
    [Keyless, NotMapped]
    public class ProhibitionCrimeViewModel
    {
        public int ProhibitioncrimeId { get; set; }
        public int? PoliceStationId { get; set; }
        public string? PoliceStationName { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? pidhela { get; set; }
        public int? kabjama { get; set; }
        public int? CrimeNumber { get; set; }
        public int? arrestsNumber { get; set; }
        public int? issue { get; set; }
        public string? mudamal_value { get; set; }
        public int? totalNumberCase { get; set; }


    }
}
