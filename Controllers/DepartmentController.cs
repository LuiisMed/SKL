using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol;
using SKL.Models;
using SKL.Services;
using SKL.Services.IServices;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SKL.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IHubContext<SystemHub> _context;
        private readonly IUserServices _service;
        private readonly ISKLServices _Sklservice;


        public DepartmentController(IHubContext<SystemHub> context, IUserServices service, ISKLServices sklservice)
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
        public IActionResult NewDepartmentPopUp()
        {

            ViewData["Title"] = "Nuevo Departamento";
            ViewBag.Action = "Insert";
            return PartialView("_NewDepartmentPopUp", new Department());
        }

        [HttpPost]
        public async Task<IActionResult> DeleteDepartamentoPopUp(int idDepartment)
        {
            var model = await _Sklservice.GetSKLDepartmentAsync(idDepartment);
            return PartialView("_DeleteDepartmentPopUp", model);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateDepartmentPopUp(int idDepartment)
        {
            var model = await _Sklservice.GetSKLDepartmentAsync(idDepartment);

            ViewData["Title"] = "Actualizar Departamento";
            ViewBag.Action = "Insert";
            return PartialView("_UpdateDepartmentPopUp", model);
        }


        public async Task<IActionResult> Insert(Department data)
        {
            var (error, message) = (false, "");
            if (ModelState.IsValid)
            {
                _Sklservice.DataChangeEventHandler += RefreshDepartmentGrid;
                (error, message) = await _Sklservice.InsertSKLDepartmentsAsync(data);
            }

            var jsonResult = Json(new
            {
                Status = error ? "error" : "success",
                Message = error ? message : "Departamento creado exitosamente.",
                Icon = error ? "error" : "success"
            });

            return (HttpContext.Request.Headers["X-Requested-With"] == "XMLHttpRequest")
                ? jsonResult
                : RedirectToAction("Error");
        }

        public async Task<IActionResult> Update(Department data)
        {
            var (error, message) = (false, "");
            if (ModelState.IsValid)
            {
                _Sklservice.DataChangeEventHandler += RefreshDepartmentGrid;
                (error, message) = await _Sklservice.UpdateSKLDepartmentsAsync(data);
            }

            var jsonResult = Json(new
            {
                Status = error ? "error" : "success",
                Message = error ? message : "Departamento actualizado exitosamente.",
                Icon = error ? "error" : "success"
            });

            return (HttpContext.Request.Headers["X-Requested-With"] == "XMLHttpRequest")
                ? jsonResult
                : RedirectToAction("Error");
        }


        public async Task<IActionResult> Delete(Department model)
        {
            _Sklservice.DataChangeEventHandler += RefreshDepartmentGrid;
            var (error, message) = await _Sklservice.DeleteSKLDepartmentsAsync(model.Id);
            //
            var jsonResult = Json(
                 new
                 {
                     Status = error ? "error" : "success",
                     Message = error ? message : "User deleted successfully.",
                     Icon = error ? "error" : "success"
                 });
            return (HttpContext.Request.Headers["X-Requested-With"] == "XMLHttpRequest")
                ? jsonResult
                : RedirectToAction("Error");
        }

        [HttpGet]
        public async Task<IActionResult> DepartmentsJSON()
        => Ok(await _Sklservice.GetSKLDepartmentsAsync());

        private async void RefreshDepartmentGrid(object? sender, EventArgs e)
            => await _context.Clients.All.SendAsync("RefreshDepartmentGrid");

    }
}
