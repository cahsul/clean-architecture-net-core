using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Menu.Resources
{
    public class MenuEndpoint
    {
        public static class Menu
        {
            public const string Create = "/api/" + nameof(Menu);
            public const string Update = "/api/" + nameof(Menu) + "/" + nameof(Update);
            public const string Delete = "/api/" + nameof(Menu);
            public const string Getmenus = "/api/" + nameof(Menu);
            public const string GetMenusUserLogin = "/api/" + nameof(Menu) + "/" + nameof(GetMenusUserLogin);
            public const string Getmenu = "/api/" + nameof(Menu) + "/" + nameof(Getmenu);
        }
    }
}
