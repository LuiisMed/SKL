using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SKL.Models;
using SKL.Repositories.IRepository;
using SKL.Services.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

#nullable disable

namespace SKL.Services
{
    public class TaskReminderHostedService : BackgroundService
    {
        private readonly IServiceScopeFactory _serviceScopeFactory;
        private readonly IEmailService _emailService;
        private readonly IWebHostEnvironment _env;

        public TaskReminderHostedService(IServiceScopeFactory serviceScopeFactory,
                                         IEmailService emailService,
                                         IWebHostEnvironment env)
        {
            _serviceScopeFactory = serviceScopeFactory;
            _emailService = emailService;
            _env = env;
        }

        //public async Task EjecutarTareaDiaria()
        //{
        //    using var scope = _serviceScopeFactory.CreateScope();
        //    var repository = scope.ServiceProvider.GetRequiredService<ISKLRepositories>();
        //    var tasks = await GetOverdueTasksAsync(repository);

        //    foreach (var task in tasks)
        //    {
        //        string path = task.DiasRestantes switch
        //        {
        //            0 => "ExpiracionUrgente.html",
        //            1 or 2 or 3 => "ExpiracionMedia.html",
        //            _ => null
        //        };

        //        if (path != null)
        //        {
        //            var mailRequest = new Mailrequest
        //            {
        //                ToEmail = task.Email,
        //                Accion = task.Accion,
        //                Fase = task.FaseName,
        //                EndDate = task.End
        //            };

        //            await SendMail(mailRequest, path);

        //        }
        //        else
        //        {
        //            Console.WriteLine($"Días restantes no manejados: {task.DiasRestantes}");
        //        }

        //        var notification = new Notifications
        //        {
        //            IdTask = task.IdTask,
        //            Message = $"La Acción (<b>{task.Accion}</b>) de la <b>{task.FaseName}</b> se vence el dia <b>{task.End.ToString("MMMM dd")}</b>",
        //            IsReaded = false,
        //            EviReaded = false,
        //            IdUsr = task.IdUser
        //        };

        //        await InsertNotificationDataAsync(repository, notification);
        //    }
        //}

        private async Task<List<SKLTasksOverdue>> GetOverdueTasksAsync(ISKLRepositories repository)
        {
            var tasks = await repository.GetSKLTasksOverDueAsync();
            return tasks.Select(task => new SKLTasksOverdue
            {
                IdTask = task.IdTask,
                Accion = task.Accion,
                FaseName = task.FaseName,
                End = task.End,
                Email = task.Email,
                IdUser = task.IdUser,
                DiasRestantes = task.DiasRestantes
            }).ToList();
        }

        private async Task<bool> InsertNotificationDataAsync(ISKLRepositories repository, Notifications notifications)
        {
            try
            {
                await repository.InsertSKLNotificationsAsync(notifications);
                return true;
            }
            catch
            {
                return false;
            }
        }

        private async Task SendMail(Mailrequest mailRequest, string path)
        {
            try
            {
                mailRequest.Subject = "La Acción SkipLevel ya casi se cierra";
                mailRequest.Body = GetHtmlContent(mailRequest, path);
                await _emailService.SendEmailAsync(mailRequest);
                Console.WriteLine("Correo enviado correctamente.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error enviando correo: {ex.Message}");
            }
        }

        private string GetHtmlContent(Mailrequest mailRequest, string path)
        {
            string pathTemplate = Path.Combine(_env.WebRootPath, "assets", "Email", path);

            if (!System.IO.File.Exists(pathTemplate))
            {
                throw new FileNotFoundException($"No se encontró la plantilla HTML en la ruta: {pathTemplate}");
            }

            string htmlTemplate = System.IO.File.ReadAllText(pathTemplate);
            return htmlTemplate
                .Replace("{{Accion}}", mailRequest.Accion ?? string.Empty)
                .Replace("{{Fase}}", mailRequest.Fase ?? string.Empty)
                .Replace("{{FechaVencimiento}}", mailRequest.EndDate.ToString("dd/MM/yyyy"));
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken) => Task.CompletedTask; // No se necesita en esta opción.
    }

}
