using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared.X.Extensions;

namespace Infrastructure.X.Settings
{
    public class InfrastructureSettings
    {
        public ConnectionStrings ConnectionStrings { get; set; }
        public IdentityUser IdentityUser { get; set; }
        public Jwt Jwt { get; set; }

        //public InfrastructureSettings()
        //{
        //    var baseDirectory = AppContext.BaseDirectory;
        //    var r = new StreamReader($"{baseDirectory}/InfrastructureSettings.json");
        //    var jsonString = r.ReadToEnd();
        //    var settings = jsonString.JsonDeserialize<InfrastructureSettings>();

        //    ConnectionStrings = settings.ConnectionStrings;
        //    IdentityUser = settings.IdentityUser;
        //    Jwt = settings.Jwt;
        //}
    }
}
