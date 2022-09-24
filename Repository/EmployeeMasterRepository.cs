using AhmedabadCityDR.Interfaces;
using AhmedabadCityDR.Models.TableModels;
using Microsoft.Data.SqlClient;

namespace AhmedabadCityDR.Repository
{
    /// <summary>
    /// Contains employee related data.
    /// </summary>
    public class EmployeeMasterRepository : GenericRepository<TblEmployeeMaster>, IEmployeeMaster
    {
        #region Private Members

        /// <summary>
        /// Context.
        /// </summary>
        private readonly AhmCityDrDbContext _context;

        #endregion

        #region Constructors

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context">Context</param>
        public EmployeeMasterRepository(AhmCityDrDbContext context) : base(context)
        {
            _context = context;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Finde user By username and password.
        /// </summary>
        /// <param name="userName">Username</param>
        /// <param name="password">Password</param>
        /// <returns>Returns user details or Null</returns>
        public async Task<ClaimUser> AuthenticateUser(string userName, string password)
        {
            if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(password))
            {
                return null;
            }

            var pUsername = new SqlParameter("@Username", userName);
            var pPassword = new SqlParameter("@Password", password);

            var user = await _context.Set<ClaimUser>().FromSqlRaw("exec USP_Employee_Login @Username, @Password", pUsername, pPassword).ToListAsync();

            return user.FirstOrDefault();
        }

        #endregion
    }
}