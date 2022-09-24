using System.ComponentModel.DataAnnotations.Schema;

namespace AhmedabadCityDR.Models.TableModels
{
    [Keyless]
    public partial class ViewCurrentYearAgeWiseMissingChildDetailsDailyReport
    {
        public int CurrentYearAgeWiseMissingChildId { get; set; }

        [Column("DOB", TypeName = "datetime")]
        public DateTime? Dob { get; set; }

        public int? ActualAge { get; set; }
        public int GenderId { get; set; }
        public string? Gender { get; set; }
        public int CategoryId { get; set; }
        public string? CategoryName { get; set; }
        public int PoliceStationId { get; set; }
        public string? PoliceStationName { get; set; }
        public int SubCategoryId { get; set; }
        public string? SubCategoryName { get; set; }
    }
}