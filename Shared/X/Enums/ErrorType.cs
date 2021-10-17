using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.X.Enums
{
    public enum ErrorType
    {
        [Description("Validation")] Validation,
        [Description("Unknown")] Unknown,
        [Description("Bad Request")] BadRequest,
        [Description("Unauthorized Access")] UnauthorizedAccess,
    }
}
