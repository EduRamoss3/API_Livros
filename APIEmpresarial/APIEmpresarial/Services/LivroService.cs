using API.Context;
using APIEmpresarial.Interfaces;
using APIEmpresarial.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APIEmpresarial.Services
{
    public class LivroService : ILivroInterface
    {
        private readonly AppDbContext _context;
        public LivroService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Create(Livro livro)
        {
            var livroExist = await _context.Livros.FirstOrDefaultAsync(l => l.Nome == livro.Nome);
            if(livroExist != null)
            {
                return new BadRequestResult();
            }
            await _context.Livros.AddAsync(livro);
            await _context.SaveChangesAsync();
            return new OkObjectResult(this);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var livroExist = await _context.Livros.FirstOrDefaultAsync(l => l.LivroId == id);
            if(livroExist == null) { return new NotFoundObjectResult(this); }
            _context.Livros.Remove(livroExist);
            await _context.SaveChangesAsync();
            return new OkObjectResult($"O livro {livroExist.Nome} foi removido com sucesso! (ID:{livroExist.LivroId}");
        }

        public async Task<ActionResult<IEnumerable<Livro>>> GetAll()
        {
            return await _context.Livros.ToListAsync();
        }

        public async Task<ActionResult<Livro>> GetLivro(int id)
        {
           var livro = await _context.Livros.FirstOrDefaultAsync(l => l.LivroId == id);
           if(livro is null) { return new NotFoundObjectResult("O livro não existe"); }
           return livro;
        }

        public async Task<IActionResult> UpdateLivro(Livro livro, int id)
        {
            var oldLivro = await _context.Livros.FirstOrDefaultAsync(l => l.LivroId == id);
            if(oldLivro is null) { return new NotFoundObjectResult(this); }
            oldLivro = livro;
            await _context.SaveChangesAsync();
            return new OkObjectResult("O livro foi atualizado com sucesso!");
        }
    }
}
