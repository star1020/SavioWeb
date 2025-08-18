using Microsoft.AspNetCore.Mvc;
using SavioWeb.Models;
using System.Text.Json;

namespace SavioWeb.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> GetUserList()
        {
            var json = await System.IO.File.ReadAllTextAsync("Config/api.json");
            var apiConfig = JsonSerializer.Deserialize<ApiConfig>(json);

            var fullUrl = new Uri(new Uri(apiConfig.endpoint), apiConfig.user.getAll).ToString();

            Console.WriteLine($"Calling: {fullUrl}");

            using (var client = new HttpClient())
            {
                var response = await client.GetAsync(fullUrl);
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    Console.WriteLine(result);

                    // var users = JsonSerializer.Deserialize<List<UserModel>>(result);

                    ViewBag.UsersJson = result;
                }
                else
                {
                    Console.WriteLine($"API call failed with status code: {response.StatusCode}");
                    ViewBag.UsersJson = $"API call failed with status code: {response.StatusCode}";
                }
            }

            return View("User");
        }
    }
}
