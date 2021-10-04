﻿using Client.Extensions;
using FluentValidation;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.JSInterop;
using Shared.Event.Commands.EventCreate;

namespace Client.Pages.Event
{

    public partial class EventCreate : ComponentBase
    {
        [Inject] public IJSRuntime JS { get; set; }
        private IJSObjectReference _module;
        protected EventCreateRequest _createModel = new();

        private void Submit(EditContext editContext)
        {
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                _module = await JS.ReadJsFile<EventCreate>();
                await _module.InvokeVoidAsync("showMessage", "yoooo");
            }
        }
    }
}
