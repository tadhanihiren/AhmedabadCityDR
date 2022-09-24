using System.ComponentModel.DataAnnotations.Schema;

namespace AhmedabadCityDR.Models.TableModels
{
    [Keyless]
    public partial class ViewTblProhibitionCrimeMasterSel
    {
        public int ProhibitioncrimeId { get; set; }

        [Column("pidhela")]
        public int? Pidhela { get; set; }

        [Column("kabjama")]
        public int? Kabjama { get; set; }

        public int? CrimeNumber { get; set; }

        [Column("arrestsNumber")]
        public int? ArrestsNumber { get; set; }

        [Column("issue")]
        public int? Issue { get; set; }

        [Column("mudamal_value")]
        public string? MudamalValue { get; set; }

        [Column("totalNumberCase")]
        public int? TotalNumberCase { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? CreatedDate { get; set; }

        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public int PoliceStationId { get; set; }
        public string? PoliceStationName { get; set; }
        public int DivisionId { get; set; }
        public string? DivisionName { get; set; }
        public int? Expr1 { get; set; }
        public string? ZoneName { get; set; }
        public int SectorId { get; set; }
        public string? SectorName { get; set; }
        public int ZoneId { get; set; }
    }
}