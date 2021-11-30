using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace Devextreme
{

    public static class DevextremeExtension
    {
        public static IServiceCollection AddDevextreme(this IServiceCollection services)
        {
            return services.AddScoped<DevextremeService>();
        }
    }
}
