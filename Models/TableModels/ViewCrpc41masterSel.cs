using System.ComponentModel.DataAnnotations.Schema;

namespace AhmedabadCityDR.Models.TableModels
{
    [Keyless]
    public partial class ViewCrpc41masterSel
    {
        [Column("CRPCId")]
        public int Crpcid { get; set; }

        [Column("CRPCNumber")]
        public string? Crpcnumber { get; set; }

        public string? Crime { get; set; }
        public string? AccusedName { get; set; }
        public string? VehicalDetails { get; set; }
        public string? AccusedDetails { get; set; }
        public string? ShortDetails { get; set; }
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }

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