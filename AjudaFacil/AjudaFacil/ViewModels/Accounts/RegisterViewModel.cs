using System.ComponentModel.DataAnnotations;

namespace AjudaFacil.ViewModels.Accounts;

public class RegisterViewModel
{
    [Required(ErrorMessage = "O nome é obrigatório!")]
    [StringLength(60, MinimumLength = 3, ErrorMessage = "{0} deve conter caracteres entre {2} and {1}")]
    public string Name { get; set; }

    [Required(ErrorMessage = "O sobrenome é obrigatório!")]
    [StringLength(60, MinimumLength = 3, ErrorMessage = "{0} deve conter caracteres entre {2} and {1}")]
    public string LastName { get; set; }

    [Required(ErrorMessage = "O E-mail é obrigatório")]
    [EmailAddress(ErrorMessage = "O E-mail é inválido!")]
    public string Email { get; set; }

    [Required(ErrorMessage = "O CPF é obrigatório")]
    [StringLength(20, MinimumLength = 10, ErrorMessage = "{0} deve conter caracteres entre {2} and {1}")]
    public string CPF { get; set; }

    [Required(ErrorMessage = "A data de nascimento é obrigatório")]
    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
    public DateTime BirthDate { get; set; }

    [Required(ErrorMessage = "O endereço é obrigatório")]
    [StringLength(60, MinimumLength = 3, ErrorMessage = "{0} deve conter caracteres entre {2} and {1}")]
    public string Adress { get; set; }

    [Required(ErrorMessage = "A cidade é obrigatório")]
    [StringLength(60, MinimumLength = 3, ErrorMessage = "{0} deve conter caracteres entre {2} and {1}")]
    public string City { get; set; }

    [Required(ErrorMessage = "A Senha é obrigatório")]
    [StringLength(60, MinimumLength = 8, ErrorMessage = "{0} deve conter caracteres entre {2} and {1}")]
    public string Password { get; set; }
}
