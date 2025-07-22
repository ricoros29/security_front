using System.ComponentModel.DataAnnotations;

namespace BlazorApp.DTO.Users
{
    public class ResetDTO
    {
        [Required(ErrorMessage = "Requerido")]
        public int IdUsuario { get; set; }

        [Required(ErrorMessage = "Requerido")]
        public string Cuenta { get; set; } = string.Empty;

        [Required (ErrorMessage ="Requerido")]
        public string Password { get; set; } = string.Empty;

        [Required(ErrorMessage = "Requerido")]
        public string PasswordConfirm { get; set; } = string.Empty;
    }
}
