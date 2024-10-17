using Microsoft.AspNetCore.Mvc;
using SKL.Services.IServices;

namespace SKL.Controllers
{
    public class NotificationsController : Controller
    {
        private readonly IHubContext<SystemHub> _context;
        private readonly IUserServices _service;
        private readonly ISKLServices _Sklservice;


        public NotificationsController(IHubContext<SystemHub> context, IUserServices service, ISKLServices sklservice)
        {
            _context = context;
            _service = service;
            _Sklservice = sklservice;
        }


        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Notifications(int IdUser)
        {

            return View();
        }

    }
}
