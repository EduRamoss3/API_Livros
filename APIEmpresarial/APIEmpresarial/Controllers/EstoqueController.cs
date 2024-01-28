using API.Context;
using APIEmpresarial.Model;
using APILivros.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;

namespace APIEmpresarial.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EstoqueController
    {
        private readonly IEstoqueService _estoqueService;
        public EstoqueController(IEstoqueService service)
        {
            _estoqueService = service;
        }
        [HttpPost]
        public async Task<IActionResult> AddEstoque(Livro livro)
        {
            return await _estoqueService.AddEstoque(livro);
        }
    }
}
