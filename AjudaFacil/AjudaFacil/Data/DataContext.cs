using AjudaFacil.Models;
using Microsoft.EntityFrameworkCore;

namespace AjudaFacil.Data;

public class DataContext : DbContext
{
	public DataContext(DbContextOptions<DataContext> options)
		: base(options) { }
	
	public DbSet<User> Users { get; set; }
    public DbSet<Donation> Donations { get; set; }
	public DbSet<SchoolSupplieDonation> SchoolSuppliesDonations { get; set; }
	public DbSet<ClothingDonation> ClothingDonations { get; set; }
}