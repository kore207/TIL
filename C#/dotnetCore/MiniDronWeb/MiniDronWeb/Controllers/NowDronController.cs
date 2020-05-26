using Microsoft.AspNetCore.Mvc;

namespace MiniDronWeb.Controllers
{
    public class NowDronController : Controller
    {
        public IActionResult NowMap()
        {
            return View();
        }
    }
}