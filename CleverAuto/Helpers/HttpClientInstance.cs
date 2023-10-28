namespace CleverAuto.Helpers
{

    public  class HttpClientInstance
        {
        private readonly HttpClient _httpClient;

        public HttpClientInstance()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("https://cleverauto.sawarii.com/"); // Set the base address here
        }

        public HttpClient GetHttpClientInstance()
        {
            return _httpClient;
        }
    }
    
}
