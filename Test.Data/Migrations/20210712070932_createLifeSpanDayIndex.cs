using Microsoft.EntityFrameworkCore.Migrations;

namespace Test.Data.Migrations
{
    public partial class createLifeSpanDayIndex : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "LifeSpanDays",
                table: "Users",
                type: "integer",
                nullable: false,
                computedColumnSql: "\"LastActivityDate\" - \"RegistrationDate\"",
                stored: true,
                oldClrType: typeof(int),
                oldType: "integer",
                oldComputedColumnSql: "\"LastActivityDate\" - \"RegistrationDate\"",
                oldStored: null);

            migrationBuilder.CreateIndex(
                name: "IX_Users_LifeSpanDays",
                table: "Users",
                column: "LifeSpanDays");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Users_LifeSpanDays",
                table: "Users");

            migrationBuilder.AlterColumn<int>(
                name: "LifeSpanDays",
                table: "Users",
                type: "integer",
                nullable: false,
                computedColumnSql: "\"LastActivityDate\" - \"RegistrationDate\"",
                oldClrType: typeof(int),
                oldType: "integer",
                oldComputedColumnSql: "\"LastActivityDate\" - \"RegistrationDate\"");
        }
    }
}
