using System.ComponentModel.DataAnnotations.Schema;

namespace AhmedabadCityDR.Models.TableModels
{
    [Keyless]
    [Table("tblCurrentYearAgeWiseMissingChildDetails_HITS")]
    public partial class TblCurrentYearAgeWiseMissingChildDetailsHit
    {
        public int CurrentYearAgeWiseMissingChildId { get; set; }
        public int? PoliceStationId { get; set; }
        public int? CategoryId { get; set; }
        public int? GenderId { get; set; }

        [Column("DOB", TypeName = "datetime")]
        public DateTime? Dob { get; set; }

        public int? ActualAge { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public int? ModifiedUserId { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? CreatedDate { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? ModifiedDate { get; set; }

        public int? CreatedUserId { get; set; }
    }
}