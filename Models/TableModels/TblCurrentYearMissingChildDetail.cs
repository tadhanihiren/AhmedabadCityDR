using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AhmedabadCityDR.Models.TableModels
{
    [Table("tblCurrentYearMissingChildDetails")]
    public partial class TblCurrentYearMissingChildDetail
    {
        [Key]
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

        [ForeignKey("GenderId")]
        [InverseProperty("TblCurrentYearMissingChildDetails")]
        public virtual TblGenderMaster? Gender { get; set; }

        [ForeignKey("PoliceStationId")]
        [InverseProperty("TblCurrentYearMissingChildDetails")]
        public virtual TblPoliceStationMaster? PoliceStation { get; set; }

        [ForeignKey("SubCategoryId")]
        [InverseProperty("TblCurrentYearMissingChildDetails")]
        public virtual TblSubCategoryMaster? SubCategory { get; set; }
    }
}