using System.ComponentModel.DataAnnotations.Schema;

namespace AhmedabadCityDR.Models.TableModels
{
    [Keyless]
    public partial class ViewTblNightRoundSel
    {
        public int NightRoundId { get; set; }
        public string? NightRoundOfficerName { get; set; }
        public string? GoingTime { get; set; }
        public string? ReturnTime { get; set; }
        public string? NightRoundPlace { get; set; }
        public string? Remarks { get; set; }
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
        public int? DesignationId { get; set; }
        public string? DesignationName { get; set; }
    }
}