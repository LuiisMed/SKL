using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol;
using SKL.Models;
using SKL.Services;
using SKL.Services.IServices;
using static System.Runtime.InteropServices.JavaScript.JSType;

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

        //public async Task<IActionResult> NewUsuarioPopUp()
        //{
        //    ViewData["Title"] = $"New Usuario";
        //    ViewBag.Action = "Insert";

        //    // Obtener la lista de departamentos del servicio
        //    var departments = await _service.GetSKLDepartmentsAsync();

        //    // Crear un modelo que incluya tanto el usuario como la lista de departamentos
        //    var viewModel = new NewUsuarioViewModel
        //    {
        //        Usuario = new Usuario(),
        //        Departments = departments
        //    };

        //    return PartialView("_NewUsuarioPopUp", viewModel);
        //}

        [HttpPost]
        public async Task<IActionResult> NewUsuarioPopUp()
        {
            var departamentos = await _service.GetSKLDepartmentsAsync(); // Método que devuelve una lista con {Id, Nombre}
            ViewBag.Departamentos = departamentos;

            ViewData["Title"] = "Nuevo Usuario";
            ViewBag.Action = "Insert";
            return PartialView("_NewUsuarioPopUp", new Usuario());
        }


        [HttpPost]
        public async Task<IActionResult> Insert(Usuario data)
        {
            var (error, message) = (false, "");
            if (ModelState.IsValid)
            {
                _service.DataChangeEventHandler += RefreshUserGrid;
                (error, message) = await _service.InsertSKLUsuariosAsync(data);
            }

            var jsonResult = Json(new
            {
                Status = error ? "error" : "success",
                Message = error ? message : "Usuario creado exitosamente.",
                Icon = error ? "error" : "success"
            });

            return (HttpContext.Request.Headers["X-Requested-With"] == "XMLHttpRequest")
                ? jsonResult
                : RedirectToAction("Error");
        }


        //public async Task<IActionResult> UpdateuUsuarioPopUp(int idusr)
        //{
        //    var model = await _service.GetSKLUsuarioAsync(idusr);
        //    return PartialView("UsuariosPopUp", model);
        //}

        //public async Task<IActionResult> DeleteUsuarioPopUp(int idusr)
        //{
        //    var model = await _service.GetSKLUsuarioAsync(idusr);
        //    return PartialView(model);
        //}

        //public async Task<IActionResult> DeleteSKLUsuarios(Usuario model)
        //{
        //    _service.DataChangeEventHandler += RefreshUserGrid;
        //    var (error, message) = await _service.DeleteSKLUsuariosAsync(model.IdUser);
        //    //
        //    var jsonResult = Json(
        //         new
        //         {
        //             Status = error ? "error" : "success",
        //             Message = error ? message : "Category deleted successfully.",
        //             Icon = error ? "error" : "success"
        //         });
        //    return (HttpContext.Request.Headers["X-Requested-With"] == "XMLHttpRequest")
        //        ? jsonResult
        //        : RedirectToAction("Error");
        //}



        [HttpGet]
        public async Task<IActionResult> UsuariosJSON()
            => Ok(await _service.GetSKLUsuarios());

        private async void RefreshUserGrid(object? sender, EventArgs e)
            => await _context.Clients.All.SendAsync("RefreshUserGrid");



    }
}
