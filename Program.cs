using SKL.Data;
using SKL.Repositories.IRepository;
using SKL.Repositories;
using SKL.Services.IServices;
using SKL.Services;
using SKL;
using System.Linq;
using Microsoft.AspNetCore.Authentication.Cookies;
using SKL.Models;


GlobalConfiguration.Setup().UseSqlServer();

var builder = WebApplication.CreateBuilder(args);



var SkipLevelContext = builder.Configuration.GetConnectionString("SKLConectionString")
    ?? throw new ArgumentNullException("SKLConectionString", "Connection string cannot be null");

// DbContext
//builder.Services.AddScoped<CDataDbContext>(s => new(cDataDBConnection));
builder.Services.AddScoped<SkipLevelContext>(s => new(SkipLevelContext));

//EmailDependecy
builder.Services.Configure<EmailSettings>(builder.Configuration.GetSection("EmailSettings"));

//Repositories
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ISKLRepositories, SKLRepository>();

//Services
builder.Services.AddScoped<IUserServices, UserServices>();
builder.Services.AddScoped<ISKLServices, SKLServices>();
builder.Services.AddTransient<IEmailService, EmailService>();
builder.Services.AddHttpContextAccessor();

// Hosted Service
builder.Services.AddHostedService<TaskReminderHostedService>();


//Add services to the container
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
});

builder.Services.AddControllersWithViews();
builder.Services.AddSignalR();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Credenciales/Login";
        options.ExpireTimeSpan = TimeSpan.FromMinutes(20);
    });


var app = builder.Build();

//Configure the HTTP request pipeline.
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
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Credenciales}/{action=Login}/{id?}");

app.MapHub<SystemHub>("/systemHub");

app.Run();

//Desarrollado por el mejor practicante de RH e Ingenieria de PASMX "LP" "EVND" "UTTN"