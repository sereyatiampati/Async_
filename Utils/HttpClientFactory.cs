using System.Net.Http;

namespace AsyncJob.Utils
{
    public static class HttpClientFactory
    {
        public static HttpClient CreateHttpClient()
        {
            HttpClient httpClient = new HttpClient();
            // Configure HttpClient if needed (e.g., base address, headers, etc.)
            return httpClient;
        }
    }
}
