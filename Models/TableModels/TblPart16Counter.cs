using System.ComponentModel.DataAnnotations.Schema;

namespace AhmedabadCityDR.Models.TableModels
{
    [Keyless]
    [Table("tblPart_1_6_Counter")]
    public partial class TblPart16Counter
    {
        [Column("Part1_5_6_Id")]
        public int Part156Id { get; set; }

        public int CategoryId { get; set; }
        public int SubCategoryId { get; set; }
        public int CrimesCount { get; set; }
        public string DeviceId { get; set; } = null!;

        [Column(TypeName = "datetime")]
        public DateTime? CreatedDate { get; set; }

        public int? SectorId { get; set; }
        public int? ZoneId { get; set; }
        public int? DivisionId { get; set; }
        public int? PoliceStationId { get; set; }

        [ForeignKey("CategoryId")]
        public virtual TblCategoryMaster Category { get; set; } = null!;

        [ForeignKey("DivisionId")]
        public virtual TblDivisionMaster? Division { get; set; }

        [ForeignKey("PoliceStationId")]
        public virtual TblPoliceStationMaster? PoliceStation { get; set; }

        [ForeignKey("SectorId")]
        public virtual TblSectorMaster? Sector { get; set; }

        [ForeignKey("SubCategoryId")]
        public virtual TblSubCategoryMaster SubCategory { get; set; } = null!;

        [ForeignKey("ZoneId")]
        public virtual TblZoneMaster? Zone { get; set; }
    }
}