using System.ComponentModel.DataAnnotations.Schema;

namespace AhmedabadCityDR.Models.TableModels
{
    [Keyless]
    public partial class ViewTblPlaceFineForNullJet
    {
        public int TrafficCategoryId { get; set; }
        public string? TrafficCategoryName { get; set; }
        public string? PoliceStationName { get; set; }
        public string? ShortName { get; set; }
        public int? DivisionId { get; set; }
        public string? DivisionName { get; set; }
        public int? ZoneId { get; set; }
        public string? ZoneName { get; set; }
        public int? SectorId { get; set; }
        public string? SectorName { get; set; }
        public int? TrafficPlaceFineId { get; set; }
        public int? PoliceStationId { get; set; }
        public int? WheelerTypeId { get; set; }

        [Column("RS100")]
        public int? Rs100 { get; set; }

        [Column("RS300")]
        public int? Rs300 { get; set; }

        [Column("RS500")]
        public int? Rs500 { get; set; }

        [Column("RS1000")]
        public int? Rs1000 { get; set; }

        public int? Total { get; set; }
        public int? Amount { get; set; }

        [Column("PROSI")]
        public int? Prosi { get; set; }

        [Column("RTO")]
        public int? Rto { get; set; }

        public int? GrandTotal { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDelete { get; set; }
        public int? CreatedUserId { get; set; }
        public int? ModifiedUserId { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? CreatedDate { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? ModifiedDate { get; set; }

        [Column("RS50")]
        public int? Rs50 { get; set; }

        public int? Rs200 { get; set; }
        public int? WardId { get; set; }
        public string? WardName { get; set; }

        [Column("RS1500")]
        public int? Rs1500 { get; set; }

        [Column("RS2000")]
        public int? Rs2000 { get; set; }

        [Column("RS3000")]
        public int? Rs3000 { get; set; }

        [Column("RS4000")]
        public int? Rs4000 { get; set; }

        [Column("RS5000")]
        public int? Rs5000 { get; set; }

        [Column("RS400")]
        public int? Rs400 { get; set; }
    }
}