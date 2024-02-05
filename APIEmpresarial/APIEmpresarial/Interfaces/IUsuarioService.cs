using APIEmpresarial.Model.Entities;
using Microsoft.AspNetCore.Mvc;

namespace APILivros.Interfaces
{
    public interface IUsuarioService
    {
        Task<ActionResult<Funcionario>> GetFuncionario(int id);
        Task<IActionResult> Create(Funcionario funcionario);
        Task<ActionResult<IEnumerable<Funcionario>>> GetAllFuncionario();   
    }
}
