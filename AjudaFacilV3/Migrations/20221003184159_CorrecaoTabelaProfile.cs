using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AjudaFacilV3.Migrations
{
    public partial class CorrecaoTabelaProfile : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Donations_Profiles_UserProfilesId",
                table: "Donations");

            migrationBuilder.DropIndex(
                name: "IX_Donations_UserProfilesId",
                table: "Donations");

            migrationBuilder.DropColumn(
                name: "UserProfilesId",
                table: "Donations");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserProfilesId",
                table: "Donations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Donations_UserProfilesId",
                table: "Donations",
                column: "UserProfilesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Donations_Profiles_UserProfilesId",
                table: "Donations",
                column: "UserProfilesId",
                principalTable: "Profiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
