namespace AhmedabadCityDR.Models.ViewModels
{
    public class MissingChildDetailsViewModel
    {
        public int? MissingChildId { get; set; }
        public int? PoliceStationId { get; set; }
        public string? PoliceStationName { get; set; }
        public int? GenderId { get; set; }
        public string? Gender { get; set; }
        public int? Age { get; set; }
        public DateTime? MissingDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public string? MissingApplicationNo_Date { get; set; }
        public string? PublisherName_Address { get; set; }
        public string? MobileNo { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int? DivisionId { get; set; }
        public string? DivisionName { get; set; }
        public int? ZoneId { get; set; }
        public string? ZoneName { get; set; }
        public int? SectorId { get; set; }
        public string? SectorName { get; set; }
        public string? MissingPersonName { get; set; }
        public string? MissingReson { get; set; }
    }
}
