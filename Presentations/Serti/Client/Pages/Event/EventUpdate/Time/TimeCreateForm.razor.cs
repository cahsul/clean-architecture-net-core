using Microsoft.AspNetCore.Components;
using Shared.Event.Commands.EventCreate;

namespace Serti.Client.Pages.Event.EventUpdate.Time
{
    public partial class TimeCreateForm
    {
        [EditorRequired] [Parameter] public EventCreateTime CModel { get; set; }
        [EditorRequired] [Parameter] public EventCallback CCancel { get; set; }
        [Parameter] public EventCallback CDelete { get; set; }
        [Parameter] public EventCallback CUpdate { get; set; }
        [Parameter] public bool CReadOnly { get; set; } = false;
    }
}
