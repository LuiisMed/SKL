using Microsoft.AspNetCore.Mvc;
using SKL.Models;
using SKL.Services.IServices;

namespace SKL.Controllers
{
    public class UsertypeController : Controller
    {
        private readonly IHubContext<SystemHub> _context;
        private readonly IUserServices _service;
        private readonly ISKLServices _Sklservice;


        public UsertypeController(IHubContext<SystemHub> context, IUserServices service, ISKLServices sklservice)
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
        public IActionResult NewUsertypePopUp()
        {

            ViewData["Title"] = "Nuevo Tipo de Usuario";
            ViewBag.Action = "Insert";
            return PartialView("_NewUsertypePopUp", new UserType());
        }

        [HttpPost]
        public async Task<IActionResult> DeleteUsertypePopUp(int idUsertype)
        {
            var model = await _Sklservice.GetSKLUsertypeAsync(idUsertype);
            return PartialView("_DeleteUsertypePopUp", model);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateUsertypePopUp(int idUsertype)
        {
            var model = await _Sklservice.GetSKLUsertypeAsync(idUsertype);

            ViewData["Title"] = "Actualizar Tipo de Usuario";
            ViewBag.Action = "Insert";
            return PartialView("_UpdateUsertypePopUp", model);
        }


        public async Task<IActionResult> Insert(UserType data)
        {
            var (error, message) = (false, "");
            if (ModelState.IsValid)
            {
                _Sklservice.DataChangeEventHandler += RefreshUsertypeGrid;
                (error, message) = await _Sklservice.InsertSKLUsertypesAsync(data);
            }

            var jsonResult = Json(new
            {
                Status = error ? "error" : "success",
                Message = error ? message : "Tipo de Usuario creado exitosamente.",
                Icon = error ? "error" : "success"
            });

            return (HttpContext.Request.Headers["X-Requested-With"] == "XMLHttpRequest")
                ? jsonResult
                : RedirectToAction("Error");
        }

        public async Task<IActionResult> Update(UserType data)
        {
            var (error, message) = (false, "");
            if (ModelState.IsValid)
            {
                _Sklservice.DataChangeEventHandler += RefreshUsertypeGrid;
                (error, message) = await _Sklservice.UpdateSKLUsertypesAsync(data);
            }

            var jsonResult = Json(new
            {
                Status = error ? "error" : "success",
                Message = error ? message : "Tipo de Usuario actualizado exitosamente.",
                Icon = error ? "error" : "success"
            });

            return (HttpContext.Request.Headers["X-Requested-With"] == "XMLHttpRequest")
                ? jsonResult
                : RedirectToAction("Error");
        }


        public async Task<IActionResult> Delete(UserType model)
        {
            _Sklservice.DataChangeEventHandler += RefreshUsertypeGrid;
            var (error, message) = await _Sklservice.DeleteSKLUsertypesAsync(model.Id);
            //
            var jsonResult = Json(
                 new
                 {
                     Status = error ? "error" : "success",
                     Message = error ? message : "Tipo de Usuario deleted successfully.",
                     Icon = error ? "error" : "success"
                 });
            return (HttpContext.Request.Headers["X-Requested-With"] == "XMLHttpRequest")
                ? jsonResult
                : RedirectToAction("Error");
        }

        [HttpGet]
        public async Task<IActionResult> UsertypesJSON()
        => Ok(await _Sklservice.GetSKLUserTypesAsync());

        private async void RefreshUsertypeGrid(object? sender, EventArgs e)
            => await _context.Clients.All.SendAsync("RefreshUsertypeGrid");
    }
}
