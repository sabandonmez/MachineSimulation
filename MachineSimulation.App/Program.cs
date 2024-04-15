using System.Reflection;
using MachineSimulation.DataAccess;
using MachineSimulation.Business;
using MachineSimulation.Business.Concrete;
using MachineSimulation.DataAccess.Concrete;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

builder.Services.AddDbContext<MachineSimulationContext>(options =>
{
	options.UseSqlite(builder.Configuration.GetConnectionString("sqlconnection"));
});
builder.Services.AddDataAccessServices();
builder.Services.AddBusinessServices();
builder.Services.AddSingleton<ModbusConnectionManager>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Home/Error");
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Machine}/{action=Index}/{id?}");

app.Run();
