using System.ComponentModel.DataAnnotations.Schema;

namespace AhmedabadCityDR.Models.TableModels
{
    [Keyless]
    [Table("tblForm3A_HITS")]
    public partial class TblForm3AHit
    {
        public int AkasmatId { get; set; }
        public int? PoliceStationId { get; set; }

        [Column("Complainant_accused")]
        public string? ComplainantAccused { get; set; }

        [Column("Complainant_accusedName")]
        public string? ComplainantAccusedName { get; set; }

        public string? HistoryofPast { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? CreatedDate { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? ModifiedDate { get; set; }

        public int? CreateduserId { get; set; }
        public int? ModifiedUserId { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
    }
}