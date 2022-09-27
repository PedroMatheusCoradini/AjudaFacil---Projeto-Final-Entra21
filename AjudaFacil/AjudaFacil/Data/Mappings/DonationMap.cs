using AjudaFacil.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AjudaFacil.Data.Mappings;

public class DonationMap : IEntityTypeConfiguration<Donation>
{
    public void Configure(EntityTypeBuilder<Donation> builder)
    {
        builder.ToTable("Donation");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedOnAdd().UseIdentityColumn();

        // Relacionamento 1 para muitos
        // eu tenho um donor com muitas donations
        builder
            .HasOne(x => x.User) // tem um User(doador)
            .WithMany(x => x.Donations) // com muitas donations(doacoes) 
            .HasConstraintName("FK_Donation_User")
            .OnDelete(DeleteBehavior.Cascade); // fikar de olho pois ele ira exluir
                                               // as donations e tmb todos os users
                                               // ligados a donation
    }
}
