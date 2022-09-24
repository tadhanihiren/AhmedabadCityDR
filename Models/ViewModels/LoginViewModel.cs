using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AhmedabadCityDR.Models.ViewModels
{
    /// <summary>
    /// Contains login view related data.
    /// </summary>
    [Keyless, NotMapped]
    public class LoginViewModel
    {
        #region Properties

        /// <summary>
        /// Gets or sets User Name
        /// </summary>
        [Required]
        public string? UserName { get; set; }

        /// <summary>
        /// Gets or sets Password
        /// </summary>
        [Required]
        public string? Password { get; set; }

        /// <summary>
        /// Gets or sets Remember me.
        /// </summary>
        public bool RememberMe { get; set; }

        #endregion Properties
    }
}