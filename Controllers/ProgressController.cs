using Microsoft.AspNetCore.Mvc;
using SKL.Models;
using SKL.Models.ViewModels;
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

        public async Task<IActionResult> Index(int fasefilter)
        {
            var fases = await _Sklservice.GetSKLFasesAsync();
            var percentagePerDept = await _Sklservice.GetPercentageTasksPerDept(fasefilter);

            TaskPerEval model = new()
            {
                FaseFilter = fasefilter,
                Fases = fases,
                PercentagePerDept = percentagePerDept 
            };

            return View(model);
        }

        public async Task<IActionResult> TasksEvaluated(int idFase, int idDepartment)
        {

            var fase = await _Sklservice.GetSKLFaseAsync(idFase);
            var departments = await _Sklservice.GetSKLDepartmentAsync(idDepartment);

            TaskPerEval model = new()
            {
                FaseFilter = idFase,
                DepartmentFilter = idDepartment,
                FaseName = fase.Name,
                DepartmentName = departments.Name
                
            };

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> TaskJson(int idFase, int idDepartment)
        {
            var tasks = await _Sklservice.GetSKLTaskCompletedPerDept(idFase, idDepartment);

            // Proyectar a un objeto anónimo con las fechas formateadas
            var fasesFormateadas = tasks.Select(f => new
            {
                f.IdTask,
                f.IdUserT,
                f.Name,
                f.IdFaseT,
                f.FaseName,
                f.Accion,
                f.IdAspect,
                f.AspectName,
                f.IsCompleted,
                f.Evidences,
                Start = f.Start.ToString("yyyy-MM-dd"),
                End = f.End.ToString("yyyy-MM-dd"),
                Month = f.Start.ToString("MMMM")
            });

            // Devolver el resultado como JSON
            return Json(fasesFormateadas);
        }

        private async void RefreshTasksGrid(object? sender, EventArgs e)
        => await _context.Clients.All.SendAsync("RefreshTasksGrid");

        public async Task<IActionResult> ChartDataJson(int idFase, int idDepartment)
        {
            var tasksCompleted = await _Sklservice.GetChartTasksCompletedPerDeptAsync(idFase, idDepartment);
            return Ok(tasksCompleted);
        }


    }
}
