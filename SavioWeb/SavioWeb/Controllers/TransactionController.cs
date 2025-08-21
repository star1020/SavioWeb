using System.Text;
using System.Transactions;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SavioWeb.Config;
using SavioWeb.Models;

namespace SavioWeb.Controllers
{
    public class TransactionController : Controller
    {
        private readonly IApiConfigProvider _apiConfigProvider;
        public TransactionController(IApiConfigProvider apiConfigProvider)
        {
            _apiConfigProvider = apiConfigProvider;
        }
        public ActionResult TransactionList()
        {
            return View();
        }
        public async Task<IActionResult> GetTransactionList()
        {
            var apiConfig = await _apiConfigProvider.GetApiConfigAsync();

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
                        return Json(new { success = true, data = parsed });
                    }
                    else
                    {
                        Console.WriteLine($"API call failed with status code: {response.StatusCode}");
                        return Json(new { success = false, message = "API call failed." });
                    }
                }

            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "API call failed." });
            }
            
        }
    }
}
