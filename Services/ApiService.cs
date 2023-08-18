using AsyncJob.Models;
using Newtonsoft.Json;

namespace AsyncJob.Services
{
    public class ApiService
    {
        private readonly HttpClient _httpClient;

        public ApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<User>> GetUsersAsync()
        {
            HttpResponseMessage response = await _httpClient.GetAsync("https://jsonplaceholder.typicode.com/users");
            string responseBody = await response.Content.ReadAsStringAsync();
            List<User> users = JsonConvert.DeserializeObject<List<User>>(responseBody);
            return users;
        }

        public async Task<List<Post>> GetPostsByUserAsync(int userId)
        {
            HttpResponseMessage response = await _httpClient.GetAsync($"https://jsonplaceholder.typicode.com/posts?userId={userId}");
            string responseBody = await response.Content.ReadAsStringAsync();
            List<Post> posts = JsonConvert.DeserializeObject<List<Post>>(responseBody);
            return posts;
        }

        public async Task<List<Comment>> GetCommentsByPostAsync(int postId)
        {
            HttpResponseMessage response = await _httpClient.GetAsync($"https://jsonplaceholder.typicode.com/comments?postId={postId}");
            string responseBody = await response.Content.ReadAsStringAsync();
            List<Comment> comments = JsonConvert.DeserializeObject<List<Comment>>(responseBody);
            return comments;
        }
    }
}
