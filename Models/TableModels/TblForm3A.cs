using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AhmedabadCityDR.Models.TableModels
{
    [Table("tblForm3A")]
    public partial class TblForm3A
    {
        [Key]
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

        [ForeignKey("PoliceStationId")]
        [InverseProperty("TblForm3As")]
        public virtual TblPoliceStationMaster? PoliceStation { get; set; }
    }
}