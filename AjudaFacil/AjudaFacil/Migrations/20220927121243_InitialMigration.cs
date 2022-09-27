using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AjudaFacil.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "NVARCHAR(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "NVARCHAR(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "VARCHAR(160)", maxLength: 160, nullable: false),
                    Password = table.Column<string>(type: "VARCHAR(255)", maxLength: 255, nullable: false),
                    BirthDate = table.Column<DateTime>(type: "SMALLDATETIME", nullable: false),
                    CPF = table.Column<string>(type: "VARCHAR(15)", maxLength: 15, nullable: true),
                    CNPJ = table.Column<string>(type: "VARCHAR(20)", maxLength: 20, nullable: true),
                    Adress = table.Column<string>(type: "VARCHAR(80)", maxLength: 80, nullable: true),
                    City = table.Column<string>(type: "VARCHAR(30)", maxLength: 30, nullable: true),
                    Cep = table.Column<int>(type: "INT", maxLength: 16, nullable: false),
                    PhoneNumber = table.Column<string>(type: "VARCHAR(20)", maxLength: 20, nullable: true),
                    ResidentialPhone = table.Column<string>(type: "VARCHAR(10)", maxLength: 10, nullable: true),
                    Sex = table.Column<string>(type: "VARCHAR(20)", maxLength: 20, nullable: true),
                    TotalDonations = table.Column<int>(type: "INT", maxLength: 1000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Donation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Donation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Donation_User",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClothingDonation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuantityOfClothes = table.Column<int>(type: "INT", nullable: false),
                    DescriptionOfClothes = table.Column<string>(type: "VARCHAR(300)", maxLength: 300, nullable: false),
                    Weight = table.Column<int>(type: "INT", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DonationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClothingDonation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClothingDonation_DonationId",
                        column: x => x.DonationId,
                        principalTable: "Donation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SchoolSupplieDonation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "VARCHAR(300)", maxLength: 300, nullable: false),
                    Weight = table.Column<int>(type: "INT", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DonationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SchoolSupplieDonation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SchoolSupplieDonation_DonationId",
                        column: x => x.DonationId,
                        principalTable: "Donation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClothingDonation_DonationId",
                table: "ClothingDonation",
                column: "DonationId");

            migrationBuilder.CreateIndex(
                name: "IX_Donation_UserId",
                table: "Donation",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_SchoolSupplieDonation_DonationId",
                table: "SchoolSupplieDonation",
                column: "DonationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClothingDonation");

            migrationBuilder.DropTable(
                name: "SchoolSupplieDonation");

            migrationBuilder.DropTable(
                name: "Donation");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
