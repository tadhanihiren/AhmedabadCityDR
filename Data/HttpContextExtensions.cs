using System.Security.Claims;

namespace AhmedabadCityDR.Data
{
    public static class HttpContextExtensions
    {
        #region Public Methods

        public static ClaimUser GetClaimsPrincipal(this HttpContext httpContext)
        {
            var claim = new ClaimUser
            {
                Username = httpContext.User.FindFirst(ClaimTypes.Name).Value,
                RoleId = httpContext.User.FindFirst(ClaimTypes.Role).Value,
                UserId = httpContext.User.FindFirst(ConstantsData.UserId).Value,
                SectorId = httpContext.User.FindFirst(ConstantsData.SectorId).Value,
                ZoneId = httpContext.User.FindFirst(ConstantsData.ZoneId).Value,
                DivisionId = httpContext.User.FindFirst(ConstantsData.DivisionId).Value,
                PoliceStationId = httpContext.User.FindFirst(ConstantsData.PoliceStationId).Value,
                ForTraffic_City = httpContext.User.FindFirst(ConstantsData.ForTraffic_City).Value,
            };

            return claim;
        }

        #endregion
    }

    /// <summary>
    /// Contains clime related data.
    /// </summary>
    [Keyless]
    public class ClaimUser
    {
        #region Properties

        public string UserId { get; set; }
        public string Username { get; set; }
        public string RoleId { get; set; }
        public string SectorId { get; set; }
        public string ZoneId { get; set; }
        public string DivisionId { get; set; }
        public string PoliceStationId { get; set; }
        public string ForTraffic_City { get; set; }

        #endregion
    }
}