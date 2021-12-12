using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Application.X.Extensions;
using Application.X.Interfaces.Persistence;
using MediatR;
using Shared.Menu.Commands.DeleteMenu;
using Shared.X.Responses;

namespace Application.Menu.Commands.DeleteMenu
{
    public class DeleteMenuCommand : DeleteMenuRequest, IRequest<ResponseBuilder<DeleteMenuResponse>>
    {
    }

    public class Handler : IRequestHandler<DeleteMenuCommand, ResponseBuilder<DeleteMenuResponse>>
    {
        private readonly IIdentityDbContext _identityDbContext;

        public Handler(IIdentityDbContext identityDbContext)
        {
            _identityDbContext = identityDbContext;
        }

        public async Task<ResponseBuilder<DeleteMenuResponse>> Handle(DeleteMenuCommand request, CancellationToken cancellationToken)
        {
            // find by ID
            var data = _identityDbContext.Menus.FirstOrDefault(w => w.Id == request.Id);

            // delete
            _identityDbContext.Menus.Remove(data);
            await _identityDbContext.SaveChangesAsync(cancellationToken);


            //var dataToSave = new Domain.Entities.Identity.Menu
            //{
            //    MenuName = request.MenuName,
            //    MenuKey = request.MenuKey,
            //    MenuAction = request.MenuAction.ToJson()
            //};

            //await _identityDbContext.Menus.AddAsync(dataToSave);
            //await _identityDbContext.SaveChangesAsync();


            return new DeleteMenuResponse
            {
            }.ResponseDelete();
        }
    }
}
