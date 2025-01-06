using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MvcCv.Models.Entity;
using MvcCv.Repositories;

namespace MvcCv.Controllers
{
	[Authorize]
	public class HakkimdaController : Controller
    {
        private readonly HakkimdaRepository _hakkimdaRepository;
        public HakkimdaController(HakkimdaRepository hakkimdaRepository)
        {
            _hakkimdaRepository = hakkimdaRepository;
        }
        public IActionResult Index()
        {
            var degerler = _hakkimdaRepository.List();
            return View(degerler);
        }
        [HttpGet]
        public IActionResult Ekle()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Ekle(TblHakkimda item)
        {
            _hakkimdaRepository.TAdd(item);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Duzenle(int id)
        {
            TblHakkimda t = _hakkimdaRepository.TGet(id);
            return View(t);
        }
        [HttpPost]
        public IActionResult Duzenle(TblHakkimda item)
        {
            TblHakkimda t = _hakkimdaRepository.TGet(item.ID);
            t.Ad = item.Ad;
            t.Soyad = item.Soyad;
            t.Adres = item.Adres;
            t.Telefon = item.Telefon;
            t.Aciklama = item.Aciklama;
            t.Resim=item.Resim;
            t.Mail = item.Mail;

            _hakkimdaRepository.TUpdate(t);
            return RedirectToAction("Index");
        }
        public IActionResult Sil(int id)
        {
            TblHakkimda t = _hakkimdaRepository.TGet(id);
            _hakkimdaRepository.Delete(t);
            return RedirectToAction("Index");
        }
    }
}
