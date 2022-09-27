namespace AjudaFacil.Models;

public class SchoolSupplieDonation
{
    public int Id { get; set; }
    public string Description { get; set; }
    public int Weight { get; set; }
    public string Image { get; set; }
    public Donation Donations { get; set; }
}
