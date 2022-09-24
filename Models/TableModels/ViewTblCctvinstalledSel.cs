using System.ComponentModel.DataAnnotations.Schema;

namespace AhmedabadCityDR.Models.TableModels
{
    [Keyless]
    public partial class ViewTblCctvinstalledSel
    {
        public int InstallId { get; set; }
        public int PoliceStationId { get; set; }
        public string? PoliceStationName { get; set; }

        [Column("PTZ_installed")]
        public int? PtzInstalled { get; set; }

        [Column("BLT_installed")]
        public int? BltInstalled { get; set; }

        [Column("DM_installed")]
        public int? DmInstalled { get; set; }

        [Column("Total_installed")]
        public int? TotalInstalled { get; set; }

        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? CreatedDate { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? ModifiedDate { get; set; }

        public int? CreatedUserId { get; set; }
        public int? ModifiedUserId { get; set; }
        public int DivisionId { get; set; }
        public string? DivisionName { get; set; }
        public int ZoneId { get; set; }
        public string? ZoneName { get; set; }
        public int SectorId { get; set; }
        public string? SectorName { get; set; }
    }
}