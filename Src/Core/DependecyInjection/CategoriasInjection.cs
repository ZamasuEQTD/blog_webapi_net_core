using Categorias.Application;
using Categorias.Domain;
using Categorias.Infraestructure;

namespace WebApp{
    static public class CategoriasDepencendies
    {
        static public void AddCategoriasDependencies(this IServiceCollection services)
        {
            services.AddScoped<ICategoriasManager, CategoriasManager>();
            services.AddScoped<ICategoriasRepository, CategoriasRepository>();

            services.AddScoped<CrearCategoriasUseCase>();
            services.AddScoped<GetCategoriasUseCase>();
        }
    }
}
