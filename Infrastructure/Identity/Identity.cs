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
using Application.X.Interfaces.Library;

namespace Infrastructure
{
    /// <summary>
    /// data user yang login, bisa ambil dari sini
    /// </summary>
    public class Identity : IIdentity
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ICryptography _cryptography;

        public Identity(IHttpContextAccessor httpContextAccessor, ICryptography cryptography)
        {
            _httpContextAccessor = httpContextAccessor;
            _cryptography = cryptography;
        }
        public bool IsAuthenticated => _httpContextAccessor.HttpContext is not null && _httpContextAccessor.HttpContext.User.Identity.IsAuthenticated;
        public string Email
        {
            get
            {
                if (_httpContextAccessor.HttpContext is null)
                { return "SystemBackgroundJob"; }
                if (_httpContextAccessor.HttpContext.Request.Cookies["E"] is null)
                { return "[Unknown_User]"; }
                var raw = _cryptography.AES_Decrypt(_httpContextAccessor.HttpContext.Request.Cookies["E"]);
                return raw ?? "[Unknown_User]";
            }

            set
            {

                if (value != null)
                {
                    _httpContextAccessor.HttpContext.Response.Cookies.Append(
                        "E"
                        , _cryptography.AES_Encrypt(value)
                        , new CookieOptions
                        {
                            HttpOnly = true,
                            Expires = DateTime.UtcNow.AddDays(7),

                        });
                }
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

                var raw = _cryptography.AES_Decrypt(_httpContextAccessor.HttpContext.Request.Cookies["MenuAccess"]);
                return raw.ToJsonDeserialize<IList<AuthorizeMenu>>();

            }

            set
            {

                if (value != null)
                {
                    _httpContextAccessor.HttpContext.Response.Cookies.Append(
                        "MenuAccess"
                        , _cryptography.AES_Encrypt(value.ToJson())
                        , new CookieOptions
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
                var raw = _cryptography.AES_Decrypt(_httpContextAccessor.HttpContext.Request.Cookies["RefreshToken"]);
                return raw.ToString();
            }

            set
            {

                if (value != null)
                {
                    _httpContextAccessor.HttpContext.Response.Cookies.Append(
                        "RefreshToken"
                        , _cryptography.AES_Encrypt(value)
                        , new CookieOptions
                        {
                            HttpOnly = true,
                            Expires = DateTime.UtcNow.AddDays(7),
                        });
                }
            }
        }

        public void Logout()
        {
            foreach (var cookie in _httpContextAccessor.HttpContext.Request.Cookies.Keys)
            {
                _httpContextAccessor.HttpContext.Response.Cookies.Delete(cookie);
            }
        }

    }
}
