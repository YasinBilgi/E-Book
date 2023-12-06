using EBook.Entities.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using Utility;

namespace EBookApp.Controllers
{
	public class AccountController : Controller
	{
		EBookDbContext context = new EBookDbContext();

        // Giriş İşlemleri

		public IActionResult Login()
		{
            ViewBag.Message = "";
            return View();
		}

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(User model)
        {
            // Doğrula
            var user = await context.Users.FirstOrDefaultAsync(x => x.Email == model.Email && x.Password == model.Password);

            if (user == null)
            {
                ViewBag.Message = "Kullanıcı bulunamadı";
                return View(model);
            }

            //Email Send
            await MailSender.SendLoginMail(model.Email);

            //auth işlemleri
            var claims = new[] {
               new Claim(ClaimTypes.Name, user.FirstName + " " + user.LastName),
               new Claim(ClaimTypes.Role, user.Role)
            };

            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(identity));

            return Redirect(new PathString("/managementpanel/dashboard/index"));
        }

        [HttpGet]

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToAction("Login");
        }

        [HttpGet]
        public async Task<IActionResult> AccessDenied()
        {
            return View();
        }


         // Kayıt İşlemleri // 

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(User model)
        {
            if (ModelState.IsValid)
            {
                //Veri tabanına kayıt işlemleri
                await context.Users.AddAsync(model);
                await context.SaveChangesAsync();

                //Email Send
                await MailSender.SendRegisterMail(model.Email);

                //auth işlemleri
                var claims = new[] {
               new Claim(ClaimTypes.Name, model.FirstName + " " + model.LastName),
               new Claim(ClaimTypes.Role, model.Role)
                };

                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(identity));

                return Redirect(new PathString("/managementpanel/dashboard/index"));
            }
            return View(model);
        }
    }
}
