using Encuestas.Application;
using Encuestas.Domain;
using Encuestas.Infraestructure;

namespace WebApp
{
    static public class EncuestasInjection
    {
        static public void AddEncuestasDependencies(this IServiceCollection services)
        {
            services.AddScoped<CrearEncuestaUseCase>();
            services.AddScoped<IEncuestaManager, EncuestaManager>();
            services.AddScoped<IEncuestaRepository, EncuestaRepository>();
        }
    }
}