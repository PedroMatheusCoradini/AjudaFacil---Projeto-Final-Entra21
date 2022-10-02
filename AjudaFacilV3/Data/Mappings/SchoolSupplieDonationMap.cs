using AjudaFacilV3.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AjudaFacil.Data.Mappings;

public class SchoolSupplieDonationMap : IEntityTypeConfiguration<SchoolSupplieDonation>
{
    public void Configure(EntityTypeBuilder<SchoolSupplieDonation> builder)
    {
        builder.ToTable("SchoolSupplieDonation");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedOnAdd().UseIdentityColumn();

        // Propertys
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


        // Relacionamentos
        // tenho uma doacao que e de um tipo schoolSupliedDonations
        builder
            .HasOne(x => x.Donations)
            .WithMany(x => x.SchoolSupplieDonations)
            .HasForeignKey("DonationId")
            .HasConstraintName("FK_SchoolSupplieDonation_DonationId")
            .OnDelete(DeleteBehavior.Cascade);
    }
}
