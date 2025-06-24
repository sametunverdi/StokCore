using Microsoft.AspNetCore.Mvc;
using StokCore.BusinessLayer.Concrete;
using StokCore.DataAccessLayer.EntityFramework;
using StokCore.EntityLayer.Concrete;

namespace StokCore.WebUI.Controllers
{
    public class UserController : Controller
    {
        AppUserManager appUserManager = new AppUserManager(new EfAppUserDal());

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(AppUser user)
        {
            if (ModelState.IsValid)
            {
                appUserManager.AddUser(user);
                return RedirectToAction("Login");
            }
            return View(user);
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(AppUser user)
        {
            var userInfo = appUserManager.GetUser(user.UserName, user.Password);
            if (userInfo != null)
            {
                HttpContext.Session.SetString("username", userInfo.UserName);
                return RedirectToAction("Index", "Category"); // Giriş sonrası yönlendirme
            }

            ViewBag.Message = "Kullanıcı adı veya şifre hatalı.";
            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
    }
}
