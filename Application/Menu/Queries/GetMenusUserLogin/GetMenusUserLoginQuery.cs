using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Application.X.Extensions;
using Application.X.Interfaces.Persistence;
using MediatR;
using Shared.Menu.Queries.GetMenusUserLogin;
using Shared.X.Responses;

namespace Application.Menu.Queries.GetMenusUserLogin
{
    public class GetMenusUserLoginQuery : GetMenusUserLoginRequest, IRequest<ResponseBuilder<List<GetMenusUserLoginResponse>>>
    {

    }

    public class Handler : IRequestHandler<GetMenusUserLoginQuery, ResponseBuilder<List<GetMenusUserLoginResponse>>>
    {
        private readonly IIdentityDbContext _identityDbContext;

        public Handler(IIdentityDbContext identityDbContext)
        {
            _identityDbContext = identityDbContext;
        }

        public async Task<ResponseBuilder<List<GetMenusUserLoginResponse>>> Handle(GetMenusUserLoginQuery request, CancellationToken cancellationToken)
        {

            //var userMenus = new List<GetMenusUserLoginResponse>
            //{
            //    new GetMenusUserLoginResponse
            //    {
            //        Label = "1",
            //        Childs = new List<GetMenusUserLoginResponse>
            //        {
            //            new GetMenusUserLoginResponse { Label = "1.1"},
            //            new GetMenusUserLoginResponse { Label = "1.2"},
            //            new GetMenusUserLoginResponse { Label = "1.3",
            //                Childs = new List<GetMenusUserLoginResponse> {
            //                new GetMenusUserLoginResponse { Label = "1.3.1"},
            //                new GetMenusUserLoginResponse { Label = "1.3.2"},
            //                new GetMenusUserLoginResponse {
            //                    Label = "1.3.3",
            //                    Childs = new List<GetMenusUserLoginResponse> {
            //                    new GetMenusUserLoginResponse { Label = "1.3.3.1"},
            //                    new GetMenusUserLoginResponse { Label = "1.3.3.2"},
            //                    new GetMenusUserLoginResponse { Label = "1.3.3.3"},
            //                    },
            //                },
            //                }
            //            },
            //        }
            //    },

            //    new GetMenusUserLoginResponse
            //    {
            //        Label = "User",
            //        Url = "/user",
            //    },

            //    new GetMenusUserLoginResponse
            //    {
            //        Label = "Menu",
            //        Url = "/menu",
            //    }
            //};

            //get menu
            var menus = _identityDbContext.Menus
                .OrderBy(o => o.ParentId).ToList();

            var userMenus = MenuBuilder(menus, null);


            return userMenus.ResponseRead();
        }

        private List<GetMenusUserLoginResponse> MenuBuilder(List<Domain.Entities.Identity.Menu> menus, Guid? parentId)
        {
            var result = new List<GetMenusUserLoginResponse>();
            foreach (var item in menus.Where(w => w.ParentId == parentId).OrderBy(o => o.Order))
            {
                var childCount = menus.Where(w => w.ParentId == item.Id).Count();
                result.Add(
                    new GetMenusUserLoginResponse
                    {
                        Label = item.Label,
                        Childs = childCount == 0 ? null : MenuBuilder(menus, item.Id),
                        Url = item.Url,
                    }
                );
                ;
            }

            return result;
        }
    }


}
