using Autofac;
using Autofac.Extensions.DependencyInjection;
using Business.DependencyResolvers.Autofac;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.Cookies;
using WebUI.Infrastructure.Extensions;

namespace WebUI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllersWithViews();

            builder.Services.AddValidatorsFromAssemblyContaining<Program>();
            builder.Services.AddMvc().AddFluentValidation();

            //var tokenOptions = builder.Configuration.GetSection("TokenOptions").Get<TokenOptions>();


            //builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            //    .AddJwtBearer(options =>
            //    {
            //        options.TokenValidationParameters = new TokenValidationParameters
            //        {
            //            ValidateIssuer = true,
            //            ValidateAudience = true,
            //            ValidateLifetime = true,
            //            ValidateIssuerSigningKey = true,
            //            ValidIssuer = tokenOptions.Issuer,
            //            ValidAudience = tokenOptions.Audience,
            //            IssuerSigningKey = SecurityKeyHelper.CreateSecurityKey(tokenOptions.SecurityKey),
            //            ClockSkew = TimeSpan.Zero
            //        };
            //    });





            var mvcBuilder = builder.Services.AddRazorPages();
            if (builder.Environment.IsDevelopment())
            {
                mvcBuilder.AddRazorRuntimeCompilation();
            }



            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(config =>
            {
                config.LoginPath = "/Admin/User/Login";

                config.AccessDeniedPath = "/Admin/User/AccessDenied";

                config.ExpireTimeSpan = TimeSpan.FromMinutes(30);

                config.SlidingExpiration = true;
            });


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

                endpoints.MapControllerRoute(
                    "default", 
                    pattern: "{controller=Home}/{action=Index}/{id?}");

                endpoints.MapRazorPages();

                endpoints.MapControllers();
            });




            app.ConfigureLocalization();
            app.Run();
        }
    }
}





