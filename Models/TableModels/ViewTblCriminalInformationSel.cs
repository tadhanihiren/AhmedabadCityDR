using System.ComponentModel.DataAnnotations.Schema;

namespace AhmedabadCityDR.Models.TableModels
{
    [Keyless]
    public partial class ViewTblCriminalInformationSel
    {
        public int CategoryId { get; set; }
        public string? CategoryName { get; set; }
        public int CriminalId { get; set; }
        public int? TodaysCrime { get; set; }
        public int? LastCrime { get; set; }
        public int? CurrentMonthCrime { get; set; }
        public int? LastMonthCrime { get; set; }
        public int? CurrentYearCrime { get; set; }
        public int? LastYearCrime { get; set; }
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? CreatedDate { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? ModifiedDate { get; set; }
    }
}