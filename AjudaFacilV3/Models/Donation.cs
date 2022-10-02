namespace AjudaFacilV3.Models
{
    public class Donation
    {
        public int Id { get; set; }
        public DateTime CreateAt { get; set; }
        public string User { get; set; } = string.Empty;
        public IList<SchoolSupplieDonation> SchoolSupplieDonations { get; set; }
        public IList<ClothingDonation> ClothingDonations { get; set; }
    }
}
