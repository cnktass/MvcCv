using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MvcCv.Data;
using MvcCv.Models.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MvcCv.Controllers
{
	public class LoginController : Controller
	{
		private readonly ApplicationDbContext _context;
		private readonly ILogger<LoginController> _logger;

		public LoginController(ApplicationDbContext context, ILogger<LoginController> logger)
		{
			_context = context;
			_logger = logger;
		}

		// GET: Login/Index
		public IActionResult Index()
		{
			return View();  // Login sayfası
		}

		// POST: Login/Index
		[HttpPost]
		public async Task<IActionResult> Index(TblAdmin p)
		{
			// Kullanıcı adı ve şifreyi kontrol ediyoruz
			var bilgi = _context.Admins.FirstOrDefault(x => x.KullaniciAdi == p.KullaniciAdi && x.Sifre == p.Sifre);

			if (bilgi != null)
			{
				// Kullanıcı adı ve şifre doğruysa, kimlik doğrulama işlemi başlatıyoruz

				var claims = new List<Claim>
				{
					new Claim(ClaimTypes.Name, bilgi.KullaniciAdi),
                    // Admin kullanıcısına özel claim (isteğe bağlı)
                    new Claim(ClaimTypes.Role, "Admin")
				};

				var identity = new ClaimsIdentity(claims, "Login");
				var principal = new ClaimsPrincipal(identity);

				// Kullanıcıyı giriş yapmış sayıyoruz ve oturum açtırıyoruz
				await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

				// Giriş başarılı, admin paneline yönlendiriyoruz
				return RedirectToAction("Index", "Deneyim"); // AdminController'da AdminPanel action'ına yönlendiriyoruz
			}

			// Eğer giriş bilgileri yanlışsa hata mesajı gösteriyoruz
			ViewBag.Hata = "Kullanıcı adı veya şifre hatalı!";
			return View();
		}

		// Kullanıcı çıkış yaparsa, çıkış işlemi yapılır
		public async Task<IActionResult> Logout()
		{
			// Kullanıcı çıkış yaparsa cookie'yi temizliyoruz
			await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

			// Çıkış sonrası login sayfasına yönlendirme yapıyoruz
			return RedirectToAction("Index", "Login");
		}
	}
}
