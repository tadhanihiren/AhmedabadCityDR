using System.ComponentModel.DataAnnotations.Schema;

namespace AhmedabadCityDR.Models.TableModels
{
    [Keyless]
    public partial class ViewTblForm3ASel
    {
        public int AkasmatId { get; set; }

        [Column("Complainant_accused")]
        public string? ComplainantAccused { get; set; }

        [Column("Complainant_accusedName")]
        public string? ComplainantAccusedName { get; set; }

        public string? HistoryofPast { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? ModifiedDate { get; set; }

        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public int PoliceStationId { get; set; }
        public string? PoliceStationName { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? CreatedDate { get; set; }

        public int DivisionId { get; set; }
        public string? DivisionName { get; set; }
        public string? ZoneName { get; set; }
        public int SectorId { get; set; }
        public string? SectorName { get; set; }
        public int ZoneId { get; set; }
        public int? CreateduserId { get; set; }
        public int? ModifiedUserId { get; set; }
    }
}