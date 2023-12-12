namespace BookStoreApp.Blazor.Server.UI.Services.Base
{
    public partial interface IBookStoreClient
    {
        public HttpClient HttpClient { get; }
    }
}
