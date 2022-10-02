namespace AjudaFacilV2.Models
{
    public class Donation
    {
        public int Id { get; set; }
        public DateTime CreateAt { get; set; }
        public string User { get; set; }
        public IList<SchoolSupplieDonation> SchoolSupplieDonations { get; set; }
        public IList<ClothingDonation> ClothingDonations { get; set; }
    }
}
