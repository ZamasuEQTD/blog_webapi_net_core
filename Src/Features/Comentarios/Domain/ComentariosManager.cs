using Core.Result;
using Hilos.Domain;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Users.Domain;

namespace Comentarios.Domain
{

    public interface IComentariosManager
    {
        public Task<Result<Comentario>> CrearComentario(CrearComentarioForm form);
        public Task<Result<List<Comentario>>> GetComentariosDeHilo(HiloId hiloId);
    }
    public class ComentariosManager : IComentariosManager
    {
        private readonly IComentariosRepository _comentariosRepository;
        private readonly ITagHelper _tagHelper;
        public ComentariosManager(
            IComentariosRepository comentariosRepository,
            ITagHelper tagHelper)
        {
            _comentariosRepository = comentariosRepository;
            _tagHelper = tagHelper;
        }
        public async Task<Result<Comentario>> CrearComentario(CrearComentarioForm form)
        {

            Hilo hilo = form.Hilo;

            Comentario comentario = new(
                form.Usuario,
                hilo,
                form.TextoDeComentario,
                new DatosDeComentario(
                    _tagHelper.CrearTag(),
                    "rojo",
                    hilo.Banderas.IdUnicoActivado? _tagHelper.CrearTagUnico(form.Usuario.Id.Value.ToString()): null,
                    null)
                ,form.Media
            ); 
            await _comentariosRepository.Add(comentario);

            return Result<Comentario>.Success(comentario);
        }

        public async  Task<Result<List<Comentario>>> GetComentariosDeHilo(HiloId hiloId)
        {
            var comentarios = await _comentariosRepository.GetComentariosDeHilo(hiloId);
            return Result<List<Comentario>>.Success(comentarios);
        }
    }
}