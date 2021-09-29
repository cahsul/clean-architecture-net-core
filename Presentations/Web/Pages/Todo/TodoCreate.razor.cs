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
        [Parameter] public EventCallback<MouseEventArgs> HideModal { get; set; }

        private bool _submitLoading = false;
        private readonly CreateTodoRequest _model = new();

        private async Task Save(EditContext editContext)
        {
            _submitLoading = true;
            var result = await todoApi.CreateTodoAsync(_model);
            if (result?.IsError == false)
            {
                _submitLoading = false;
                await HandleHideModal(new MouseEventArgs());
                await notification.Success("Tambah Data Berhasil");
                await HandleReloadData(new MouseEventArgs());
            }
            _submitLoading = false;

        }


        private async Task HandleReloadData(MouseEventArgs args)
        {
            if (ReloadData.HasDelegate)
            {
                await ReloadData.InvokeAsync(args);
            }
        }

        private async Task HandleHideModal(MouseEventArgs args)
        {
            if (HideModal.HasDelegate)
            {
                await HideModal.InvokeAsync(args);
            }
        }
    }
}
