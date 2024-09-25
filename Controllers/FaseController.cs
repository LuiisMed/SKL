using Microsoft.AspNetCore.Mvc;
using SKL.Models;
using SKL.Services.IServices;

namespace SKL.Controllers
{
    public class FaseController : Controller
    {

        private readonly IHubContext<SystemHub> _context;
        private readonly IUserServices _service;
        private readonly ISKLServices _Sklservice;


        public FaseController(IHubContext<SystemHub> context, IUserServices service, ISKLServices sklservice)
        {
            _context = context;
            _service = service;
            _Sklservice = sklservice;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult NewFasePopUp()
        {

            ViewData["Title"] = "Nueva Fase";
            ViewBag.Action = "Insert";
            return PartialView("_NewFasePopUp", new Fase());
        }

        [HttpPost]
        public async Task<IActionResult> DeleteFasePopUp(int idFase)
        {
            var model = await _Sklservice.GetSKLFaseAsync(idFase);
            return PartialView("_DeleteFasePopUp", model);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateFasePopUp(int idFase)
        {
            var model = await _Sklservice.GetSKLFaseAsync(idFase);

            ViewData["Title"] = "Actualizar Fase";
            ViewBag.Action = "Insert";
            return PartialView("_UpdateFasePopUp", model);
        }


        public async Task<IActionResult> Insert(Fase data)
        {
            var (error, message) = (false, "");
            if (ModelState.IsValid)
            {
                _Sklservice.DataChangeEventHandler += RefreshFasesGrid;
                (error, message) = await _Sklservice.InsertSKLFaseAsync(data);
            }

            var jsonResult = Json(new
            {
                Status = error ? "error" : "success",
                Message = error ? message : "Fase creada exitosamente.",
                Icon = error ? "error" : "success"
            });

            return (HttpContext.Request.Headers["X-Requested-With"] == "XMLHttpRequest")
                ? jsonResult
                : RedirectToAction("Error");
        }

        public async Task<IActionResult> Update(Fase data)
        {
            var (error, message) = (false, "");
            if (ModelState.IsValid)
            {
                _Sklservice.DataChangeEventHandler += RefreshFasesGrid;
                (error, message) = await _Sklservice.UpdateSKLFaseAsync(data);
            }

            var jsonResult = Json(new
            {
                Status = error ? "error" : "success",
                Message = error ? message : "Fase actualizada exitosamente.",
                Icon = error ? "error" : "success"
            });

            return (HttpContext.Request.Headers["X-Requested-With"] == "XMLHttpRequest")
                ? jsonResult
                : RedirectToAction("Error");
        }


        public async Task<IActionResult> Delete(Fase model)
        {
            _Sklservice.DataChangeEventHandler += RefreshFasesGrid;
            var (error, message) = await _Sklservice.DeleteSKLFaseAsync(model.Id);
            //
            var jsonResult = Json(
                 new
                 {
                     Status = error ? "error" : "success",
                     Message = error ? message : "Fase deleted successfully.",
                     Icon = error ? "error" : "success"
                 });
            return (HttpContext.Request.Headers["X-Requested-With"] == "XMLHttpRequest")
                ? jsonResult
                : RedirectToAction("Error");
        }

        //[HttpGet]
        //public async Task<IActionResult> FasesJSON()
        //=> Ok(await _Sklservice.GetSKLFasesAsync());

        [HttpGet]
        public async Task<IActionResult> FasesJSON()
        {
            var fases = await _Sklservice.GetSKLFasesAsync();

            // Proyectar a un objeto anónimo con las fechas formateadas
            var fasesFormateadas = fases.Select(f => new
            {
                f.Id,
                f.Name,
                f.CurrentDate,
                f.IsActive,
                Start = f.Start.ToString("yyyy-MM-dd"), 
                End = f.End.ToString("yyyy-MM-dd")      
            });

            // Devolver el resultado como JSON
            return Json(fasesFormateadas);
        }


        private async void RefreshFasesGrid(object? sender, EventArgs e)
            => await _context.Clients.All.SendAsync("RefreshFasesGrid");

    }
}
