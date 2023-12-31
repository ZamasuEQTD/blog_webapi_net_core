using Hilos.Domain;

namespace WebApp
{
    static public class HilosInjection
    {
        static public void AddHilosDependencies(this IServiceCollection services)
        {
            services.AddScoped<IHiloManager, HiloManager>();
        }
    }
}