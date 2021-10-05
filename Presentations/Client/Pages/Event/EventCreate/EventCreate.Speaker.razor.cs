using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace Client.Pages.Event.EventCreate
{

    public class EventCreateSpeakerModel
    {
        public bool EditMode { get; set; } = false; // true = form create tampil di layar
        public string Speaker { get; set; }
        public string Topics { get; set; }
        public string Institution { get; set; }
    }


    public partial class EventCreate_Speaker : ComponentBase
    {
        public List<EventCreateSpeakerModel> _eventCreateSpeakerModels = new();
        public EventCreateSpeakerModel _eventCreateSpeakerModel = new();
        public bool _showFormCreate = true;

        protected override Task OnInitializedAsync()
        {
            return base.OnInitializedAsync();
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {

            }
        }

        private void Save(EditContext editContext)
        {
            _eventCreateSpeakerModels.Add(_eventCreateSpeakerModel);
            _eventCreateSpeakerModel = new();

        }
    }
}
