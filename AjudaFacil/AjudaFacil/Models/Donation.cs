namespace AjudaFacil.Models;

public class Donation
{
    public int Id { get; set; }
    public User User { get; set; }
    public IList<SchoolSupplieDonation> SchoolSupplieDonations { get; set; }
    public IList<ClothingDonation> ClothingDonations { get; set; }
}
