using System.ComponentModel.DataAnnotations;

namespace webapi.healthclinic.manha.ViewModel
{
    public class LoginViewModel
    {
            [Required(ErrorMessage = "Email Obrigatorio")]
            public string? Email { get; set; }


            [Required(ErrorMessage = "Senha Obrigatoria")]
            public string? Senha { get; set; }
        
    }
}
