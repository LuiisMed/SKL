using Microsoft.AspNetCore.Mvc;
using SKL.Models;
using SKL.Services.IServices;

namespace SKL.Controllers
{
    public class PositionController : Controller
    {
        private readonly IHubContext<SystemHub> _context;
        private readonly IUserServices _service;
        private readonly ISKLServices _Sklservice;


        public PositionController(IHubContext<SystemHub> context, IUserServices service, ISKLServices sklservice)
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
        public IActionResult NewPositionPopUp()
        {

            ViewData["Title"] = "Nueva Posicion";
            ViewBag.Action = "Insert";
            return PartialView("_NewPositionPopUp", new Position());
        }

        [HttpPost]
        public async Task<IActionResult> DeletePosicionPopUp(int idPosition)
        {
            var model = await _Sklservice.GetSKLPositionAsync(idPosition);
            return PartialView("_DeletePosicionPopUp", model);
        }

        [HttpPost]
        public async Task<IActionResult> UpdatePosicionPopUp(int idPosition)
        {
            var model = await _Sklservice.GetSKLPositionAsync(idPosition);

            ViewData["Title"] = "Actualizar posicion";
            ViewBag.Action = "Insert";
            return PartialView("_UpdatePosicionPopUp", model);
        }


        public async Task<IActionResult> Insert(Position data)
        {
            var (error, message) = (false, "");
            if (ModelState.IsValid)
            {
                _Sklservice.DataChangeEventHandler += RefreshPosicionsGrid;
                (error, message) = await _Sklservice.InsertSKLPositionAsync(data);
            }

            var jsonResult = Json(new
            {
                Status = error ? "error" : "success",
                Message = error ? message : "Posicion creada exitosamente.",
                Icon = error ? "error" : "success"
            });

            return (HttpContext.Request.Headers["X-Requested-With"] == "XMLHttpRequest")
                ? jsonResult
                : RedirectToAction("Error");
        }

        public async Task<IActionResult> Update(Position data)
        {
            var (error, message) = (false, "");
            if (ModelState.IsValid)
            {
                _Sklservice.DataChangeEventHandler += RefreshPosicionsGrid;
                (error, message) = await _Sklservice.UpdateSKLPositionAsync(data);
            }

            var jsonResult = Json(new
            {
                Status = error ? "error" : "success",
                Message = error ? message : "Posicion actualizada exitosamente.",
                Icon = error ? "error" : "success"
            });

            return (HttpContext.Request.Headers["X-Requested-With"] == "XMLHttpRequest")
                ? jsonResult
                : RedirectToAction("Error");
        }


        public async Task<IActionResult> Delete(Position model)
        {
            _Sklservice.DataChangeEventHandler += RefreshPosicionsGrid;
            var (error, message) = await _Sklservice.DeleteSKLPositionAsync(model.Id);
            //
            var jsonResult = Json(
                 new
                 {
                     Status = error ? "error" : "success",
                     Message = error ? message : "Position deleted successfully.",
                     Icon = error ? "error" : "success"
                 });
            return (HttpContext.Request.Headers["X-Requested-With"] == "XMLHttpRequest")
                ? jsonResult
                : RedirectToAction("Error");
        }

        [HttpGet]
        public async Task<IActionResult> PosicionsJSON()
        => Ok(await _Sklservice.GetSKLPositionsAsync());

        private async void RefreshPosicionsGrid(object? sender, EventArgs e)
            => await _context.Clients.All.SendAsync("RefreshPosicionsGrid");
    }
}
