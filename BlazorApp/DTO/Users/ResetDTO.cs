using System.ComponentModel.DataAnnotations;

namespace BlazorApp.DTO.Users
{
    public class ResetDTO
    {
        [Required(ErrorMessage = "Obligatorio")]
        public int IdUsuario { get; set; }

        [Required(ErrorMessage = "Obligatorio")]
        public string Cuenta { get; set; } = string.Empty;

        [Required (ErrorMessage ="Obligatorio")]
        public string Password { get; set; } = string.Empty;

        [Required(ErrorMessage = "Obligatorio")]
        public string PasswordConfirm { get; set; } = string.Empty;
    }
}
