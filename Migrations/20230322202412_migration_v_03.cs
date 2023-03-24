using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TesteBitzen.Migrations
{
    /// <inheritdoc />
    public partial class migration_v_03 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "VehicleCategoryId",
                table: "Vehicles",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VehicleCategoryId",
                table: "Vehicles");
        }
    }
}
