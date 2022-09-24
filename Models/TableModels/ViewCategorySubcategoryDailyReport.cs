using System.ComponentModel.DataAnnotations.Schema;

namespace AhmedabadCityDR.Models.TableModels
{
    [Keyless]
    public partial class ViewCategorySubcategoryDailyReport
    {
        public int CurrentYearAgeWiseMissingChildId { get; set; }

        [Column("DOB", TypeName = "datetime")]
        public DateTime? Dob { get; set; }

        public int? ActualAge { get; set; }
        public int CategoryId { get; set; }
        public string? CategoryName { get; set; }
        public string? SubCategoryName { get; set; }
    }
}