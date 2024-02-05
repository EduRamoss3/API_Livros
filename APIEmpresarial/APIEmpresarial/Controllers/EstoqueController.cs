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
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> AddEstoque(Livro livro)
        {
            return await _estoqueService.AddEstoque(livro);
        }
        [HttpGet]
        [Authorize(Roles = "Administrador")]
        [Route("[controller]/get_all_estoque")]
        public async Task<ActionResult<IEnumerable<Estoque>>> GetAllEstoque()
        {
            return await _estoqueService.GetAllEstoque();
        }
        [HttpGet]
        [Authorize(Roles = "Administrador")]
        [Route("[controller]/quantidade_estoque")]
        public async Task<ActionResult<int>> QuantidadeEstoque()
        {
            return await _estoqueService.Quantity();

        }
        [HttpGet]
        [Authorize(Roles = "Administrador")]
        [Route("[controller]/total_estoque")]
        public async Task<ActionResult<decimal>> TotalEstoque()
        {
            return await _estoqueService.TotalInEstoque();

        }

    }
}
