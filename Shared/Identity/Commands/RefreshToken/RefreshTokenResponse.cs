using Shared._.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Identity.Commands.RefreshToken
{
    public class RefreshTokenResponse : BaseResponse
    {
        public string Token { get; set; }
        public string RefreshToken { get; set; }
        public DateTimeOffset ValidTo { get; set; }
    }
}
