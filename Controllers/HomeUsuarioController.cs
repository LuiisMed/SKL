using Microsoft.AspNetCore.Mvc;

namespace SKL.Controllers
{
    public class HomeUsuarioController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
