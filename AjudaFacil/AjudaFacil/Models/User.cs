namespace AjudaFacil.Models;

public class User
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public DateTime BirthDate { get; set; }
    public string CPF { get; set; }
    public string CNPJ { get; set; }
    public string Adress { get; set; }
    public string City { get; set; }
    public int Cep { get; set; }
    public string PhoneNumber { get; set; }
    public string ResidentialPhone { get; set; }
    public string Sex { get; set; }
    public int TotalDonations { get; set; } = 0;
    public IList<Donation> Donations { get; set; }
}

