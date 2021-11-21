using Microsoft.AspNetCore.Components;
using Toastr;

namespace Serti.Client.Pages
{
    public partial class Coba
    {
        [Inject] public ToastrService ToastrService { get; set; }

        public async Task ShowToastrInfo()
        {
            var message = "This is a message sent from the C# method";
            //var options = new ToastrOptions
            //{
            //    CloseButton = true,
            //    HideDuration = 300,
            //    HideMethod = ToastrHideMethod.SlideUp,
            //    ShowMethod = ToastrShowMethod.SlideDown,
            //    Position = ToastrPosition.BottomRight
            //};

            await ToastrService.ShowInfoMessage(message);
        }
    }
}
