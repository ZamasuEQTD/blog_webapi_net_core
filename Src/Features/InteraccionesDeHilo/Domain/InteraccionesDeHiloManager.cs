using Hilos.Domain;
using Users.Domain;

namespace InteraccionesDeHilo.Domain {
    public interface IInteraccionesDeHiloManager {
        public Task CambiarInteracciones(CrearInteraccionDeHiloForm form);
    }
    public class InteraccionesDeHiloManager : IInteraccionesDeHiloManager
    {
        public IInteraccionesDeHiloRepository _interaccionesDeHiloRepository;

        public InteraccionesDeHiloManager(IInteraccionesDeHiloRepository interaccionesDeHiloRepository)
        {
            _interaccionesDeHiloRepository = interaccionesDeHiloRepository;
        }

        public async Task CambiarInteracciones(CrearInteraccionDeHiloForm form)
        {
            var interaccionResult = await  _interaccionesDeHiloRepository.GetInteraccionDeHiloPorUsuario(form.UserId,form.HiloId);
            InteraccionDeHilo interaccion;
            if(interaccionResult.IsSuccess){
                interaccion = interaccionResult.Value;
            } else {
                interaccion = new(InteraccionDeHiloId.Nuevo(), form.UserId,form.HiloId);
            }

            interaccion.Oculto = form.Ocultar;
            interaccion.Favorito = form.Favorito;
            interaccion.Siguiendo = form.Seguir;
        }

    
    }
}