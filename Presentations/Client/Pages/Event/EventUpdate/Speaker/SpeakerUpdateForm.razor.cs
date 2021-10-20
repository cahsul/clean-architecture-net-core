using Microsoft.AspNetCore.Components;
using Shared.Event.Commands.EventCreate;
using Shared.Event.Commands.SpeakerCreate;
using Shared.Event.Commands.SpeakerUpdate;

namespace Client.Pages.Event.EventUpdate.Speaker
{
    public partial class SpeakerUpdateForm : ComponentBase
    {
        [EditorRequired] [Parameter] public SpeakerUpdateRequest CModel { get; set; }
        [EditorRequired] [Parameter] public EventCallback CCancel { get; set; }

    }
}
