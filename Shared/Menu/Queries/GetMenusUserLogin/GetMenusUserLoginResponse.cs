using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Menu.Queries.GetMenusUserLogin
{
    public class GetMenusUserLoginResponse
    {
        public List<GetMenusUserLoginResponse> Childs { get; set; }
        public string Label { get; set; }
        public string Url { get; set; }
    }
}
