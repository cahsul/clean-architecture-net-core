using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared._.Extensions
{
    public static class ListExtension
    {
        public static string ToString(this IEnumerable<string> values, string? separator)
        {
            return string.Join(separator, values);
        }
    }
}
