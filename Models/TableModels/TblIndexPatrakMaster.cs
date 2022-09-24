using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AhmedabadCityDR.Models.TableModels
{
    [Table("tblIndexPatrakMaster")]
    public partial class TblIndexPatrakMaster
    {
        public TblIndexPatrakMaster()
        {
            TblChangeColors = new HashSet<TblChangeColor>();
            TblSamelPatrakMasters = new HashSet<TblSamelPatrakMaster>();
        }

        [Key]
        public int PatrakId { get; set; }

        [Column("Patrak_Name")]
        public string? PatrakName { get; set; }

        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }
        public int? GroupNo { get; set; }
        public bool IsTraffic { get; set; }

        [InverseProperty("Patrak")]
        public virtual ICollection<TblChangeColor> TblChangeColors { get; set; }

        [InverseProperty("Patrak")]
        public virtual ICollection<TblSamelPatrakMaster> TblSamelPatrakMasters { get; set; }
    }
}