namespace AhmedabadCityDR.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        #region Properties

        /// <summary>
        /// Gets or sets Leave Type.
        /// </summary>
        public ILeaveTypeMaster LeaveType { get; set; }

        /// <summary>
        /// Gets or sets DesignationName.
        /// </summary>
        public IDesignationName DesignationName { get; set; }

        /// <summary>
        /// Gets or sets LeaveApplication.
        /// </summary>
        public ILeaveApplicationMaster LeaveApplication { get; set; }

        /// <summary>
        /// Gets or sets Samans_Details.
        /// </summary>
        public ISamans_Details Samans_Details { get; set; }

        /// <summary>
        /// Gets or sets AtakayatiPagla Case.
        /// </summary>
        public IAtakayatiPagla AtakayatiPagla { get; set; }

        /// <summary>
        /// Gets or sets Prohibition Raid Case.
        /// </summary>
        public IProhibitionRaidCase ProhibitionRaidCase { get; set; }

        /// <summary>
        /// Gets or sets employee master.
        /// </summary>
        public IEmployeeMaster EmployeeMaster { get; set; }

        /// <summary>
        /// Gets or sets stored procedure.
        /// </summary>
        public IStoredProcedure StoredProcedure { get; set; }

        /// <summary>
        /// Gets or sets atakayati pagla summary.
        /// </summary>
        public IAtakayatiPaglaSummaryMaster AtakayatiPaglaSummary { get; set; }

        /// <summary>
        /// Gets or sets Aksmat Death.
        /// </summary>
        public IAksmat_Death Aksmat_Death { get; set; }

        /// <summary>
        /// Gets or sets Form3A.
        /// </summary>
        public IForm3A Form3A { get; set; }

        /// <summary>
        /// Gets or sets login master.
        /// </summary>
        public ILoginMaster LoginMaster { get; set; }

        /// <summary>
        /// Gets or sets sector master.
        /// </summary>
        public ISectorMaster SectorMaster { get; set; }

        /// <summary>
        /// Gets or sets zone master.
        /// </summary>
        public IZoneMaster ZoneMaster { get; set; }

        /// <summary>
        /// Gets or sets division master.
        /// </summary>
        public IDivisionMaster DivisionMaster { get; set; }

        /// <summary>
        /// Gets or sets police station master.
        /// </summary>
        public IPoliceStationMaster PoliceStationMaster { get; set; }

        /// <summary>
        /// Gets or sets designation master.
        /// </summary>
        public IDesignationMaster DesignationMaster { get; set; }

        /// <summary>
        /// Gets or sets part 1 to 5 crimes.
        /// </summary>
        public IPart1_5Crime Part1_5Crime { get; set; }

        /// <summary>
        /// Gets or sets part 6 crimes.
        /// </summary>
        public IPart6Crime Part6Crime { get; set; }

        /// <summary>
        /// Gets or sets category master.
        /// </summary>
        public ICategoryMaster CategoryMaster { get; set; }

        /// <summary>
        /// Gets or sets Pidhela Kabja Category Master.
        /// </summary>
        public IPidhela_Kabja_CategoryMaster Pidhela_Kabja_CategoryMaster { get; set; }

        /// <summary>
        /// Gets or sets sub category master.
        /// </summary>
        public ISubCategoryMaster SubCategoryMaster { get; set; }

        /// <summary>
        /// Gets or sets Accused Information.
        /// </summary>
        public IAccusedInformation AccusedInformation { get; set; }

        /// <summary>
        /// Gets or sets Phohibution
        /// </summary>
        public IProhibition Prohibition { get; set; }

        /// <summary>
        /// Gets or sets Phohibution
        /// </summary>
        public IProhibitionCrime ProhibitionCrime { get; set; }

        /// <summary>
        /// Gets or sets Bin_varsi_lash
        /// </summary>
        public IBin_varsi_lash Bin_varsi_lash { get; set; }

        #endregion

        #region Public Method

        /// <summary>
        /// Save all changes.
        /// </summary>
        /// <returns>Returns int</returns>
        public int Save();

        #endregion
    }
}