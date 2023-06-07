using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SoruCevap.Migrations
{
    /// <inheritdoc />
    public partial class IpAprovecolumnisaddedtoUserEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsAprove",
                table: "Users",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsAprove",
                table: "Users");
        }
    }
}
