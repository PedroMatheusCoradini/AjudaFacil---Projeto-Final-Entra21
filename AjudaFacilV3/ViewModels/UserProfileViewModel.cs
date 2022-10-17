using System.ComponentModel.DataAnnotations;

namespace AjudaFacilV3.ViewModels;

public class UserProfileViewModel
{
    public int Id { get; set; }

    [StringLength(60, MinimumLength = 3)]
    public string Name { get; set; }

    public DateTime BirthDate { get; set; }

    [StringLength(20, MinimumLength = 10)]
    public string CPF { get; set; }

    [StringLength(60, MinimumLength = 3)]
    public string Adress { get; set; }

    [StringLength(60, MinimumLength = 3)]
    public string City { get; set; }

    [StringLength(20, MinimumLength = 8)]
    public string CEP { get; set; }

    [StringLength(20, MinimumLength = 9)]
    public string PhoneNumber { get; set; }

    [StringLength(20, MinimumLength = 2)]
    public string Sex { get; set; }
    public int TotalDonation { get; set; } = 0;
    public string User { get; set; }
}
