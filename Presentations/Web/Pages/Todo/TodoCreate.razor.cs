using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using FluentValidation;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Web;
using Shared.Todos.Commands.CreateTodo;

namespace Web.Pages.Todo
{
    public partial class TodoCreate
    {

        [Parameter] public EventCallback<MouseEventArgs> ReloadData { get; set; }

        private readonly CreateTodoRequest _model = new();

        private async Task OnFinishAsync(EditContext editContext)
        {
            var result = await todoApi.CreateTodoAsync(_model);
            if (result?.IsError == false)
            {
                await notification.Error("HOREEEEEEEEEEEEEEE");
                await ReloadData.InvokeAsync(new MouseEventArgs());
            }
        }

        private void OnFinishFailed(EditContext editContext)
        {
            Console.WriteLine($"Failed:{JsonSerializer.Serialize(_model)}");
        }

        private async Task HandleReloadData(MouseEventArgs args)
        {
            if (ReloadData.HasDelegate)
            {
                await ReloadData.InvokeAsync(args);
            }
        }
    }
}
