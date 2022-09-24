using System.ComponentModel.DataAnnotations.Schema;

namespace AhmedabadCityDR.Models.TableModels
{
    [Keyless]
    [Table("tblEquipments_HITS")]
    public partial class TblEquipmentsHit
    {
        public int EquipmentsId { get; set; }

        [Column("type")]
        public string? Type { get; set; }
    }
}