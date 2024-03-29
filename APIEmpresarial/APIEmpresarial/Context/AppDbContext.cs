﻿
using APIEmpresarial.Model;
using APIEmpresarial.Model.Entities;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;

namespace API.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Livro> Livros { get; set; }
        public DbSet<Funcionario> Funcionarios { get; set; }
        public DbSet<Vendas> Vendas { get; set; }
        public DbSet<Estoque> Estoque { get; set; }
        public DbSet<Gastos> Gastos { get; set;}
        
    }
}
