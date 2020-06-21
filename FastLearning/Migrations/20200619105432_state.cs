using Microsoft.EntityFrameworkCore.Migrations;

namespace FastLearning.Migrations
{
    public partial class state : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "State",
                table: "Students",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "State",
                table: "Students",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(string));
        }
    }
}
