using AutoMapper;
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
        private readonly IMapper _mapper;
        public HilosController(
            IMapper mapper,
            GetHiloUseCase getHiloUseCase,
            CrearHiloUseCase crearHiloUseCase)
        {
            _mapper = mapper;
            _getHiloUseCase = getHiloUseCase;
            _crearHiloUseCase = crearHiloUseCase;
        }
        [HttpPost("crear-hilo")]
        public async Task<IActionResult> CrearHilo([FromForm] CrearHiloRequestDto dto)
        {
            await _crearHiloUseCase.Execute(new CrearHiloDto(dto.Categoria, dto.Usuario, dto.Titulo, dto.Descripcion, dto.Portada, dto.DadosActivado, dto.IdUnicoActivado, new List<string>() { "hola", "perro" }));
            return Ok();
        }

        [HttpGet(":id")]
        public async Task<ActionResult<GetPortadaDeHiloResponse>> GetHilo(Guid id)
        {
            var hilo = await this._getHiloUseCase.Execute(new GetHiloDto(id.ToString()));

            var res = _mapper.Map<GetPortadaDeHiloResponse>(hilo.Value);
            return Ok(res);
        }


    }
}