using Microsoft.AspNetCore.Mvc;
using MvcCv.Models.Entity;
using MvcCv.Repositories;

namespace MvcCv.Controllers
{
    public class DeneyimController : Controller
    {


        private readonly DeneyimRepository _deneyimRepository;
        public DeneyimController(DeneyimRepository deneyimRepository)
        {
            _deneyimRepository = deneyimRepository;
        }
        public IActionResult Index()
        {
            var degerler = _deneyimRepository.List();
            return View(degerler);
        }
        [HttpGet]
        public IActionResult DeneyimEkle()
        {
            return View();
        }
        [HttpPost]
        public IActionResult DeneyimEkle(TblDeneyimlerim item )
        {
            _deneyimRepository.TAdd(item);
            return RedirectToAction("Index");   
        }

        public IActionResult Sil(int id)
        {
            TblDeneyimlerim t = _deneyimRepository.TGet(id);

            if (t == null)
            {
                return NotFound("Belirtilen ID'ye ait deneyim bulunamadı.");
            }

            _deneyimRepository.Delete(t);
            return RedirectToAction("Index");
        }


    }
}
