using System.ComponentModel.DataAnnotations.Schema;

namespace AhmedabadCityDR.Models.TableModels
{
    [Keyless]
    public partial class ViewTblAtakayatiPaglaSummarySel
    {
        [Column("IPC_GPCId")]
        public int IpcGpcid { get; set; }

        [Column("IPC_GPCName")]
        public string? IpcGpcname { get; set; }

        public int PoliceStationId { get; set; }
        public string? PoliceStationName { get; set; }
        public string? ZoneName { get; set; }
        public int SectorId { get; set; }
        public string? SectorName { get; set; }
        public int DivisionId { get; set; }
        public string? DivisionName { get; set; }
        public int ZoneId { get; set; }
        public int? Todays { get; set; }
        public int? Last { get; set; }
        public int? CurrentMonth { get; set; }
        public int? LastMonth { get; set; }
        public int? CurrentYear { get; set; }
        public int? LastYear { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? CreatedDate { get; set; }

        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public int AtakayatiPagalaSummaryId { get; set; }
        public string? SubCategoryName { get; set; }
        public int SubCategoryId { get; set; }
    }
}