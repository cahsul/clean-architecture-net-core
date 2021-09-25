using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application._.Interfaces.Identity
{
    public interface IIdentity
    {
        bool IsAuthenticated { get; }
        string Email { get; }
        IList<string> MenuAccess { get; }
    }
}
