using Shared._.Jwt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Application._.Interfaces.Jwt
{
    public interface IJwtGenerator
    {
        Task<JwtToken> GetToken(IEnumerable<Claim> claims, string userId);
    }
}
