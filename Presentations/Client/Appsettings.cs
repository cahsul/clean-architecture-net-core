namespace Client
{
    public class Appsettings
    {
        private readonly IConfiguration _config;

        public Appsettings(IConfiguration config)
        {
            _config = config;
        }

        public string Api_Serti() { return _config["Api:Serti"].Trim().ToString(); }


    }
}
