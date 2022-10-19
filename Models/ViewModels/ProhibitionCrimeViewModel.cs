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
        public int? Pidhela { get; set; }
        public int? Kabjama { get; set; }
        public int? CrimeNumber { get; set; }
        public int? ArrestsNumber { get; set; }
        public int? Issue { get; set; }
        public string? Mudamal_value { get; set; }
        public int? TotalNumberCase { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }
    }
}
