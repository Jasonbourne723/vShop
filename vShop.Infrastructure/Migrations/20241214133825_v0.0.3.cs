using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace vShop.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class v003 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "OrderItems");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "UserId",
                table: "OrderItems",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }
    }
}
