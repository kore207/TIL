using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

//통계 화면 컨트롤러

namespace MiniDron.Controllers
{
    public class StatisticController : Controller
    {
        public IActionResult StatisticView()
        {
            return View();
        }
    }
}
