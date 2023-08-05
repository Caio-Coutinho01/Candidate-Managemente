using System.ComponentModel.DataAnnotations;

namespace CandidateManagemente.Web.ViewModel
{
    public class LoginRequest
    {
        [Required(ErrorMessage = "O campo Email é obrigatório")]
        [EmailAddress(ErrorMessage = "O Email fornecido não é válido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O campo Senha é obrigatório")]
        [MinLength(6, ErrorMessage = "A senha deve ter pelo menos 6 caracteres")]
        public string Password { get; set; }
    }
}
