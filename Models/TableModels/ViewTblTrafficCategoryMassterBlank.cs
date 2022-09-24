using System.ComponentModel.DataAnnotations.Schema;

namespace AhmedabadCityDR.Models.TableModels
{
    [Keyless]
    public partial class ViewTblTrafficCategoryMassterBlank
    {
        public string? TrafficCategoryName { get; set; }

        [Column("RS100")]
        public int? Rs100 { get; set; }

        [Column("RS300")]
        public int? Rs300 { get; set; }

        [Column("RS500")]
        public int? Rs500 { get; set; }

        [Column("RS1000")]
        public int? Rs1000 { get; set; }

        [Column("PROSI")]
        public int? Prosi { get; set; }

        [Column("RTO")]
        public int? Rto { get; set; }

        public int? Total { get; set; }
        public int? Amount { get; set; }
    }
}