using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Event.Enums
{
    public enum StatusEvent
    {
        [Description("Draft")]
        Draft, // user klik create new event di halaman even

        [Description("Submit")]
        Submit, // ketika event di save untuk pertama kali
    }
}
