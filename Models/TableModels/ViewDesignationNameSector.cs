namespace AhmedabadCityDR.Models.TableModels
{
    [Keyless]
    public partial class ViewDesignationNameSector
    {
        public int DesignationId { get; set; }
        public string? DesignationName { get; set; }
        public int SectorId { get; set; }
        public string? SectorName { get; set; }
        public int ZoneId { get; set; }
        public string? ZoneName { get; set; }
        public int DivisionId { get; set; }
        public string? DivisionName { get; set; }
        public int PoliceStationId { get; set; }
        public string? PoliceStationName { get; set; }
        public int EmployeeId { get; set; }
        public string? EmployeName { get; set; }
    }
}