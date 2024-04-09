using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookStoreDBLib.Migrations
{
    /// <inheritdoc />
    public partial class AddViewsColumns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ViewsPerDay",
                table: "Books",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ViewsPerMonth",
                table: "Books",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ViewsPerWeek",
                table: "Books",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ViewsPerDay", "ViewsPerMonth", "ViewsPerWeek" },
                values: new object[] { 0, 0, 0 });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ViewsPerDay", "ViewsPerMonth", "ViewsPerWeek" },
                values: new object[] { 0, 0, 0 });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ViewsPerDay", "ViewsPerMonth", "ViewsPerWeek" },
                values: new object[] { 0, 0, 0 });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ViewsPerDay", "ViewsPerMonth", "ViewsPerWeek" },
                values: new object[] { 0, 0, 0 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ViewsPerDay",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "ViewsPerMonth",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "ViewsPerWeek",
                table: "Books");
        }
    }
}
