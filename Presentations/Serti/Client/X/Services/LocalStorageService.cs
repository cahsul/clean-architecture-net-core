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

        public async Task Login()
        {
            //await _localStorageService.SetItemAsync("user aaaaaaaaaaa", "asdasdasdasd");
        }
    }
}
