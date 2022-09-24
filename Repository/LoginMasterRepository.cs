using AhmedabadCityDR.Interfaces;
using AhmedabadCityDR.Models.TableModels;
using AhmedabadCityDR.Models.ViewModels;

namespace AhmedabadCityDR.Repository
{
    public class LoginMasterRepository : GenericRepository<TblLoginMasterMobile>, ILoginMaster
    {
        #region Private Memebers

        /// <summary>
        /// Get context.
        /// </summary>
        private readonly AhmCityDrDbContext _context;

        #endregion

        #region Constructors

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context">Context</param>
        public LoginMasterRepository(AhmCityDrDbContext context) : base(context)
        {
            _context = context;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Gets login users
        /// </summary>
        /// <returns>Returns list of Login user</returns>
        public IEnumerable<Login_UserNamePassWord_ViewModel> GetLoginUsers()
        {
            return _context.Set<Login_UserNamePassWord_ViewModel>().FromSqlRaw("exec USP_Login_Policestationwise_Sel").ToList();
        }

        #endregion
    }
}