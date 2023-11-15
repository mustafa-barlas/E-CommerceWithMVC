using Entities.Concrete;
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
}