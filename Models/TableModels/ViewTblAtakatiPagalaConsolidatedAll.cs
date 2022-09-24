using System.ComponentModel.DataAnnotations.Schema;

namespace AhmedabadCityDR.Models.TableModels
{
    [Keyless]
    public partial class ViewTblAtakatiPagalaConsolidatedAll
    {
        public int SectorId { get; set; }
        public string? SectorName { get; set; }
        public int ZoneId { get; set; }
        public string? ZoneName { get; set; }
        public int DivisionId { get; set; }
        public string? DivisionName { get; set; }
        public int PoliceStationId { get; set; }
        public string? PoliceStationName { get; set; }
        public int AtakayatiPagalaBackupId { get; set; }

        [Column("CRPC107")]
        public int? Crpc107 { get; set; }

        [Column("CRPC109")]
        public int? Crpc109 { get; set; }

        [Column("CRPC110")]
        public int? Crpc110 { get; set; }

        [Column("BPACT122C")]
        public int? Bpact122c { get; set; }

        [Column("BPACT124")]
        public int? Bpact124 { get; set; }

        [Column("BPACT56")]
        public int? Bpact56 { get; set; }

        [Column("BPACT57")]
        public int? Bpact57 { get; set; }

        [Column("BPACT135_1")]
        public int? Bpact1351 { get; set; }

        [Column("BPACT142")]
        public int? Bpact142 { get; set; }

        public int? Prohi93 { get; set; }
        public int? Total { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? CreatedDate { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? ModifiedDate { get; set; }

        public int? CreateduserId { get; set; }
        public int? ModifiedUserId { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }

        [Column("PASA")]
        public int? Pasa { get; set; }
    }
}