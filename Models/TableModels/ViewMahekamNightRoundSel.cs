using System.ComponentModel.DataAnnotations.Schema;

namespace AhmedabadCityDR.Models.TableModels
{
    [Keyless]
    public partial class ViewMahekamNightRoundSel
    {
        public int NightEmployeeId { get; set; }
        public int EmployeeId { get; set; }
        public string? EmployeName { get; set; }
        public int PoliceStationId { get; set; }
        public string? PoliceStationName { get; set; }
        public int DesignationId { get; set; }
        public string? DesignationName { get; set; }
        public string? GoingTime { get; set; }
        public string? ReturnTime { get; set; }
        public string? Remarks { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? CreatedDate { get; set; }

        public int DivisionId { get; set; }
        public string? DivisionName { get; set; }
        public int ZoneId { get; set; }
        public string? ZoneName { get; set; }
        public int MahekamId { get; set; }
        public int? ManjurMahekam { get; set; }
        public int? HajarMahekam { get; set; }
    }
}