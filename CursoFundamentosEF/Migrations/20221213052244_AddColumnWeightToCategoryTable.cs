using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CursoFundamentosEF.Migrations
{
    public partial class AddColumnWeightToCategoryTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Weight",
                table: "Category",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Weight",
                table: "Category");
        }
    }
}
