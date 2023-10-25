using System.ComponentModel.DataAnnotations;

namespace Manager.API.ViewModels;

public class CreateUserViewModel
{
    [Required(ErrorMessage = "O nome não pode ser nulo")]
    [MinLength(3, ErrorMessage = "O nome não pode ter menos de três caracteres")]
    [MaxLength(80,ErrorMessage = "O nome não pode ser maior que 80 caracteres")]
    public string Name { get;  set; }
    
    [Required(ErrorMessage = "O email não pode ser nulo")]
    [MinLength(13, ErrorMessage = "O email não pode ter menos de 13 caracteres")]
    [MaxLength(180, ErrorMessage = "O email não pode ter mais de 180 caracteres")]
    public string Email { get; set; }
    
    [Required(ErrorMessage = "Campo 'senha' é obrigatório")]
    [MinLength(6, ErrorMessage = "A senha deve ter, no minimo, 6 caracteres")]
    [MaxLength(80, ErrorMessage = "A senha deve ter, no máximo, 80 caracteres")]
    public string Password { get; set; }
    
}