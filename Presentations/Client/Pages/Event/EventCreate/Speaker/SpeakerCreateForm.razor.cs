using Microsoft.AspNetCore.Components;
using Shared.Event.Commands.EventCreate;

namespace Client.Pages.Event.EventCreate.Speaker
{
    public partial class SpeakerCreateForm : ComponentBase
    {
        [EditorRequired] [Parameter] public EventCreateSpeaker CModel { get; set; }
        [EditorRequired] [Parameter] public EventCallback CCancel { get; set; }

    }
}
