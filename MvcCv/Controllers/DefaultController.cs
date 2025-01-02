using Microsoft.AspNetCore.Mvc;

namespace MvcCv.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
