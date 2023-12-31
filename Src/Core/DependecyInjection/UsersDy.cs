using Auth.Application;
using Users.Domain;
using Users.Infraestructure;

namespace WebApp
{
    static public class UsersDy
    {
        static public void AddUserDependencies(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
        }
    }
}