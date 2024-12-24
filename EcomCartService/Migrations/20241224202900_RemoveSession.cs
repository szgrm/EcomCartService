using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EcomCartService.Migrations
{
    /// <inheritdoc />
    public partial class RemoveSession : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SessionId",
                table: "CartItems",
                newName: "Username");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Username",
                table: "CartItems",
                newName: "SessionId");
        }
    }
}
