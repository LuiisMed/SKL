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
        private readonly ISKLServices _Sklservice;


        public UsuarioController(IHubContext<SystemHub> context, IUserServices service, ISKLServices sklservice)
        {
            _context = context;
            _service = service;
            _Sklservice = sklservice;
        }


        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> NewUsuarioPopUp()
        {
            var departamentos = await _Sklservice.GetSKLDepartmentsAsync();
            var usertypes = await _Sklservice.GetSKLUserTypeAsync();
            var shifts = await _Sklservice.GetSKLShiftsAsync();
            var positions = await _Sklservice.GetSKLPositionAsync();


            ViewBag.Departamentos = departamentos;
            ViewBag.UserTypes = usertypes;
            ViewBag.Shifts = shifts;
            ViewBag.Positions = positions;

            ViewData["Title"] = "Nuevo Usuario";
            ViewBag.Action = "Insert";
            return PartialView("NewUsuarioPopUp", new Usuario());
        }


        [HttpPost]
        public async Task<IActionResult> Insert(Usuario data, IFormFile imageFile)
        {
            var (error, message) = (false, "");
            if (ModelState.IsValid)
            {
                if (imageFile != null && imageFile.Length > 0)
                {
                    // Guardar la imagen en el servidor
                    var fileName = Path.GetFileName(imageFile.FileName);
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img", fileName);

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await imageFile.CopyToAsync(stream);
                    }

                    // Guardar la ruta de la imagen en el modelo
                    data.ImagePath = $"/img/{fileName}";
                }

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

        //public async Task<IActionResult> Insert(Usuario data)
        //{
        //    var (error, message) = (false, "");
        //    if (ModelState.IsValid)
        //    {
        //        _service.DataChangeEventHandler += RefreshUserGrid;
        //        (error, message) = await _service.InsertSKLUsuariosAsync(data);
        //    }

        //    var jsonResult = Json(new
        //    {
        //        Status = error ? "error" : "success",
        //        Message = error ? message : "Usuario creado exitosamente.",
        //        Icon = error ? "error" : "success"
        //    });

        //    return (HttpContext.Request.Headers["X-Requested-With"] == "XMLHttpRequest")
        //        ? jsonResult
        //        : RedirectToAction("Error");
        //}

        //public async Task<IActionResult> Insert(Usuario data, IFormFile imageFile)
        //{
        //    var (error, message) = (false, "");
        //    if (ModelState.IsValid)
        //    {
        //        if (imageFile != null && imageFile.Length > 0)
        //        {
        //            // Guardar la imagen en el servidor
        //            var fileName = Path.GetFileName(imageFile.FileName);
        //            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img", fileName);

        //            using (var stream = new FileStream(filePath, FileMode.Create))
        //            {
        //                await imageFile.CopyToAsync(stream);
        //            }

        //            // Guardar la ruta de la imagen en el modelo
        //            data.ImagePath = $"/img/{fileName}";
        //        }

        //        _service.DataChangeEventHandler += RefreshUserGrid;
        //        (error, message) = await _service.InsertSKLUsuariosAsync(data);
        //    }

        //    var jsonResult = Json(new
        //    {
        //        Status = error ? "error" : "success",
        //        Message = error ? message : "Usuario creado exitosamente.",
        //        Icon = error ? "error" : "success"
        //    });

        //    return (HttpContext.Request.Headers["X-Requested-With"] == "XMLHttpRequest")
        //        ? jsonResult
        //        : RedirectToAction("Error");
        //}


        public async Task<IActionResult> UpdateUsuarioPopUp(int idusr)
        {
            var departamentos = await _Sklservice.GetSKLDepartmentsAsync();
            var usertypes = await _Sklservice.GetSKLUserTypeAsync();
            var shifts = await _Sklservice.GetSKLShiftsAsync();
            var positions = await _Sklservice.GetSKLPositionAsync();
            var model = await _service.GetSKLUsuarioAsync(idusr);



            ViewBag.Departamentos = departamentos;
            ViewBag.UserTypes = usertypes;
            ViewBag.Shifts = shifts;
            ViewBag.Positions = positions;

            ViewData["Title"] = "Nuevo Usuario";
            ViewBag.Action = "Insert";
            return PartialView("UpdateUsuarioPopUp", model);
        }

        [HttpPost]
        public async Task<IActionResult> Update(Usuario data)
        {
            var (error, message) = (false, "");
            if (ModelState.IsValid)
            {
                _service.DataChangeEventHandler += RefreshUserGrid;
                (error, message) = await _service.UpdateSKLUsuariosAsync(data);
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




        //public async Task<IActionResult> Update(Usuario data)
        //{
        //    var (error, message) = (false, "");
        //    if (ModelState.IsValid)
        //    {
        //        _service.DataChangeEventHandler += RefreshUserGrid;
        //        (error, message) = await _service.UpdateSKLUsuariosAsync(data);
        //    }

        //    var jsonResult = Json(new
        //    {
        //        Status = error ? "error" : "success",
        //        Message = error ? message : "Usuario creado exitosamente.",
        //        Icon = error ? "error" : "success"
        //    });

        //    return (HttpContext.Request.Headers["X-Requested-With"] == "XMLHttpRequest")
        //        ? jsonResult
        //        : RedirectToAction("Error");
        //}


        public async Task<IActionResult> DeleteUsuarioPopUp(int idusr)
        {
            var model = await _service.GetSKLUsuarioAsync(idusr);
            return PartialView(model);
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
                     Message = error ? message : "User deleted successfully.",
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
