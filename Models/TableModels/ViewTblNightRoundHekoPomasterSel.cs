using System.ComponentModel.DataAnnotations.Schema;

namespace AhmedabadCityDR.Models.TableModels
{
    [Keyless]
    public partial class ViewTblNightRoundHekoPomasterSel
    {
        [Column("NightRound_HEKO_POID")]
        public int NightRoundHekoPoid { get; set; }

        public int? TotalOfMotarcycle { get; set; }
        public int? MaofNumber { get; set; }

        [Column("NightRound_Heko_PONumber")]
        public int? NightRoundHekoPonumber { get; set; }

        public int? DefectNumber { get; set; }
        public int? NotavailabelNumber { get; set; }
        public string? Remark { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? CreatedDate { get; set; }

        public int PoliceStationId { get; set; }
        public string? PoliceStationName { get; set; }
        public int DivisionId { get; set; }
        public string? DivisionName { get; set; }
        public int ZoneId { get; set; }
        public string? ZoneName { get; set; }
        public int SectorId { get; set; }
        public string? SectorName { get; set; }
    }
}