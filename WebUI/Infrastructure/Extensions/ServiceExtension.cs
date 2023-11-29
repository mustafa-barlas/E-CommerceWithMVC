using DataAccess.Concrete.EntityFramework.Contexts;
using Entities.Concrete;
using Microsoft.AspNetCore.Identity;
using WebUI.Models;

namespace WebUI.Infrastructure.Extensions;

public static class ServiceExtension
{
    public static void ConfigureSession(this IServiceCollection services)
    {
        services.AddDistributedMemoryCache(); // session
        services.AddSession(options => // session
        {
            options.Cookie.Name = "Alalim.Session";
            options.IdleTimeout = TimeSpan.FromSeconds(10);
        });
        services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        services.AddScoped<Cart>(c => SessionCart.GetCart(c));


    }

    public static void ConfigureRouting(this IServiceCollection services)
    {
        services.AddRouting(options =>
        {
            options.LowercaseUrls = true; 
            options.AppendTrailingSlash = true; 
        });
    }

    public static void ConfigureIdentity(this IServiceCollection services)
    {
        services.AddIdentity<IdentityUser, IdentityRole>
        (
            options =>
            {
                options.SignIn.RequireConfirmedAccount = false;
                options.User.RequireUniqueEmail = true;
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 6;
            }
        ).AddEntityFrameworkStores<AlalimContext>();
    }
}