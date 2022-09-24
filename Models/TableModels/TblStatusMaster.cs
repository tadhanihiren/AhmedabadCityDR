using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AhmedabadCityDR.Models.TableModels
{
    [Table("tblStatusMaster")]
    public partial class TblStatusMaster
    {
        public TblStatusMaster()
        {
            TblCctvMasters = new HashSet<TblCctvMaster>();
        }

        [Key]
        public int StatusId { get; set; }

        public string? StatusType { get; set; }

        [InverseProperty("Status")]
        public virtual ICollection<TblCctvMaster> TblCctvMasters { get; set; }
    }
}