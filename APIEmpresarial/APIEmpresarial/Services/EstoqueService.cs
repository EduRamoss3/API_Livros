using API.Context;
using APIEmpresarial.Model;
using APILivros.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;

namespace APILivros.Services;

public class EstoqueService : IEstoqueService
{
    private readonly AppDbContext _context;
    public EstoqueService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> AddEstoque(Livro livro)
    {
        if (livro is null) { return new BadRequestObjectResult($"O livro '{livro}' é nulo!"); }
        if (livro is not Livro exampleLivro) { return new BadRequestObjectResult($"'{livro}' não está em formato correto!"); }

        Livro existLivro = _context.Livros.FirstOrDefault(l => l.Equals(livro));
        if(existLivro is not null)
        {
            existLivro.Quantidade++;
            _context.Livros.Update(existLivro);
        }
        else
        {  
            Estoque estoque = new Estoque(livro);
            _context.Estoque.Add(estoque);
            _context.Livros.Add(livro);
        }
        await _context.SaveChangesAsync();
        return new OkObjectResult("Adicionado ao estoque com sucesso!");
    }

    public async Task<ActionResult<IEnumerable<Estoque>>> GetAllEstoque()
    {
        return await _context.Estoque.ToListAsync();
    }

    public async Task<ActionResult<int>> Quantity()
    {
        var totalQuantity = await _context.Estoque.SumAsync(e => e.QuantidadeLivros);
        return totalQuantity;
       
    }

    public async Task<ActionResult<decimal>> TotalInEstoque()
    {
        decimal  totalQuantity = await _context.Estoque.SumAsync(e => e.QuantidadeLivros);
        decimal  totalPrice = await _context.Estoque.SumAsync(e => e.Livro.Preco);
        return totalQuantity * totalPrice;
    }
}


