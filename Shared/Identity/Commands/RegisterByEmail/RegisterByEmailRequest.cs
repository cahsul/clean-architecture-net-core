using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Identity.Commands.RegisterByEmail
{
    public class RegisterByEmailRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
