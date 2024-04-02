using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace POC.ASKBLUE.LIBRARY.CORE.User
{
    public interface IAspNetUser
    {
        #region Properties

        string Name { get; }

        #endregion

        #region Methods Publics

        Guid GetUserId();
        string GetUserEmail();
        string GetUserToken();
        bool IsAuthenticated();
        bool HasRole(string role);
        IEnumerable<Claim> GetClaims();
        HttpContext GetHttpContext();

        #endregion

    }

}
