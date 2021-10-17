using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.X.Settings
{
    public class IdentityUser
    {
        public string ConnectionStrings { get; set; }
        public Options Options { get; set; }
    }

    public class Options
    {
        public Password Password { get; set; }
        public SignIn SignIn { get; set; }
    }

    public class Password
    {
        public bool RequireDigit { get; set; }
        public bool RequireLowercase { get; set; }
        public int RequiredLength { get; set; }
        public bool RequireNonAlphanumeric { get; set; }
        public bool RequireUppercase { get; set; }

    }

    public class SignIn
    {
        public bool RequireConfirmedAccount { get; set; }
        public bool RequireConfirmedEmail { get; set; }
        public bool RequireConfirmedPhoneNumber { get; set; }
    }
}
