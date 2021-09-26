using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using AntDesign;
using AntDesign.TableModels;
using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;
using Shared._.Responses;
using Shared.Todos.Queries.GetTodos;

namespace Web.Pages.Todo
{
    public partial class TodoList
    {
        protected List<GetTodosResponse> _todos;

        protected override async Task OnInitializedAsync()
        {
            await LoadDateAsync();
        }

        public void DeleteData(Guid id)
        {
            _todos = _todos.Where(w => w.Id != id).ToList();
        }

        private async Task LoadDateAsync()
        {
            var response = await todoApi.GetTodosAsync();
            if (response != null)
            { _todos = response.Data; StateHasChanged(); }
        }
    }
}
