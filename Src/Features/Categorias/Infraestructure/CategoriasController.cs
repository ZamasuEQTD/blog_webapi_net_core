using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Categorias.Application;
using Core;
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
        public async Task<ActionResult<ApiResponse<List<GetCategoriaDto>>>>GetCategorias(){
            ApiResponse<List<GetCategoriaDto>> response = new();

            var listaResult = await _getCategoriasUseCase.Execute();
            if(listaResult.IsFailure){ 
                response.SetError(listaResult.Error.Descripcion?? listaResult.Error.Code);
            } else { 
                var categoriasResonse = _mapper.Map<List<GetCategoriaDto>>(listaResult.Value);
                response.Body = categoriasResonse;
            }
            return Ok(response);
        }

        [HttpPost("crear-categorias")]
        public async Task<IActionResult> CrearCategorias([FromBody] List<CrearCategoriaDto> dtos){
            return Ok(await _crearCategoriasUseCase.Execute(dtos));
        }
    }
}