using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AhmedabadCityDR.Models.TableModels
{
    [Table("tblSubCategoryMaster")]
    public partial class TblSubCategoryMaster
    {
        public TblSubCategoryMaster()
        {
            TblAtakayatiPaglaSummaries = new HashSet<TblAtakayatiPaglaSummary>();
            TblAtakayatidetails = new HashSet<TblAtakayatidetail>();
            TblCurrentYearMissingChildDetails = new HashSet<TblCurrentYearMissingChildDetail>();
            TblForm5Masters = new HashSet<TblForm5Master>();
            TblLaborInformationMasters = new HashSet<TblLaborInformationMaster>();
            TbldetainMasters = new HashSet<TbldetainMaster>();
        }

        [Key]
        public int SubCategoryId { get; set; }

        public int CategoryId { get; set; }
        public string? SubCategoryName { get; set; }

        [Column("IPC")]
        public string? Ipc { get; set; }

        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? CreatedDate { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? ModifiedDate { get; set; }

        public int? CreatedUserId { get; set; }
        public int? ModifiedUserId { get; set; }
        public string? SubCategoryGname { get; set; }

        [ForeignKey("CategoryId")]
        [InverseProperty("TblSubCategoryMasters")]
        public virtual TblCategoryMaster Category { get; set; } = null!;

        [InverseProperty("SubCategory")]
        public virtual ICollection<TblAtakayatiPaglaSummary> TblAtakayatiPaglaSummaries { get; set; }

        [InverseProperty("SubCategory")]
        public virtual ICollection<TblAtakayatidetail> TblAtakayatidetails { get; set; }

        [InverseProperty("SubCategory")]
        public virtual ICollection<TblCurrentYearMissingChildDetail> TblCurrentYearMissingChildDetails { get; set; }

        [InverseProperty("SubCategory")]
        public virtual ICollection<TblForm5Master> TblForm5Masters { get; set; }

        [InverseProperty("SubCategory")]
        public virtual ICollection<TblLaborInformationMaster> TblLaborInformationMasters { get; set; }

        [InverseProperty("SubCategory")]
        public virtual ICollection<TbldetainMaster> TbldetainMasters { get; set; }
    }
}