using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.X.Interfaces.Identity
{
    public interface IIdentity
    {
        bool IsAuthenticated { get; }
        string Email { get; }
        IList<string> MenuAccess { get; }
    }
}
