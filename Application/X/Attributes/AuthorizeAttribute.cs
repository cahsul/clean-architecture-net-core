using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared.X.Enums;
using Shared.X.Extensions;

namespace Application.X.Attributes
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = true)]
    public class AuthorizeAttribute : Attribute
    {
        public string MenuKey { get; }
        public string MenuAction { get; }

        public AuthorizeAttribute()
        {
        }
        public AuthorizeAttribute(string menuKey, string menuAction)
        {
            MenuKey = menuKey;
            MenuAction = menuAction;
        }

        public AuthorizeAttribute(MenuKey menuKey, MenuAction menuAction)
        {
            MenuKey = menuKey.GetDescription();
            MenuAction = menuAction.GetDescription();
        }
    }
}
