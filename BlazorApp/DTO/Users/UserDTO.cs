using BlazorApp.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace BlazorApp.DTO.Users;
public class UserDTO : IUser
{
    public int IdUsuario { get; set; }

    [Required (ErrorMessage = "Obligatorio")]
    [MaxLength (50, ErrorMessage ="Ingresar máximo 50 caracteres.")]
    //[RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Solo se permiten caracteres alfabéticos.")]
    public string? Nombre { get; set; }

    [Required (ErrorMessage ="Obligatorio")]
    [MaxLength(50, ErrorMessage = "Ingresar máximo 50 caracteres.")]
    //[RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Solo se permiten caracteres alfabéticos.")]
    public string? ApellidoPaterno { get; set; }

    [MaxLength(50, ErrorMessage = "Ingresar máximo 50 caracteres.")]
    //[RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Solo se permiten caracteres alfabéticos.")]
    public string? ApellidoMaterno { get; set; }

    [Required(ErrorMessage = "Obligatorio")]
    //[RegularExpression(@"^[a-zA-Z_0-9]+$", ErrorMessage = "Solo se permiten caracteres alfanuméricos.")]
    public string? Cuenta { get; set; }

    [Required (ErrorMessage ="Obligatorio")]
    public int? IdEstado { get; set; }
    
    [Required (ErrorMessage ="Obligatorio")]
    public short? IdDependenciaOrigen { get; set; }
    
    //[Required (ErrorMessage ="Obligatorio")]
    //[RegularExpression(@"^[0-9]+$", ErrorMessage = "Solo se permiten caracteres numéricos.")]
    public string? NoEmpleado { get; set; }

    [Required (ErrorMessage ="Obligatorio")]
    //[RegularExpression(@"^[a-zA-z0-9]+$", ErrorMessage = "Solo se permiten caracteres alfanuméricos.")]
    public string? Rfc { get; set; }

    [Required (ErrorMessage ="Obligatorio")]
    [MaxLength(150, ErrorMessage = "Ingresar máximo 150 caracteres.")]
    //[RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Solo se permiten caracteres alfabéticos.")]
    public string? Cargo { get; set; }


    [Required (ErrorMessage ="Obligatorio")]
    [MaxLength(150, ErrorMessage = "Ingresar máximo 150 caracteres.")]
    //[RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Solo se permiten caracteres alfabéticos.")]
    public string? UnidadAdministrativa { get; set; }


    [Required (ErrorMessage ="Obligatorio")]
    [MaxLength(50, ErrorMessage = "Ingresar máximo 50 caracteres.")]
    //[RegularExpression(@"^[^@\s]+@[^@\s]+\.[^@\s]+$", ErrorMessage = "El formato del correo no es válido.")]
    public string? CorreoElectronico { get; set; }

    [Required (ErrorMessage ="Obligatorio")]
    public byte? IdModulo { get; set; }
    
    [Required (ErrorMessage ="Obligatorio")]
    public int? IdRol { get; set; }


    [Required(ErrorMessage = "Obligatorio")]
    //[RegularExpression(@"^[\w]+$", ErrorMessage = "Solo se permiten caracteres alfanuméricos.")]
    public string? Password { get; set; }
}