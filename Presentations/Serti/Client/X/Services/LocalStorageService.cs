using Blazored.LocalStorage;

namespace Serti.Client.X.Services
{


    public class LocalStorageService
    {
        private readonly ILocalStorageService _localStorageService;

        public LocalStorageService(ILocalStorageService localStorageService)
        {
            _localStorageService = localStorageService;
        }

        public async Task SetJwtToken(string jwtToken)
        {
            await _localStorageService.SetItemAsync("JwtToken", jwtToken);
        }
    }
}
