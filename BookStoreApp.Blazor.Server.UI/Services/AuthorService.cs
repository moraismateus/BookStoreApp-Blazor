using AutoMapper;
using Blazored.LocalStorage;
using BookStoreApp.Blazor.Server.UI.Services.Base;

namespace BookStoreApp.Blazor.Server.UI.Services
{
    public class AuthorService : BaseHttpService, IAuthorService
    {
        private readonly IBookStoreClient _bookStoreClient;
        private readonly IMapper _mapper;

        public AuthorService(IBookStoreClient bookStoreClient, ILocalStorageService localStorageService, IMapper mapper) : base(bookStoreClient, localStorageService)
        {
            _bookStoreClient = bookStoreClient;
            _mapper = mapper;
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

        public async Task<Response<int>> EditAuthor(int id, AuthorUpdateDto author)
        {
            Response<int> response = new Response<int>();
            try
            {
                await GetBearerTokenAsync();
                await _bookStoreClient.AuthorsPUTAsync(id, author);
            }
            catch (ApiException apiException)
            {
                response = ConvertApiExceptions<int>(apiException);
            }

            return response;
        }

        public async Task<Response<AuthorReadOnlyDto>> GetAuthor(int id)
        {
            Response<AuthorReadOnlyDto> response;

            try
            {
                await GetBearerTokenAsync();
                var data = await _bookStoreClient.AuthorsGETAsync(id);
                response = new Response<AuthorReadOnlyDto>
                {
                    Data = data,
                    Success = true
                };
            }
            catch (ApiException apiException)
            {
                response = ConvertApiExceptions<AuthorReadOnlyDto>(apiException);
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

        public async Task<Response<AuthorUpdateDto>> GetAuthorForUpdate(int id)
        {
            Response<AuthorUpdateDto> response;

            try
            {
                await GetBearerTokenAsync();
                var data = await _bookStoreClient.AuthorsGETAsync(id);
                response = new Response<AuthorUpdateDto>
                {
                    Data = _mapper.Map<AuthorUpdateDto>(data),
                    Success = true
                };
            }
            catch (ApiException apiException)
            {
                response = ConvertApiExceptions<AuthorUpdateDto>(apiException);
            }

            return response;
        }
    }
}
