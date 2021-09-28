using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace Web.Shared.Components
{
    public partial class CModal
    {
        [Parameter] public RenderFragment ChildContent { get; set; }
        [Parameter] public string Title { get; set; }


        protected bool _visible = false;


        public void HideModal(MouseEventArgs e)
        {
            _visible = false;
        }

        public void ShowModal(MouseEventArgs e)
        {
            _visible = true;
        }
    }
}
