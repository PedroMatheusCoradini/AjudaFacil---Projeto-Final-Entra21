using AjudaFacil.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AjudaFacil.Data.Mappings;

public class UserMap : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("User");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedOnAdd().UseIdentityColumn();

        // Propertys
        builder.Property(x => x.Name)
            .IsRequired()
            .HasColumnName("Name")
            .HasColumnType("NVARCHAR")
            .HasMaxLength(100);

        builder.Property(x => x.LastName)
            .IsRequired()
            .HasColumnName("LastName")
            .HasColumnType("NVARCHAR")
            .HasMaxLength(100);

        builder.Property(x => x.Email)
            .IsRequired()
            .HasColumnName("Email")
            .HasColumnType("VARCHAR")
            .HasMaxLength(160);

        builder.Property(x => x.Password)
            .IsRequired()
            .HasColumnName("Password")
            .HasColumnType("VARCHAR")
            .HasMaxLength(255);

        builder.Property(x => x.BirthDate)
            .IsRequired()
            .HasColumnName("BirthDate")
            .HasColumnType("SMALLDATETIME");

        builder.Property(x => x.CPF)
            .IsRequired(false)
            .HasColumnName("CPF")
            .HasColumnType("VARCHAR")
            .HasMaxLength(15);

        builder.Property(x => x.CNPJ)
            .IsRequired(false)
            .HasColumnName("CNPJ")
            .HasColumnType("VARCHAR")
            .HasMaxLength(20);

        builder.Property(x => x.Adress)
            .IsRequired(false)
            .HasColumnName("Adress")
            .HasColumnType("VARCHAR")
            .HasMaxLength(80);

        builder.Property(x => x.City)
            .IsRequired(false)
            .HasColumnName("City")
            .HasColumnType("VARCHAR")
            .HasMaxLength(30);

        builder.Property(x => x.Cep)
            .HasColumnName("Cep")
            .HasColumnType("INT")
            .HasMaxLength(16);

        builder.Property(x => x.PhoneNumber)
            .IsRequired(false)
            .HasColumnName("PhoneNumber")
            .HasColumnType("VARCHAR")
            .HasMaxLength(20);

        builder.Property(x => x.ResidentialPhone)
            .IsRequired(false)
            .HasColumnName("ResidentialPhone")
            .HasColumnType("VARCHAR")
            .HasMaxLength(10);

        builder.Property(x => x.Sex)
            .IsRequired(false)
            .HasColumnName("Sex")
            .HasColumnType("VARCHAR")
            .HasMaxLength(20);

        builder.Property(x => x.TotalDonations)
            .HasColumnName("TotalDonations")
            .HasColumnType("INT")
            .HasMaxLength(1000);
    }
}
