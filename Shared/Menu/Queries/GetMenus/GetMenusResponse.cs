using System;
using System.Collections.Generic;
using System.Text;
using Shared.X.Responses;

namespace Shared.Menu.Queries.GetMenus
{
    public class GetMenusResponse : BaseResponse<Guid>
    {
        public bool IsMenu { get; set; }
        public Guid? ParentId { get; set; }
        public string Label { get; set; }
        public string Url { get; set; }
        public string MenuKey { get; set; }
        public List<string> MenuAction { get; set; }


    }
}
