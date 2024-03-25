using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Trader.EF.Migrations
{
    /// <inheritdoc />
    public partial class addMissingColumnstoUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DateProcessed",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateProcessed",
                table: "Users");
        }
    }
}
