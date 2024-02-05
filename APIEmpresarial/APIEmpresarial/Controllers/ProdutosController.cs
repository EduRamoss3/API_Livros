using API.Context;
using APIEmpresarial.Interfaces;
using APIEmpresarial.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;

namespace APIEmpresarial.Controllers
{
    [ApiController]
    [Authorize]
    [Route("[controller]")]
    public class ProdutosController : ControllerBase
    {
        private readonly ILivroInterface _livrointerface;
        public ProdutosController(ILivroInterface livroInterface)
        {
            _livrointerface = livroInterface;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Livro>>> GetLivros()
        {
            return await _livrointerface.GetAll();
        }
        [HttpGet("{id:int}", Name = "ObterProduto")]
        public async Task<ActionResult<Livro>> GetLivro(int id)
        {

            return await _livrointerface.GetLivro(id);
            
        }
        [HttpPost("NovoProduto")]
        public async Task<IActionResult> Post(Livro livro)
        {

            await _livrointerface.Create(livro);
            return new CreatedAtRouteResult("ObterProduto",
            new { id = livro.LivroId }, livro);
        }
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Put(int id, Livro livro)
        {
            return await _livrointerface.UpdateLivro(livro, id);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            return await _livrointerface.Delete(id);
        }
    }
}
