using Microsoft.AspNetCore.Mvc;

namespace CashTrail.Controllers // Replace with your actual namespace
{
    public class WalletController : Controller
    {
        public IActionResult Wallet()
        {
            return View();
        }
    }
}
