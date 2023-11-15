using Autofac;
using Autofac.Core;
using Autofac.Extensions.DependencyInjection;
using Business.DependencyResolvers.Autofac;
using WebUI.Infrastructure.Extensions;
using WebUI.Models;

namespace WebUI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllersWithViews();


            var mvcBuilder = builder.Services.AddRazorPages();
            if (builder.Environment.IsDevelopment())
            {
                mvcBuilder.AddRazorRuntimeCompilation();
            }

           

            builder.Services.ConfigureSession();
            builder.Services.ConfigureRouting();

            builder.Services.AddAutoMapper(typeof(Program)); // ben

            builder.Host.                                                        // IOC Container  // Autofac
                UseServiceProviderFactory(new AutofacServiceProviderFactory
                    (options =>
                        options.RegisterModule(new AutofacBusinessModule())));

            var app = builder.Build();

            app.UseStaticFiles();
            app.UseSession();

            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapAreaControllerRoute(
                    name: "Admin",
                    areaName: "Admin",
                    pattern: "Admin/{controller=Dashboard}/{action=Index}/{id?}"
                );

                endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");

                endpoints.MapRazorPages();

                endpoints.MapControllers();
            });


            app.ConfigureLocalization();
            app.Run();
        }
    }
}





