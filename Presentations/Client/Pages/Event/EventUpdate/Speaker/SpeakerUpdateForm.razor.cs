using Microsoft.AspNetCore.Components;
using Shared.Event.Commands.UpdateSpeaker;

namespace Client.Pages.Event.EventUpdate.Speaker
{
    public partial class SpeakerUpdateForm : ComponentBase
    {
        [EditorRequired] [Parameter] public UpdateSpeakerRequest CModel { get; set; }
        [EditorRequired] [Parameter] public EventCallback CCancel { get; set; }

    }
}
