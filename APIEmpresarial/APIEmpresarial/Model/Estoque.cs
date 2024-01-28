using System.Collections;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace APIEmpresarial.Model
{
    public class Estoque
    {
        [Key]
        public int EstoqueId { get; set; }
        public Livro Livro { get; set; }
        [Required]
        public string NomeLivro { get; set; }
        [Required]
        [MaxLength(300)]
        public int QuantidadeLivros { get; set; }
        public Estoque(int estoqueId, Livro livro)
        {
            EstoqueId = estoqueId;
            Livro = livro;
            NomeLivro = livro.Nome;
            QuantidadeLivros = livro.Quantidade;
        }
        public Estoque(Livro livro)
        {
            Livro = livro;
            NomeLivro = livro.Nome;

            QuantidadeLivros = livro.Quantidade;
        }
        public Estoque()
        {

        }

    }

}
