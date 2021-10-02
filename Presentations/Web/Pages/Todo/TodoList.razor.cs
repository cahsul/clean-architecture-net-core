using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
//using AntDesign;
//using AntDesign.TableModels;
using Fluxor;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Newtonsoft.Json;
using Shared._.Responses;
using Shared.Todos.Queries.GetTodos;
using Web.Shared.Components;
using Web.Store.Todo.TodoUpdate;

namespace Web.Pages.Todo
{
    public partial class TodoList
    {

        [Inject] private IState<TodoUpdateState> TodoUpdateState { get; set; }
        [Inject] public IDispatcher Dispatcher { get; set; }



        protected List<GetTodosResponse> _todos;
        protected CModal _modalCreate;
        protected CModal _modalUpdate;

        protected override async Task OnInitializedAsync()
        {
            await LoadDateAsync();
        }

        public async Task<bool> DeleteDataAsync(Guid id)
        {
            var result = await todoApi.DeleteTodoAsync(id);

            if (result == null)
            { return false; }

            if (result.IsError == true)
            {
                await notification.Error(result.ErrorsMessage[0]);
                return false;
            }
            // reload data
            await LoadDateAsync();

            return true;

        }

        public async Task UpdateDataAsync(Guid id)
        {
            Dispatcher.Dispatch(new TodoUpdateAction(id));
            _modalUpdate.ShowModal(new MouseEventArgs());
        }

        private async Task LoadDateAsync()
        {
            var response = await todoApi.GetTodosAsync();
            if (response != null)
            { _todos = response.Data; StateHasChanged(); }
        }
    }
}
