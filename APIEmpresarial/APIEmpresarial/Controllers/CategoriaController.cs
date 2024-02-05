using API.Context;
using APIEmpresarial.Interfaces;
using APIEmpresarial.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace APIEmpresarial.Controllers
{
    [ApiController]
    [Authorize]
    [Route("[controller]")]

    public class CategoriaController : ControllerBase
    {
        private ICategoriaInterface _categoriainterface;
        public CategoriaController(ICategoriaInterface categoriaInterface)
        {
            _categoriainterface = categoriaInterface;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Categoria>>> GetCategoriasProdutos()
        {
            return await _categoriainterface.GetAll();
        }
        [HttpGet("ObterProdutos")]
        public async Task<ActionResult<IEnumerable<Categoria>>> Get()
        {
            
            return await _categoriainterface.GetAll();
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
            if (ModelState.IsValid)
            {
                ModelState.AddModelError("ErroFormato", "Erro no formato de preenchimento!");
            }
            return new CreatedAtRouteResult("ObterCategoria", new { id = categoria.CategoriaId }, categoria) ;
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

