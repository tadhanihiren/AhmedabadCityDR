using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AhmedabadCityDR.Models.TableModels
{
    [Table("tblCriminalCountInformation")]
    public partial class TblCriminalCountInformation
    {
        [Key]
        public int CriminalCountId { get; set; }

        public int? CategoryId { get; set; }
        public int? CurrentMonthCrime { get; set; }
        public int? LastMonthCrime { get; set; }
        public int? CurrentYearCrime { get; set; }
        public int? LastYearCrime { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDelete { get; set; }
        public int? CreatedUserId { get; set; }
        public int? ModifiedUserId { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? CreatedDate { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? ModifiedDate { get; set; }

        public int? PoliceStationId { get; set; }

        [ForeignKey("CategoryId")]
        [InverseProperty("TblCriminalCountInformations")]
        public virtual TblCategoryMaster? Category { get; set; }

        [ForeignKey("PoliceStationId")]
        [InverseProperty("TblCriminalCountInformations")]
        public virtual TblPoliceStationMaster? PoliceStation { get; set; }
    }
}