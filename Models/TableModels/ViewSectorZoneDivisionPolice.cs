namespace AhmedabadCityDR.Models.TableModels
{
    [Keyless]
    public partial class ViewSectorZoneDivisionPolice
    {
        public int SectorId { get; set; }
        public string? SectorName { get; set; }
        public int ZoneId { get; set; }
        public string? ZoneName { get; set; }
        public int DivisionId { get; set; }
        public string? DivisionName { get; set; }
        public int PoliceStationId { get; set; }
        public string? PoliceStationName { get; set; }
        public bool IsTraffic { get; set; }
    }
}