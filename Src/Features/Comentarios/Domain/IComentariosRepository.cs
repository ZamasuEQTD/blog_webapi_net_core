using Hilos.Domain;

namespace Comentarios.Domain
{
    public interface IComentariosRepository
    {
        public Task Add(Comentario comentario);
        public Task Update(Comentario comentario);
        public Task<List<Comentario>> GetComentariosDeHilo(HiloId hiloId);
        public Task<List<Comentario>> GetComentariosDestacadosDeHilo(HiloId hiloId);


    }
}