using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AhmedabadCityDR.Models.TableModels
{
    [Table("tblEquipments")]
    public partial class TblEquipment
    {
        public TblEquipment()
        {
            TblCctvMasters = new HashSet<TblCctvMaster>();
        }

        [Key]
        public int EquipmentsId { get; set; }

        [Column("type")]
        public string? Type { get; set; }

        [InverseProperty("Equipments")]
        public virtual ICollection<TblCctvMaster> TblCctvMasters { get; set; }
    }
}