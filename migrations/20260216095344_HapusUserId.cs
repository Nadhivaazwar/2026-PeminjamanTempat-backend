using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _2026_PeminjamanTempat_backend.Migrations
{
    /// <inheritdoc />
    public partial class HapusUserId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Peminjaman");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Peminjaman",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }
    }
}
