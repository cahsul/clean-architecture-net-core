using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.X.Attributes
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = true)]
    public class AuthorizeAttribute : Attribute
    {
        public string MenuName { get; }
        public string ActionName { get; }

        public AuthorizeAttribute()
        {
        }
        public AuthorizeAttribute(string menuName, string actionName)
        {
            MenuName = menuName;
            ActionName = actionName;
        }
    }
}
