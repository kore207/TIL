using System.Linq;
using AspnetNot.MVC.DataContext;
using AspnetNot.MVC.Models;
using AspnetNot.MVC.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AspnetNot.MVC.Controllers
{
    public class AccountController : Controller
    {
        /// <summary>
        /// 로그인
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            // ID ,PW - 필수 
            if(ModelState.IsValid)
            {
                using (var db = new AspnetNoteDbContext())
                {
                    //Linq - 메서드 체이닝                      
                    //var user = db.Users  //메모리 누수가 발생한다 ( ==을 사용하면 새로운 객체가 생성되기 떄문)
                    //    .FirstOrDefault(u=>u.UserId == model.UserId && u.UserPassword == model.UserPassword);
                    var user = db.Users
                        .FirstOrDefault(u => u.UserId.Equals(model.UserId) &&
                        u.UserPassword.Equals(model.UserPassword));

                    if(user != null)
                    {
                        //로그인에 성공했을 때
                        HttpContext.Session.SetInt32("USER_LOGIN_KEY",user.UserNo);
                        return RedirectToAction("LoginSuccess", "Home"); //로그인 성공페이지로 이동                        
                    }                    
                }
                //로그인에 실패했을 때
                ModelState.AddModelError(string.Empty, "사용자 ID 혹은 비밀번호가 올바르지 않습니다.");
            }
            return View(model);
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Remove("USER_LOGIN_KEY");
            //HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }

        /// <summary>
        /// 회원 가입
        /// </summary>
        /// <returns></returns>
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(User model)
        {
            if(ModelState.IsValid)
            {
                using (var db = new AspnetNoteDbContext()) //using문은 db open close까지 다된다 
                {
                    db.Users.Add(model); //메모리에 올리고
                    db.SaveChanges(); //sql에 저장 
                }
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
    }
}
