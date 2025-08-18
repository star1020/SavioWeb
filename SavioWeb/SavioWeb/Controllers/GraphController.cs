using Microsoft.AspNetCore.Mvc;

namespace SavioWeb.Controllers
{
    public class GraphController : Controller
    {
        public IActionResult Index()
        {
            return View("Graph");
        }
    }
}
