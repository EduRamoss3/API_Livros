using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace APIEmpresarial.Model.Entities
{
    public class Funcionario : IComparable
    {
        [Key]
        public int FuncionarioId { get; set; }
        [Required]
        [StringLength(300)]
        public string? Nome { get; set; }
        [Required]
        public double? Salario { get; set; }
        [Required]
        [MinLength(12)]
        private string? Usuario { get; set; }
        [Required]
        [MinLength(8)]
        [MaxLength(20)]
        private string? Password;
        public string? GetPassword()
        {
            if (Password != null)
            {
                return Password;
            }
            return null;

        }
        public void SetPassword(string password)
        {
            Password = password;
        }

        public int RecursosHumanosId { get; set; }
        public override int GetHashCode()
        {
            return FuncionarioId.GetHashCode();
        }
        public int CompareTo(object? obj)
        {   
         
             Funcionario? other = obj as Funcionario;
            if (other is not null)
            {
                return FuncionarioId.CompareTo(other.FuncionarioId);
            }
            else
            {
                return -1;
            }
            
        }
    }
}
