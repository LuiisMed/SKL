using Microsoft.AspNetCore.Mvc;
using SKL.Models;
using SKL.Models.ViewModels;
using SKL.Services.IServices;
using static Microsoft.CodeAnalysis.IOperation;
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

        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> Index(int userfilter, int fasefilter)
            {

            var users = await _service.GetSKLUsuarios();
            var aspects = await _Sklservice.GetSKLAspectsAsync();
            var eval = await _Sklservice.GetSKLEvalsAsync();

            TaskPerEval model = new()
            {
                UserFilter = userfilter,
                FaseFilter = fasefilter,
                Usuarios = users,
                Aspectos = aspects,
                Evals = eval
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteTaskPopUp(int idTask)
        {
            var model = await _Sklservice.GetSKLTask(idTask);
            return PartialView("DeleteTaskPopUp", model);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateTaskPopUp(int idTask)
        {
            var model = await _Sklservice.GetSKLTask(idTask);

            var aspects = await _Sklservice.GetSKLAspectsAsync();

            ViewData["Title"] = "Actualizar Accion";

            ViewBag.Aspectos = aspects;
            ViewBag.Action = "Insert";
            return PartialView("UpdateTaskPopUp", model);
        }


        //Los ID Del Modelo Principal y del ViewModel Tienen que ser los mismos
        //RECUERDA RESULTS NO PUEDE SER NULL
        //public async Task<IActionResult> Insert()
        //{
        //    var (error, message) = (false, "");
        //    try
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            // Insertar en la tabla Tasks
        //            await _Sklservice.InsertSKLTaskAsync(taskData); // Guarda cambios en la tabla Tasks

        //            // Insertar en la tabla Eval
        //            await _Sklservice.InsertSKLEvalAsync(evalData); // Guarda cambios en la tabla Tasks



        //        }  
        //    }
        //    catch (Exception ex)
        //    {
        //        // Manejo de errores
        //        message = ex.Message;
        //        error = true;
        //    }

        //    var jsonResult = Json(new
        //    {
        //        Status = error ? "error" : "success",
        //        Message = error ? message : "Datos creados exitosamente.",
        //        Icon = error ? "error" : "success"
        //    });

        //    return (HttpContext.Request.Headers["X-Requested-With"] == "XMLHttpRequest")
        //        ? jsonResult
        //        : RedirectToAction("Error");
        //}

        public async Task<IActionResult> Insert(Tasks taskData, Eval evalData)
        {
            var (error, message) = (false, "");
            //ACUERDATE LUIS DEL FUTURO DE CAMBIAR AQUI PARA QUE SI EL ARCHIVO DEL LA EVALUACION ES NULL NO ACEPTE LA INSERCION DE DATOS
            var existingEval = await _Sklservice.GetSKLEvalPerUserAsync(evalData.IdUserE, evalData.IdFaseE);

            if (taskData.IdTask == 0)
            {
                _Sklservice.DataChangeEventHandler += RefreshTasksGrid;
                (error, message) = await _Sklservice.InsertSKLTaskAsync(taskData);
            }

            if (existingEval == null || !existingEval.Any())
            {
                await _Sklservice.InsertSKLEvalAsync(evalData);
            }

            var jsonResult = Json(new
            {
                Status = error ? "error" : "success",
                Message = error ? message : "Accion creada exitosamente.",
                Icon = error ? "error" : "success"
            });

            return (HttpContext.Request.Headers["X-Requested-With"] == "XMLHttpRequest")
                ? jsonResult
                : RedirectToAction("Error");
        }


        public async Task<IActionResult> Update(Tasks data)
        {
            var (error, message) = (false, "");
            if (ModelState.IsValid)
            {
                _Sklservice.DataChangeEventHandler += RefreshTasksGrid;
                (error, message) = await _Sklservice.UpdateSKLTaskAsync(data);
            }

            var jsonResult = Json(new
            {
                Status = error ? "error" : "success",
                Message = error ? message : "Accion actualizada exitosamente.",
                Icon = error ? "error" : "success"
            });

            return (HttpContext.Request.Headers["X-Requested-With"] == "XMLHttpRequest")
                ? jsonResult
                : RedirectToAction("Error");
        }

        public async Task<IActionResult> Delete(Tasks model)
        {
            _Sklservice.DataChangeEventHandler += RefreshTasksGrid;
            var (error, message) = await _Sklservice.DeleteSKLTaskAsync(model.IdTask);

            var jsonResult = Json(
                 new
                 {
                     Status = error ? "error" : "success",
                     Message = error ? message : "Action deleted successfully.",
                     Icon = error ? "error" : "success"
                 });
            return (HttpContext.Request.Headers["X-Requested-With"] == "XMLHttpRequest")
                ? jsonResult
                : RedirectToAction("Error");
        }

        private async void RefreshTasksGrid(object? sender, EventArgs e)
        => await _context.Clients.All.SendAsync("RefreshTasksGrid");

        public async Task<IActionResult> TaskJson(int idUser, int idFase)
        => Ok(await _Sklservice.GetSKLTaskPerUserFase(idUser, idFase));
    }
}
