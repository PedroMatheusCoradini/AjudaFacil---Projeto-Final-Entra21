using AjudaFacilV3.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AjudaFacil.Data.Mappings;

public class ClothingDonationMap : IEntityTypeConfiguration<ClothingDonation>
{
    public void Configure(EntityTypeBuilder<ClothingDonation> builder)
    {
        builder.ToTable("ClothingDonation");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedOnAdd().UseIdentityColumn();

        builder.Property(x => x.QuantityOfClothes)
            .IsRequired()
            .HasColumnName("QuantityOfClothes")
            .HasColumnType("INT");

        builder.Property(x => x.Description)
            .IsRequired()
            .HasColumnName("Description")
            .HasColumnType("VARCHAR")
            .HasMaxLength(300);

        builder.Property(x => x.Weight)
            .IsRequired()
            .HasColumnName("Weight")
            .HasColumnType("INT");

        builder.Property(x => x.Image).IsRequired();

            
        // relacionamentos
        builder
            .HasOne(x => x.Donations)
            .WithMany(x => x.ClothingDonations)
            .HasForeignKey("DonationId")
            .HasConstraintName("FK_ClothingDonation_DonationId")
            .OnDelete(DeleteBehavior.Cascade);
    }
}
