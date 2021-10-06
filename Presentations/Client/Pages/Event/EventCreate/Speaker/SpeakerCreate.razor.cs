using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Shared.Event.Commands.EventCreate;

namespace Client.Pages.Event.EventCreate.Speaker
{
    public partial class SpeakerCreate : ComponentBase
    {
        public List<EventCreateSpeaker> _dataSpeakers = new();
        public EventCreateSpeaker _eventCreateSpeakerModel = new();
        public bool? _showFormCreate = false;


        private void Save(EditContext editContext)
        {
            if (_eventCreateSpeakerModel.Id == null)
            { // create
                _eventCreateSpeakerModel.Id = Guid.NewGuid();
                _dataSpeakers.Add(_eventCreateSpeakerModel);
            }
            else
            { // update
                _eventCreateSpeakerModel.EditMode = false;
                _dataSpeakers[_dataSpeakers.FindIndex(w => w.Id == _eventCreateSpeakerModel.Id)] = _eventCreateSpeakerModel;
            }
            _eventCreateSpeakerModel = new();
            _showFormCreate = false;
            StateHasChanged();

        }

        private void Delete(Guid? id)
        {
            _dataSpeakers = _dataSpeakers.Where(w => w.Id != id).ToList();
            StateHasChanged();
        }

        private void Update(Guid? id)
        {
            _dataSpeakers.Select(s => { s.EditMode = false; return s; }).ToList();
            _dataSpeakers.Find(x => x.Id == id).EditMode = true;
            _eventCreateSpeakerModel = _dataSpeakers.Find(x => x.Id == id);
            _showFormCreate = null;
            StateHasChanged();
        }

        private void CancelUpdate(Guid? id)
        {
            _dataSpeakers.Find(x => x.Id == id).EditMode = false;
            _eventCreateSpeakerModel = new();
            _showFormCreate = false;
            StateHasChanged();
        }


    }
}
