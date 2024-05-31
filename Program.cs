using BigonWebUI.Helpers;
using BigonWebUI.Helpers.Services;
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


builder.Services.Configure<EmailOptions>(cfg=>
{
    builder.Configuration.GetSection("emailAccount").Bind(cfg);
});
 


builder.Services.AddSingleton<IEmailService, EmailServices>();     //bu ne edir? -Addsingletonda kod ilk defe run olanda gedecek bu kod ucun instans yaradacaq , amma addscoped ve addtransient in ferqleri vra birinde her respons atanda yeni instans yaradir digerinde ise her servis ozun cagiranda

var app = builder.Build();

app.MapControllerRoute(
            name: "areas",
            pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
          );

app.MapControllerRoute("default", "{controller=home}/{action=index}/{id?}");

app.UseStaticFiles();

app.Run();

