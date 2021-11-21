using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Shared.Event.Commands.EventCreate;

namespace Serti.Client.Pages.Event.EventUpdate.Time
{
    public partial class TimeCreate : ComponentBase
    {
        public List<EventCreateTime> _dataTimes = new();
        public EventCreateTime _timeModel = new();
        public bool? _showFormCreate = false;

        private void Save(EditContext editContext)
        {
            if (_timeModel.Id == null)
            { // create
                _timeModel.Id = Guid.NewGuid();
                _dataTimes.Add(_timeModel);
            }
            else
            { // update
                _timeModel.EditMode = false;
                _dataTimes[_dataTimes.FindIndex(w => w.Id == _timeModel.Id)] = _timeModel;
            }
            _timeModel = new();
            _showFormCreate = false;
            StateHasChanged();

        }

        private void Delete(Guid? id)
        {
            _dataTimes = _dataTimes.Where(w => w.Id != id).ToList();
            StateHasChanged();
        }

        private void Update(Guid? id)
        {
            _dataTimes.Select(s => { s.EditMode = false; return s; }).ToList();
            _dataTimes.Find(x => x.Id == id).EditMode = true;
            _timeModel = _dataTimes.Find(x => x.Id == id);
            _showFormCreate = null;
            StateHasChanged();
        }

        private void CancelUpdate(Guid? id)
        {
            _dataTimes.Find(x => x.Id == id).EditMode = false;
            _timeModel = new();
            _showFormCreate = false;
            StateHasChanged();
        }
    }


}
