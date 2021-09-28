using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace Web.Shared.Components
{
    public partial class TableActionComponent
    {



        [Parameter] public Func<MouseEventArgs, Task<bool>> OnClickDelete { get; set; }
        [Parameter] public EventCallback<MouseEventArgs> OnClickUpdate { get; set; }


        private bool _onClickDeleteLoading = false;


        private async Task HandleOnClickDelete(MouseEventArgs args)
        {
            if (OnClickDelete != null)
            {
                _onClickDeleteLoading = true;
                var isSuccess = await OnClickDelete.Invoke(args);
                _onClickDeleteLoading = false;

                if (isSuccess)
                {
                    await notification.Success("hapus data sukses");
                }
            }
        }

        private async Task HandleOnClickUpdate(MouseEventArgs args)
        {
            if (OnClickUpdate.HasDelegate)
            {
                await OnClickUpdate.InvokeAsync(args);
            }
        }
    }
}
