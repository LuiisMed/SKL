using Microsoft.AspNetCore.Mvc;
using SKL.Models;
using SKL.Services.IServices;

namespace SKL.Controllers
{
    public class TaskUsController : Controller
    {

        private readonly IHubContext<SystemHub> _context;
        private readonly IUserServices _service;
        private readonly ISKLServices _Sklservice;


        public TaskUsController(IHubContext<SystemHub> context, IUserServices service, ISKLServices sklservice)
        {
            _context = context;
            _service = service;
            _Sklservice = sklservice;
        }

        public async Task<IActionResult> Index(int userfilter, int fasefilter)
        {

            var users = await _service.GetSKLUsuarios();
            var aspects = await _Sklservice.GetSKLAspectsAsync();
            var eval = await _Sklservice.GetSKLEvalsAsync();

            TaskPerEval model = new()
            {
                UserFilter = userfilter,
                FaseFilter = fasefilter,
                Usuarios = users,
                Aspectos = aspects,
                Evals = eval
            };

            return View(model);
        }

        private async void RefreshTasksGrid(object? sender, EventArgs e)
        => await _context.Clients.All.SendAsync("RefreshTasksGrid");

        public async Task<IActionResult> TaskJson(int idUser, int idFase)
        {
            var tasks = await _Sklservice.GetSKLTaskPerUserFase(idUser, idFase);
            return Ok(tasks);
        }




    }
}
