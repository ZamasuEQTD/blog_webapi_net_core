using AutoMapper;
using Core;
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
        private readonly GetPortadasDeHilosUseCase _getPortadasDeHilosUseCase;
        private readonly IMapper _mapper;
        public HilosController(
            IMapper mapper,
            GetPortadasDeHilosUseCase getPortadasDeHilosUseCase,
            GetHiloUseCase getHiloUseCase,
            CrearHiloUseCase crearHiloUseCase)
        {
            _mapper = mapper;
            _getPortadasDeHilosUseCase = getPortadasDeHilosUseCase;
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
        public async Task<ActionResult<ApiResponse<GetHiloResponse>>> GetHilo(Guid id)
        {
            ApiResponse<GetHiloResponse> response = new();
            var hiloResponse = await _getHiloUseCase.Execute(new GetHiloDto(id.ToString()));
            
            if(hiloResponse.IsFailure) {
                response.SetError(hiloResponse.Error.Descripcion ?? hiloResponse.Error.Code);
            }else {
                var res = _mapper.Map<GetHiloResponse>(hiloResponse.Value);
            
                response.Body = res;
            }

            return Ok(response);
        }

        [HttpGet("portadas")]
        public async Task<ActionResult<List<GetPortadaDeHiloResponse>>> GetPortadasDeHilo([FromQuery] int pagina, [FromQuery] DateTime? bump   ){
            ApiResponse<List<GetPortadaDeHiloResponse>> response = new();
            
            var hilosResult = await _getPortadasDeHilosUseCase.Execute(new FiltrarPortadasDeHilosDto(pagina,new(),null,null,null,bump));

            if(hilosResult.IsSuccess){
                response.SetError(hilosResult.Error.Descripcion ?? hilosResult.Error.Code);
            } else {
                var portadas  = _mapper.Map<List<GetPortadaDeHiloResponse>>(hilosResult.Value);
                response.Body = portadas;
            }
            
            return Ok(response);            
        }
    }
}