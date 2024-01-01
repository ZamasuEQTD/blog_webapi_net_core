using Hilos.Application;
using Microsoft.AspNetCore.Mvc;

namespace Hilos.Infraestructure
{
    [ApiController]
    [Route("api/[controller]")]
    public class HilosController : ControllerBase
    {
        private readonly CrearHiloUseCase _crearHiloUseCase;
        private readonly GetHiloUseCase _getHiloUseCase;

        public HilosController(
            GetHiloUseCase getHiloUseCase,
            CrearHiloUseCase crearHiloUseCase)
        {
            _getHiloUseCase = getHiloUseCase;
            _crearHiloUseCase = crearHiloUseCase;
        }
        [HttpPost("crear-hilo")]
        public async Task<IActionResult> CrearHilo([FromForm] CrearHiloRequestDto dto)
        {
            await _crearHiloUseCase.Execute(new CrearHiloDto(dto.Usuario, dto.Titulo,dto.Descripcion,dto.Portada,new List<string>(){"hola","perro"}));
            return Ok();
        }

        [HttpGet(":id")]
        public async Task<IActionResult> GetHilo(Guid id) {
            return Ok(await this._getHiloUseCase.Execute(new GetHiloDto(id.ToString())));
        }

        
    }
}