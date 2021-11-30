using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared.X.Classes;

namespace Application.X.Interfaces.Identity
{
    public interface IIdentity
    {
        bool IsAuthenticated { get; }
        string Email { get; }
        IList<AuthorizeMenu> MenuAccess { get; set; }
        string JwtToken { get; set; }
        string RefreshToken { get; set; }
    }
}
