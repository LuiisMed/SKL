﻿using Microsoft.AspNetCore.Mvc;
using SKL.Models;
using SKL.Services.IServices;
using System.Linq.Expressions;
using System.Linq;
using RepoDb;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;


namespace SKL.Controllers;

public class CredencialesController : Controller
{
    private readonly IHubContext<SystemHub> _context;
    private readonly IUserServices _service;

    public CredencialesController(IHubContext<SystemHub> context, IUserServices service)
    {
        _context = context;
        _service = service;
    }

    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }

    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }


    [HttpPost]
    public async Task<IActionResult> Login(Login modelo)
    {
        var data = await _service.GetSKLCredentials();
        Login? usuario_encontrado = data.Where(u => u.Usuario == modelo.Usuario && u.Clave == modelo.Clave).FirstOrDefault();

        if(usuario_encontrado == null)
        {
            ViewData["Mensaje"] = "El nombre de usuario o contraseña son incorrectos";
            return View();
        }

        List<Claim> claims = new List<Claim>()
        {
            new Claim(ClaimTypes.Name, usuario_encontrado.Name),
            new Claim(ClaimTypes.Role, usuario_encontrado.RolName),
            new Claim(ClaimTypes.NameIdentifier, usuario_encontrado.IdUser.ToString())
        };

        if (!string.IsNullOrEmpty(usuario_encontrado.ImagePath))
        {
            claims.Add(new Claim("imageFile", usuario_encontrado.ImagePath));
        }

        ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
        AuthenticationProperties properties = new AuthenticationProperties()
        {
            AllowRefresh = true,
        };

        await HttpContext.SignInAsync(
            CookieAuthenticationDefaults.AuthenticationScheme,
            new ClaimsPrincipal(claimsIdentity),
            properties
            );

        if (usuario_encontrado.RolName == "Administrador")
        {
            return RedirectToAction("Index", "Home");
        }
        else if (usuario_encontrado.RolName == "Usuario")
        {
            return RedirectToAction("Index", "HomeUsuario");
        }
        else
        {
            return View();
        }
    }

}
