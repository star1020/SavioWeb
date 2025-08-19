using System.Text;
using System.Transactions;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SavioWeb.Models;

namespace SavioWeb.Controllers
{
    public class TransactionController : Controller
    {
        public async Task<IActionResult> GetTransactionList()
        {

            var json = await System.IO.File.ReadAllTextAsync("Config/api.json");
            var apiConfig = JsonConvert.DeserializeObject<ApiConfig>(json);

            try
            {
                using (HttpClient client = new HttpClient())
                {
                    var apiUrl = new Uri(new Uri(apiConfig.endpoint), apiConfig.transaction.getAllWithData).ToString();

                    var dataToSend = new
                    {
                    };

                    string jsonData = JsonConvert.SerializeObject(dataToSend);
                    var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
                    Console.WriteLine($"Calling: {apiUrl}");

                    HttpResponseMessage response = await client.PostAsync(apiUrl, content);

                    if (response.IsSuccessStatusCode)
                    {
                        string responseData = await response.Content.ReadAsStringAsync();
                        var parsed = JsonConvert.DeserializeObject<TransactionResponse>(responseData);

                        ViewData["TransactionList"] = parsed;
                        return View();
                    }
                    else
                    {
                        Console.WriteLine($"API call failed with status code: {response.StatusCode}");
                        return View();
                    }
                }

            }
            catch (Exception ex)
            {
                return Json(new { draw = 0, recordsFiltered = 0, recordsTotal = 0, data = 0 });
            }
            
        }
    }
}
