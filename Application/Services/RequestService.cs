using Microsoft.Identity.Abstractions;
using Microsoft.Identity.Web;

namespace Application.Services
{
    // interface
    public interface IRequestService
    {
        Task<string> GetWorkItemAsync();
    }

    // implementation
    public class RequestService : IRequestService
    {
        private IDownstreamApi _downstreamWebApi;
        public RequestService(IDownstreamApi downstreamApi)
        {
            _downstreamWebApi = downstreamApi;
        }

        public async Task<string> GetWorkItemAsync()
        {
            var url = "api/WorkItems/request";

            var test = await _downstreamWebApi.GetForUserAsync<string>("TemplateApi", options => options.RelativePath = url);

            return test ?? string.Empty;
        }

        ////private readonly HttpClient _httpClient;
        //private readonly IHttpClientFactory _httpClientFactory;
        ////public RequestService(HttpClient httpClient, IHttpClientFactory httpClientFactory) 
        //public RequestService(IHttpClientFactory httpClientFactory)
        //{
        //    //_httpClient = httpClient ?? throw new ArgumentNullException();
        //    _httpClientFactory = httpClientFactory ?? throw new ArgumentNullException(nameof(httpClientFactory));
        //}

        //public async Task<string> GetWorkItemAsync()
        //{
        //    using var httpClient = _httpClientFactory.CreateClient("api");
        //    //var test = await httpClient.GetFromJsonAsync<string>("api/workitem/request");
        //    var request = new HttpRequestMessage(HttpMethod.Get, "https://localhost:7046/api/workitem/request");
        //    //var client = ClientFactory.CreateClient();
        //    var response = await httpClient.SendAsync(request); //should return hi
        //    var baseAddress = httpClient.BaseAddress;
        //    var testing = await httpClient.GetAsync("api/workitem/request");
        //    string test = "";
        //    if (response.IsSuccessStatusCode)
        //    {
        //        test = await response.Content.ReadAsStringAsync();
        //        //using var responseStream = await response.Content.ReadAsStreamAsync();
        //        //test = await JsonSerializer.DeserializeAsync<string>(responseStream);
        //    }
        //    //var test = httpClient.BaseAddress;
        //    return "hello";
        //}
    }
}
