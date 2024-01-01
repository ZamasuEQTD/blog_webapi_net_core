using Medias.Application;
using Medias.Domain;
using Medias.Infraestructure;
using Shared.Archivos.Domain;
using Shared.Hasher;
using Shared.Imagess;

namespace WebApp
{
    static public class MediaInjection
    {
        public static void AddMediaDependecies(this IServiceCollection services){
            services.AddScoped<IMediaManager,MediaManager>(x=> new MediaManager(
                services.BuildServiceProvider().GetService<IMediaRepository>()!,
                services.BuildServiceProvider().GetService<IArchivosHelper>()!,
                services.BuildServiceProvider().GetService<IVistaPreviaHelper>()!,
                services.BuildServiceProvider().GetService<IMiniaturaHelper>()!,
                services.BuildServiceProvider().GetService<IHasherHelper>()!,
                Path.Join(services.BuildServiceProvider().GetService<IWebHostEnvironment>()!.ContentRootPath, "Media","Files")

                ));
            services.AddScoped<IMediaRepository,MediaRepository>();
            services.AddScoped<CrearMediaUseCase>();
            services.AddScoped<IArchivosHelper,ArchivosHelper>();
            services.AddScoped<IImagesHelper, ImagesHelper>();
            services.AddScoped<IVistaPreviaHelper,VistaPreviaHelper>();
            services.AddScoped<IMiniaturaHelper,MiniaturaHelper>();
            services.AddScoped<IHasherHelper,HasherHelper>();
        }
    }
}