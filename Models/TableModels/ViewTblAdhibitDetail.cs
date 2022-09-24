using System.ComponentModel.DataAnnotations.Schema;

namespace AhmedabadCityDR.Models.TableModels
{
    [Keyless]
    public partial class ViewTblAdhibitDetail
    {
        public int AdhiBitId { get; set; }
        public int? PoliceStationId { get; set; }
        public string? EmployeeName { get; set; }
        public string? CasePlace { get; set; }
        public string? PlaceFine { get; set; }
        public string? Detaine { get; set; }

        [Column("MVAct185")]
        public string? Mvact185 { get; set; }

        [Column("IPC188")]
        public string? Ipc188 { get; set; }

        [Column("GPAct131")]
        public string? Gpact131 { get; set; }

        [Column("IPC279")]
        public string? Ipc279 { get; set; }

        [Column("IPC283")]
        public string? Ipc283 { get; set; }

        public string? TamakuCaseFine { get; set; }
        public string? Remarks { get; set; }
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? CreatedDate { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? ModifiedDate { get; set; }

        public int? CreatedUserId { get; set; }
        public int? ModifiedUserId { get; set; }
        public string? PoliceStationName { get; set; }
        public int? DivisionId { get; set; }
        public string? ShortName { get; set; }
        public string? DivisionName { get; set; }
        public int? ZoneId { get; set; }
        public string? ZoneName { get; set; }
        public int SectorId { get; set; }
        public string? SectorName { get; set; }
        public string? CityName { get; set; }
    }
}