using System.ComponentModel.DataAnnotations.Schema;

namespace AhmedabadCityDR.Models.TableModels
{
    [Keyless]
    [Table("tblCurrentYearMissingChildDetails_HITS")]
    public partial class TblCurrentYearMissingChildDetailsHit
    {
        public int CurrentYearMissingChildId { get; set; }
        public int? PoliceStationId { get; set; }
        public int? SubCategoryId { get; set; }
        public int? GenderId { get; set; }
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