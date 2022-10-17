using System.ComponentModel.DataAnnotations;

namespace AjudaFacilV3.Models;

public class Institution
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string Name { get; set; }

    [Required]
    public string Email { get; set; }

    [Required]
    public string Address { get; set; }

    [Required]
    public string City { get; set; }

    public string Site { get; set; }

    [Required]
    [StringLength(20, MinimumLength = 14)]
    public string CNPJ { get; set; }

    [Required]
    [StringLength(100, MinimumLength = 5)]
    public string District { get; set; }

    [Required]
    [DataType(DataType.PhoneNumber)]
    public string Phone { get; set; }
}
