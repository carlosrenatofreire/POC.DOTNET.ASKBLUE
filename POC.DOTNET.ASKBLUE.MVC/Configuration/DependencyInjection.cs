using Microsoft.AspNetCore.Mvc.DataAnnotations;
using POC.ASKBLUE.LIBRARY.CORE.User;
using POC.DOTNET.ASKBLUE.MVC.Extensions;
using POC.DOTNET.ASKBLUE.MVC.Services.Handlers;

namespace POC.DOTNET.ASKBLUE.MVC.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static void RegisterServices(this IServiceCollection services, IConfiguration configuration)
        {
            //Attribute
            services.AddSingleton<IValidationAttributeAdapterProvider, NifValidationAttributeAdapterProvider>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IAspNetUser, AspNetUser>();

            #region HttpServices

            // Register (to take JWT)
            services.AddTransient<HttpClientAuthorizationDelegatingHandler>();


            #endregion

        }
    }
}
