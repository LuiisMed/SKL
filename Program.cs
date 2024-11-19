using Hangfire;
using Hangfire.SqlServer;
using Microsoft.AspNetCore.Authentication.Cookies;
using SKL.Data;
using SKL.Repositories;
using SKL.Repositories.IRepository;
using SKL.Services;
using SKL.Services.IServices;
using SKL.Models;
using System.Text.Json.Serialization;
using SKL;
using RepoDb;

var builder = WebApplication.CreateBuilder(args);

// Inicializar el bootstrapper de RepoDB para Microsoft.Data.SqlClient
SqlServerBootstrap.Initialize();

// Configurar conexión a la base de datos para Hangfire
var connectionString = builder.Configuration.GetConnectionString("SKLConectionString")
    ?? throw new ArgumentNullException("SKLConectionString", "Connection string cannot be null");

// Configurar Hangfire para usar SQL Server
builder.Services.AddHangfire(config =>
    config.SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
          .UseSimpleAssemblyNameTypeSerializer()
          .UseRecommendedSerializerSettings()
          .UseSqlServerStorage(connectionString, new SqlServerStorageOptions
          {
              CommandBatchMaxTimeout = TimeSpan.FromMinutes(5),
              SlidingInvisibilityTimeout = TimeSpan.FromMinutes(5),
              QueuePollInterval = TimeSpan.Zero,
              UseRecommendedIsolationLevel = true,
              DisableGlobalLocks = true // Importante para Azure SQL
          }));

builder.Services.AddHangfireServer(); // Agregar servidor de Hangfire

// Repositorios y servicios
builder.Services.AddScoped<SkipLevelContext>(s => new SkipLevelContext(connectionString));
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ISKLRepositories, SKLRepository>();
builder.Services.AddScoped<IUserServices, UserServices>();
builder.Services.AddScoped<ISKLServices, SKLServices>();
builder.Services.AddTransient<IEmailService, EmailService>();
builder.Services.AddHttpContextAccessor();

// Configuración de Email
builder.Services.Configure<EmailSettings>(builder.Configuration.GetSection("EmailSettings"));

// Hosted Service (opcional)
builder.Services.AddHostedService<TaskReminderHostedService>();

// Configurar autenticación
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Credenciales/Login";
        options.ExpireTimeSpan = TimeSpan.FromMinutes(20);
    });

// Controladores y opciones de JSON
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
});

builder.Services.AddControllersWithViews();
builder.Services.AddSignalR();

var app = builder.Build();

// Middleware y Pipeline de Solicitudes HTTP
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}

app.UseDeveloperExceptionPage();
app.UseStaticFiles();
app.UseDefaultFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

// Configurar el dashboard de Hangfire (opcional)
app.UseHangfireDashboard("/hangfire");
//app.UseHangfireDashboard("/hangfire");


// Rutas
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Credenciales}/{action=Login}/{id?}");

app.MapHub<SystemHub>("/systemHub");

// Programar la tarea recurrente
RecurringJob.AddOrUpdate<TaskReminderHostedService>(
    "RecordatorioDiario",
    servicio => servicio.EjecutarTareaDiaria(),
    "0 7 * * 1-5", TimeZoneInfo.Local);

app.Run();
