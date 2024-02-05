using APIEmpresarial.Model.Entities;
using APILivros.Interfaces;
using APILivros.Model.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Org.BouncyCastle.Crypto.Generators;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace APILivros.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class UsuarioController : ControllerBase
    {

        private readonly IUsuarioService _usuarioService;
        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }
        [HttpPost]
        [Route("[controller]/Create")]
        [Authorize(Roles = "Administrador, Usuario")]
        public async Task<IActionResult> Create(Funcionario funcionario)
        {
            return await _usuarioService.Create(funcionario); 
        }
        [HttpGet]
        [Authorize(Roles = "Administrador")]
        public async Task<ActionResult<IEnumerable<Funcionario>>> GetAllFuncionarios()
        {
            return await _usuarioService.GetAllFuncionario();
        }

        [HttpPost]
        [Route("/Authenticate")]
        [AllowAnonymous]
        public async Task<ActionResult> Authenticate(AuthenticationDto model)
        {
            
            var usuarioDb = await _usuarioService.GetFuncionario(model.Id);
            if (usuarioDb is null) { return new UnauthorizedResult(); }
            if (!BCrypt.Equals(model.Password, usuarioDb.Value.Password))
            {
                return Unauthorized();
            }
            var jwt = GenerateJwtToken(usuarioDb.Value);
            return Ok(new { jwtToken = jwt });
        }
        private string GenerateJwtToken(Funcionario model)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("Ry74cBQva5dThwbwchR9jhbtRFnJxWSZ");
            var claims = new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.NameIdentifier, model.FuncionarioId.ToString()),
                new Claim(ClaimTypes.Role, model.Perfil.ToString())
            });
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = claims,
                Expires = DateTime.UtcNow.AddHours(8),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
