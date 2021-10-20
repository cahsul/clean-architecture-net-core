using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Shared.Event.Commands.EventCreate;
using Shared.Event.Commands.SpeakerCreate;
using Shared.Event.Commands.SpeakerDelete;
using Shared.Event.Commands.SpeakerUpdate;
using Shared.Event.Queries.GetSpeaker;
using Shared.Event.Queries.GetSpeakers;
using Shared.Event.Queries.GetSpeakersByEvent;

namespace Client.Pages.Event.EventUpdate.Speaker
{
    public partial class SpeakerUpdate : ComponentBase
    {
        [EditorRequired] [Parameter] public Guid EventId { get; set; }

        public List<SpeakerUpdateRequest> _dataSpeakers = new();
        public SpeakerUpdateRequest _eventUpdateSpeakerModel = new();
        public bool? _showFormCreate = false;


        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                // get data from API
                var getData = await EventApi.GetSpeakersByEvent(new GetSpeakersByEventRequest { EventId = EventId });
                if (getData.IsError)
                { return; }

                // set value to model
                _dataSpeakers = getData.Data.Select(s => new SpeakerUpdateRequest
                {
                    Id = s.Id,
                    Institution = s.Institution,
                    SpeakerName = s.SpeakerName,
                    Topics = s.Topics,
                }).ToList();

                StateHasChanged();
            }
        }

        private async Task SaveAsync(EditContext editContext)
        {
            if (_eventUpdateSpeakerModel.Id == null)
            { // create

                _eventUpdateSpeakerModel.Id = Guid.NewGuid();
                _eventUpdateSpeakerModel.EventId = EventId;
                var dataToCreate = await EventApi.SpeakerCreateAsync(new SpeakerCreateRequest
                {
                    Id = _eventUpdateSpeakerModel.Id,
                    Institution = _eventUpdateSpeakerModel.Institution,
                    SpeakerName = _eventUpdateSpeakerModel.SpeakerName,
                    Topics = _eventUpdateSpeakerModel.Topics,
                    EventId = _eventUpdateSpeakerModel.EventId,
                });
                if (dataToCreate.IsError)
                { return; }
                _dataSpeakers.Add(_eventUpdateSpeakerModel);
            }
            else
            { // update
                _eventUpdateSpeakerModel.EditMode = false;
                _dataSpeakers[_dataSpeakers.FindIndex(w => w.Id == _eventUpdateSpeakerModel.Id)] = _eventUpdateSpeakerModel;
            }
            _eventUpdateSpeakerModel = new();
            _showFormCreate = false;
            StateHasChanged();

        }

        private async Task DeleteAsync(Guid? id)
        {
            var dataToDelete = await EventApi.SpeakerDeleteAsync(new SpeakerDeleteRequest { Id = (Guid)id });
            if (dataToDelete.IsError)
            { return; }

            _dataSpeakers = _dataSpeakers.Where(w => w.Id != id).ToList();
            StateHasChanged();
        }

        private void Update(Guid? id)
        {
            _dataSpeakers.Select(s => { s.EditMode = false; return s; }).ToList();
            _dataSpeakers.Find(x => x.Id == id).EditMode = true;
            _eventUpdateSpeakerModel = _dataSpeakers.Find(x => x.Id == id);
            _showFormCreate = null;
            StateHasChanged();
        }

        private void CancelUpdate(Guid? id)
        {
            _dataSpeakers.Find(x => x.Id == id).EditMode = false;
            _eventUpdateSpeakerModel = new();
            _showFormCreate = false;
            StateHasChanged();
        }


    }
}
