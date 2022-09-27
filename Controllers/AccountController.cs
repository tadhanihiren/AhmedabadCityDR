using AhmedabadCityDR.Interfaces;
using AhmedabadCityDR.Models.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace AhmedabadCityDR.Controllers
{
    /// <summary>
    /// Contains account related data.
    /// </summary>
    [AllowAnonymous]
    public class AccountController : Controller
    {
        #region Pivate Members

        /// <summary>
        /// Unit of work.
        /// </summary>
        protected IUnitOfWork _unitOfWork;

        #endregion Pivate Members

        #region Constructors

        /// <summary>
        /// Constructor
        /// </summary>
        public AccountController(IUnitOfWork iUnitOfWork)
        {
            _unitOfWork = iUnitOfWork;
        }

        #endregion Constructors

        #region Public Methods

        /// <summary>
        /// Login view.
        /// </summary>
        /// <returns>Returns view</returns>
        [HttpGet]
        public IActionResult Login()
        {
            if (HttpContext.User.Identity.IsAuthenticated)
                HttpContext.Response.Redirect("/Dashboard/Index");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {
            if (ModelState.IsValid)
            {
                var user = await _unitOfWork.EmployeeMaster.AuthenticateUser(loginViewModel.UserName.Trim(), loginViewModel.Password.Trim());

                if (user == null)
                {
                    ModelState.AddModelError("Password", "Invalid username or Password!");
                    return View();
                }

                var claims = new List<Claim>
                    {
                        new Claim(ConstantsData.UserId, user.UserId),
                        new Claim(ClaimTypes.Name, user.Username),
                        new Claim(ClaimTypes.Role, user.RoleId),
                        new Claim(ConstantsData.SectorId, user.SectorId),
                        new Claim(ConstantsData.ZoneId, user.ZoneId),
                        new Claim(ConstantsData.DivisionId, user.DivisionId),
                        new Claim(ConstantsData.PoliceStationId, user.PoliceStationId),
                        new Claim(ConstantsData.ForTraffic_City, user.ForTraffic_City),
                    };

                var claimsIdentity = new ClaimsIdentity(
                    claims, CookieAuthenticationDefaults.AuthenticationScheme);

                var authProperties = new AuthenticationProperties
                {
                    //AllowRefresh = <bool>,
                    // Refreshing the authentication session should be allowed.

                    //ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(10),
                    // The time at which the authentication ticket expires. A
                    // value set here overrides the ExpireTimeSpan option of
                    // CookieAuthenticationOptions set with AddCookie.

                    //IsPersistent = true,
                    // Whether the authentication session is persisted across
                    // multiple requests. When used with cookies, controls
                    // whether the cookie's lifetime is absolute (matching the
                    // lifetime of the authentication ticket) or session-based.

                    //IssuedUtc = <DateTimeOffset>,
                    // The time at which the authentication ticket was issued.

                    //RedirectUri = <string>
                    // The full path or absolute URI to be used as an http
                    // redirect response value.
                };

                await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity),
                    authProperties);

                var forTraffic = Convert.ToInt16(user.ForTraffic_City);

                if (forTraffic == 1)
                {
                    return RedirectToAction("TrafficIndex", "Dashboard");
                }

                return RedirectToAction("Index", "Dashboard");
            }
            return View();
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Account");
        }

        #endregion Public Methods
    }
}