using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Auth.Application;
using Microsoft.AspNetCore.Mvc;

namespace blog_webapi_net_core.Src.Features.Auth.Infraestructure
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly LoginUseCase _loginUseCase;
        private readonly RegistroUseCase _registroUseCase;

        public AuthController(LoginUseCase loginUseCase, RegistroUseCase registroUseCase)
        {
            _loginUseCase = loginUseCase;
            _registroUseCase = registroUseCase;
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto dto)
        {
            await _loginUseCase.Execute(dto);
            return Ok();
        }

        [HttpPost("registro")]
        public async Task<IActionResult> Registro([FromBody] RegistroDto dto)
        {
            await _registroUseCase.Execute(dto);
            return Ok();
        }
    }
}