using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AhmedabadCityDR.Models.TableModels
{
    [Table("tblCityMaster")]
    public partial class TblCityMaster
    {
        public TblCityMaster()
        {
            TblSectorMasters = new HashSet<TblSectorMaster>();
        }

        [Key]
        public int CityId { get; set; }

        public string? CityName { get; set; }
        public int? StateId { get; set; }

        [ForeignKey("StateId")]
        [InverseProperty("TblCityMasters")]
        public virtual TblStateMaster? State { get; set; }

        [InverseProperty("City")]
        public virtual ICollection<TblSectorMaster> TblSectorMasters { get; set; }
    }
}