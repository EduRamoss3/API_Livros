using API.Context;
using APIEmpresarial.Model;
using Microsoft.AspNetCore.Mvc;

namespace APIEmpresarial.Interfaces
{
    public interface ILivroInterface
    {
        
        Task<IActionResult>Create(Livro livro);
        Task<ActionResult<IEnumerable<Livro>>> GetAll();
        Task<ActionResult<Livro>> GetLivro(int id);
        Task<IActionResult> UpdateLivro(Livro livro, int id);
        Task<IActionResult> Delete(int id);
    }
}
