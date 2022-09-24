using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AhmedabadCityDR.Models.TableModels
{
    [Table("tblStateMaster")]
    public partial class TblStateMaster
    {
        public TblStateMaster()
        {
            TblCityMasters = new HashSet<TblCityMaster>();
        }

        [Key]
        public int StateId { get; set; }

        public string? StateName { get; set; }

        [InverseProperty("State")]
        public virtual ICollection<TblCityMaster> TblCityMasters { get; set; }
    }
}