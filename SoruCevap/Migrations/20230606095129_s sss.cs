using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SoruCevap.Migrations
{
    /// <inheritdoc />
    public partial class ssss : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_CevapSonucs_CevapId",
                table: "CevapSonucs",
                column: "CevapId");

            migrationBuilder.AddForeignKey(
                name: "FK_CevapSonucs_Cevaps_CevapId",
                table: "CevapSonucs",
                column: "CevapId",
                principalTable: "Cevaps",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CevapSonucs_Cevaps_CevapId",
                table: "CevapSonucs");

            migrationBuilder.DropIndex(
                name: "IX_CevapSonucs_CevapId",
                table: "CevapSonucs");
        }
    }
}
