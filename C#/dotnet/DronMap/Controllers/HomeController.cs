using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DronMap.Models;
using DronMap.ViewModels;

//Controller파일을 만들때는 반드시 XXXController.cs 형식으로 생성해야한다.
namespace DronMap.Controllers
{    
    public class HomeController : Controller
    {
        public IActionResult Map2()
        {

            return View();
        }
        public IActionResult Map()
        {
            
            return View();
        }

        public IActionResult DronIndex()
        {
            List<Dron> drons = new List<Dron>
            {
                new Dron() { Name = "A", Region = "대전"},
                new Dron() { Name = "B", Region = "서울"},
                new Dron() { Name = "C", Region = "세종"}
            };

            var viewModel = new CustomDronViewModel()
            {
                DronIndex = new DronIndex(),
                Dron = drons
            };

            return View(viewModel);
        }

        [HttpPost] //이 태그를 붙임으로써 뷰에서 넘어오는 값들은 받는 역활을 할 수있다.
        [ValidateAntiForgeryToken] //토큰 사용 권장 
        public IActionResult DronIndex(CustomDronViewModel model) //위에 DronIndex와 이름이 같아야한다?
        {
            if(ModelState.IsValid)
            {
                //model 데이터를 테이블에 저장
            }
            else
            {
                //에러처리 
            }
            return View();
        }

        public IActionResult Index() 
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
