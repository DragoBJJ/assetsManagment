using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Assets.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateMaterialName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Nsame",
                table: "Material",
                newName: "Name");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Material",
                newName: "Nsame");
        }
    }
}
