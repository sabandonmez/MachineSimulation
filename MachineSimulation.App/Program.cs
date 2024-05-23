using System.Reflection;
using MachineSimulation.DataAccess;
using MachineSimulation.Business;
using MachineSimulation.Business.Concrete;
using MachineSimulation.DataAccess.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using MachineSimulation.App.Infrastructe.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

builder.Services.AddDbContext<MachineSimulationContext>(options =>
{
    options.UseSqlite(builder.Configuration.GetConnectionString("sqlconnection"));
    options.EnableSensitiveDataLogging(true);
});

builder.Services.AddIdentity<IdentityUser, IdentityRole>(options =>
{
    options.SignIn.RequireConfirmedAccount = false;
    options.User.RequireUniqueEmail = true;
    options.Password.RequireUppercase = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireDigit = false;
    options.Password.RequiredLength = 6;
}).AddEntityFrameworkStores<MachineSimulationContext>();

builder.Services.AddDataAccessServices();
builder.Services.AddBusinessServices();
builder.Services.AddSingleton<ModbusConnectionManager>();
builder.Services.AddLogging(); // Loglama servisini ekleyin

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapAreaControllerRoute(
        name: "Area",
        areaName: "Admin",
        pattern: "Admin/{Controller=Dashboard}/{Action=Index}/{id?}"
    );
    endpoints.MapControllerRoute("default", "{controller=Machine}/{action=Index}/{id?}");
});

await app.ConfigureDefaultAdminUser(); // Admin kullanýcý kontrolü ve oluþturulmasý

app.Run();
