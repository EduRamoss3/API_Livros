﻿// <auto-generated />
using System;
using API.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace APIEmpresarial.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240128184058_altertable")]
    partial class altertable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("APIEmpresarial.Model.Categoria", b =>
                {
                    b.Property<int>("CategoriaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ImagemUrl")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("varchar(300)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("varchar(80)");

                    b.HasKey("CategoriaId");

                    b.ToTable("Categoria");
                });

            modelBuilder.Entity("APIEmpresarial.Model.Entities.Funcionario", b =>
                {
                    b.Property<int>("FuncionarioId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("varchar(300)");

                    b.Property<double>("Salario")
                        .HasColumnType("double");

                    b.HasKey("FuncionarioId");

                    b.ToTable("Funcionarios");
                });

            modelBuilder.Entity("APIEmpresarial.Model.Estoque", b =>
                {
                    b.Property<int>("EstoqueId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("LivroId")
                        .HasColumnType("int");

                    b.Property<string>("NomeLivro")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<float>("QuantidadeLivros")
                        .HasMaxLength(300)
                        .HasColumnType("float");

                    b.HasKey("EstoqueId");

                    b.HasIndex("LivroId");

                    b.ToTable("Estoque");
                });

            modelBuilder.Entity("APIEmpresarial.Model.Gastos", b =>
                {
                    b.Property<int>("GastosId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("DataGasto")
                        .HasColumnType("datetime(6)");

                    b.Property<double>("TotalGasto")
                        .HasColumnType("double");

                    b.HasKey("GastosId");

                    b.ToTable("Gastos");
                });

            modelBuilder.Entity("APIEmpresarial.Model.Livro", b =>
                {
                    b.Property<int>("LivroId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("CategoriaId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnType("datetime(6)");

                    b.Property<int?>("EstoqueId")
                        .HasColumnType("int");

                    b.Property<string>("ImagemUrl")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("varchar(300)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("varchar(80)");

                    b.Property<decimal>("Preco")
                        .HasColumnType("decimal(10,2)");

                    b.Property<int>("Quantidade")
                        .HasColumnType("int");

                    b.Property<string>("Sinopse")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("varchar(300)");

                    b.Property<int?>("VendasVendaId")
                        .HasColumnType("int");

                    b.HasKey("LivroId");

                    b.HasIndex("CategoriaId");

                    b.HasIndex("EstoqueId");

                    b.HasIndex("VendasVendaId");

                    b.ToTable("Livros");
                });

            modelBuilder.Entity("APIEmpresarial.Model.Vendas", b =>
                {
                    b.Property<int>("VendaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("DataVenda")
                        .HasColumnType("datetime(6)");

                    b.Property<int?>("GastosId")
                        .HasColumnType("int");

                    b.Property<int>("LivroId")
                        .HasColumnType("int");

                    b.Property<int>("QuantidadeVenda")
                        .HasColumnType("int");

                    b.Property<double>("ValorTotal")
                        .HasColumnType("double");

                    b.HasKey("VendaId");

                    b.HasIndex("GastosId");

                    b.ToTable("Vendas");
                });

            modelBuilder.Entity("APIEmpresarial.Model.Estoque", b =>
                {
                    b.HasOne("APIEmpresarial.Model.Livro", "Livro")
                        .WithMany()
                        .HasForeignKey("LivroId");

                    b.Navigation("Livro");
                });

            modelBuilder.Entity("APIEmpresarial.Model.Livro", b =>
                {
                    b.HasOne("APIEmpresarial.Model.Categoria", "Categoria")
                        .WithMany("Livros")
                        .HasForeignKey("CategoriaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("APIEmpresarial.Model.Estoque", null)
                        .WithMany("Livros")
                        .HasForeignKey("EstoqueId");

                    b.HasOne("APIEmpresarial.Model.Vendas", null)
                        .WithMany("Livros")
                        .HasForeignKey("VendasVendaId");

                    b.Navigation("Categoria");
                });

            modelBuilder.Entity("APIEmpresarial.Model.Vendas", b =>
                {
                    b.HasOne("APIEmpresarial.Model.Gastos", null)
                        .WithMany("_Vendas")
                        .HasForeignKey("GastosId");
                });

            modelBuilder.Entity("APIEmpresarial.Model.Categoria", b =>
                {
                    b.Navigation("Livros");
                });

            modelBuilder.Entity("APIEmpresarial.Model.Estoque", b =>
                {
                    b.Navigation("Livros");
                });

            modelBuilder.Entity("APIEmpresarial.Model.Gastos", b =>
                {
                    b.Navigation("_Vendas");
                });

            modelBuilder.Entity("APIEmpresarial.Model.Vendas", b =>
                {
                    b.Navigation("Livros");
                });
#pragma warning restore 612, 618
        }
    }
}
