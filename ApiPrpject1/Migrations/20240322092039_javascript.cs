using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiPrpject1.Migrations
{
    /// <inheritdoc />
    public partial class javascript : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Javascriptportfolio",
                table: "Javascriptportfolio");

            migrationBuilder.RenameTable(
                name: "Javascriptportfolio",
                newName: "Javascriptportfolios");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Javascriptportfolios",
                table: "Javascriptportfolios",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Javascriptportfolios",
                table: "Javascriptportfolios");

            migrationBuilder.RenameTable(
                name: "Javascriptportfolios",
                newName: "Javascriptportfolio");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Javascriptportfolio",
                table: "Javascriptportfolio",
                column: "Id");
        }
    }
}
