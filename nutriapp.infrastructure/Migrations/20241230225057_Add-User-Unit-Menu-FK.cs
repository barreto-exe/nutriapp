using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace nutriapp.infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddUserUnitMenuFK : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "User",
                table: "UnitMenu",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_UnitMenu_User",
                table: "UnitMenu",
                column: "User");

            migrationBuilder.AddForeignKey(
                name: "FK__UnitMenu__User__06CD04F7",
                table: "UnitMenu",
                column: "User",
                principalTable: "User",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK__UnitMenu__User__06CD04F7",
                table: "UnitMenu");

            migrationBuilder.DropIndex(
                name: "IX_UnitMenu_User",
                table: "UnitMenu");

            migrationBuilder.DropColumn(
                name: "User",
                table: "UnitMenu");
        }
    }
}
