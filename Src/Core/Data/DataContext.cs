using Categorias.Domain;
using Comentarios.Domain;
using Encuestas.Domain;
using Hilos.Domain;
using InteraccionesDeHilo.Domain;
using Medias.Domain;
using Microsoft.EntityFrameworkCore;
using Users.Domain;
namespace Data
{
    public class DataContext(DbContextOptions<DataContext> options) : DbContext(options)
    {
        public DbSet<Hilo> Hilos => Set<Hilo>();
        public DbSet<User> Usuarios => Set<User>();
        public DbSet<Encuesta> Encuestas => Set<Encuesta>();
        public DbSet<EncuestaOpcion> OpcionesDeEncuestas => Set<EncuestaOpcion>();
        public DbSet<MediaReference> MediaReferences => Set<MediaReference>();
        public DbSet<Media> Medias => Set<Media>();
        public DbSet<Comentario>Comentarios => Set<Comentario>();

        public DbSet<Categoria> Categorias => Set<Categoria>();
        public DbSet<Subcategoria> Subcategorias => Set<Subcategoria>();
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
            modelBuilder.ApplyConfiguration(new VotacionDeEncuestaConfiguration());
            modelBuilder.ApplyConfiguration(new CategoriaBuilder());
            modelBuilder.ApplyConfiguration(new SubcategoriaBuilder());
            modelBuilder.ApplyConfiguration(new ComentarioConfiguration());

        }
    }


}