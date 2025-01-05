using Microsoft.AspNetCore.Mvc;
using MvcCv.Models.Entity;
using MvcCv.Repositories;

namespace MvcCv.Controllers
{
    public class HobiController : Controller
    {
        private readonly HobilerimRepository _hobilerimRepository;
        public HobiController(HobilerimRepository hobilerimRepository)
        {
            _hobilerimRepository = hobilerimRepository;
        }
        public IActionResult Index()
        {
            var degerler = _hobilerimRepository.List();
            return View(degerler);
        }
        [HttpGet]
        public IActionResult Ekle()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Ekle(TblHobilerim item)
        {
            _hobilerimRepository.TAdd(item);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Duzenle(int id)
        {
            TblHobilerim t = _hobilerimRepository.TGet(id);
            return View(t);
        }
        [HttpPost]
        public IActionResult Duzenle(TblHobilerim item)
        {
            TblHobilerim t = _hobilerimRepository.TGet(item.ID);
            t.Aciklama1= item.Aciklama1;
            t.Aciklama2 = item.Aciklama2;
            _hobilerimRepository.TUpdate(t);
            return RedirectToAction("Index");
        }
        public IActionResult Sil(int id)
        {
            TblHobilerim t= _hobilerimRepository.TGet(id);
            _hobilerimRepository.Delete(t);
            return RedirectToAction("Index"); 
        }
    }
}
