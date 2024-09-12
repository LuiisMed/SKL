using Microsoft.AspNetCore.Mvc;
using SKL.Models;
using SKL.Services.IServices;

namespace SKL.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly IHubContext<SystemHub> _context;
        private readonly IUserServices _service;

        public UsuarioController(IHubContext<SystemHub> context, IUserServices service)
        {
            _context = context;
            _service = service;
        }


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult NewCategoryPopUp() => PartialView("CategoryPopUp", new Usuario() { Name = "" });

        public async Task<IActionResult> UpdateCategoryPopUp(int id)
        {
            var model = await _service.GetSKLUsuarios(id);
            return PartialView("CategoryPopUp", model);
        }

        public async Task<IActionResult> DeleteCategoryPopUp(int id)
        {
            var model = await _service.GetSKLUsuarios(id);
            return PartialView(model);
        }

        public async Task<IActionResult> SaveSKLUsuarios(Usuario model)
        {
            var (error, message) = (false, "");
            if (ModelState.IsValid)
            {
                _service.DataChangeEventHandler += RefreshUserGrid;
                (error, message) = await _service.SaveSKLUsuariosAsync(model);
            }
            //
            var jsonResult = Json(
                 new
                 {
                     Status = error ? "error" : "success",
                     Message = error ? message : "Category saved successfully.",
                     Icon = error ? "error" : "success"
                 });
            return (HttpContext.Request.Headers["X-Requested-With"] == "XMLHttpRequest")
                ? jsonResult
                : RedirectToAction("Error");
        }

        public async Task<IActionResult> DeleteSKLUsuarios(Usuario model)
        {
            _service.DataChangeEventHandler += RefreshUserGrid;
            var (error, message) = await _service.DeleteSKLUsuariosAsync(model.IdUser);
            //
            var jsonResult = Json(
                 new
                 {
                     Status = error ? "error" : "success",
                     Message = error ? message : "Category deleted successfully.",
                     Icon = error ? "error" : "success"
                 });
            return (HttpContext.Request.Headers["X-Requested-With"] == "XMLHttpRequest")
                ? jsonResult
                : RedirectToAction("Error");
        }



        [HttpGet]
        public async Task<IActionResult> UsuariosJSON()
            => Ok(await _service.GetSKLUsuarios());

        private async void RefreshUserGrid(object? sender, EventArgs e)
            => await _context.Clients.All.SendAsync("RefreshUserGrid");



    }
}
