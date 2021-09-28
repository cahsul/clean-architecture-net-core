using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fluxor;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Web.Store.Todo.TodoUpdate;

namespace Web.Pages.Todo
{
    public partial class TodoUpdate
    {
        [Inject] private IState<TodoUpdateState> TodoUpdateState { get; set; }

        [Parameter] public EventCallback<MouseEventArgs> HideModal { get; set; }



        private async Task HandleHideModal(MouseEventArgs args)
        {
            if (HideModal.HasDelegate)
            {
                await HideModal.InvokeAsync(args);
            }
        }
    }
}
