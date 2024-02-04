using APIEmpresarial.Model;
using Microsoft.AspNetCore.Mvc;

namespace APIEmpresarial.Interfaces
{
    public interface ICategoriaInterface
    {
        Task<IActionResult> Create(Categoria categoria);
        Task<ActionResult<IEnumerable<Categoria>>> GetAll();
        ActionResult<Categoria> GetCategoria(int id);
        Task<IActionResult> Delete(int id);
        Task<IActionResult> Update(int id);
        
    }
}
