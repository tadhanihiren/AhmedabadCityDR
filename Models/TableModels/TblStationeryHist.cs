using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AhmedabadCityDR.Models.TableModels
{
    [Keyless]
    [Table("tblStationery_HIST")]
    public partial class TblStationeryHist
    {
        [Column("stationaryId")]
        public int StationaryId { get; set; }

        public int? PoliceStationId { get; set; }

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

        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? CreatedDate { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? ModifiedDate { get; set; }

        public int? CreatedUserId { get; set; }
        public int? ModifiedUserId { get; set; }
    }
}