using Shared.X.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Application.X.Interfaces.Jwt
{
    public interface IJwtGenerator
    {
        Task<JwtToken> GetToken(IEnumerable<Claim> claims, string userId);
    }
}
