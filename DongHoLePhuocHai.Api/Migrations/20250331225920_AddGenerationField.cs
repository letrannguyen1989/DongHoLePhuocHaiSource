using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DongHoLePhuocHai.Api.Migrations
{
    /// <inheritdoc />
    public partial class AddGenerationField : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Generation",
                table: "FamilyMembers",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Generation",
                table: "FamilyMembers");
        }
    }
}
