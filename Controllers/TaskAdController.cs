using Microsoft.AspNetCore.Mvc;
using SKL.Models;
using SKL.Services.IServices;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SKL.Controllers
{
    public class TaskAdController : Controller
    {
        private readonly IHubContext<SystemHub> _context;
        private readonly IUserServices _service;
        private readonly ISKLServices _Sklservice;


        public TaskAdController(IHubContext<SystemHub> context, IUserServices service, ISKLServices sklservice)
        {
            _context = context;
            _service = service;
            _Sklservice = sklservice;
        }

        public async Task<IActionResult> Index()
        {
            var users = await _service.GetSKLUsuarios();
            var aspects = await _Sklservice.GetSKLAspectsAsync();



            ViewBag.Usuarios = users;
            ViewBag.Aspectos = aspects;

            return View();
        }

        public async Task<IActionResult> Insert(Tasks taskData, Eval evalData)
        {
            var (error, message) = (false, "");
            try
            {
                if (ModelState.IsValid)
                {
                    // Insertar en la tabla Tasks
                    await _Sklservice.InsertSKLTaskAsync(taskData); // Guarda cambios en la tabla Tasks

                    // Insertar en la tabla Eval
                    await _Sklservice.InsertSKLEvalAsync(evalData); // Guarda cambios en la tabla Tasks

                    _Sklservice.DataChangeEventHandler += RefreshTasksGrid;

                }  
            }
            catch (Exception ex)
            {
                // Manejo de errores
                message = ex.Message;
                error = true;
            }

            var jsonResult = Json(new
            {
                Status = error ? "error" : "success",
                Message = error ? message : "Datos creados exitosamente.",
                Icon = error ? "error" : "success"
            });

            return (HttpContext.Request.Headers["X-Requested-With"] == "XMLHttpRequest")
                ? jsonResult
                : RedirectToAction("Error");
        }


        private async void RefreshTasksGrid(object? sender, EventArgs e)
        => await _context.Clients.All.SendAsync("RefreshTasksGrid");
    }
}
