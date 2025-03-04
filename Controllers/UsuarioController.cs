﻿using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol;
using Org.BouncyCastle.Crypto;
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

        [Authorize(Roles = "Administrador")]
        public IActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "Administrador")]
        [HttpPost]
        public async Task<IActionResult> NewUsuarioPopUp()
        {
            var departamentos = await _Sklservice.GetSKLDepartmentsAsync();
            var usertypes = await _Sklservice.GetSKLUserTypesAsync();
            var shifts = await _Sklservice.GetSKLShiftsAsync();
            var positions = await _Sklservice.GetSKLPositionsAsync();


            ViewBag.Departamentos = departamentos;
            ViewBag.UserTypes = usertypes;
            ViewBag.Shifts = shifts;
            ViewBag.Positions = positions;

            ViewData["Title"] = "Nuevo Usuario";
            ViewBag.Action = "Insert";
            return PartialView("NewUsuarioPopUp", new Usuario());
        }

        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> UpdateUsuarioPopUp(int idusr)
        {
            var departamentos = await _Sklservice.GetSKLDepartmentsAsync();
            var usertypes = await _Sklservice.GetSKLUserTypesAsync();
            var shifts = await _Sklservice.GetSKLShiftsAsync();
            var positions = await _Sklservice.GetSKLPositionsAsync();
            var model = await _service.GetSKLUsuarioAsync(idusr);



            ViewBag.Departamentos = departamentos;
            ViewBag.UserTypes = usertypes;
            ViewBag.Shifts = shifts;
            ViewBag.Positions = positions;

            ViewData["Title"] = "Nuevo Usuario";
            ViewBag.Action = "Insert";
            return PartialView("UpdateUsuarioPopUp", model);
        }


        public async Task<IActionResult> Profile(int idusr, string role)
        {
            var departamentos = await _Sklservice.GetSKLDepartmentsAsync();
            var usertypes = await _Sklservice.GetSKLUserTypesAsync();
            var shifts = await _Sklservice.GetSKLShiftsAsync();
            var positions = await _Sklservice.GetSKLPositionsAsync();
            var model = await _service.GetSKLUsuarioAsync(idusr);

            ViewBag.Departamentos = departamentos;
            ViewBag.UserTypes = usertypes;
            ViewBag.Shifts = shifts;
            ViewBag.Positions = positions;


            if (role == "Administrador")
            {
                return View("Profile", model);
            }
            else
            {
                return View("ProfileUser",model);
            }

        }

        [Authorize(Roles = "Administrador")]
        [HttpPost]
        public async Task<IActionResult> Insert(Usuario data, IFormFile imageFile)
        {
            var (error, message) = (false, "");
            if (data.IdUser == 0)
            {
                if (imageFile != null && imageFile.Length > 0)
                {
                    // Generar un nombre único para la imagen
                    var uniqueFileName = $"{Guid.NewGuid()}{Path.GetExtension(imageFile.FileName)}";
                    var filePath = Path.Combine(@"wwwroot/usrimg", uniqueFileName);

                    // Guardar la imagen en el servidor
                    using (var stream = System.IO.File.Create(filePath))
                    {
                        await imageFile.CopyToAsync(stream);
                    }

                    // Guardar la ruta de la imagen en el modelo
                    data.ImagePath = $"{uniqueFileName}";
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


        [HttpPost]
        public async Task<IActionResult> Update(Usuario data, IFormFile imageFile)
        {
            var (error, message) = (false, "");

            // Si el modelo es válido o si no se está proporcionando una imagen nueva (la validación no debería fallar por la imagen)
            if (ModelState.IsValid || (imageFile == null && ModelState["imageFile"]?.Errors.Count > 0))
            {
                // Si se proporciona una nueva imagen, reemplazar la existente
                if (imageFile != null && imageFile.Length > 0)
                {
                    var uniqueFileName = $"{Guid.NewGuid()}{Path.GetExtension(imageFile.FileName)}";
                    //var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/usrimg", uniqueFileName);
                    var filePath = Path.Combine(@"wwwroot/img", uniqueFileName);


                    using (var stream = System.IO.File.Create(filePath))
                    {
                        await imageFile.CopyToAsync(stream);
                    }

                    data.ImagePath = $"{uniqueFileName}";
                }
                else
                {
                    var existingUser = await _service.GetSKLUsuarioAsync(data.IdUser);
                    data.ImagePath = existingUser?.ImagePath;
                }

                // Invocar el evento de actualización del grid
                _service.DataChangeEventHandler += RefreshUserGrid;
                (error, message) = await _service.UpdateSKLUsuariosAsync(data);
            }

            var jsonResult = Json(new
            {
                Status = error ? "error" : "success",
                Message = error ? message : "Usuario actualizado exitosamente.",
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

        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> DeleteUsuarioPopUp(int idusr)
        {
            var model = await _service.GetSKLUsuarioAsync(idusr);
            return PartialView(model);
        }

        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> DeleteSKLUsuarios(Usuario model)
        {
            var (error, message) = (false, "");

            // Obtener el usuario para acceder a la ruta de la imagen antes de eliminarlo
            var existingUser = await _service.GetSKLUsuarioAsync(model.IdUser);
            if (existingUser != null)
            {
                // Verificar si el usuario tiene una imagen antes de intentar eliminarla
                if (!string.IsNullOrWhiteSpace(existingUser.ImagePath))
                {
                    // Eliminar la imagen del servidor si existe
                    var imagePath = Path.Combine(Directory.GetCurrentDirectory(), "usrimg", existingUser.ImagePath.TrimStart('/'));
                    if (System.IO.File.Exists(imagePath))
                    {
                        System.IO.File.Delete(imagePath);
                    }
                }

                _service.DataChangeEventHandler += RefreshUserGrid;
                (error, message) = await _service.DeleteSKLUsuariosAsync(model.IdUser);
            }
            else
            {
                error = true;
                message = "User not found.";
            }

            var jsonResult = Json(new
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
