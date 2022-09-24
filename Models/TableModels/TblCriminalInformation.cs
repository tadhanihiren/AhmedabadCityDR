using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AhmedabadCityDR.Models.TableModels
{
    [Table("tblCriminalInformation")]
    public partial class TblCriminalInformation
    {
        [Key]
        public int CriminalId { get; set; }

        public int? CategoryId { get; set; }
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

        public int? CreatedUserId { get; set; }
        public int? ModifiedUserId { get; set; }

        [ForeignKey("CategoryId")]
        [InverseProperty("TblCriminalInformations")]
        public virtual TblCategoryMaster? Category { get; set; }
    }
}