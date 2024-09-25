using Microsoft.AspNetCore.Mvc;
using SKL.Models;
using SKL.Services.IServices;

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

        public async Task<IActionResult> Insert(Task taskData, E evalData)
        {
            var (error, message) = (false, "");
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    if (ModelState.IsValid)
                    {
                        // Insertar en la tabla Tasks
                        _context.Tasks.Add(taskData);
                        await _context.SaveChangesAsync(); // Guarda cambios en la tabla Tasks

                        // Insertar en la tabla Eval
                        _context.Eval.Add(evalData);
                        await _context.SaveChangesAsync(); // Guarda cambios en la tabla Eval

                        // Confirma la transacción
                        await transaction.CommitAsync();
                    }
                }
                catch (Exception ex)
                {
                    // Si ocurre un error, se revierte la transacción
                    await transaction.RollbackAsync();
                    message = ex.Message;
                    error = true;
                }
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


    }
}
