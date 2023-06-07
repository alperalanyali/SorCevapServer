using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SoruCevap.Migrations
{
    /// <inheritdoc />
    public partial class SinavSonucandCevapSonucareaddedtodb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CevapSonucs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SinavSonucId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CevapId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CevapSonucs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SinavSonucs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SinavId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SinavSonucs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SinavSonucs_Sinavs_SinavId",
                        column: x => x.SinavId,
                        principalTable: "Sinavs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SinavSonucs_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SinavSonucs_SinavId",
                table: "SinavSonucs",
                column: "SinavId");

            migrationBuilder.CreateIndex(
                name: "IX_SinavSonucs_UserId",
                table: "SinavSonucs",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CevapSonucs");

            migrationBuilder.DropTable(
                name: "SinavSonucs");
        }
    }
}
