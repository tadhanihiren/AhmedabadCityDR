using AhmedabadCityDR.Interfaces;

namespace AhmedabadCityDR.Repository
{
    /// <summary>
    /// Contains UnitOfWork related data.
    /// </summary>
    public class UnitOfWork : IUnitOfWork
    {
        #region Private Members

        /// <summary>
        /// People context.
        /// </summary>
        private readonly AhmCityDrDbContext _context;

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets VehicleCheckingMaster.
        /// </summary>
        public IVehicleCheckingMaster VehicleCheckingMaster { get; set; }

        /// <summary>
        /// Gets or sets DcbPolicestationMaster.
        /// </summary>
        public IDcbPolicestationMaster DcbPolicestationMaster { get; set; }

        /// <summary>
        /// Gets or sets CRPC41Master.
        /// </summary>
        public ICRPC41Master CRPC41Master { get; set; }

        /// <summary>
        /// Gets or sets NightRountPersonCountMaster.
        /// </summary>
        public INightRountPersonCountMaster NightRountPersonCountMaster { get; set; }

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
        /// Gets or sets Accused Information.
        /// </summary>
        public IAccusedInformation AccusedInformation { get; set; }

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
        /// Gets or sets atakayati pagla summary.
        /// </summary>
        public IAtakayatiDetails AtakayatiDetails { get; set; }

        /// <summary>
        /// Gets or sets Designation Master.
        /// </summary>
        public IDesignationMaster DesignationMaster { get; set; }

        /// <summary>
        /// Gets or sets Login master.
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
        /// Gets or sets sub category master.
        /// </summary>
        public ISubCategoryMaster SubCategoryMaster { get; set; }

        /// <summary>
        /// Gets or sets Pidhela Kabja Category Master.
        /// </summary>
        public IPidhela_Kabja_CategoryMaster Pidhela_Kabja_CategoryMaster { get; set; }

        /// <summary>
        /// Gets or sets Aksmat Death.
        /// </summary>
        public IAksmat_Death Aksmat_Death { get; set; }

        /// <summary>
        /// Gets or sets Form3A.
        /// </summary>
        public IForm3A Form3A { get; set; }

        /// <summary>
        /// Gets or sets Prohibition
        /// </summary>
        public IProhibition Prohibition { get; set; }

        /// <summary>
        /// Gets or sets Prohibition
        /// </summary>
        public IProhibitionCrime ProhibitionCrime { get; set; }

        /// <summary>
        /// Gets or sets  Bin_varsi_lash
        /// </summary>
        public IBin_varsi_lash Bin_varsi_lash { get; set; }

        /// <summary>
        /// Gets or sets  Night Round
        /// </summary>
        public INightRound NightRound { get; set; }

        /// <summary>
        /// Gets or sets  Night Round HEKO PO
        /// </summary>
        public INightRound_HEKO_PO NightRound_HEKO_PO { get; set; }

        /// <summary>
        /// Gets or sets INightEmployeeMaster
        /// </summary>
        public INightEmployeeMaster NightEmployeeMaster { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context">Context</param>
        public UnitOfWork(AhmCityDrDbContext context)
        {
            _context = context;
            _context.Database.SetCommandTimeout(TimeSpan.FromMinutes(30));
            EmployeeMaster = new EmployeeMasterRepository(_context);
            StoredProcedure = new StoredProcedure(_context);
            DesignationMaster = new DesignationMasterRepository(_context);
            AtakayatiDetails = new AtakayatiDetailsRepository(_context);
            AtakayatiPaglaSummary = new AtakayatiPaglaSummaryRepository(_context);
            ProhibitionCrime = new ProhibitionCrimeRepository(_context);
            Aksmat_Death = new Aksmat_DeathRepository(_context);
            NightEmployeeMaster = new NightEmployeeMasterRepository(_context);
            NightRound = new NightRoundRepository(_context);
            NightRound_HEKO_PO = new NightRound_HEKO_PO_Repository(_context);
            Form3A = new Form3ARepository(_context);
            LoginMaster = new LoginMasterRepository(_context);
            SectorMaster = new SectorMasterRepository(_context);
            ZoneMaster = new ZoneMasterRepository(_context);
            DivisionMaster = new DivisionMasterRepository(_context);
            PoliceStationMaster = new PoliceStationMasterRepository(_context);
            Part1_5Crime = new Part1_5CrimeRepository(_context);
            Part6Crime = new Part6CrimeRepository(_context);
            CategoryMaster = new CategoryMasterRepository(_context);
            SubCategoryMaster = new SubCategoryMasterRepository(_context);
            Pidhela_Kabja_CategoryMaster = new Pidhela_Kabja_CategoryMasterRepository(_context);
            Prohibition = new ProhibitionRepository(_context);
            AccusedInformation = new AccusedInformationRepository(_context);
            Bin_varsi_lash = new Bin_varsi_lashRepository(_context);
            ProhibitionRaidCase = new ProhibitionRaidCaseRepository(_context);
            AtakayatiPagla = new AtakayatiPaglaRepository(_context);
            Samans_Details = new Samans_DetailsRepository(_context);
            LeaveApplication = new LeaveApplicationMasterRepository(_context);
            DesignationName = new DesignationNameRepository(_context);
            LeaveType = new LeaveTypeMasterRepository(_context);
            NightRountPersonCountMaster = new NightRountPersonCountMasterRepository(_context);
            CRPC41Master = new CRPC41MasterRepository(_context);
            DcbPolicestationMaster = new DcbPolicestationMasterRepository(_context);
            VehicleCheckingMaster = new VehicleCheckingMasterRepository(_context);
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Dispose
        /// </summary>
        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Save all changes.
        /// </summary>
        /// <returns>Returns int</returns>
        public int Save()
        {
            return _context.SaveChanges();
        }

        #endregion
    }
}