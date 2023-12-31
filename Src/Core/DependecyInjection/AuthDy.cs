using Auth.Application;
using Auth.Domain;

namespace WebApp
{
    static public class AuthDependencyInjection
    {
        static public void AddAuthDependencies(this IServiceCollection services)
        {
            services.AddScoped<IAuthManager, AuthManager>();
            services.AddScoped<IPasswordHasherHelper, PasswordHasherHelper>();
            services.AddScoped<LoginUseCase>();
            services.AddScoped<RegistroUseCase>();
        }
    }
}