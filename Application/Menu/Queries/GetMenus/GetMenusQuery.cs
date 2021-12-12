using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Application.X.Attributes;
using Application.X.Extensions;
using Application.X.Interfaces.Persistence;
using MediatR;
using Shared.Menu.Queries.GetMenus;
using Shared.X.Responses;
using Shared.X.Extensions;
using Microsoft.EntityFrameworkCore;
using Shared.X.Enums;

namespace Application.Menu.Queries.GetMenus
{

    //[Authorize(MenuKey.Menu, MenuAction.List)]
    public class GetMenusQuery : GetMenusRequest, IRequest<ResponseBuilder<List<GetMenusResponse>>>
    {

    }

    public class Handler : IRequestHandler<GetMenusQuery, ResponseBuilder<List<GetMenusResponse>>>
    {
        private readonly IIdentityDbContext _identityDbContext;

        public Handler(IIdentityDbContext identityDbContext)
        {
            _identityDbContext = identityDbContext;
        }

        public async Task<ResponseBuilder<List<GetMenusResponse>>> Handle(GetMenusQuery request, CancellationToken cancellationToken)
        {
            var data = _identityDbContext.Menus
                .OrderBy(o => o.Order)
                .Select(s => new GetMenusResponse
                {
                    Id = s.Id,
                    MenuAction = s.MenuAction.ToJsonDeserialize<List<string>>(),
                    Label = s.Label,
                    MenuKey = s.MenuKey,
                    ParentId = s.ParentId,
                    IsMenu = s.IsMenu,
                    Url = s.Url,
                }).ToList();



            return data.ResponseRead();
        }
    }
}
