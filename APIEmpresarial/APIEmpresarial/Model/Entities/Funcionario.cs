using APILivros.Model.Enum;
using System.ComponentModel.DataAnnotations;

namespace APIEmpresarial.Model.Entities
{
    public sealed class Funcionario 
    {
        [Key]
        public int FuncionarioId { get; set; }
        [Required]
        [StringLength(300)]
        public string Nome { get; set; }
        [Required]
        public double Salario { get; set; }
        [Required]
        public Tipo Perfil { get; set; }
        [Required]
        public string Password { get; set; }
       
    }
}
