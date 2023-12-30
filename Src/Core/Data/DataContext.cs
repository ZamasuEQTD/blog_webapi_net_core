using Encuestas.Domain;
using Hilos.Domain;
using InteraccionesDeHilo.Domain;
using Medias.Domain;
using Microsoft.EntityFrameworkCore;
using Users.Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
namespace Data
{
    class DataContext(DbContextOptions<DataContext> options) : IdentityDbContext(options)
    {
        public DbSet<Hilo> Hilos => Set<Hilo>();
        public DbSet<User> Usuarios => Set<User>();
        public DbSet<Encuesta> Encuestas => Set<Encuesta>();
        public DbSet<EncuestaOpcion> OpcionesDeEncuestas => Set<EncuestaOpcion>();
        public DbSet<MediaReference> MediaReferences => Set<MediaReference>();
        public DbSet<Media> Medias => Set<Media>();
        public DbSet<InteraccionDeHilo> InteraccionDeHilos => Set<InteraccionDeHilo>();
        public DbSet<VotacionDeEncuesta> VotosDeEncuesta => Set<VotacionDeEncuesta>();
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new InteraccionesDeHiloConfiguration());
            modelBuilder.ApplyConfiguration(new HiloConfiguration());
            modelBuilder.ApplyConfiguration(new MediaConfiguration());
            modelBuilder.ApplyConfiguration(new MediaReferenceConfiguration());
            modelBuilder.ApplyConfiguration(new EncuestaConfiguration());
            modelBuilder.ApplyConfiguration(new EncuestaOpcionConfiguration());
        }
    }
}