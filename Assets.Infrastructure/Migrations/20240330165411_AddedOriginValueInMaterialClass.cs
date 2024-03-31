using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Assets.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddedOriginValueInMaterialClass : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Origin",
                table: "Material",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Origin",
                table: "Material");
        }
    }
}
