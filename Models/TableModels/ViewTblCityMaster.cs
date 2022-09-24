namespace AhmedabadCityDR.Models.TableModels
{
    [Keyless]
    public partial class ViewTblCityMaster
    {
        public int CityId { get; set; }
        public string? CityName { get; set; }
        public int StateId { get; set; }
        public string? StateName { get; set; }
    }
}