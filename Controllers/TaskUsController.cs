using Microsoft.AspNetCore.Mvc;
using SKL.Models;
using SKL.Services;
using SKL.Services.IServices;
using System.Net;

namespace SKL.Controllers
{
    public class TaskUsController : Controller
    {

        private readonly IHubContext<SystemHub> _context;
        private readonly IUserServices _service;
        private readonly ISKLServices _Sklservice;


        public TaskUsController(IHubContext<SystemHub> context, IUserServices service, ISKLServices sklservice)
        {
            _context = context;
            _service = service;
            _Sklservice = sklservice;
        }

        public async Task<IActionResult> Index(int userfilter, int fasefilter)
        {

            var eval = await _Sklservice.GetSKLEvalsAsync();

            TaskPerEval model = new()
            {
                UserFilter = userfilter,
                FaseFilter = fasefilter,
                Evals = eval
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> NewEvidencePopUp(int idTask)
        {
            var model = await _Sklservice.GetSKLTaskEvidence(idTask);
            ViewData["Title"] = "Carga de Evidencia";
            ViewBag.Action = "Insert";

            var evidence = new Evidence
            {
                IdTask = idTask 
            };

            return PartialView("NewEvidencePopUp", evidence);
        }


        [HttpPost]
        public async Task<IActionResult> DeleteEviPopUp(int idEvidences)
        {
            var model = await _Sklservice.GetSKLEvidenceAsync(idEvidences);
            return PartialView("DeleteEviPopUp", model);
        }


        [HttpPost]
        public async Task<IActionResult> Insert(Evidence evidencedata, IFormFile imageFile)
        {
            var (error, message) = (false, "");
            if (ModelState.IsValid)
            {
                if (imageFile != null && imageFile.Length > 0)
                {
                    // Generar un nombre único para la imagen
                    var uniqueFileName = $"{Guid.NewGuid()}{Path.GetExtension(imageFile.FileName)}";
                    var filePath = Path.Combine(@"\\10.131.40.121\Paperless\RH\Evidences", uniqueFileName);

                    // Guardar la imagen en el servidor
                    using (var stream = System.IO.File.Create(filePath))
                    {
                        await imageFile.CopyToAsync(stream);
                    }

                    // Guardar la ruta de la imagen en el modelo
                    evidencedata.Evidences = $"{uniqueFileName}";
                }

                _Sklservice.DataChangeEventHandler += RefreshTasksGrid;
                (error, message) = await _Sklservice.InsertSKLEvidencesAsync(evidencedata);
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

        public async Task<IActionResult> Delete(Evidence model)
        {
            _Sklservice.DataChangeEventHandler += RefreshTasksGrid;
            var (error, message) = await _Sklservice.DeleteSKLEvidencesAsync(model.IdEvidences);

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

        //public async Task<IActionResult> TaskJson(int idUser, int idFase)
        //{
        //    var tasks = await _Sklservice.GetSKLEviPerTaskAsync(idUser, idFase);
        //    return Ok(tasks);
        //}

        [HttpGet]
        public async Task<IActionResult> TaskJson(int idUser, int idFase)
        {
            var tasks = await _Sklservice.GetSKLEviPerTaskAsync(idUser, idFase);

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
                Start = f.Start.ToString("yyyy-MM-dd"),
                End = f.End.ToString("yyyy-MM-dd"),
                f.IdEvidences,
                f.Evidences,
                Month = f.End.ToString("MMMM")
        });

            return Json(fasesFormateadas);
        }


        [HttpGet]
        public async Task<IActionResult> DownloadFile(string fileName)
        {
            var filePath = Path.Combine(@"\\10.131.40.121\Paperless\RH\Evidences", fileName);

            if (System.IO.File.Exists(filePath))
            {
                var memory = new MemoryStream();
                using (var stream = new FileStream(filePath, FileMode.Open))
                {
                    await stream.CopyToAsync(memory);
                }
                memory.Position = 0;
                return File(memory, "application/octet-stream", fileName);
            }
            else
            {
                return Ok();
            }
        }

        [HttpGet]
        public async Task<IActionResult> DownloadEva(string fileName)
        {
            var filePath = Path.Combine(@"\\10.131.40.121\Paperless\RH\Evaluations", fileName);

            if (System.IO.File.Exists(filePath))
            {
                var memory = new MemoryStream();
                using (var stream = new FileStream(filePath, FileMode.Open))
                {
                    await stream.CopyToAsync(memory);
                }
                memory.Position = 0;
                return File(memory, "application/octet-stream", fileName);
            }
            else
            {
                return NotFound();
            }
        }


    }
}
















//[HttpPost]
//public async Task<IActionResult> Insert(Evidence evidencedata, IFormFile imageFile)
//{
//    try
//    {
//        var (error, message) = (false, "");
//        if (ModelState.IsValid)
//        {
//            if (imageFile != null && imageFile.Length > 0)
//            {
//                // Generar un nombre único para la imagen
//                var uniqueFileName = $"{Guid.NewGuid()}{Path.GetExtension(imageFile.FileName)}";
//                //var filePath = Path.Combine(Directory.GetCurrentDirectory(), @"\\reyprdnas01\Pasmxshared\Hector Garcia\SKL", uniqueFileName);
//                var filePath = Path.Combine(@"\\10.131.40.121\Paperless\RH", uniqueFileName);

//                // Guardar la imagen en el servidor
//                using (var stream = System.IO.File.Create(filePath))
//                {
//                    await imageFile.CopyToAsync(stream);
//                }

//                // Guardar la ruta de la imagen en el modelo
//                evidencedata.Evidences = $"{uniqueFileName}";
//            }

//            _Sklservice.DataChangeEventHandler += RefreshTasksGrid;
//            (error, message) = await _Sklservice.InsertSKLEvidencesAsync(evidencedata);
//        }

//        var jsonResult = Json(new
//        {
//            Status = error ? "error" : "success",
//            Message = error ? message : "Usuario creado exitosamente.",
//            Icon = error ? "error" : "success"
//        });

//        return (HttpContext.Request.Headers["X-Requested-With"] == "XMLHttpRequest")
//            ? jsonResult
//            : RedirectToAction("Error");
//    }
//    catch (Exception x)
//    {
//        return Json(new { err = x.Message });
//    }


//}
