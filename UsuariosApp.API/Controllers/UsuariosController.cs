using Microsoft.AspNetCore.Mvc;

namespace UsuariosApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : Controller
    {
        public UsuariosController() { }

        /// <summary>
        /// Autenticação de usuários
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("autenticar")]
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
        public IActionResult CriarConta()
        {
            return Ok();
        }
    }
}
