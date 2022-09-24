using System.ComponentModel.DataAnnotations.Schema;

namespace AhmedabadCityDR.Models.TableModels
{
    [Keyless]
    [Table("tblNightRound_HEKO_POMaster_HIST")]
    public partial class TblNightRoundHekoPomasterHist
    {
        [Column("NightRound_HEKO_POID")]
        public int NightRoundHekoPoid { get; set; }

        public int? PoliceStationId { get; set; }
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

        [Column(TypeName = "datetime")]
        public DateTime? ModifiedDate { get; set; }

        public int? CreatedUserId { get; set; }
        public int? ModifiedUserId { get; set; }
    }
}