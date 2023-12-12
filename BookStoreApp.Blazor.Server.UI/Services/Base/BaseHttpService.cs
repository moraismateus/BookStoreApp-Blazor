using Blazored.LocalStorage;
using System.Net.Http.Headers;

namespace BookStoreApp.Blazor.Server.UI.Services.Base
{
    public class BaseHttpService
    {
        private readonly IBookStoreClient _bookStoreClient;
        private readonly ILocalStorageService _localStorageService;

        public BaseHttpService(IBookStoreClient bookStoreClient, ILocalStorageService localStorageService)
        {
            _bookStoreClient = bookStoreClient;
            _localStorageService = localStorageService;
        }

        protected Response<Guid> ConvertApiExceptions<Guid>(ApiException apiException)
        {
            if (apiException.StatusCode == 400)
            {
                return new Response<Guid>() { Message = "Validation errors have occurred.", ValidationErrors = apiException.Response, Success = false };
            }

            if (apiException.StatusCode == 404)
            {
                return new Response<Guid>() { Message = "The requested item could not be found.", Success = false };
            }

            if (apiException.StatusCode >= 200 && apiException.StatusCode <= 299)
            {
                return new Response<Guid>() { Message = "Operation Reported Success", Success = true };
            }

            return new Response<Guid>() { Message = "Something went wrong, please try again.", Success = false };
        }

        protected async Task GetBearerTokenAsync()
        {
            var token = await _localStorageService.GetItemAsync<string>("accessToken");
            if (token != null)
            {
                _bookStoreClient.HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", token);
            }
        }
    }
}
