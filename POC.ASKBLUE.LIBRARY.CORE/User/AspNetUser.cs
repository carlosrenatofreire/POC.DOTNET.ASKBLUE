﻿using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace POC.ASKBLUE.LIBRARY.CORE.User
{
    public class AspNetUser : IAspNetUser
    {
        #region Variables

        private readonly IHttpContextAccessor _accessor;

        #endregion

        #region Constructors

        public AspNetUser(IHttpContextAccessor accessor)
        {
            _accessor = accessor;
        }

        #endregion

        #region Properties

        public string Name => _accessor.HttpContext.User.Identity.Name;

        #endregion

        #region Methods Publics

        public Guid GetUserId()
        {
            return IsAuthenticated() ? Guid.Parse(_accessor.HttpContext.User.GetUserId()) : Guid.Empty;
        }

        public string GetUserEmail()
        {
            return IsAuthenticated() ? _accessor.HttpContext.User.GetUserEmail() : "";
        }

        public string GetUserToken()
        {
            return IsAuthenticated() ? _accessor.HttpContext.User.GetUserToken() : "";
        }

        public bool IsAuthenticated()
        {
            return _accessor.HttpContext.User.Identity.IsAuthenticated;
        }

        public bool HasRole(string role)
        {
            return _accessor.HttpContext.User.IsInRole(role);
        }

        public IEnumerable<Claim> GetClaims()
        {
            return _accessor.HttpContext.User.Claims;
        }

        public HttpContext GetHttpContext()
        {
            return _accessor.HttpContext;
        }

        #endregion
    }
}
