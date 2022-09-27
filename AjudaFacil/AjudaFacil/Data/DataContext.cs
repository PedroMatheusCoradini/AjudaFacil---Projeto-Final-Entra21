using AjudaFacil.Data.Mappings;
using AjudaFacil.Models;
using Microsoft.EntityFrameworkCore;

namespace AjudaFacil.Data;

public class DataContext : DbContext
{
	public DataContext(DbContextOptions<DataContext> options)
		: base(options) { }
	
	public DbSet<User> User { get; set; }
    public DbSet<Donation> Donation { get; set; }
	public DbSet<SchoolSupplieDonation> SchoolSupplieDonation { get; set; }
	public DbSet<ClothingDonation> ClothingDonation { get; set; }

	protected override void OnModelCreating(ModelBuilder modelBuilder) 
	{
		modelBuilder.ApplyConfiguration(new UserMap());
		modelBuilder.ApplyConfiguration(new DonationMap());
		modelBuilder.ApplyConfiguration(new SchoolSupplieDonationMap());
		modelBuilder.ApplyConfiguration(new ClothingDonationMap());
	}
}