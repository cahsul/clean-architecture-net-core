using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared._.Jwt
{
    public class JwtToken
    {
        public string Token { get; set; }
        public string RefreshToken { get; set; }
        public DateTime ValidTo { get; set; }
    }
}
