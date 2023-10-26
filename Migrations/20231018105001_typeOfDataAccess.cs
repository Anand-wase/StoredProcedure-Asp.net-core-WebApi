using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StoredProcedure.Migrations
{
    /// <inheritdoc />
    public partial class typeOfDataAccess : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Employes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "Employes");
        }
    }
}
