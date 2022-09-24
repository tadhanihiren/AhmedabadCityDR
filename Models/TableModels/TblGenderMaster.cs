using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AhmedabadCityDR.Models.TableModels
{
    [Table("tblGenderMaster")]
    public partial class TblGenderMaster
    {
        public TblGenderMaster()
        {
            TblCurrentYearAgeWiseMissingChildDetails = new HashSet<TblCurrentYearAgeWiseMissingChildDetail>();
            TblCurrentYearMissingChildDetails = new HashSet<TblCurrentYearMissingChildDetail>();
            TblMissingChildDetails = new HashSet<TblMissingChildDetail>();
        }

        [Key]
        public int GenderId { get; set; }

        public string? Gender { get; set; }

        [InverseProperty("Gender")]
        public virtual ICollection<TblCurrentYearAgeWiseMissingChildDetail> TblCurrentYearAgeWiseMissingChildDetails { get; set; }

        [InverseProperty("Gender")]
        public virtual ICollection<TblCurrentYearMissingChildDetail> TblCurrentYearMissingChildDetails { get; set; }

        [InverseProperty("Gender")]
        public virtual ICollection<TblMissingChildDetail> TblMissingChildDetails { get; set; }
    }
}