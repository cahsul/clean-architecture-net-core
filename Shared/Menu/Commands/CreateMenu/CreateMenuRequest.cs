using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Menu.Commands.CreateMenu
{
    public class CreateMenuRequest
    {
        public Guid? ParentId { get; set; }
        public string Label { get; set; }
        public string Url { get; set; }
        public string MenuKey { get; set; }
        public List<string> MenuAction { get; set; }
    }
}
