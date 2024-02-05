using APIEmpresarial.Model;
using Microsoft.AspNetCore.Mvc;
using System.Collections.ObjectModel;

namespace APILivros.Interfaces;
    public interface IEstoqueService
    {
    Task<ActionResult<IEnumerable<Estoque>>> GetAllEstoque();
    Task<IActionResult> AddEstoque(Livro livros);
    Task<ActionResult<decimal>> TotalInEstoque();
    Task<ActionResult<int>> Quantity();

    }
