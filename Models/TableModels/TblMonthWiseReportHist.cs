using System.ComponentModel.DataAnnotations.Schema;

namespace AhmedabadCityDR.Models.TableModels
{
    [Keyless]
    [Table("tblMonthWiseReport_HIST")]
    public partial class TblMonthWiseReportHist
    {
        public int MonthWiseReportId { get; set; }
        public string? Name { get; set; }

        [Column("Mobile_Number")]
        public string? MobileNumber { get; set; }

        public int? CategoryId { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? CreatedDate { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? ModifiedDate { get; set; }

        public int? CreatedUserId { get; set; }
        public int? ModifiedUserId { get; set; }
    }
}