using System.ComponentModel.DataAnnotations;

namespace APILivros.Model.Entities
{
    public class AuthenticationDto
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
