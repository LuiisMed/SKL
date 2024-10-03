using Microsoft.AspNetCore.Mvc;
using SKL.Services.IServices;

namespace SKL.Controllers
{
    public class HomeUsuarioController : Controller
    {

        private readonly ILogger<HomeController> _logger;
        private readonly ISKLServices _Sklservice;


        public HomeUsuarioController(ILogger<HomeController> logger, ISKLServices sklservice)
        {
            _logger = logger;
            _Sklservice = sklservice;
        }

        public async Task<IActionResult> Index()
        {
            var fases = await _Sklservice.GetSKLFasesAsync();
            return View(fases);
        }
    }
}
