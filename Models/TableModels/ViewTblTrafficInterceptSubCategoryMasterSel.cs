namespace AhmedabadCityDR.Models.TableModels
{
    [Keyless]
    public partial class ViewTblTrafficInterceptSubCategoryMasterSel
    {
        public int TrafficInterceptSubCategoryId { get; set; }
        public string? TrafficeInterceptSubCategoryName { get; set; }
        public int TrafficInterceptCategoryId { get; set; }
        public string? TrafficInterceptCategoryName { get; set; }
    }
}