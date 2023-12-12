using Blazored.LocalStorage;
using BookStoreApp.Blazor.Server.UI.Services.Base;

namespace BookStoreApp.Blazor.Server.UI.Services
{
    public class AuthorService : BaseHttpService, IAuthorService
    {
        private readonly IBookStoreClient _bookStoreClient;

        public AuthorService(IBookStoreClient bookStoreClient, ILocalStorageService localStorageService) : base(bookStoreClient, localStorageService)
        {
            _bookStoreClient = bookStoreClient;
        }

        public async Task<Response<int>> CreateAuthor(AuthorCreateDto author)
        {
            Response<int> response = new Response<int>();
            try
            {
                await GetBearerTokenAsync();
                await _bookStoreClient.AuthorsPOSTAsync(author);
            }
            catch (ApiException apiException)
            {
                response = ConvertApiExceptions<int>(apiException);
            }

            return response;
        }

        public async Task<Response<List<AuthorReadOnlyDto>>> GetAuthors()
        {
            Response<List<AuthorReadOnlyDto>> response;

            try
            {
                await GetBearerTokenAsync();
                var data = await _bookStoreClient.AuthorsAllAsync();
                response = new Response<List<AuthorReadOnlyDto>>
                {
                    Data = data.ToList(),
                    Success = true
                };
            }
            catch (ApiException apiException)
            {
                response = ConvertApiExceptions<List<AuthorReadOnlyDto>>(apiException);
            }

            return response;
        }
    }
}
