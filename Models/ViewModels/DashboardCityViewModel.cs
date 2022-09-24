using System.ComponentModel.DataAnnotations.Schema;

namespace AhmedabadCityDR.Models.ViewModels
{
    [Keyless, NotMapped]
    public class DashboardCommonCityCount
    {
        #region Properties

        public string Name { get; set; }
        public int Counts { get; set; }

        #endregion
    }

    [Keyless, NotMapped]
    public class DashboardCommonTrafficCount
    {
        #region Properties

        public string Name { get; set; }
        public long Counts { get; set; }

        #endregion
    }

    [Keyless, NotMapped]
    public class CrimeCountByDay
    {
        #region Properties

        public int Today { get; set; }
        public int Yesterday { get; set; }

        #endregion
    }

    [Keyless, NotMapped]
    public class DashboardCitySingalCount
    {
        #region Properties

        public int Counts { get; set; }

        #endregion
    }

    [Keyless, NotMapped]
    public class TrafficTotalAndAmount
    {
        #region Properties

        public int Total { get; set; }
        public int Amount { get; set; }

        #endregion
    }

    /// <summary>
    /// Contains  dashboard city count related data.
    /// </summary>
    [Keyless, NotMapped]
    public class DashboardCityViewModel
    {
        #region Properties

        public int Manjur_Mahekam { get; set; }
        public int Hajar_Mahekam { get; set; }
        public int Raja_Upar { get; set; }
        public int ChoKhhu_Hajar_Mahekam { get; set; }
        public int Part_1_To_5 { get; set; }
        public int Part_6 { get; set; }
        public int Prohibision { get; set; }
        public int Akashmat_mot { get; set; }
        public int Gum_thayel_balako_Stree_Purush { get; set; }
        public int Atkayati_paglani_mahiti { get; set; }
        public int DCB_po_station_ni_mahiti { get; set; }
        public int Adhikari_shri_ni_night_round_mahiti { get; set; }
        public int Samans_jamin_layak_warant { get; set; }
        public int Jamin_layak_warant { get; set; }
        public int Bin_jamin_layak_warant { get; set; }
        public int ProhibitionQualityCase_Crime { get; set; }
        public int Anya_notice { get; set; }
        public int Family_court_thi_malti_notice { get; set; }
        public int Nashata_farta_aropi_ni_mahiti { get; set; }
        public int Pending_arajinu_patrak { get; set; }
        public int Bandobast_ni_vigat_patrak { get; set; }
        public int Pending_janva_jognu_patrak { get; set; }
        public int Today { get; set; }
        public int Last { get; set; }
        public int Currentyear { get; set; }
        public int Lastyear { get; set; }

        #endregion
    }

    /// <summary>
    /// Contains  dashboard traffic count related data.
    /// </summary>
    [Keyless, NotMapped]
    public class DashboardTrafficViewModel
    {
        #region Properties

        public long Manjur_Mahekam { get; set; }
        public long Hajar_Mahekam { get; set; }
        public long Raja_Upar { get; set; }
        public long ChoKhhu_Hajar_Mahekam { get; set; }
        public long Vahan_Akasmat { get; set; }
        public long Part_1_5_Crime { get; set; }
        public long MVACT_207 { get; set; }
        public long TabakuCase { get; set; }
        public long TabakuDand { get; set; }
        public long Total_Crane_Number { get; set; }
        public long Total_Crane_Amount { get; set; }
        public long Private_Crane_Number { get; set; }
        public long Private_Crane_Amount { get; set; }
        public long Sarkari_Crane_Number { get; set; }
        public long Sarkari_Crane_Amount { get; set; }
        public long DriveCaseNumber { get; set; }
        public long DriveCaseAmount { get; set; }
        public long Challan { get; set; }
        public long Totalplacefine { get; set; }
        public long E_Challan { get; set; }
        public long E_Total { get; set; }
        public long VIP { get; set; }
        public long Festival { get; set; }
        public long Sabha { get; set; }
        public long Others { get; set; }

        #endregion
    }
}