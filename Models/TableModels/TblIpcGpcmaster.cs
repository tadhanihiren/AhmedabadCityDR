using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AhmedabadCityDR.Models.TableModels
{
    [Table("tblIPC_GPCMaster")]
    public partial class TblIpcGpcmaster
    {
        public TblIpcGpcmaster()
        {
            TblAtakayatiPaglaSummaries = new HashSet<TblAtakayatiPaglaSummary>();
        }

        [Key]
        [Column("IPC_GPCId")]
        public int IpcGpcid { get; set; }

        [Column("IPC_GPCName")]
        public string? IpcGpcname { get; set; }

        [InverseProperty("IpcGpc")]
        public virtual ICollection<TblAtakayatiPaglaSummary> TblAtakayatiPaglaSummaries { get; set; }
    }
}