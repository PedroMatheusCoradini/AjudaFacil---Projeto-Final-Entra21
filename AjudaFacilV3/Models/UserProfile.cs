using System.ComponentModel.DataAnnotations;

namespace AjudaFacilV3.Models;

public class UserProfile
{
    [Key]
    public int Id { get; set; }

    [StringLength(60, MinimumLength = 3)]
    public string Name { get; set; }

    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
    public DateTime BirthDate { get; set; } = DateTime.Now;

    [StringLength(20, MinimumLength = 10)]
    public string CPF { get; set; } = null;

    [StringLength(60, MinimumLength = 3)]
    public string Adress { get; set; } = null;

    [StringLength(60, MinimumLength = 3)]
    public string City { get; set; } = null;

    [StringLength(20, MinimumLength = 11)]
    public string CEP { get; set; } = null;

    [StringLength(20, MinimumLength = 3)]
    public string PhoneNumber { get; set; } = null;

    [StringLength(20, MinimumLength = 2)]
    public string Sex { get; set; } = null;
    public int TotalDonation { get; set; } = 0;
    public string User { get; set; } = null;
}
