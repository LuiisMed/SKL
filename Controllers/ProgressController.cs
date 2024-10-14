using Microsoft.AspNetCore.Mvc;
using SKL.Services.IServices;

namespace SKL.Controllers
{
    public class ProgressController : Controller
    {
        private readonly IHubContext<SystemHub> _context;
        private readonly IUserServices _service;
        private readonly ISKLServices _Sklservice;

        public ProgressController(IHubContext<SystemHub> context, IUserServices service, ISKLServices sklservice)
        {
            _context = context;
            _service = service;
            _Sklservice = sklservice;
        }

        public async Task<IActionResult> Index()
        {
            return View();
        }


    }
}
