

using Application.Menu.Commands.CreateMenu;
using Application.Menu.Commands.DeleteMenu;
using Application.Menu.Queries.GetMenus;
using Application.Menu.Queries.GetMenusUserLogin;
using Microsoft.AspNetCore.Mvc;
using Shared.Menu.Commands.CreateMenu;
using Shared.Menu.Commands.DeleteMenu;
using Shared.Menu.Queries.GetMenus;
using Shared.Menu.Queries.GetMenusUserLogin;
using Shared.Menu.Resources;
using Shared.X.Responses;

namespace Serti.Server.Controllers
{

    public class MenuController : ApiController
    {
        [HttpPost(MenuEndpoint.Menu.Create)]
        public async Task<ActionResult<ResponseBuilder<CreateMenuResponse>>> CreateMenu([FromForm] CreateMenuCommand query)
        {
            return await Mediator.Send(query);
        }

        [HttpGet(MenuEndpoint.Menu.Getmenus)]
        public async Task<ActionResult<ResponseBuilder<List<GetMenusResponse>>>> Getmenus(GetMenusQuery query)
        {
            return await Mediator.Send(query);
        }

        [HttpGet(MenuEndpoint.Menu.GetMenusUserLogin)]
        public async Task<ActionResult<ResponseBuilder<List<GetMenusUserLoginResponse>>>> GetMenusUserUserLogin(GetMenusUserLoginQuery query)
        {
            return await Mediator.Send(query);
        }

        [HttpDelete(MenuEndpoint.Menu.Delete)]
        public async Task<ActionResult<ResponseBuilder<DeleteMenuResponse>>> DeleteMenu([FromForm] DeleteMenuCommand query)
        {
            return await Mediator.Send(query);
        }


    }


}
