using Microsoft.AspNetCore.Mvc;
using SKL.Models;
using SKL.Services.IServices;

namespace SKL.Controllers
{
    public class NotificationsController : Controller
    {
        private readonly IHubContext<SystemHub> _context;
        private readonly IUserServices _service;
        private readonly ISKLServices _Sklservice;


        public NotificationsController(IHubContext<SystemHub> context, IUserServices service, ISKLServices sklservice)
        {
            _context = context;
            _service = service;
            _Sklservice = sklservice;
        }


        public IActionResult Index()
        {
            return View();
        }



        public async Task<IActionResult> Update(Notifications notifications)
        {
            var (error, message) = (false, "");

            if (ModelState.IsValid)
            {
                (error, message) = await _Sklservice.UpdateSKLNotificationsAsync(notifications);

                return RedirectToAction("Index", "TaskUs", new
                {
                    fasefilter = notifications.IdFase,
                    userfilter = notifications.IdUsr
                });
            }

            ViewBag.ErrorMessage = message;
            return View(notifications);
        }

        public async Task<IActionResult> UpdateAdmNotification(Notifications notifications)
        {
            var (error, message) = (false, "");

            if (ModelState.IsValid)
            {
                (error, message) = await _Sklservice.UpdateSKLAdminNotificationsAsync(notifications);

                return RedirectToAction("TasksEvaluated", "Progress", new
                {
                    idFase = notifications.IdFase,
                    idDepartment = notifications.IdDepartment
                });
            }

            ViewBag.ErrorMessage = message;
            return View(notifications);
        }


        public async Task<IActionResult> NotificationsJson(int IdUser)
        {
            var notifications = await _Sklservice.GetSKLNotificationsAsync(IdUser);
            return Ok(notifications);
        }

        public async Task<IActionResult> AdminNotificationsJson()
        {
            var notifications = await _Sklservice.GetSKLAdminNotificationsAsync();
            return Ok(notifications);
        }

    }
}
