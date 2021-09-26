using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace Web.Shared.Components
{
    public partial class TableActionComponent
    {



        [Parameter] public EventCallback<MouseEventArgs> OnClickDelete { get; set; }
        [Parameter] public EventCallback<MouseEventArgs> OnClickEdit { get; set; }


        private async Task HandleOnClickDelete(MouseEventArgs args)
        {
            if (OnClickDelete.HasDelegate)
            {
                await OnClickDelete.InvokeAsync(args);
            }
        }

        private async Task HandleOnClickEdit(MouseEventArgs args)
        {
            if (OnClickEdit.HasDelegate)
            {
                await OnClickEdit.InvokeAsync(args);
            }
        }
    }
}
