using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AhmedabadCityDR.Models.TableModels
{
    [Table("tblAtakayatiPagla")]
    public partial class TblAtakayatiPagla
    {
        [Key]
        public int AtakayatiPagalaBackupId { get; set; }

        public int? PoliceStationId { get; set; }

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

        [ForeignKey("PoliceStationId")]
        [InverseProperty("TblAtakayatiPaglas")]
        public virtual TblPoliceStationMaster? PoliceStation { get; set; }
    }
}