using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.X.Enums
{
    public enum MenuAction
    {
        [Description("Create")] Create,
        [Description("Update")] Update,
        [Description("Delete")] Delete,
        [Description("List")] List,
    }
}
