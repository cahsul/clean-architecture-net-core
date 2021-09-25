using Application._.Interfaces.Identity;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

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

        public IList<string> MenuAccess
        {
            get
            {
                if (_httpContextAccessor.HttpContext is null)
                {
                    return new List<string>();
                }

                return _httpContextAccessor.HttpContext.User.FindAll("MenuAccess").Select(x => x.Value).ToList();
            }
        }
    }
}
