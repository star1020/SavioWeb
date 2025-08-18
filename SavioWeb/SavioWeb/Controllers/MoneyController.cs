using Microsoft.AspNetCore.Mvc;

namespace SavioWeb.Controllers
{
    public class MoneyController : Controller
    {
        public IActionResult Index()
        {
            return View("Money");
        }
    }
}
