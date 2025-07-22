using System.ComponentModel.DataAnnotations;

namespace BlazorApp.DTO.Security;

public sealed class CredentialsDTO
{
    [Required(ErrorMessage = "Requerido")]
    public string Username { get; set; } = string.Empty;


    [Required(ErrorMessage = "Requerido")]
    public string Password { get; set; } = string.Empty;
}