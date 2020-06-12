using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

//이력 조회 컨트롤러 

namespace MiniDron.Controllers
{
    public class HistoryController : Controller
    {
        public IActionResult HMap()
        {
            return View();
        }

        public IActionResult HDronSearch()
        {
            return View();
        }

        public IActionResult FlightViolation()
        {
            return View();
        }
    }
}
