using APILivros.Model.Entities;
using Microsoft.AspNetCore.Mvc;

namespace APILivros.Controllers
{
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;
        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpPost]
        public async Task<ActionResult> Authenticate(AuthenticationDto model)
        {

        }
    }
}
