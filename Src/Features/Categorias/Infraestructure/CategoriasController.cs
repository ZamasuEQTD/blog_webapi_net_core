using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Categorias.Application;
using Microsoft.AspNetCore.Mvc;

namespace Categorias.Infraestructure
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriasController : ControllerBase
    {

        private readonly CrearCategoriasUseCase _crearCategoriasUseCase;
        private readonly GetCategoriasUseCase _getCategoriasUseCase;
        private readonly IMapper _mapper;


        public CategoriasController(
            IMapper mapper,
            CrearCategoriasUseCase crearCategoriasUseCase,
            GetCategoriasUseCase getCategoriasUseCase)
        {
            _mapper = mapper;
            _getCategoriasUseCase = getCategoriasUseCase;
            _crearCategoriasUseCase = crearCategoriasUseCase;
        }

        [HttpGet]
        public async Task<ActionResult<List<GetCategoriaDto>>>GetCategorias(){
            var listaResult = await _getCategoriasUseCase.Execute();

            var categoriasResonse = _mapper.Map<List<GetCategoriaDto>>(listaResult.Value);
            return Ok(categoriasResonse);
        }

        [HttpPost("crear-categorias")]
        public async Task<IActionResult> CrearCategorias([FromBody] List<CrearCategoriaDto> dtos){
            return Ok(await _crearCategoriasUseCase.Execute(dtos));
        }
    }
}