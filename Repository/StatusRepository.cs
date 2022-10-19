using AhmedabadCityDR.Interfaces;
using AhmedabadCityDR.Models.TableModels;

namespace AhmedabadCityDR.Repository
{
    public class StatusRepository : GenericRepository<TblStatusMaster>, IStatusMaster
    {
        #region Private Memebers

        /// <summary>
        /// Gets Context.
        /// </summary>
        private readonly AhmCityDrDbContext _context;

        #endregion

        #region Constructors

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context">Context</param>
        public StatusRepository(AhmCityDrDbContext context) : base(context)
        {
            _context = context;
        }

        #endregion

    }
}

