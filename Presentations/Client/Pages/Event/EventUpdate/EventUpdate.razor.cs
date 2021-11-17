using System.Net.Http.Headers;
using System.Threading.Tasks;
using Client.X.Extensions;
using FluentValidation;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.JSInterop;
using Shared.Event.Commands.CreateEvent;
using Shared.Event.Commands.UpdateEvent;
using Shared.Event.Queries.GetEvent;
using Toastr;

namespace Client.Pages.Event.EventUpdate
{

    public partial class EventUpdate : ComponentBase
    {
        [Inject] private IJSRuntime JS { get; set; }
        [Inject] private ToastrService ToastrService { get; set; }
        [Inject] private NavigationManager NavigationManager { get; set; }

        [Parameter] public Guid Id { get; set; }

        private IJSObjectReference _module;
        protected UpdateEventRequest _updateModel = new();
        protected ElementReference _speakerRef;
        protected List<IBrowserFile> _files = new();
        protected IBrowserFile _poster;


        private async Task SubmitAsync(EditContext editContext)
        {
            // colect file
            _files.Add(_poster);

            // send to API
            var result = await EventApi.EventUpdateAsync(_updateModel, _files);

            if (result.IsError == false)
            {
                await ToastrService.Success(result.Message);
                NavigationManager.NavigateTo("/event"); // TODO : hardcode
            }
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                // load JS
                _module = await JS.ReadJsFile<EventUpdate>();

                // get data from API
                var getData = await EventApi.EventGetAsync(new GetEventRequest { Id = Id });
                if (getData.IsError)
                { return; }

                // set value to model
                _updateModel.EventName = getData.Data?.EventName;
                _updateModel.Id = getData.Data?.Id;
                StateHasChanged();
            }
        }

        private async Task LoadPosterAsync(InputFileChangeEventArgs e)
        {

            _poster = e.File;

            //_files.AddRange(e.GetMultipleFiles().ToList());

            //using var content = new MultipartFormDataContent();

            //foreach (var file in e.GetMultipleFiles())
            //{
            //    try
            //    {
            //        var fileContent = new StreamContent(file.OpenReadStream());
            //        fileContent.Headers.ContentType = new MediaTypeHeaderValue(file.ContentType);

            //        content.Add(
            //           content: fileContent,
            //           name: "\"files\"",
            //           fileName: file.Name);

            //        //var response = await Http.PostAsync("/Filesave", content);
            //    }
            //    catch (Exception ex)
            //    {
            //    }
            //}



            //await using FileStream fs = new("pathpathpath", FileMode.Create);
            //await browserFile.OpenReadStream().CopyToAsync(fs);
        }
    }
}
