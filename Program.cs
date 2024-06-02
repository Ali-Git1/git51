using BigonWebUI.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

var cString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<DataContext>(cfg =>
{
    cfg.UseSqlServer(cString, opt=>
    {
        //Bu sql serverde migrations tablenin adini deyismek ucun istifade olunur
        opt.MigrationsHistoryTable("Migrations");
    });
});


var app = builder.Build();

app.MapControllerRoute("default", "{controller=home}/{action=index}/{id?}");

app.UseStaticFiles();

app.Run();

