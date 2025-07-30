using BlazorApp.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace BlazorApp.DTO.Users;
public class UserDTO : IUser
{
    public int IdUsuario { get; set; }

    [Required (ErrorMessage = "Obligatorio")]
    [MaxLength (50, ErrorMessage ="Ingresar m�ximo 50 caracteres.")]
    //[RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Solo se permiten caracteres alfab�ticos.")]
    public string? Nombre { get; set; }

    [Required (ErrorMessage ="Obligatorio")]
    [MaxLength(50, ErrorMessage = "Ingresar m�ximo 50 caracteres.")]
    //[RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Solo se permiten caracteres alfab�ticos.")]
    public string? ApellidoPaterno { get; set; }

    [MaxLength(50, ErrorMessage = "Ingresar m�ximo 50 caracteres.")]
    //[RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Solo se permiten caracteres alfab�ticos.")]
    public string? ApellidoMaterno { get; set; }

    [Required(ErrorMessage = "Obligatorio")]
    //[RegularExpression(@"^[a-zA-Z_0-9]+$", ErrorMessage = "Solo se permiten caracteres alfanum�ricos.")]
    public string? Cuenta { get; set; }

    [Required (ErrorMessage ="Obligatorio")]
    public int? IdEstado { get; set; }
    
    [Required (ErrorMessage ="Obligatorio")]
    public short? IdDependenciaOrigen { get; set; }
    
    //[Required (ErrorMessage ="Obligatorio")]
    //[RegularExpression(@"^[0-9]+$", ErrorMessage = "Solo se permiten caracteres num�ricos.")]
    public string? NoEmpleado { get; set; }

    [Required (ErrorMessage ="Obligatorio")]
    //[RegularExpression(@"^[a-zA-z0-9]+$", ErrorMessage = "Solo se permiten caracteres alfanum�ricos.")]
    public string? Rfc { get; set; }

    [Required (ErrorMessage ="Obligatorio")]
    [MaxLength(150, ErrorMessage = "Ingresar m�ximo 150 caracteres.")]
    //[RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Solo se permiten caracteres alfab�ticos.")]
    public string? Cargo { get; set; }


    [Required (ErrorMessage ="Obligatorio")]
    [MaxLength(150, ErrorMessage = "Ingresar m�ximo 150 caracteres.")]
    //[RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Solo se permiten caracteres alfab�ticos.")]
    public string? UnidadAdministrativa { get; set; }


    [Required (ErrorMessage ="Obligatorio")]
    [MaxLength(50, ErrorMessage = "Ingresar m�ximo 50 caracteres.")]
    //[RegularExpression(@"^[^@\s]+@[^@\s]+\.[^@\s]+$", ErrorMessage = "El formato del correo no es v�lido.")]
    public string? CorreoElectronico { get; set; }

    [Required (ErrorMessage ="Obligatorio")]
    public byte? IdModulo { get; set; }
    
    [Required (ErrorMessage ="Obligatorio")]
    public int? IdRol { get; set; }


    [Required(ErrorMessage = "Obligatorio")]
    //[RegularExpression(@"^[\w]+$", ErrorMessage = "Solo se permiten caracteres alfanum�ricos.")]
    public string? Password { get; set; }
}