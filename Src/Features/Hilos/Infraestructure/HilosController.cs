using Hilos.Application;
using Microsoft.AspNetCore.Mvc;

namespace Hilos.Infraestructure
{
    [ApiController]
    [Route("api/[controller]")]
    public class HilosController : ControllerBase
    {
        private readonly CrearHiloUseCase _crearHiloUseCase;
        public HilosController(CrearHiloUseCase crearHiloUseCase)
        {
            _crearHiloUseCase = crearHiloUseCase;
        }
        [HttpPost("crear-hilo")]
        public async Task<IActionResult> Login([FromForm] CrearHiloRequestDto dto)
        {
            await _crearHiloUseCase.Execute(new CrearHiloDto(dto.Usuario, dto.Titulo,dto.Descripcion,dto.Portada,new List<string>(){"hola","perro"}));
            return Ok();
        }

        
    }
}