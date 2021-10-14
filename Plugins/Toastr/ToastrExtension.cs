using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace Toastr
{
    public static class ToastrExtension
    {
        public static IServiceCollection AddToastr(this IServiceCollection services)
        {
            return services.AddScoped<ToastrService>();
        }
    }
}
