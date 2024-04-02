using Microsoft.AspNetCore.Authentication.Cookies;

namespace POC.DOTNET.ASKBLUE.MVC.Configuration
{
    public static class IdentityConfig
    {
        public static void AddIdentityConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    options.LoginPath = "/login";
                    options.AccessDeniedPath = "/access-denied";
                });

            //services.AddAuthentication(OpenIdConnectDefaults.AuthenticationScheme)
            //        .AddMicrosoftIdentityWebApp(configuration.GetSection("AzureAd"));
        }

        public static void UseIdentityConfiguration(this IApplicationBuilder app)
        {
            app.UseAuthentication();
            app.UseAuthorization();
        }
    }
}
