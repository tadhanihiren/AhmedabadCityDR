namespace AhmedabadCityDR.Models.APIModels
{
    public class Post_HistoryOfCurrentYearMissing
    {
        public int HistroryOfCurrentMissingId { get; set; }
        public int? PoliceStationId { get; set; }
        public int? Missingboy { get; set; }
        public int? Missinggirl { get; set; }
        public int? Returnboy { get; set; }
        public int? Returngirl { get; set; }
        public int? Missingwoman { get; set; }
        public int? Missingman { get; set; }
        public int? ReturnWoman { get; set; }
        public int? Returnman { get; set; }
        public int? TotalmissingChild { get; set; }
        public int? TotalRetrunChild { get; set; }
        public int? TotalMissingPerson { get; set; }
        public int? TotalReturnPerson { get; set; }
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }
        public int? CreatedUserId { get; set; }
        public int? ModifiedUserId { get; set; }
       public DateTime? CreatedDate { get; set; }

    }
}
