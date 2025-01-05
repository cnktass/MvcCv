using Microsoft.AspNetCore.Mvc;
using MvcCv.Models.Entity;
using MvcCv.Repositories;

namespace MvcCv.Controllers
{
    public class IletisimController : Controller
    {
        private readonly IletisimRepository _iletisimRepository;
        public IletisimController(IletisimRepository iletisimrepository)
        {
            _iletisimRepository = iletisimrepository;
        }
        public IActionResult Index()
        {
            var degerler = _iletisimRepository.List();
            return View(degerler);
        }
        public IActionResult Sil(int id)
        {
            TblIletisim t = _iletisimRepository.TGet(id);
            _iletisimRepository.Delete(t);
            return RedirectToAction("Index");
        }
    }
}
