using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AhmedabadCityDR.Models.TableModels
{
    [Keyless]
    public partial class ViewTblStationerySel
    {
        [Column("stationaryId")]
        public int StationaryId { get; set; }

        public string? PoliceStationName { get; set; }
        public int? Expr1 { get; set; }

        [StringLength(50)]
        public string? Telephone { get; set; }

        [StringLength(50)]
        public string? Computer { get; set; }

        [Column("Giswan_Connectivity")]
        [StringLength(50)]
        public string? GiswanConnectivity { get; set; }

        [Column("Fax_machine")]
        [StringLength(50)]
        public string? FaxMachine { get; set; }

        [Column("Xerox_machine")]
        [StringLength(50)]
        public string? XeroxMachine { get; set; }

        [Column("Other_Stationary_Stocks")]
        [StringLength(50)]
        public string? OtherStationaryStocks { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? CreatedDate { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? ModifiedDate { get; set; }

        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }
        public int? CreatedUserId { get; set; }
        public int? ModifiedUserId { get; set; }
        public int PoliceStationId { get; set; }
        public int DivisionId { get; set; }
        public string? DivisionName { get; set; }
        public int ZoneId { get; set; }
        public string? ZoneName { get; set; }
        public int SectorId { get; set; }
        public string? SectorName { get; set; }
    }
}