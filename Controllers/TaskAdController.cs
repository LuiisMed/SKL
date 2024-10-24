using Microsoft.AspNetCore.Mvc;
using SKL.Models;
using SKL.Models.ViewModels;
using SKL.Services.IServices;
using static Microsoft.CodeAnalysis.IOperation;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using System.Threading.Tasks;

namespace SKL.Controllers
{
    public class TaskAdController : Controller
    {
        private readonly IHubContext<SystemHub> _context;
        private readonly IUserServices _service;
        private readonly ISKLServices _Sklservice;
        private readonly IEmailService _emailservice;
        private readonly IWebHostEnvironment _env;

        public TaskAdController(IHubContext<SystemHub> context, IUserServices service, ISKLServices sklservice, IEmailService emailservice, IWebHostEnvironment env)
        {
            _context = context;
            _service = service;
            _Sklservice = sklservice;
            this._emailservice = emailservice;
            _env = env;
        }

        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> Index(int userfilter, int fasefilter)
            {

            var users = await _service.GetSKLUsuarios();
            var aspects = await _Sklservice.GetSKLAspectsAsync();
            var eval = await _Sklservice.GetSKLEvalsAsync();
            var user = await _service.GetSKLUserEmailAsync(userfilter);
            var fase = await _Sklservice.GetSKLFaseName(fasefilter);


            var email = user.FirstOrDefault()?.Email ?? "Email no encontrado";
            var fasename = fase.FirstOrDefault()?.Name ?? "Email no encontrado";

            TaskPerEval model = new()
            {
                UserFilter = userfilter,
                FaseFilter = fasefilter,
                Usuarios = users,
                Email = email,
                FaseName = fasename,
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

        public async Task<IActionResult> InsertEval(Eval evalData, IFormFile imageFile)
        {
            var (error, message) = (false, "");
            var existingEval = await _Sklservice.GetSKLEvalPerUserAsync(evalData.IdUserE, evalData.IdFaseE);

            if (existingEval == null || !existingEval.Any())
            {
                if (imageFile != null && imageFile.Length > 0)
                {
                    var uniqueFileName = $"{Guid.NewGuid()}{Path.GetExtension(imageFile.FileName)}";
                    var filePath = Path.Combine(@"\\10.131.40.121\Paperless\RH\Evaluations", uniqueFileName);

                    using (var stream = System.IO.File.Create(filePath))
                    {
                        await imageFile.CopyToAsync(stream);
                    }

                    evalData.Results = $"{uniqueFileName}";
                }

                await _Sklservice.InsertSKLEvalAsync(evalData);

            }
            return RedirectToAction("Index", new { UserFilter = evalData.IdUserE, FaseFilter = evalData.IdFaseE });

        }



        public async Task<IActionResult> Insert(Tasks taskData)
        {
            var (error, message, newTaskId) = await _Sklservice.InsertSKLTaskAsync(taskData);

            if (!error && newTaskId > 0)
            {
                var notification = new Notifications
                {
                    IdTask = newTaskId,
                    Message = taskData.Accion,
                    IsReaded = false,
                    EviReaded = false,
                    IdUsr = taskData.IdUserT
                };

                var secondInsertResult = await InsertRelatedDataAsync(notification);

                if (!secondInsertResult)
                {
                    error = true;
                    message = "Error en la inserción de los datos relacionados.";
                }

                var mailrequest = new Mailrequest
                {
                    ToEmail = taskData.Email,
                    Subject = "Nueva Accion SkipLevel",
                    Accion = taskData.Accion,
                    Fase = taskData.FaseName,
                    EndDate = taskData.End
                };

                var thirdInsertResult = await SendMail(mailrequest);

            }

            var jsonResult = Json(new
            {
                Status = error ? "error" : "success",
                Message = error ? message : "Acción agregada correctamente.",
                Icon = error ? "error" : "info"
            });

            return (HttpContext.Request.Headers["X-Requested-With"] == "XMLHttpRequest")
                ? jsonResult
                : RedirectToAction("Error");
        }




        [HttpPost("SendMail")]
        public async Task<IActionResult> SendMail(Mailrequest mailrequest)
        {
            try
            {
                mailrequest.ToEmail = mailrequest.ToEmail;
                mailrequest.Subject = mailrequest.Subject;
                mailrequest.Body = GetHtmlContent(mailrequest);
                await _emailservice.SendEmailAsync(mailrequest);
                return Ok();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private string GetHtmlContent(Mailrequest mailrequest)
        {
            string path = Path.Combine(_env.WebRootPath, "assets", "Email", "AsignacionEmail.html");

            if (!System.IO.File.Exists(path))
            {
                throw new FileNotFoundException($"No se encontró la plantilla HTML en la ruta: {path}");
            }

            // Leer el contenido del archivo
            string htmlTemplate = System.IO.File.ReadAllText(path);

            // Reemplazar los marcadores en la plantilla con los valores de Mailrequest
            string emailBody = htmlTemplate
                .Replace("{{Accion}}", mailrequest.Accion ?? string.Empty)
                .Replace("{{Fase}}", mailrequest.Fase ?? string.Empty)
                .Replace("{{FechaVencimiento}}", mailrequest.EndDate.ToString("dd/MM/yyyy"));

            return emailBody;
        }




        //private string GetHtmlContent(Mailrequest mailrequest)
        //{
        //    string response = $"<h1>Que onda soy la accion {mailrequest.Accion}</h1> ";

        //    return response;
        //}

        private async Task<bool> InsertRelatedDataAsync(Notifications notifications)
        {
            try
            {
                _Sklservice.DataChangeEventHandler += RefreshTasksGrid;
                await _Sklservice.InsertSKLNotificationsAsync(notifications);
                return true;
            }
            catch
            {
                return false;
            }
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

        [HttpGet]
        public async Task<IActionResult> TaskJson(int idUser, int idFase)
        {
            var tasks = await _Sklservice.GetSKLTaskPerUserFase(idUser, idFase);

            // Proyectar a un objeto anónimo con las fechas formateadas
            var fasesFormateadas = tasks.Select(f => new
            {
                f.IdTask,
                f.IdUserT,
                f.Name,
                f.IdFaseT,
                f.FaseName,
                f.Accion,
                f.IdAspect,
                f.AspectName,
                f.IsCompleted,
                f.Evidences,
                Start = f.Start.ToString("yyyy-MM-dd"),
                End = f.End.ToString("yyyy-MM-dd"),
                Month = f.Start.ToString("MMMM")
            });

            return Json(fasesFormateadas);
        }


    }
}
