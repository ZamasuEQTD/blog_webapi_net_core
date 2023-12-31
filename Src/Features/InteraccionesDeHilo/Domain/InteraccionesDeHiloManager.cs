using Core.Failures;
using Hilos.Domain;
using Users.Domain;

namespace InteraccionesDeHilo.Domain
{
    public interface IInteraccionesDeHiloManager
    {
        public Task<Failure> CambiarInteracciones(CrearInteraccionDeHiloForm form);
    }
    public class InteraccionesDeHiloManager : IInteraccionesDeHiloManager
    {
        public IInteraccionesDeHiloRepository _interaccionesDeHiloRepository;

        public InteraccionesDeHiloManager(IInteraccionesDeHiloRepository interaccionesDeHiloRepository)
        {
            _interaccionesDeHiloRepository = interaccionesDeHiloRepository;
        }

        public async Task<Failure> CambiarInteracciones(CrearInteraccionDeHiloForm form)
        {
            InteraccionDeHilo? interaccion = await _interaccionesDeHiloRepository.GetInteraccionDeHiloPorUsuario(form.UserId, form.HiloId);
             
            if(interaccion is null) {
                interaccion = new(InteraccionDeHiloId.Nuevo(), form.UserId, form.HiloId);
                await _interaccionesDeHiloRepository.Add(interaccion);
            }

            interaccion.Oculto = form.Ocultar;
            interaccion.Favorito = form.Favorito;
            interaccion.Siguiendo = form.Seguir;

            await _interaccionesDeHiloRepository.Update(interaccion);
            return Failure.None;
        }

    }
}