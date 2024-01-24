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

        public async Task<Response<int>> Create(AuthorCreateDto author)
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

        public async Task<Response<int>> Delete(int id)
        {
            Response<int> response = new Response<int>();
            try
            {
                await GetBearerTokenAsync();
                await _bookStoreClient.AuthorsDELETEAsync(id);
            }
            catch (ApiException apiException)
            {
                response = ConvertApiExceptions<int>(apiException);
            }

            return response;
        }

        public async Task<Response<int>> Edit(int id, AuthorUpdateDto author)
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

        public async Task<Response<AuthorDetailsDto>> Get(int id)
        {
            Response<AuthorDetailsDto> response;

            try
            {
                await GetBearerTokenAsync();
                var data = await _bookStoreClient.AuthorsGETAsync(id);
                response = new Response<AuthorDetailsDto>
                {
                    Data = data,
                    Success = true
                };
            }
            catch (ApiException apiException)
            {
                response = ConvertApiExceptions<AuthorDetailsDto>(apiException);
            }

            return response;
        }

        public async Task<Response<List<AuthorReadOnlyDto>>> Get()
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

        public async Task<Response<AuthorUpdateDto>> GetForUpdate(int id)
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
