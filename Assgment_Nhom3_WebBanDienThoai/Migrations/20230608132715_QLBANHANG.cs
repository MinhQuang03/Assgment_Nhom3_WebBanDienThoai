using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Assgment_Nhom3_WebBanDienThoai.Migrations
{
    /// <inheritdoc />
    public partial class QLBANHANG : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Gia",
                table: "HoaDonChiTiets",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "Gia",
                table: "HoaDonChiTiets",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");
        }
    }
}
