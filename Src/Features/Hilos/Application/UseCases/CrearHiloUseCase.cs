using Core.Failures;
using Core.Result;
using Encuestas.Application;
using Encuestas.Domain;
using Hilos.Domain;

namespace Hilos.Application
{
    public class CrearHiloUseCase
    {
        private readonly CrearEncuestaUseCase _crearEncuestaUseCase;
        private readonly IHiloManager _hiloManager;
        public CrearHiloUseCase(IHiloManager hiloManager, CrearEncuestaUseCase  crearEncuestaUseCase)
        {
            _crearEncuestaUseCase = crearEncuestaUseCase;
            _hiloManager = hiloManager;
        }
        public async  Task<Result<Hilo>> Execute(CrearHiloDto dto) {
            var formResult = await CrearForm(dto);

            return await _hiloManager.CrearHilo(formResult.Value);
        }

        private async Task<Result<CrearHiloForm>> CrearForm(CrearHiloDto dto) {
            
            var tituloResult = TituloDeHilo.Create(dto.Titulo);
            if(tituloResult.IsFailure){
                return Result<CrearHiloForm>.Failure(tituloResult.Error);
            }
            var descripcionResult = DescripcionDeHilo.Create(dto.Descripcion);
            if(descripcionResult.IsFailure){
                return Result<CrearHiloForm>.Failure(tituloResult.Error);
            }
            Result<Encuesta>? encuestaResult =null;
            if(dto.Encuesta is not null) {
                encuestaResult = await _crearEncuestaUseCase.Execute(new CrearEncuestaDto(dto.Encuesta));
            }
            var form = new CrearHiloForm(new (Guid.Parse(dto.Usuario)),tituloResult.Value,descripcionResult.Value,encuestaResult!.Value);
            return Result<CrearHiloForm>.Success(form);
        }
    }

}