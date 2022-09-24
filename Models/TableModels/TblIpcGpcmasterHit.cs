using System.ComponentModel.DataAnnotations.Schema;

namespace AhmedabadCityDR.Models.TableModels
{
    [Keyless]
    [Table("tblIPC_GPCMaster_HITS")]
    public partial class TblIpcGpcmasterHit
    {
        [Column("IPC_GPCId")]
        public int IpcGpcid { get; set; }

        [Column("IPC_GPCName")]
        public string? IpcGpcname { get; set; }
    }
}