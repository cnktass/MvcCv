using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MvcCv.Models.Entity;
using MvcCv.Repositories;

namespace MvcCv.Controllers
{
	[Authorize]
	public class EgitimController : Controller
    {
        private readonly EgitimRepository _egitimRepository;
        public EgitimController(EgitimRepository egitimRepository)
        {
            _egitimRepository = egitimRepository;
        }
        public IActionResult Index()
        {
            var degerler = _egitimRepository.List();
            return View(degerler);
        }
        [HttpGet]
        public IActionResult EgitimEkle()
        {
            return View();  
        }
        [HttpPost]
        public IActionResult EgitimEkle(TblEgitimlerim item)
        {
            _egitimRepository.TAdd(item);
            return RedirectToAction("Index");   
        }
        [HttpGet]
        public IActionResult Duzenle(int id)
        {
            TblEgitimlerim t = _egitimRepository.TGet(id);
            return View(t);
        }
        [HttpPost]
        public IActionResult Duzenle(TblEgitimlerim item)
        {
            TblEgitimlerim t = _egitimRepository.TGet(item.ID);
            t.Baslik=item.Baslik;
            t.AltBaslik1 = item.AltBaslik1;
            t.AltBaslik2 = item.AltBaslik2;
            t.GNO=item.GNO;
            t.Tarih=item.Tarih;
            _egitimRepository.TUpdate(t);
            return RedirectToAction("Index");
        }


        public IActionResult Sil(int id)
        {
            TblEgitimlerim t = _egitimRepository.TGet(id);
            _egitimRepository.Delete(t);
            return RedirectToAction("Index");
        }
    }
}
