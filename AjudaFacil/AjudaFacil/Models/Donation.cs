namespace AjudaFacil.Models;

public class Donation
{
    public int Id { get; set; }
    public User Donor { get; set; }
    public List<ClothingDonation> ClothingDonations { get; set; } = new List<ClothingDonation>();
    public List<SchoolSupplieDonation> SchoolSuppliesDonations { get; set; } = new List<SchoolSupplieDonation>();
}
