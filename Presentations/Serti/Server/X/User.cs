using System.Security.Claims;
using Application.X.Interfaces;

namespace Serti.Server.X
{
    public class User : IUser
    {
        public User(IHttpContextAccessor httpContextAccessor)
        {
            Email = httpContextAccessor.HttpContext?.User?.FindFirstValue("Email");
            UserId = httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        }

        public string UserId { get; }

        public string Email { get; }
    }
}
