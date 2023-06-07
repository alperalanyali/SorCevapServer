using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SoruCevap.Migrations
{
    /// <inheritdoc />
    public partial class SiralamaisaddedtoSoruTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Siralama",
                table: "Sorus",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Siralama",
                table: "Sorus");
        }
    }
}
