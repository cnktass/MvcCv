using Microsoft.AspNetCore.Mvc;
using MvcCv.Models.Entity;
using MvcCv.Repositories;

namespace MvcCv.Controllers
{
    public class YetenekController : Controller
    {
        private readonly YetenekRepository  _yetenekRepository;
        public YetenekController(YetenekRepository yetenekRepository)
        {
            _yetenekRepository = yetenekRepository;
        }
        public IActionResult Index()
        {
            var degerler = _yetenekRepository.List();
            return View(degerler);
        }
        [HttpGet]
        public IActionResult YetenekEkle()
        {
            return View();
        }
        [HttpPost]
        public IActionResult YetenekEkle(TblYeteneklerim item)
        {
            _yetenekRepository.TAdd(item);
            return RedirectToAction("Index");

        }

        public IActionResult Sil(int id)
        {
           TblYeteneklerim t = _yetenekRepository.TGet(id);
            _yetenekRepository.Delete(t);
            return RedirectToAction("Index");
        }
    }
}
