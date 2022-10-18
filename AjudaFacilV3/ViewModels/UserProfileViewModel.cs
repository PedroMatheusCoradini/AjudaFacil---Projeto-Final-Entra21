using System.ComponentModel.DataAnnotations;

namespace AjudaFacilV3.ViewModels;

public class UserProfileViewModel
{
    public int Id { get; set; }

    [StringLength(60, MinimumLength = 3)]
    [Required(ErrorMessage = "Informe seu nome completo")]
    public string Name { get; set; }

    [Required(ErrorMessage = "Informe sua data de nascimento")]
    public DateTime BirthDate { get; set; }

    [StringLength(20, MinimumLength = 10)]
    [Required(ErrorMessage = "Informe seu CPF")]
    public string CPF { get; set; }

    [StringLength(60, MinimumLength = 3)]
    [Required(ErrorMessage = "Informe Seu endereço")]
    public string Adress { get; set; }

    [StringLength(60, MinimumLength = 3)]
    [Required(ErrorMessage = "Informe sua cidade")]
    public string City { get; set; }

    [StringLength(20, MinimumLength = 8)]
    [Required(ErrorMessage = "Informe seu CEP")]
    public string CEP { get; set; }

    [StringLength(20, MinimumLength = 9)]
    [Required(ErrorMessage = "Informe seu celular")]
    public string PhoneNumber { get; set; }

    [StringLength(20, MinimumLength = 2)]
    [Required(ErrorMessage = "Informe seu Sexo")]
    public string Sex { get; set; }
    public int TotalDonation { get; set; } = 0;
    public string User { get; set; }
}
