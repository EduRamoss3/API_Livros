using API.Context;
using APIEmpresarial.Interfaces;
using APIEmpresarial.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace APIEmpresarial.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class CategoriaController : ControllerBase
    {
        private ICategoriaInterface _categoriainterface;
        public CategoriaController(AppDbContext context, ICategoriaInterface categoriaInterface)
        {
            _categoriainterface = categoriaInterface;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Categoria>> GetCategoriasProdutos()
        {
            return _categoriainterface.GetAll();
        }
        [HttpGet("ObterProdutos")]
        public ActionResult<IEnumerable<Categoria>> Get()
        {
            return _categoriainterface.GetAll();
        }
        [HttpGet("{id:int}", Name = "ObterCategoria")]
        public ActionResult<Categoria> Get(int id)
        {
            return _categoriainterface.GetCategoria(id);

        }
        [HttpPost("NovaCategoria")]
        public async Task<IActionResult> Post(Categoria categoria)
        {
            await _categoriainterface.Create(categoria);
            return new CreatedAtRouteResult("ObterCategoria", new { id = categoria.CategoriaId }, categoria);
        }
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Put(int id, Categoria categoria)
        {
            if (categoria is null) { return NotFound(); }
            if (id != categoria.CategoriaId) { return BadRequest(); }
            return await _categoriainterface.Update(id);
        }
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            return await _categoriainterface.Delete(id);
        }
    }
}

