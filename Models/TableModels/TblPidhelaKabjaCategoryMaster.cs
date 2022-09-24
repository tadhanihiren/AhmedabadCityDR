using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AhmedabadCityDR.Models.TableModels
{
    [Table("tblPidhela_Kabja_CategoryMaster")]
    public partial class TblPidhelaKabjaCategoryMaster
    {
        [Key]
        [Column("Pidhela_Kabja_CategoryId")]
        public int PidhelaKabjaCategoryId { get; set; }

        [Column("Pidhela_Kabja_CategoryName")]
        public string? PidhelaKabjaCategoryName { get; set; }
    }
}