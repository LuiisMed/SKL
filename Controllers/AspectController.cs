using Microsoft.AspNetCore.Mvc;
using SKL.Services.IServices;
using SKL.Models;


namespace SKL.Controllers
{
    public class AspectController : Controller
    {
        private readonly IHubContext<SystemHub> _context;
        private readonly IUserServices _service;
        private readonly ISKLServices _Sklservice;


        public AspectController(IHubContext<SystemHub> context, IUserServices service, ISKLServices sklservice)
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
        public IActionResult NewAspectPopUp()
        {

            ViewData["Title"] = "Nuevo Aspecto";
            ViewBag.Action = "Insert";
            return PartialView("_NewAspectPopUp", new Aspect());
        }

        [HttpPost]
        public async Task<IActionResult> DeleteAspectPopUp(int idAspect)
        {
            var model = await _Sklservice.GetSKLAspectAsync(idAspect);
            return PartialView("_DeleteAspectPopUp", model);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateAspectPopUp(int idAspect)
        {
            var model = await _Sklservice.GetSKLAspectAsync(idAspect);

            ViewData["Title"] = "Actualizar Aspecto";
            ViewBag.Action = "Insert";
            return PartialView("_UpdateAspectPopUp", model);
        }


        public async Task<IActionResult> Insert(Aspect data)
        {
            var (error, message) = (false, "");
            if (ModelState.IsValid)
            {
                _Sklservice.DataChangeEventHandler += RefreshAspectsGrid;
                (error, message) = await _Sklservice.InsertSKLAspectAsync(data);
            }

            var jsonResult = Json(new
            {
                Status = error ? "error" : "success",
                Message = error ? message : "Aspecto creado exitosamente.",
                Icon = error ? "error" : "success"
            });

            return (HttpContext.Request.Headers["X-Requested-With"] == "XMLHttpRequest")
                ? jsonResult
                : RedirectToAction("Error");
        }

        public async Task<IActionResult> Update(Aspect data)
        {
            var (error, message) = (false, "");
            if (ModelState.IsValid)
            {
                _Sklservice.DataChangeEventHandler += RefreshAspectsGrid;
                (error, message) = await _Sklservice.UpdateSKLAspectAsync(data);
            }

            var jsonResult = Json(new
            {
                Status = error ? "error" : "success",
                Message = error ? message : "Aspecto actualizado exitosamente.",
                Icon = error ? "error" : "success"
            });

            return (HttpContext.Request.Headers["X-Requested-With"] == "XMLHttpRequest")
                ? jsonResult
                : RedirectToAction("Error");
        }


        public async Task<IActionResult> Delete(Aspect model)
        {
            _Sklservice.DataChangeEventHandler += RefreshAspectsGrid;
            var (error, message) = await _Sklservice.DeleteSKLAspectAsync(model.Id);
            //
            var jsonResult = Json(
                 new
                 {
                     Status = error ? "error" : "success",
                     Message = error ? message : "Aspect deleted successfully.",
                     Icon = error ? "error" : "success"
                 });
            return (HttpContext.Request.Headers["X-Requested-With"] == "XMLHttpRequest")
                ? jsonResult
                : RedirectToAction("Error");
        }

        [HttpGet]
        public async Task<IActionResult> AspectsJSON()
        => Ok(await _Sklservice.GetSKLAspectsAsync());

        private async void RefreshAspectsGrid(object? sender, EventArgs e)
            => await _context.Clients.All.SendAsync("RefreshAspectsGrid");
    }
}
