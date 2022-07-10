using System.ComponentModel.DataAnnotations;

namespace Managely.Models.DTO;

public class LoginRequestDto
{
    [Required(ErrorMessage = "Por favor ingrese un e-mail")]
    [EmailAddress(ErrorMessage = "Por favor ingrese un e-mail válido")]
    public string Email { get; set; }
        
    [Required(ErrorMessage = "Por favor ingrese una contraseña")]
        
    public string Password { get; set; }
}