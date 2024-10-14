using Microsoft.AspNetCore.Mvc;
using SKL.Services.IServices;

namespace SKL.Controllers
{
    public class VisualManagementController : Controller
    {

        private readonly IHubContext<SystemHub> _context;
        private readonly IUserServices _service;
        private readonly ISKLServices _Sklservice;


        public VisualManagementController(IHubContext<SystemHub> context, IUserServices service, ISKLServices sklservice)
        {
            _context = context;
            _service = service;
            _Sklservice = sklservice;
        }



        public async Task<IActionResult> Index()
        {
            var fases = await _Sklservice.GetSKLFasesAsync();
            return View(fases);
        }

        public async Task<IActionResult> ChartDataJson()
        {
            var tasksCompleted = await _Sklservice.GetChartTasksCompletedAsync();
            return Ok(tasksCompleted);
        }


    }
}
