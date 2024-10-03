using Microsoft.AspNetCore.Mvc;
using SKL.Models;
using SKL.Services.IServices;

namespace SKL.Controllers
{
    public class ShiftController : Controller
    {
        private readonly IHubContext<SystemHub> _context;
        private readonly IUserServices _service;
        private readonly ISKLServices _Sklservice;


        public ShiftController(IHubContext<SystemHub> context, IUserServices service, ISKLServices sklservice)
        {
            _context = context;
            _service = service;
            _Sklservice = sklservice;
        }

        [Authorize(Roles = "Administrador")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult NewShiftPopUp()
        {

            ViewData["Title"] = "Nuevo Turno";
            ViewBag.Action = "Insert";
            return PartialView("_NewShiftPopUp", new Shift());
        }

        [HttpPost]
        public async Task<IActionResult> DeleteShiftPopUp(int idShift)
        {
            var model = await _Sklservice.GetSKLShiftAsync(idShift);
            return PartialView("_DeleteShiftPopUp", model);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateShiftPopUp(int idShift)
        {
            var model = await _Sklservice.GetSKLShiftAsync(idShift);

            ViewData["Title"] = "Actualizar Turno";
            ViewBag.Action = "Insert";
            return PartialView("_UpdateShiftPopUp", model);
        }


        public async Task<IActionResult> Insert(Shift data)
        {
            var (error, message) = (false, "");
            if (ModelState.IsValid)
            {
                _Sklservice.DataChangeEventHandler += RefreshShiftsGrid;
                (error, message) = await _Sklservice.InsertSKLShiftsAsync(data);
            }

            var jsonResult = Json(new
            {
                Status = error ? "error" : "success",
                Message = error ? message : "Turno creado exitosamente.",
                Icon = error ? "error" : "success"
            });

            return (HttpContext.Request.Headers["X-Requested-With"] == "XMLHttpRequest")
                ? jsonResult
                : RedirectToAction("Error");
        }

        public async Task<IActionResult> Update(Shift data)
        {
            var (error, message) = (false, "");
            if (ModelState.IsValid)
            {
                _Sklservice.DataChangeEventHandler += RefreshShiftsGrid;
                (error, message) = await _Sklservice.UpdateSKLShiftsAsync(data);
            }

            var jsonResult = Json(new
            {
                Status = error ? "error" : "success",
                Message = error ? message : "Turno actualizado exitosamente.",
                Icon = error ? "error" : "success"
            });

            return (HttpContext.Request.Headers["X-Requested-With"] == "XMLHttpRequest")
                ? jsonResult
                : RedirectToAction("Error");
        }


        public async Task<IActionResult> Delete(Shift model)
        {
            _Sklservice.DataChangeEventHandler += RefreshShiftsGrid;
            var (error, message) = await _Sklservice.DeleteSKLShiftsAsync(model.Id);
            //
            var jsonResult = Json(
                 new
                 {
                     Status = error ? "error" : "success",
                     Message = error ? message : "Shift deleted successfully.",
                     Icon = error ? "error" : "success"
                 });
            return (HttpContext.Request.Headers["X-Requested-With"] == "XMLHttpRequest")
                ? jsonResult
                : RedirectToAction("Error");
        }

        [HttpGet]
        public async Task<IActionResult> ShiftsJSON()
        => Ok(await _Sklservice.GetSKLShiftsAsync());

        private async void RefreshShiftsGrid(object? sender, EventArgs e)
            => await _context.Clients.All.SendAsync("RefreshShiftsGrid");
    }
}
