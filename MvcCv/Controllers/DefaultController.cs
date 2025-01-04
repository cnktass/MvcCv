using Microsoft.AspNetCore.Mvc;
using MvcCv.Data;
using MvcCv.Models.Entity;

namespace MvcCv.Controllers
{
    public class DefaultController : Controller
    {
        private readonly ApplicationDbContext _context;
        public DefaultController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var degerler = _context.Hakkimda.ToList();
            return View(degerler);
        }
        public PartialViewResult Deneyim()
        {
            var deneyimler = _context.Deneyimlerim.ToList();
            return PartialView("Deneyim", deneyimler);
        }
        public PartialViewResult Egitimlerim()
        {
            var egitimler = _context.Egitimlerim.ToList();
            return PartialView("Egitimlerim", egitimler);
        }
        public PartialViewResult Yeteneklerim()
        {
            var yetenekler = _context.Yeteneklerim.ToList();
            return PartialView("Yeteneklerim", yetenekler);
        }
        public PartialViewResult Hobilerim()
        {
            var hobiler = _context.Hobilerim.ToList();
            return PartialView("Hobilerim", hobiler);
        }
        public PartialViewResult Sertifikalarim()
        {
            var sertifikalar = _context.Hobilerim.ToList();
            return PartialView("Sertifikalarim", sertifikalar);
        }

        [HttpGet]
        public PartialViewResult Iletisim()
        {
            var model = new TblIletisim(); 
            return PartialView("Iletisim", model);
        }

        [HttpPost]
        public IActionResult Iletisim(TblIletisim iletisim)
        {
            if (ModelState.IsValid)
            {
                iletisim.Tarih = DateTime.Parse(DateTime.Now.ToShortDateString());
                _context.Iletisim.Add(iletisim);
                _context.SaveChanges();
                TempData["Message"] = "Mesajınız başarıyla gönderildi!";
            }
            else
            {
                TempData["Message"] = "Lütfen tüm alanları doğru doldurun.";
            }

            return RedirectToAction("Index", "Default");
        }




    }
}
