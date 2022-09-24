using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AhmedabadCityDR.Models.TableModels
{
    [Table("tblE_GujakopMaster")]
    public partial class TblEGujakopMaster
    {
        [Key]
        [Column("E_GujakopId")]
        public int EGujakopId { get; set; }

        public int? PoliceStationId { get; set; }
        public int? Part1to5number { get; set; }

        [Column("Part1to5E_Gujakop")]
        public int? Part1to5EGujakop { get; set; }

        [Column("part6number")]
        public int? Part6number { get; set; }

        [Column("part6E_Gujakop")]
        public int? Part6EGujakop { get; set; }

        public int? ProhiNumber { get; set; }

        [Column("ProhiE_Gujakop")]
        public int? ProhiEGujakop { get; set; }

        [Column("a_amNumber")]
        public int? AAmNumber { get; set; }

        [Column("a_amE_Gujakop")]
        public int? AAmEGujakop { get; set; }

        [Column("acciendentNumber")]
        public int? AcciendentNumber { get; set; }

        [Column("acciendentE_Gujakop")]
        public int? AcciendentEGujakop { get; set; }

        [Column("janvajogNumber")]
        public int? JanvajogNumber { get; set; }

        [Column("janvajogE_Gujakop")]
        public int? JanvajogEGujakop { get; set; }

        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? CreatedDate { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? ModifiedDate { get; set; }

        public int? CreatedUserId { get; set; }
        public int? ModifiedUserId { get; set; }

        [ForeignKey("PoliceStationId")]
        [InverseProperty("TblEGujakopMasters")]
        public virtual TblPoliceStationMaster? PoliceStation { get; set; }
    }
}