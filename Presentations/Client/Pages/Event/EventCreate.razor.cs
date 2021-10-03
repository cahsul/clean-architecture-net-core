using FluentValidation;
using Microsoft.AspNetCore.Components;
using Shared.Event.Commands.EventCreate;

namespace Client.Pages.Event
{

    public partial class EventCreate : ComponentBase
    {
        protected EventCreateRequest _createModel = new();

        private void Submit()
        {
        }
    }
}
