using Microsoft.AspNetCore.Mvc;
using MvcCv.Models.Entity;
using MvcCv.Repositories;

namespace MvcCv.Controllers
{
    public class SertifikaController : Controller
    {
        private readonly SertifikaRepository _sertifikaRepository;
        public SertifikaController(SertifikaRepository sertifikaRepository)
        {
            _sertifikaRepository = sertifikaRepository;
        }
        public IActionResult Index()
        {
          var degerler = _sertifikaRepository.List();

            return View(degerler);
        }
        [HttpGet]
        public IActionResult Ekle()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Ekle(TblSertifikalarim item)
        {
            _sertifikaRepository.TAdd(item);
            return RedirectToAction("Index");
        }
        public IActionResult Sil(int id)
        {
            TblSertifikalarim t = _sertifikaRepository.TGet(id);
           _sertifikaRepository.Delete(t);
            return RedirectToAction("Index");
        }

    }
}
