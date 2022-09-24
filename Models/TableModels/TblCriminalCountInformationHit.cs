using System.ComponentModel.DataAnnotations.Schema;

namespace AhmedabadCityDR.Models.TableModels
{
    [Keyless]
    [Table("tblCriminalCountInformation_HITS")]
    public partial class TblCriminalCountInformationHit
    {
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
    }
}