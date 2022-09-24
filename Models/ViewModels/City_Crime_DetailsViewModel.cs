using System.ComponentModel.DataAnnotations.Schema;

namespace AhmedabadCityDR.Models.ViewModels
{
    [Keyless, NotMapped]
    public class City_Crime_DetailsViewModel
    {
        public int SubCategoryId { get; set; }
        public string? SubCategoryName { get; set; }
        public int? Total { get; set; }
        public string? PoliceStationName { get; set; }
    }
}