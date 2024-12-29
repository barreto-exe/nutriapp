using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace nutriapp.infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddWaterMeasure : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WaterMeasure",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    User = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<double>(type: "float", nullable: false),
                    MeasureType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__WaterMea__3214EC07C392C313", x => x.Id);
                    table.ForeignKey(
                        name: "FK__WaterMeas__Measu__6E01572D",
                        column: x => x.MeasureType,
                        principalTable: "MeasureType",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK__WaterMeasu__User__6D0D32F4",
                        column: x => x.User,
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_WaterMeasure_MeasureType",
                table: "WaterMeasure",
                column: "MeasureType");

            migrationBuilder.CreateIndex(
                name: "IX_WaterMeasure_User",
                table: "WaterMeasure",
                column: "User");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WaterMeasure");
        }
    }
}
