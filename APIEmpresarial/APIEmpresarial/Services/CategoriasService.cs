using API.Context;
using APIEmpresarial.Interfaces;
using APIEmpresarial.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APIEmpresarial.Services
{
    public class CategoriasService : ICategoriaInterface
    {
        private readonly AppDbContext _context;

        public CategoriasService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Create(Categoria categoria)
        {
            if (categoria is not Categoria example)
            {
                return new BadRequestObjectResult("O formato da categoria está incorreto!");
            }
            _context.Categorias.Add(categoria);
            await _context.SaveChangesAsync();
            return new OkObjectResult(Task.CompletedTask);
        }
        public ActionResult<IEnumerable<Categoria>> GetAll()
        {
            if (_context.Categorias is not null)
            {
                return _context.Categorias.AsNoTracking().Include(p => p.Livros).Where(c => c.CategoriaId <= 5).ToList();
            }
            else
            {
                return new BadRequestResult();
            }
        }
        public ActionResult<Categoria> GetCategoria(int id)
        {
            if (_context.Categorias is not null)
            {
                var categoria = _context.Categorias.FirstOrDefault(p => p.CategoriaId == id);
                if (categoria != null)
                {
                    return categoria;
                }
            }

            return new NotFoundObjectResult("Categoria não encontrada!");
        }
        public async Task<IActionResult> Delete(int id)
        {
            var categoria = _context.Categorias?.FirstOrDefault(p => p.CategoriaId == id);
            if (categoria is null && categoria is not Categoria example)
            {
                return new BadRequestObjectResult("Erro ao deletar a categoria");
            }
            _context.Categorias?.Remove(categoria);
            await _context.SaveChangesAsync();
            return new OkObjectResult("Deletado com sucesso!");

        }
        public async Task<IActionResult> Update(int id)
        {
            var categoria = _context.Categorias?.FirstOrDefault(p => p.CategoriaId == id);
            if (categoria is null && categoria is not Categoria example)
            {
                return new BadRequestObjectResult("Erro ao atualizar a categoria");
            }
            _context.Categorias.Entry(categoria).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return new OkObjectResult("Atualizado com sucesso!");
        }
    }
}

