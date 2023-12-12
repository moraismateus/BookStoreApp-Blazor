namespace BookStoreApp.Blazor.Server.UI.Services.Base
{
    public partial class BookStoreClient : IBookStoreClient
    {
        public HttpClient HttpClient 
        {
            get => _httpClient;
        }
    }

}
