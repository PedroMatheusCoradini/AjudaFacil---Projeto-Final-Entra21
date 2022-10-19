using System.ComponentModel.DataAnnotations;

namespace AjudaFacilV3.Models;

public class Institution
{
    [Key]
    public int Id { get; set; }

    [Required(ErrorMessage = "Campo obrigatorio.")]
    public string Name { get; set; }

    [Required(ErrorMessage = "Campo obrigatorio.")]
    public string Email { get; set; }

    [Required(ErrorMessage = "Campo obrigatorio.")]
    public string Address { get; set; }

    [Required(ErrorMessage = "Campo obrigatorio.")]
    public string City { get; set; }

    [Required(ErrorMessage = "Campo obrigatorio.")]
    public string Site { get; set; }

    [Required(ErrorMessage = "Campo obrigatorio.")]
    [StringLength(20, MinimumLength = 14)]
    public string CNPJ { get; set; }

    [Required(ErrorMessage = "Campo obrigatorio.")]
    [StringLength(100, MinimumLength = 5)]
    public string District { get; set; }

    [Required(ErrorMessage = "Campo obrigatorio.")]
    [StringLength(15, MinimumLength = 11)]
    public string Phone { get; set; }
}
