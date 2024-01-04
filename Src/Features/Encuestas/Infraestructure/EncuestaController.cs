using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Core;
using Encuestas.Application;
using Microsoft.AspNetCore.Mvc;

namespace blog_netcore.Src.Features.Encuestas.Infraestructure
{
    [ApiController]
    [Route("api/[controller]")]
    public class EncuestaController : ControllerBase
    {

        private readonly VotarEncuestaUseCase _votarEncuestaUseCase;
        
        public EncuestaController(VotarEncuestaUseCase votarEncuestaUseCase)
        {
            _votarEncuestaUseCase = votarEncuestaUseCase;
        }
        [HttpPost("votar/:id")]
        public async Task<ActionResult<ApiResponse<string>>> VotarEnEncuesta(string id){
            ApiResponse<string> response = new();
            var votacionResult = await _votarEncuestaUseCase.Execute(new(id,""));
            if(votacionResult.IsFailure) {
                response.SetError(votacionResult.Error.Descripcion ?? votacionResult.Error.Code);
            } else {
                response.Body = "Creado correctamente";
            }
            return Ok(response);
        }
    }
}