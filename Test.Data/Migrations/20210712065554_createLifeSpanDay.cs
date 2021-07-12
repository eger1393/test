using Microsoft.EntityFrameworkCore.Migrations;

namespace Test.Data.Migrations
{
    public partial class createLifeSpanDay : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LifeSpanDays",
                table: "Users",
                type: "integer",
                nullable: false,
                computedColumnSql: "\"LastActivityDate\" - \"RegistrationDate\"", stored: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_RegistrationDate",
                table: "Users",
                column: "RegistrationDate");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Users_RegistrationDate",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "LifeSpanDays",
                table: "Users");
        }
    }
}
