using AjudaFacil.Data.Mappings;
using AjudaFacilV3.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AjudaFacilV3.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<UserProfile> Profiles { get; set; }
    public DbSet<Donation> Donations { get; set; }
    public DbSet<SchoolSupplieDonation> SchoolSupplieDonations { get; set; }
    public DbSet<ClothingDonation> ClothingDonations { get; set; }
}
