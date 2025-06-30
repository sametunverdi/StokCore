using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using StokCore.BusinessLayer.Concrete;
using StokCore.DataAccessLayer.EntityFramework;
using StokCore.EntityLayer.Concrete;
using System.Security.Claims;

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

        //[HttpPost]
        //public IActionResult Login(AppUser user)
        //{
        //    var userInfo = appUserManager.GetUser(user.UserName, user.Password);
        //    if (userInfo != null)
        //    {
        //        HttpContext.Session.SetString("username", userInfo.UserName);
        //        return RedirectToAction("Index", "Category"); // Giriş sonrası yönlendirme
        //    }

        //    ViewBag.Message = "Kullanıcı adı veya şifre hatalı.";
        //    return View();
        //}
        [HttpPost]
        public async Task<IActionResult> Login(AppUser user)
        {
            // Veritabanından kullanıcıyı alıyoruz
            var userInfo = appUserManager.GetUser(user.UserName, user.Password);

            if (userInfo != null)
            {
                // Cookie içine yazılacak kimlik bilgisi
                var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, userInfo.UserName) // Kullanıcının adıyla giriş yapılıyor
        };

                // Bu bilgileri taşıyan kimlik oluşturuluyor
                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                // ASP.NET'e bu kullanıcıyı tanıtıyoruz
                var principal = new ClaimsPrincipal(identity);

                // Giriş işlemi (cookie oluşturulur)
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

                // Giriş başarılıysa yönlendirme
                return RedirectToAction("Index", "Category");
            }

            // Giriş başarısızsa hata mesajı
            ViewBag.Message = "Kullanıcı adı veya şifre hatalı.";
            return View();
        }
        public async Task<IActionResult> Logout()
        {
            // Cookie'yi temizleyip çıkış yapıyoruz
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login");
        }
        //public IActionResult Logout()
        //{
        //    HttpContext.Session.Clear();
        //    return RedirectToAction("Login");
        //}
    }
}
