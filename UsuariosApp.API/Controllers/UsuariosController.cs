using Microsoft.AspNetCore.Mvc;
using UsuariosApp.Application.Interfaces;
using UsuariosApp.Application.Models.Responses;

namespace UsuariosApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : Controller
    {
        private readonly IUsuarioAppService? _usuarioAppService;
        public UsuariosController(IUsuarioAppService? usuarioAppService) 
        {
            _usuarioAppService = usuarioAppService;
        }

        /// <summary>
        /// Autenticação de usuários
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("autenticar")]
        [ProducesResponseType(typeof(AutenticarResponseDTO),StatusCodes.Status200OK)]
        [ProducesErrorResponseType(typeof(void))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult Autenticar()
        {
            return Ok();
        }
        /// <summary>
        /// Criação de contas de usuários
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("criar-conta")]
        [ProducesResponseType(typeof(CriarContaResponseDTO),StatusCodes.Status201Created)]
        public IActionResult CriarConta()
        {
            return Ok();
        }
    }
}
