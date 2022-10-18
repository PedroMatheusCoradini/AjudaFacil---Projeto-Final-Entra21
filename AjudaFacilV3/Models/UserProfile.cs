using System.ComponentModel.DataAnnotations;

namespace AjudaFacilV3.Models;

public class UserProfile
{
    [Key]
    public int Id { get; set; }

    [StringLength(60, MinimumLength = 3, ErrorMessage = "O nome deve conter de {2} à {1} caracteres")]
    [Required(ErrorMessage = "Informe seu nome completo")]
    public string Name { get; set; }

    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
    [Required(ErrorMessage = "Informe sua data de nascimento")]
    public DateTime BirthDate { get; set; } = DateTime.Now;

    [StringLength(20, MinimumLength = 11, ErrorMessage = "O CPF deve conter {2} caracteres")]
    [Required(ErrorMessage = "Informe seu CPF")]
    public string CPF { get; set; }

    [StringLength(60, MinimumLength = 3, ErrorMessage = "O Endereço deve conter de {2} à {1} caracteres")]
    [Required(ErrorMessage = "Informe Seu endereço")]
    public string Adress { get; set; }

    [StringLength(60, MinimumLength = 3, ErrorMessage = "A cidade deve conter de {2} à {1} caracteres")]
    [Required(ErrorMessage = "Informe sua cidade")]
    public string City { get; set; }

    [StringLength(20, MinimumLength = 8, ErrorMessage = "O CEP deve conter {2} caracteres")]
    [Required(ErrorMessage = "Informe seu CEP")]
    public string CEP { get; set; }

    [StringLength(20, MinimumLength = 11, ErrorMessage = "O Celular deve conter {2} caracteres")]
    [Required(ErrorMessage = "Informe seu celular")]
    public string PhoneNumber { get; set; }

    [StringLength(20, MinimumLength = 2, ErrorMessage = "O Sexo deve conter de {2} à {1} caracteres")]
    [Required(ErrorMessage = "Informe seu Sexo")]
    public string Sex { get; set; }
    public int TotalDonation { get; set; }
    public string User { get; set; }
}
