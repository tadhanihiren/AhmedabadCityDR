using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AhmedabadCityDR.Models.TableModels
{
    [Table("tblCurrentYearAgeWiseMissingChildDetails")]
    public partial class TblCurrentYearAgeWiseMissingChildDetail
    {
        [Key]
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

        [ForeignKey("CategoryId")]
        [InverseProperty("TblCurrentYearAgeWiseMissingChildDetails")]
        public virtual TblCategoryMaster? Category { get; set; }

        [ForeignKey("GenderId")]
        [InverseProperty("TblCurrentYearAgeWiseMissingChildDetails")]
        public virtual TblGenderMaster? Gender { get; set; }

        [ForeignKey("PoliceStationId")]
        [InverseProperty("TblCurrentYearAgeWiseMissingChildDetails")]
        public virtual TblPoliceStationMaster? PoliceStation { get; set; }
    }
}