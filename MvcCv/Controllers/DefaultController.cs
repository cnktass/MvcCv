using Microsoft.AspNetCore.Mvc;
using MvcCv.Data;

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
    }
}
