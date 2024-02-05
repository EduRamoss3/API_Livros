using API.Context;
using APIEmpresarial.Model;
using APILivros.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;

namespace APIEmpresarial.Controllers
{
    [ApiController]
    [Authorize]
    [Route("[controller]")]
    public class EstoqueController : ControllerBase
    {
        private readonly IEstoqueService _estoqueService;
        public EstoqueController(IEstoqueService service)
        {
            _estoqueService = service;
        }
        [HttpPost]
        [Authorize(Roles ="Administrador")]
        public async Task<IActionResult> AddEstoque(Livro livro)
        {
            return await _estoqueService.AddEstoque(livro);
        }
    }
}
