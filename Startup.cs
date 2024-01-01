using System.Text.Json.Serialization;
using Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
namespace WebApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; set; }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAuthorizationBuilder();
            // services.AddSignalR();

            // this.AddServices(services);
            services.AddHttpContextAccessor();



            AddBearerTokenSupport(services);

            services.AddDbContext<DataContext>(options =>
            {
                options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection"));
            });

            services.AddAuthDependencies();
            services.AddUserDependencies();
            services.AddHilosDependencies();
            services.AddMediaDependecies();
            services.AddEncuestasDependencies();

            services.AddEndpointsApiExplorer();

            services.AddControllers().AddJsonOptions(x =>
                 x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
            services.AddControllers().AddJsonOptions(opt => opt.JsonSerializerOptions.DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull);
        }

        public async void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }
            // app.UseStaticFiles(new StaticFileOptions
            // {
            //     RequestPath = "/static", // Cambia la URL base
            //     FileProvider = new PhysicalFileProvider(Path.Combine(env.ContentRootPath, "static"))
            // });
            // app.UseStaticFiles(new StaticFileOptions
            // {
            //     RequestPath = "/archivos", // Cambia la URL base
            //     FileProvider = new PhysicalFileProvider(Path.Combine(env.ContentRootPath, "Media"))
            // });
            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                // endpoints.MapHub<HubAppSignalr>("/hub");
            });

        }

        private void AddBearerTokenSupport(IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT"
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement {
        {
            new OpenApiSecurityScheme {
            Reference = new OpenApiReference {
                Type = ReferenceType.SecurityScheme,
                Id = "Bearer"
            }
        },
        new string [] {}
        }
        });
            });

        }

        private void AddAuth(IServiceCollection services)
        {
            services.AddAuthentication(defaultScheme: JwtBearerDefaults.AuthenticationScheme).AddJwtBearer();
        }
    }


}
