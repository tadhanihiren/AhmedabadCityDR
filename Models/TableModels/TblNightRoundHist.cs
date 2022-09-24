using System.ComponentModel.DataAnnotations.Schema;

namespace AhmedabadCityDR.Models.TableModels
{
    [Keyless]
    [Table("tblNightRound_HIST")]
    public partial class TblNightRoundHist
    {
        public int NightRoundId { get; set; }
        public string? NightRoundOfficerName { get; set; }
        public int? PoliceStationId { get; set; }
        public string? GoingTime { get; set; }
        public string? ReturnTime { get; set; }
        public string? NightRoundPlace { get; set; }
        public string? Remarks { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public int? CreatedUserId { get; set; }
        public int? ModifiedUserId { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? CreatedDate { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? ModifiedDate { get; set; }

        public int? DesignationId { get; set; }
        public int? SectorId { get; set; }
        public int? ZoneId { get; set; }
        public int? DivisionId { get; set; }
    }
}