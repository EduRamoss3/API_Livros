using API.Context;
using APIEmpresarial.Model.Entities;
using APIes.Interfaces;
using System.Linq;

namespace APIes.Services
{
    public class LoginService 
    {
        private readonly AppDbContext _context;
        public LoginService(AppDbContext context)
        {
            _context = context;
        }
        public bool Cadastrar(Funcionario funcionario)
        {
            if (_context.Funcionarios is not null)
            {
                if (!(_context.Funcionarios.Contains(funcionario)) && funcionario is not null)
                {
                    _context.Funcionarios.Add(funcionario);
                    _context.SaveChanges();
                    return true;
                }
                else { return false; }
            }
            return true;
        }
        public bool Logar(string user, string password)
        {
            if(_context.Funcionarios is not null)
            {
                var tryuser = _context.Funcionarios.Find(user);
                if (tryuser != null)
                {
                    var trypassword = _context.Funcionarios.Find(password);
                    return true;
                }
                else { return false; }
            }
            else { return false; }

        }
    }
}
