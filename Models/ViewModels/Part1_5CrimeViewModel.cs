using System.ComponentModel.DataAnnotations.Schema;

namespace AhmedabadCityDR.Models.ViewModels
{
    /// <summary>
    /// Contains Part 1 to 5 Crime related data.
    /// </summary>
    [Keyless, NotMapped]
    public class Part1_5CrimeViewModel
    {
        public int CrimesId { get; set; }
        public string? PoliceStationName { get; set; }
        public string? Complainer { get; set; }
        public string? Accused { get; set; }
        public string? Gubatata { get; set; }
        public string? Gujatata { get; set; }
        public string? Gudatata { get; set; }
        public string? CrimePlace { get; set; }
        public string? CrimePurpose { get; set; }
        public string? PersonNameWhoFiledCrime { get; set; }
        public string? InvestigationOfficer { get; set; }
        public string? ShortDetail { get; set; }
        public string? LateComplaintReason { get; set; }
        public string? HdiitsEntry { get; set; }
        public bool Savendansil { get; set; }
        public bool BinSavendansil { get; set; }
        public string? Complainer_AccusedCriminalHistory { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDelete { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int? CreatedUserId { get; set; }
        public int? ModifiedUserId { get; set; }
        public int? DivisionId { get; set; }
        public string? DivisionName { get; set; }
        public int? ZoneId { get; set; }
        public string? ZoneName { get; set; }
        public int? SectorId { get; set; }
        public string? SectorName { get; set; }
        public string? SubCategoryName { get; set; }
        public int? SubCategoryId { get; set; }
        public string? PoliceStationNumber { get; set; }
        public int? CategoryId { get; set; }
        public string? CategoryName { get; set; }
        public decimal? Latitude { get; set; }
        public decimal? Longitude { get; set; }
        public bool IsTraffic { get; set; }
        public int? PoliceStationId { get; set; }
        public string? IPCACT { get; set; }
        public string? Pidhela_Kabjana_Type { get; set; }
        public string? SavendansilText { get; set; }
        public string? BinSavendansilText { get; set; }
    }
}