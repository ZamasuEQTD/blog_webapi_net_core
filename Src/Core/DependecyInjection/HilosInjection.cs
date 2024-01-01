using Hilos.Application;
using Hilos.Domain;
using Hilos.Infraestructure;

namespace WebApp
{
    static public class HilosInjection
    {
        static public void AddHilosDependencies(this IServiceCollection services)
        {
            services.AddScoped<IHiloManager, HiloManager>();
            services.AddScoped<IHilosRepository, HilosRepository>();
            services.AddScoped<CrearHiloUseCase>();
            services.AddScoped<GetHiloUseCase>();
            services.AddScoped<GetPortadasDeHilosUseCase>();


        
        }
    }
}