using System.ComponentModel.DataAnnotations;

namespace CandidateManagemente.Web.ViewModel
{
    public class RegisterRequest
    {
        [Required(ErrorMessage = "O campo Email é obrigatório")]
        [EmailAddress(ErrorMessage = "O Email fornecido não é válido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O campo Senha é obrigatório")]
        [MinLength(6, ErrorMessage = "A senha deve ter pelo menos 6 caracteres")]
        public string Password { get; set; }

        [Required(ErrorMessage = "O campo Nome é obrigatório")]
        public string Name { get; set; }

        [Required(ErrorMessage = "O campo Sobrenome é obrigatório")]
        public string Surname { get; set; }
    }
}
