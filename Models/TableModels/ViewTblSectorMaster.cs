namespace AhmedabadCityDR.Models.TableModels
{
    [Keyless]
    public partial class ViewTblSectorMaster
    {
        public int SectorId { get; set; }
        public string? SectorName { get; set; }
        public int CityId { get; set; }
        public string? CityName { get; set; }
    }
}