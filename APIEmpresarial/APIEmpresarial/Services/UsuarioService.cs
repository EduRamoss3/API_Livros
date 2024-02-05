using API.Context;
using APIEmpresarial.Model.Entities;
using APILivros.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APILivros.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly AppDbContext _context;
        public UsuarioService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ActionResult<Funcionario>> GetFuncionario(int id)
        {
            var funcionario = await _context.Funcionarios.FirstAsync(f => f.FuncionarioId == id);
            if (funcionario == null) { return new NotFoundResult(); }
            return funcionario;
        }
        public async Task<IActionResult> Create(Funcionario funcionario)
        {
            var testExists = _context.Funcionarios.FirstOrDefault(f => f.Nome == funcionario.Nome);
            if(testExists != null) { return new BadRequestResult(); }
            await _context.Funcionarios.AddAsync(funcionario);
            await _context.SaveChangesAsync();
            return new OkObjectResult(this);
        }

        public async Task<ActionResult<IEnumerable<Funcionario>>> GetAllFuncionario()
        {
            return await _context.Funcionarios.ToListAsync();
        }
    }
}
