using MGQSEmployeeAppMVC.Context;
using MGQSEmployeeAppMVC.Implementations;
using MGQSEmployeeAppMVC.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MGQSEmployeeAppMVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            var app = builder.Build();
            builder.Services.AddDbContext<ApplicationContext>(option => option.UseMySQL(builder.Configuration.GetConnectionString("ApplicationContext")));
                  builder.Services.AddScoped<IEmployeeRepository,EmployeeRepository>();
                   builder.Services.AddScoped<IEmployeeService,EmployeeService>();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}