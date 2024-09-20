using Microsoft.AspNetCore.Mvc;
using SKL.Models;
using System.Diagnostics;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using SKL.Services.IServices;

namespace SKL.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ISKLServices _Sklservice;


        public HomeController(ILogger<HomeController> logger, ISKLServices sklservice)
        {
            _logger = logger;
            _Sklservice = sklservice;
        }

        [Authorize]
        public IActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "Administrador")]
        public IActionResult Privacy()
        {
            return View();
        }

        public async Task<IActionResult> FasesJSON()
        {
            var fases = await _Sklservice.GetSKLFasesAsync();

            // Proyectar a un objeto anónimo con las fechas formateadas
            var fasesFormateadas = fases.Select(f => new
            {
                f.Id,
                f.Name,
                f.CurrentDate,
                Start = f.Start.ToString("yyyy-MM-dd"),
                End = f.End.ToString("yyyy-MM-dd")
            });

            // Devolver el resultado como JSON
            return Json(fasesFormateadas);
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToAction("Login", "Credenciales");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
