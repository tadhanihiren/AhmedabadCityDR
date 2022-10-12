using AhmedabadCityDR.Interfaces;
using AhmedabadCityDR.Models.TableModels;

namespace AhmedabadCityDR.Repository
{
    public class BandobastTypeRepository : GenericRepository<TblBandobastTypeMaster>, IBandobastType
    {
        #region Private Members

        /// <summary>
        /// Context
        /// </summary>
        private readonly AhmCityDrDbContext _context;

        #endregion

        #region Constructors

        /// <summary>
        /// Constructors
        /// </summary>
        /// <param name="context">Context</param>
        public BandobastTypeRepository(AhmCityDrDbContext context) : base(context)
        {
            _context = context;
        }

        #endregion
    }
}
