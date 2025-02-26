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
//SqlServerBootstrap.Initialize();

GlobalConfiguration
    .Setup()
    .UseSqlServer();


// Configurar conexión a la base de datos
var connectionString = builder.Configuration.GetConnectionString("SKLConectionString")
    ?? throw new ArgumentNullException("SKLConectionString", "Connection string cannot be null");

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
//builder.Services.AddHostedService<TaskReminderHostedService>();

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


// Rutas
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Credenciales}/{action=Login}/{id?}");

app.MapHub<SystemHub>("/systemHub");


app.Run();
