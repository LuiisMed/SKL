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

namespace SKL.Services
{
    public class TaskReminderHostedService : BackgroundService
    {
        private readonly IServiceScopeFactory _serviceScopeFactory;
        private readonly IEmailService _emailService;
        private readonly IWebHostEnvironment _env;


        public event EventHandler? DataChangeEventHandler;

        public TaskReminderHostedService(IServiceScopeFactory serviceScopeFactory, IEmailService emailService, IWebHostEnvironment env)
        {
            _serviceScopeFactory = serviceScopeFactory;
            _emailService = emailService;
            _env = env;
        }

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
                IdUser = task.IdUser
            }).ToList();
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    using var scope = _serviceScopeFactory.CreateScope();
                    var repository = scope.ServiceProvider.GetRequiredService<ISKLRepositories>();

                    var tasks = await GetOverdueTasksAsync(repository);

                    foreach (var task in tasks)
                    {
                        var mailRequest = new Mailrequest
                        {
                            ToEmail = task.Email,
                            Accion = task.Accion,
                            Fase = task.FaseName,
                            EndDate = task.End
                        };

                        // Ejecuta el método correspondiente según los días restantes
                        switch (task.DiasRestantes)
                        {
                            case 3:
                                await SendMail3DaysLeftAsync(mailRequest);
                                break;
                            //case 2:
                            //    await SendMail2DaysLeftAsync(mailRequest);
                            //    break;
                            //case 1:
                            //    await SendMail1DaysLeftAsync(mailRequest);
                            //    break;
                            //case 0:
                            //    await SendMail0DaysLeftAsync(mailRequest);
                            //    break;
                            default:
                                Console.WriteLine($"Días restantes no manejados: {task.DiasRestantes}");
                                break;
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }

                await Task.Delay(TimeSpan.FromMinutes(1), stoppingToken);
            }
        }



        private async Task SendMail3DaysLeftAsync(Mailrequest mailRequest)
        {
            try
            {
                mailRequest.ToEmail = mailRequest.ToEmail;
                mailRequest.Subject = "La Accion Vence en 3 dias";
                mailRequest.Body = GetHtml3daysleftContent(mailRequest);
                await _emailService.SendEmailAsync(mailRequest);
                Console.WriteLine("Correo enviado correctamente.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error enviando correo: {ex.Message}");
            }
        }

        //private async Task SendMail3DaysLeftAsync(Mailrequest mailRequest)
        //{
        //    try
        //    {
        //        mailRequest.Subject = "La Accion Vence en 3 dias";
        //        mailRequest.Body = GetHtml3daysleftContent(mailRequest);
        //        await _emailService.SendEmailAsync(mailRequest);
        //        Console.WriteLine("Correo enviado correctamente.");
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine($"Error enviando correo: {ex.Message}");
        //    }
        //}
        //private async Task SendMail3DaysLeftAsync(Mailrequest mailRequest)
        //{
        //    try
        //    {
        //        mailRequest.Subject = "La Accion Vence en 3 dias";
        //        mailRequest.Body = GetHtml3daysleftContent(mailRequest);
        //        await _emailService.SendEmailAsync(mailRequest);
        //        Console.WriteLine("Correo enviado correctamente.");
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine($"Error enviando correo: {ex.Message}");
        //    }
        //}
        //private async Task SendMail3DaysLeftAsync(Mailrequest mailRequest)
        //{
        //    try
        //    {
        //        mailRequest.Subject = "La Accion Vence en 3 dias";
        //        mailRequest.Body = GetHtml3daysleftContent(mailRequest);
        //        await _emailService.SendEmailAsync(mailRequest);
        //        Console.WriteLine("Correo enviado correctamente.");
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine($"Error enviando correo: {ex.Message}");
        //    }
        //}


        private string GetHtml3daysleftContent(Mailrequest mailRequest)
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
                .Replace("{{Accion}}", mailRequest.Accion ?? string.Empty)
                .Replace("{{Fase}}", mailRequest.Fase ?? string.Empty)
                .Replace("{{FechaVencimiento}}", mailRequest.EndDate.ToString("dd/MM/yyyy"));

            return emailBody;
        }
    }
}
