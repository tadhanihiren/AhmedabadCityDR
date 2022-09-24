using System.ComponentModel.DataAnnotations.Schema;

namespace AhmedabadCityDR.Models.TableModels
{
    [Keyless]
    public partial class ViewHistroryOfCurrentMissingSel
    {
        [Column("histroryOfCurrentMissingId")]
        public int HistroryOfCurrentMissingId { get; set; }

        public int? PoliceStationId { get; set; }
        public int? Missingboy { get; set; }
        public int? Missinggirl { get; set; }
        public int? Returnboy { get; set; }
        public int? Returngirl { get; set; }
        public int? Missingwoman { get; set; }
        public int? Missingman { get; set; }
        public int? ReturnWoman { get; set; }
        public int? Returnman { get; set; }
        public int? TotalmissingChild { get; set; }
        public int? TotalRetrunChild { get; set; }
        public int? TotalMissingPerson { get; set; }
        public int? TotalReturnPerson { get; set; }
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? CreatedDate { get; set; }

        public string? PoliceStationName { get; set; }
        public int DivisionId { get; set; }
        public string? DivisionName { get; set; }
        public int ZoneId { get; set; }
        public string? ZoneName { get; set; }
        public int SectorId { get; set; }
        public string? SectorName { get; set; }
    }
}