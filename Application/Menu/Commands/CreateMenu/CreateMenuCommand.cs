using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Application.X.Extensions;
using Application.X.Interfaces.Persistence;
using MediatR;
using Shared.Menu.Commands.CreateMenu;
using Shared.X.Responses;
using Shared.X.Extensions;

namespace Application.Menu.Commands.CreateMenu
{

    public class CreateMenuCommand : CreateMenuRequest, IRequest<ResponseBuilder<CreateMenuResponse>>
    {
    }

    public class Handler : IRequestHandler<CreateMenuCommand, ResponseBuilder<CreateMenuResponse>>
    {
        private readonly IIdentityDbContext _identityDbContext;

        public Handler(IIdentityDbContext identityDbContext)
        {
            _identityDbContext = identityDbContext;
        }

        public async Task<ResponseBuilder<CreateMenuResponse>> Handle(CreateMenuCommand request, CancellationToken cancellationToken)
        {

            // save
            var dataToSave = new Domain.Entities.Identity.Menu
            {
                ParentId = request.ParentId ?? null,
                Label = request.Label,
                Url = request.Url,
                MenuKey = request.MenuKey,
                MenuAction = request.MenuAction.ToJson()
            };

            await _identityDbContext.Menus.AddAsync(dataToSave);
            await _identityDbContext.SaveChangesAsync();


            return new CreateMenuResponse
            {
                Id = dataToSave.Id
            }.ResponseCreate();
        }
    }
}
