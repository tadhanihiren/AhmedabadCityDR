using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AhmedabadCityDR.Models.TableModels
{
    [Table("tblHistoryMissingAgeWiseChild")]
    public partial class TblHistoryMissingAgeWiseChild
    {
        [Key]
        public int HistoryMissingAgeWiseId { get; set; }

        public int? PoliceStationId { get; set; }
        public int? Missingboy { get; set; }
        public int? Missinggirl { get; set; }
        public int? MissingChildDetails { get; set; }
        public int? Returnboy { get; set; }
        public int? Returngirl { get; set; }
        public int? ReturnChildDetails { get; set; }
        public int? Missing1to5Girl { get; set; }
        public int? Missing1to5boy { get; set; }
        public int? Missing6to12Girl { get; set; }
        public int? Missing6to12boy { get; set; }
        public int? Missing13to18Girl { get; set; }
        public int? Missing13to18boy { get; set; }

        [Column("return1to5Girl")]
        public int? Return1to5Girl { get; set; }

        [Column("return1to5boy")]
        public int? Return1to5boy { get; set; }

        [Column("return6to12Girl")]
        public int? Return6to12Girl { get; set; }

        [Column("return6to12boy")]
        public int? Return6to12boy { get; set; }

        [Column("return13to18Girl")]
        public int? Return13to18Girl { get; set; }

        [Column("return13to18boy")]
        public int? Return13to18boy { get; set; }

        [Column("totalmissing")]
        public int? Totalmissing { get; set; }

        [Column("totalreturn")]
        public int? Totalreturn { get; set; }

        [Column("per")]
        public int? Per { get; set; }

        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }
        public int? CreatedUserId { get; set; }
        public int? ModifiedUserId { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? CreatedDate { get; set; }

        [ForeignKey("PoliceStationId")]
        [InverseProperty("TblHistoryMissingAgeWiseChildren")]
        public virtual TblPoliceStationMaster? PoliceStation { get; set; }
    }
}