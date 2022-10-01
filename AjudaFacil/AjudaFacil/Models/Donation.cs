namespace AjudaFacil.Models;

public class Donation
{
    public int Id { get; set; }
    public User User { get; set; }
    public IList<SchoolSupplieDonation> SchoolSupplieDonations { get; set; } 
    public IList<ClothingDonation> ClothingDonations { get; set; }
}

// fazer no proximo model que o usuario tem uma donation e uma donation n tem muitas
// donations de um tipo e sim 1 donation de alimentos ou de outro tipo
