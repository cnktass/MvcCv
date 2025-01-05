using Microsoft.AspNetCore.Mvc;
using MvcCv.Data;
using MvcCv.Models.Entity;

namespace MvcCv.Controllers
{
    public class LoginController : Controller
    {
        private readonly ApplicationDbContext _context;
        public LoginController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
		public IActionResult Index(TblAdmin p )
		{
            var bilgi = _context.Admins.FirstOrDefault(x=> x.KullaniciAdi==p.KullaniciAdi && x.Sifre==p.Sifre);
            if(bilgi != null)
            {
				HttpContext.Session.SetString("KullaniciAdi", bilgi.KullaniciAdi);
				HttpContext.Session.SetInt32("AdminID", bilgi.ID); // Opsiyonel: Admin ID tutabilirsiniz
				return RedirectToAction("Index", "Hakkimda");
			}
			ViewBag.Hata = "Kullanıcı adı veya şifre hatalı!";
			return View();
		}
	}
}
