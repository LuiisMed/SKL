using Microsoft.AspNetCore.Mvc;

namespace SKL.Controllers
{
    public class AspectController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
