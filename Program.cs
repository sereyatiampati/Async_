using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using AsyncJob.Models;
using AsyncJob.Services;
using AsyncJob.Helpers;
using AsyncJob.Utils;

class Program
{
    static async Task Main(string[] args)
    {
        using HttpClient httpClient = HttpClientFactory.CreateHttpClient();
        ApiService apiService = new ApiService(httpClient);

        List<User> users = await apiService.GetUsersAsync();

        Console.WriteLine("Users:");
        foreach (User user in users)
        {
            Console.WriteLine(user.Username);
        }

        string selectedUsername = ConsoleHelper.ReadInput("Enter the username of the user to see their posts: ");

        User selectedUser = users.Find(user => user.Username == selectedUsername);
        if (selectedUser != null)
        {
            List<Post> posts = await apiService.GetPostsByUserAsync(selectedUser.Id);

            Console.WriteLine($"Posts by {selectedUser.Username}:");
            foreach (Post post in posts)
            {
                Console.WriteLine($"Title: {post.Title}");
                Console.WriteLine($"Body: {post.Body}");
                Console.WriteLine("------------------------------");
            }

            string selectedPostTitle = ConsoleHelper.ReadInput("Enter the title of the post to see its comments: ");

            Post selectedPost = posts.Find(post => post.Title == selectedPostTitle);
            if (selectedPost != null)
            {
                List<Comment> comments = await apiService.GetCommentsByPostAsync(selectedPost.Id);

                Console.WriteLine($"Comments for post '{selectedPost.Title}':");
                foreach (Comment comment in comments)
                {
                    Console.WriteLine($"Name: {comment.Name}");
                    Console.WriteLine($"Email: {comment.Email}");
                    Console.WriteLine($"Body: {comment.Body}");
                    Console.WriteLine("------------------------------");
                }
            }
            else
            {
                Console.WriteLine("Post not found.");
            }
        }
        else
        {
            Console.WriteLine("User not found.");
        }
    }
}
