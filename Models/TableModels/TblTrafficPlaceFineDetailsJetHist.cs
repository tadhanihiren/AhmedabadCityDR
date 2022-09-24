using System.ComponentModel.DataAnnotations.Schema;

namespace AhmedabadCityDR.Models.TableModels
{
    [Keyless]
    [Table("tblTrafficPlaceFineDetailsJET_HIST")]
    public partial class TblTrafficPlaceFineDetailsJetHist
    {
        public int TrafficPlaceJetFineId { get; set; }
        public int? TrafficCategoryId { get; set; }
        public int? WardId { get; set; }
        public int? WheelerTypeId { get; set; }

        [Column("RS50")]
        public int? Rs50 { get; set; }

        [Column("RS100")]
        public int? Rs100 { get; set; }

        [Column("RS200")]
        public int? Rs200 { get; set; }

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
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }
        public int? CreatedUserId { get; set; }
        public int? ModifiedUserId { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? CreatedDate { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? ModifiedDate { get; set; }

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