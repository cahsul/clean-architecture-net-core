using Application.X.Interfaces.Identity;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Shared.X.Extensions;
using Shared.X.Classes;

namespace Infrastructure
{
    /// <summary>
    /// data user yang login, bisa ambil dari sini
    /// </summary>
    public class Identity : IIdentity
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public Identity(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        public bool IsAuthenticated => _httpContextAccessor.HttpContext is not null && _httpContextAccessor.HttpContext.User.Identity.IsAuthenticated;
        public string Email
        {
            get
            {
                if (_httpContextAccessor.HttpContext is null)
                {
                    return "SystemBackgroundJob";
                }

                return _httpContextAccessor?.HttpContext?.User?.FindFirstValue("Email") ?? "Unknown";
            }
        }

        public IList<AuthorizeMenu> MenuAccess
        {
            get
            {
                if (_httpContextAccessor.HttpContext is null)
                { return null; }
                if (_httpContextAccessor.HttpContext.Request.Cookies["MenuAccess"] is null)
                { return null; }
                return _httpContextAccessor.HttpContext.Request.Cookies["MenuAccess"].ToJsonDeserialize<IList<AuthorizeMenu>>();

                //if (_httpContextAccessor.HttpContext is null)
                //{
                //    return new List<string>();
                //}

                // return _httpContextAccessor.HttpContext.User.FindAll("MenuAccess").Select(x => x.Value).ToList();
            }

            set
            {

                if (value != null)
                {
                    _httpContextAccessor.HttpContext.Response.Cookies.Append("MenuAccess", value.ToJson(), new CookieOptions
                    {
                        HttpOnly = true,
                        Expires = DateTime.UtcNow.AddDays(7),

                    });
                }
            }
        }

        public string JwtToken
        {
            get
            {
                if (_httpContextAccessor.HttpContext is null)
                { return null; }
                if (_httpContextAccessor.HttpContext.Request.Cookies["JwtToken"] is null)
                { return null; }
                return _httpContextAccessor.HttpContext.Request.Cookies["JwtToken"].ToString();
            }

            set
            {

                if (value != null)
                {
                    _httpContextAccessor.HttpContext.Response.Cookies.Append("JwtToken", value, new CookieOptions
                    {
                        HttpOnly = true,
                        Expires = DateTime.UtcNow.AddDays(7),

                    });
                }
            }
        }

        public string RefreshToken
        {
            get
            {
                if (_httpContextAccessor.HttpContext is null)
                { return null; }
                if (_httpContextAccessor.HttpContext.Request.Cookies["RefreshToken"] is null)
                { return null; }
                return _httpContextAccessor.HttpContext.Request.Cookies["RefreshToken"].ToString();
            }

            set
            {

                if (value != null)
                {
                    _httpContextAccessor.HttpContext.Response.Cookies.Append("RefreshToken", value, new CookieOptions
                    {
                        HttpOnly = true,
                        Expires = DateTime.UtcNow.AddDays(7),
                    });
                }
            }
        }

        public void Logout()
        {

        }




    }
}
