using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Comentarios.Domain;
using Core;
using Microsoft.AspNetCore.Mvc;

namespace blog_netcore.Src.Features.Comentarios.Infraestructure
{
    [ApiController]
    [Route("api/[controller]")]
    public class ComentariosController : ControllerBase
    {

        [HttpGet(":hiloId")]
        public async Task<ActionResult<ApiResponse<List<Comentario>>>> GetComentariosDeHilo(string hiloId){ 
            throw new Exception("");
        }
    }
}