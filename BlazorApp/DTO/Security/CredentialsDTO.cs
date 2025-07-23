using System.ComponentModel.DataAnnotations;

namespace BlazorApp.DTO.Security;

public sealed class CredentialsDTO
{
    [Required(ErrorMessage = "Obligatorio")]
    public string Username { get; set; } = string.Empty;


    [Required(ErrorMessage = "Obligatorio")]
    public string Password { get; set; } = string.Empty;
}