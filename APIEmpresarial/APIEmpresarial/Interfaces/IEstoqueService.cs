using APIEmpresarial.Model;
using Microsoft.AspNetCore.Mvc;
using System.Collections.ObjectModel;

namespace APILivros.Interfaces;
    public interface IEstoqueService
    {
    Task<IActionResult> GetAllEstoque();
    Task<IActionResult> AddEstoque(Livro livros);
    ActionResult<Livro> GetLivroById(int id);
    ActionResult<float> TotalInEstoque();
    ActionResult<float> Quantity();

    }
